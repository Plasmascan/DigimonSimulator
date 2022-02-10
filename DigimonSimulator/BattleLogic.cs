using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
        public Digimon currentDigimon;
        public Digimon opponentDigimon;
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
            currentDigimon = game.currentDigimon;
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
                    digimonsTurn = currentDigimon;
                }
                else
                {
                    digimonsTurn = opponentDigimon;
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

        public void DecodeBattleCode(string code)
        {
            int stringIndex = 0;
            int turnIndexC = 0;
            bool result;
            int StringToInt;
            string charToString;
            BattleTurn battleTurn;
            while (stringIndex < code.Length)
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
            int counter = 0;
            int sendCount = 0;
            int digimonID = (int)currentDigimon.digimonID;
            isConnecting = true;
            string dataToSend;
            return Task.Factory.StartNew(() =>
            {
                while (!isEnded)
                {
                    try
                    {
                        client = new TcpClient(game.connectIP, 1402);

                        // Return if the connection is no longer active
                        if (isPendingCancel)
                        {
                            battleFound = false;
                            return;
                        }

                        // Send digimon Id to client
                        if (sendCount == 0)
                        {
                            dataToSend = digimonID.ToString();
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
                        if (sendCount == 0)
                        {
                            game.animate.Opponent = new Digimon(game, (DigimonId)Int32.Parse(response));
                        }

                        // Data recieved, return and start battle
                        if (sendCount == 1)
                        {
                            DecodeBattleCode(response);
                            battleFound = true;
                            isEnded = true;
                            return;
                        }

                        if (response != null)
                        {
                            sendCount++;
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
            listener = new TcpListener(System.Net.IPAddress.Any, 1402);
            listener.Start();
            isHostActive = true;
            int sendcount = 0;
            string dataToSend;
            int digimonID = (int)currentDigimon.digimonID;

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

                        if (sendcount == 0)
                        {
                            dataToSend = digimonID.ToString();
                            game.animate.Opponent = new Digimon(game, (DigimonId)Int32.Parse(request));
                        }

                        else if (sendcount == 1)
                        {
                            GenerateBattle();
                            dataToSend = GenerateBattleCode();
                            battleFound = true;
                        }

                        else
                        {
                            return;
                        }

                        sw.WriteLine(dataToSend);
                        sw.Flush();

                        // Finished recieving data
                        if (sendcount == 1)
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
                    game.resetMainScreen();
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
                    game.resetMainScreen();
                }
            }

        }
    }
}
