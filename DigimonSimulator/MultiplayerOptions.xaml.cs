using Open.Nat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DigimonSimulator
{
    /// <summary>
    /// Interaction logic for MultiplayerOptions.xaml
    /// </summary>
    public partial class MultiplayerOptions : Window
    {
        DigimonGame game;
        static string keyString = "b14cahszi24e413hsz4e2ea2315ag4s3";
        static string externalIP = "";
        bool isResolveIpInProgress = false;
        bool isMapPortInProgress = false;

        public MultiplayerOptions(DigimonGame game)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.game = game;
            InitializeComponent();
            userCodeTextBox.Text = "Obtaining Code...";
            applyHostOButton.IsEnabled = false;
            ipAddressLabel.IsEnabled = false;
            ipAddressTextBox.IsEnabled = false;
            ipAddressPortLabel.IsEnabled = false;
            ipAddressPortTextBox.IsEnabled = false;

            if (game.isHost)
            {
                hostCheckBox.IsChecked = true;
                ConnectGroupBox.IsEnabled = false;
                hostGroupBox.IsEnabled = true;
            }
            else
            {
                connectCheckBox.IsChecked = true;
                ConnectGroupBox.IsEnabled = true;
                hostGroupBox.IsEnabled = false;
            }

            if (game.connectIP != "127.0.0.1")
            {
                connectCodeTextBox.Text = SymmetricKeyEncryptionDecryption.EncryptString(keyString, game.connectIP + "port:" + game.connectPort);
            }

            //try
            //{
            //    externalIP = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            //    string externalIpString = SymmetricKeyEncryptionDecryption.EncryptString(keyString, externalIP + "port:" + game.hostPort);
            //    userCodeTextBox.Text = externalIpString;
            //}
            //catch
            //{
            //    externalIP = string.Empty;
            //    userCodeTextBox.Text = "Can't resolve IP";
            //    copyButton.IsEnabled = false;
            //}

            
            //userCodeTextBox.Text = game.externalIP;

            GetExternalIP();
            CreatePortMapping(game.hostPort);

            
            portTextBox.Text = game.hostPort.ToString();
        }

        public async void GetExternalIP()
        {
            bool isIPResolved;
            try
            {
                isResolveIpInProgress = true;
                var discoverer = new NatDiscoverer();
                var device = await discoverer.DiscoverDeviceAsync();
                var ip = await device.GetExternalIPAsync();
                externalIP = ip.ToString();
                string externalIpString = SymmetricKeyEncryptionDecryption.EncryptString(keyString, externalIP + "port:" + game.hostPort);
                Debug.WriteLine(externalIP + "port:" + game.hostPort);
                userCodeTextBox.Text = externalIpString;
                isIPResolved = true;
            }
            catch
            {
                isIPResolved = false;
            }

            if (!isIPResolved)
            {
                try
                {
                    externalIP = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
                    string externalIpString = SymmetricKeyEncryptionDecryption.EncryptString(keyString, externalIP + "port:" + game.hostPort);
                    userCodeTextBox.Text = externalIpString;
                }
                catch
                {
                    userCodeTextBox.Text = "Can't resolve IP, The game will still be hosted over the local network.";
                    externalIP = string.Empty;
                    copyButton.IsEnabled = false;
                }
            }

            isResolveIpInProgress = false;

            if (isMapPortInProgress == false)
            {
                applyHostOButton.IsEnabled = true;
                portTextBox.IsEnabled = true;
            }
        }

        public async void CreatePortMapping(int portNumber)
        {
            isMapPortInProgress = true;
            try
            {
                var discoverer = new NatDiscoverer();
                var cts = new CancellationTokenSource(10000);
                var device = await discoverer.DiscoverDeviceAsync(PortMapper.Upnp, cts);

                // Check to see if port is already mapped
                Mapping returnedMap = await device.GetSpecificMappingAsync(Protocol.Tcp, portNumber);
                if (returnedMap == null)
                {
                    await device.CreatePortMapAsync(new Mapping(Protocol.Tcp, portNumber, portNumber, 600000, "Digimon Simulator"));
                }
                else
                {
                    Debug.WriteLine(returnedMap.Expiration);
                }
            }
            catch
            {
                if (externalIP != string.Empty)
                {
                    MessageBox.Show("Failed to map port, Required port forwarding if playing online.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            isMapPortInProgress = false;

            if (isResolveIpInProgress == false)
            {
                applyHostOButton.IsEnabled = true;
                portTextBox.IsEnabled = true;
            }
        }

        private void hostCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (connectCheckBox.IsChecked == true)
            {
                hostCheckBox.IsChecked = true;
                connectCheckBox.IsChecked = false;
                ConnectGroupBox.IsEnabled = false;
                hostGroupBox.IsEnabled = true;
            }
            else
            {
                hostCheckBox.IsChecked = true;
            }
        }

        private void connectCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (hostCheckBox.IsChecked == true)
            {
                connectCheckBox.IsChecked = true;
                hostCheckBox.IsChecked = false;
                ConnectGroupBox.IsEnabled = true;
                hostGroupBox.IsEnabled = false;
            }
            else
            {
                connectCheckBox.IsChecked = true;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (hostCheckBox.IsChecked == true)
            {
                game.isHost = true;
            }
            else
            {
                game.isHost = false;

                // store old values incase of exception
                string connectionIP = game.connectIP;
                int connectionPort = game.connectPort;

                if (connectCodeTextBox.Text.ToString() != string.Empty && IpConnectCheckBox.IsChecked == false)
                {

                    try
                    {
                        string decode = SymmetricKeyEncryptionDecryption.DecryptString(keyString, connectCodeTextBox.Text.ToString());
                        Debug.WriteLine(decode);
                        // Find index of port and set as connection port
                        int portIndex = decode.IndexOf("port:");
                        string port = "";

                        for (int i = portIndex + 5; i < decode.Length; i++)
                        {
                            port += decode[i];
                        }
                        game.connectPort = Convert.ToInt32(port);

                        // Remove port from IP address and set as connection ip adress
                        decode = decode.Remove(portIndex, decode.Length - portIndex);
                        IPAddress outAddress;
                        bool isValidIp = IPAddress.TryParse(decode, out outAddress);
                        if (!isValidIp)
                        {
                            throw new Exception();
                        }
                        game.connectIP = decode;
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Code.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        game.connectIP = connectionIP;
                        game.connectPort = connectionPort;
                        return;
                    }
                }
                else if (connectCodeTextBox.Text.ToString() != string.Empty && IpConnectCheckBox.IsChecked == true)
                {
                    try
                    {
                        IPAddress address;
                        int port;
                        bool isValidIP = false;
                        bool isValidPort = false;
                        port = Convert.ToInt32(ipAddressPortTextBox.Text.ToString());
                        isValidIP = IPAddress.TryParse(ipAddressTextBox.Text.ToString(), out address);
                        if (port > -1 && port < 65535)
                        {
                            isValidPort = true;
                        }

                        if (isValidIP && isValidPort)
                        {
                            game.connectIP = ipAddressTextBox.Text.ToString();
                            game.connectPort = port;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid IP Address or port.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    game.connectIP = "127.0.0.1";
                    game.connectPort = game.hostPort;
                }
            }
            Close();
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            connectCodeTextBox.Text = Clipboard.GetText();
        }

        private void connectCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (connectCodeTextBox.Text.Length > 100)
            {
                string text = connectCodeTextBox.Text.ToString();
                text = text.Remove(101, text.Length - 101);
                connectCodeTextBox.Text = text;
                connectCodeTextBox.SelectionStart = connectCodeTextBox.Text.Length;
            }
        }

        private void portTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validatePortInput(e, portTextBox);
        }

        private void validatePortInput(TextCompositionEventArgs e, TextBox textbox)
        {
            Regex regex = new Regex("[^0-9]+");
            int result;
            bool isNumber = int.TryParse(e.Text, out result);
            e.Handled = regex.IsMatch(e.Text);

            if (textbox.Text.ToString() != string.Empty && isNumber)
            {
                string text = textbox.Text.ToString();
                string fullText = textbox.Text.ToString() + e.Text;
                int textToInt = Convert.ToInt32(fullText);
                if (textToInt > 65535)
                {
                    textbox.Text = "65535";
                    textbox.SelectionStart = textbox.Text.Length;
                    e.Handled = true;
                }
            }
        } 

        private void portTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (portTextBox.IsFocused)
            {
                if (e.Key == Key.Space)
                {
                    e.Handled = true;
                }
            }
        }

        private void portTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (externalIP != string.Empty)
            {
                userCodeTextBox.Text = SymmetricKeyEncryptionDecryption.EncryptString(keyString, externalIP + "port:" + portTextBox.Text);
            }
        }

        private bool setPort(string port, bool isHostPort)
        {
            try
            {
                int newPort = Convert.ToInt32(port);
                if (newPort > 65535 || newPort < 1)
                {
                    throw new Exception();
                }
                if (isHostPort)
                {
                    game.hostPort = newPort;
                }
                else
                {
                    game.connectPort = newPort;
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Invalid Port.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(userCodeTextBox.Text.ToString());
        }

        private void applyHostOButton_Click(object sender, RoutedEventArgs e)
        {
            applyHostOButton.IsEnabled = false;
            portTextBox.IsEnabled = false;
            userCodeTextBox.Text = "Refreshing...";
            GetExternalIP();
            bool isValidPort = setPort(portTextBox.Text.ToString(), true);
            if (isValidPort)
            {
                CreatePortMapping(game.hostPort);
            }
        }

        private void showLocalCodeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (IpConnectCheckBox.IsChecked == true)
            {
                hostscodeLabel.IsEnabled = false;
                connectCodeTextBox.IsEnabled = false;
                pasteButton.IsEnabled = false;
                ipAddressLabel.IsEnabled = true;
                ipAddressTextBox.IsEnabled = true;
                ipAddressPortLabel.IsEnabled = true;
                ipAddressPortTextBox.IsEnabled = true;
            }
            else
            {
                hostscodeLabel.IsEnabled = true;
                connectCodeTextBox.IsEnabled = true;
                pasteButton.IsEnabled = true;
                ipAddressLabel.IsEnabled = false;
                ipAddressTextBox.IsEnabled = false;
                ipAddressPortLabel.IsEnabled = false;
                ipAddressPortTextBox.IsEnabled = false;
            }
        }

        private void ipAddressPortTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            validatePortInput(e, ipAddressPortTextBox);
        }

        private void ipAddressTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9A-Fa-f/.:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            game.isMultiplayerOptionsOpen = false;
        }
    }
}
