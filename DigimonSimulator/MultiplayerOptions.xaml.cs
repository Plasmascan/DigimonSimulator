using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
        static string externalIP;

        public MultiplayerOptions(DigimonGame game)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.game = game;
            InitializeComponent();
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

            try
            {
                externalIP = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
                string externalIpString = SymmetricKeyEncryptionDecryption.EncryptString(keyString, externalIP + "port:" + game.hostPort);
                userCodeTextBox.Text = externalIpString;
            }
            catch
            {
                externalIP = string.Empty;
                userCodeTextBox.Text = "Can't resolve IP";
                copyButton.IsEnabled = false;
            }
            
            portTextBox.Text = game.hostPort.ToString();

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
                try
                {
                    int newPort = Convert.ToInt32(portTextBox.Text.ToString());
                    game.hostPort = newPort;
                }
                catch
                {
                    MessageBox.Show("Invalid Port", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                game.isHost = false;

                // store old values incase of exception
                string connectionIP = game.connectIP;
                int connectionPort = game.connectPort;

                if (connectCodeTextBox.Text.ToString() != string.Empty)
                {

                    try
                    {
                        string decode = SymmetricKeyEncryptionDecryption.DecryptString(keyString, connectCodeTextBox.Text.ToString());

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
                        MessageBox.Show("Invalid Code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        game.connectIP = connectionIP;
                        game.connectPort = connectionPort;
                        return;
                    }
                }
                else
                {
                    game.connectIP = "127.0.0.1";
                    game.connectPort = 1402;
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
            Regex regex = new Regex("[^0-9]+");
            int result;
            bool isNumber = int.TryParse(e.Text, out result);
            e.Handled = regex.IsMatch(e.Text);

            if (portTextBox.Text.ToString() != string.Empty && isNumber)
            {
                string text = portTextBox.Text.ToString();
                string fullText = portTextBox.Text.ToString() + e.Text;
                int textToInt = Convert.ToInt32(fullText);
                if (textToInt > 65535)
                {
                    portTextBox.Text = "65535";
                    portTextBox.SelectionStart = portTextBox.Text.Length;
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

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(userCodeTextBox.Text.ToString());
        }
    }
}
