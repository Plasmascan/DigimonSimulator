using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DigimonSimulator
{

    public class BattleTurn
    {
        public bool isHit;
        public bool isDoubleShot;
        public bool isBattleEnded;
    }

    public class BattleLogic
    {
        private const int MAXTURNS = 10;
        public int turnIndex;
        Random rnd = new Random();
        DigimonGame game;
        public bool isCurrentDigimonsTurn;
        public BattleTurn[] turns;
        public TcpListener listener;
        public TcpClient client;
        public bool isPendingCancel = false;
        public bool isConnecting = false;

        public BattleLogic(DigimonGame game)
        {
            this.game = game;
            turns = new BattleTurn[MAXTURNS];
            turnIndex = 0;
            isCurrentDigimonsTurn = true;
        }


        public void GenerateBattle()
        {
            int hitChance, doubleShotChance;
            BattleTurn battleTurn;
            Digimon digimonsTurn;


            for (int i = 0; i < MAXTURNS; i++)
            {
                // Select digimon's turn
                if (isCurrentDigimonsTurn)
                {
                    digimonsTurn = game.currentDigimon;
                }
                else
                {
                    digimonsTurn = game.animate.Opponent;
                }

                hitChance = rnd.Next(1, 100);
                doubleShotChance = rnd.Next(1, 100);
                battleTurn = new BattleTurn();

                if (hitChance > 50)
                {
                    battleTurn.isHit = true;
                }

                if (doubleShotChance > 50)
                {
                    battleTurn.isDoubleShot = true;
                }

                if (i == MAXTURNS - 1)
                {
                    battleTurn.isBattleEnded = true;
                }

                turns[i] = battleTurn;

                // Change digimon turn to oposite digimon
                isCurrentDigimonsTurn = !isCurrentDigimonsTurn;
            }

        }

        public string GenerateBattleCode()
        {
            string code = "";
            foreach (BattleTurn turn in turns)
            {
                if (turn == null)
                {
                    break;
                }

                if (turn.isHit)
                {
                    code += "1,";
                }
                else
                {
                    code += "0,";
                }
                if (turn.isDoubleShot)
                {
                    code += "1,";
                }
                else
                {
                    code += "0,";
                }
                if (turn.isBattleEnded)
                {
                    code += "1,";
                }
                else
                {
                    code += "0,";
                }
            }

            return code;
        }

        public void ResetTurns()
        {
            Array.Clear(turns, 0, turns.Length);
            turnIndex = 0;
        }

        public bool DecodeBattleCode(string code)
        {
            int stringIndex = 0;
            int turnIndexC = 0;
            bool result;
            int StringToInt;
            string charToString;
            BattleTurn battleTurn;
            while (stringIndex < code.Length)
            {
                try
                {
                    battleTurn = new BattleTurn();
                    charToString = code[stringIndex].ToString();
                    StringToInt = Int32.Parse(charToString);
                    result = Convert.ToBoolean(StringToInt);
                    battleTurn.isHit = result;
                    stringIndex += 2;


                    charToString = code[stringIndex].ToString();
                    StringToInt = Int32.Parse(charToString);
                    result = Convert.ToBoolean(StringToInt);
                    battleTurn.isDoubleShot = result;
                    stringIndex += 2;


                    charToString = code[stringIndex].ToString();
                    StringToInt = Int32.Parse(charToString);
                    result = Convert.ToBoolean(StringToInt);
                    battleTurn.isBattleEnded = result;
                    turns[turnIndexC] = battleTurn;
                    stringIndex += 2;
                    turnIndexC++;
                }
                catch
                {
                    return false;
                }
            }
            return true;
            Debug.WriteLine(code);
        }

        public void CloseTCPConnections()
        {
            if (listener != null)
            {
                listener.Stop();
            }
            if (client != null)
            {
                client.Close();
            }
            if (stream != null)
            {
                stream = null;
            }
        }
        NetworkStream stream;
        public Task Connect()
        {
            bool isEnded = false;
            bool isInitialConnectionSuccess = false;
            battleFound = false;
            int counter = 0;
            int sendCount = 0;
            int digimonID = (int)game.currentDigimon.digimonID;
            isConnecting = true;
            string dataToSend;
            return Task.Factory.StartNew(() =>
            {
                while (!isEnded)
                {
                    try
                    {
                        // Determine if address is either ipv4 or ipv6
                        IPAddress iAddr = IPAddress.Parse(game.connectIP);
                        if (iAddr.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            Debug.WriteLine("ip6");
                            client = new TcpClient(AddressFamily.InterNetworkV6);
                            client.Connect(iAddr, game.connectPort);
                        }
                        else
                        {
                            Debug.WriteLine("ip4");
                            client = new TcpClient(game.connectIP, game.connectPort);
                        }
                        

                        // Return if the connection is no longer active
                        if (isPendingCancel)
                        {
                            battleFound = false;
                            return;
                        }

                        // Send digimon Id to host
                        if (sendCount == 0)
                        {
                            dataToSend = "Send1:" + digimonID.ToString();
                        }

                        // Final message
                        else if (sendCount == 1)
                        {
                            dataToSend = "Ready";
                        }

                        else
                        {
                            return;
                        }

                        // Get byte count and convert string into a byte array
                        int byteCount = Encoding.ASCII.GetByteCount(dataToSend + 1);
                        byte[] sendData = new byte[byteCount];
                        sendData = Encoding.ASCII.GetBytes(dataToSend);

                        stream = client.GetStream();
                        stream.Write(sendData, 0, sendData.Length);
                        stream.Flush();
                        Debug.WriteLine("Sending");

                        StreamReader sr = new StreamReader(stream);
                        string response = sr.ReadLine();
                        Debug.WriteLine(response);

                        // Recieve opponent's digimon id from host
                        if (response.IndexOf("Send1:") != -1)
                        {
                            response = response.Remove(response.IndexOf("Send1:"), 6);
                            Debug.WriteLine(response);
                            game.animate.Opponent = new Digimon(game, (DigimonId)Int32.Parse(response));
                            sendCount = 1;
                            isInitialConnectionSuccess = true;
                        }

                        // Data recieved, return and start battle
                        else if (response.IndexOf("Send2:") != -1 && isInitialConnectionSuccess)
                        {
                            response = response.Remove(response.IndexOf("Send2:"), 6);
                            Debug.WriteLine(response);
                            battleFound = DecodeBattleCode(response);
                            isEnded = true;
                            return;
                        }

                        else
                        {
                            sendCount = 0;
                        }

                        
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("failed");
                        counter++;

                        // Ensure the client is still active, timeout after 15 tries or if an exception is thrown after already recieving data
                        if (counter == 15 || sendCount > 0 || isPendingCancel)
                        {
                            battleFound = false;
                            return;
                        }
                    }
                }

            });

        }

        public bool isHostActive = false;
        public bool battleFound = false;

        public Task Host()
        {
            battleFound = false;
            isHostActive = true;
            bool isInitialConnectionSuccess = false;
            int sendcount = 0;
            string dataToSend;
            int digimonID = (int)game.currentDigimon.digimonID;

            // Listern on port
            try
            {
                listener = TcpListener.Create(game.hostPort);
                listener.Start();
            }
            catch
            {
                MessageBox.Show("Failed to open port: " + game.hostPort, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return Task.CompletedTask;
            }

            return Task.Factory.StartNew(() =>
            {

                while (isHostActive)
                {
                    try
                    {

                        Debug.WriteLine("waiting");
                        TcpClient client = listener.AcceptTcpClient();

                        // Cancel if user is no longer host or the user has left the battle start screen
                        if (!game.isHost || game.CurrentScreen != MenuScreen.Battle || game.animate.isInBattle)
                        {
                            battleFound = false;
                            return;
                        }

                        Debug.WriteLine("accepted");
                        stream = client.GetStream();
                        StreamReader sr = new StreamReader(client.GetStream());
                        StreamWriter sw = new StreamWriter(client.GetStream());

                        // Caculate how many bytes used
                        byte[] buffer = new byte[1024];
                        stream.Read(buffer, 0, buffer.Length);
                        int recv = 0;
                        foreach (byte b in buffer)
                        {
                            if (b != 0)
                            {
                                recv++;
                            }
                        }

                        // Convert used bytes in buffer to string
                        string request = Encoding.UTF8.GetString(buffer, 0, recv);
                        Debug.WriteLine("request recieved:" + request);

                        if (request.IndexOf("Send1:") != -1)
                        {
                            dataToSend = "Send1:" + digimonID.ToString();
                            request = request.Remove(request.IndexOf("Send1:"), 6);
                            Debug.WriteLine("request recieved:" + request);
                            game.animate.Opponent = new Digimon(game, (DigimonId)Int32.Parse(request));
                            isInitialConnectionSuccess = true;
                        }

                        else if (request.IndexOf("Ready") != -1 && isInitialConnectionSuccess)
                        {
                            GenerateBattle();
                            dataToSend = "Send2:" + GenerateBattleCode();
                            battleFound = true;
                        }

                        else
                        {
                            return;
                        }

                        sw.WriteLine(dataToSend);
                        sw.Flush();

                        // Finished recieving data
                        if (request.IndexOf("Ready") != -1)
                        {
                            return;
                        }

                        if (request != null)
                        {
                            sendcount++;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("failed");

                        // Cancel if user is no longer on the battle screen
                        if (!game.isHost || game.CurrentScreen != MenuScreen.Battle || sendcount > 0)
                        {
                            battleFound = false;
                            return;
                        }
                    }
                }
            });
        }

        public async void ConnectBattle()
        {
            await Connect();
            Debug.WriteLine("connect done");
            CloseTCPConnections();
            isConnecting = false;
            isPendingCancel = false;

            // Ensure user is still on the battlescreen
            if (game.CurrentScreen == MenuScreen.Battle)
            {
                if (battleFound)
                {
                    game.animate.SetupMultiplayer();
                }
                else
                {
                    game.ResetMainScreen();
                }
            }
        }

        public async void HostBattle()
        {
            await Host();
            Debug.WriteLine("host done");
            isHostActive = false;
            CloseTCPConnections();

            // Ensure user is still on the battlescreen
            if (game.CurrentScreen == MenuScreen.Battle && !game.animate.isInBattle)
            {
                if (battleFound)
                {
                    game.animate.isInBattle = true;
                    game.animate.SetupMultiplayer();
                }
                else
                {
                    game.animate.isInBattle = true;
                    game.ResetMainScreen();
                }
            }

        }
    }
}
