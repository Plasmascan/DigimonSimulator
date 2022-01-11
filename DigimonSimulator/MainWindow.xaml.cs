using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigimonSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DigimonGame mainGame = new DigimonGame();

        public MainWindow()
        {
            InitializeComponent();
            mainGame.InitializeGame(screenCavas);
        }

        private void mouseLeftButtonClick(object sender, MouseButtonEventArgs e)
        {
            int x = (int)e.GetPosition(screenCavas).X;
            int y = (int)e.GetPosition(screenCavas).Y;
            mainGame.pixelScreen.pixelClick(x, y);
        }

        private void aButton_Click(object sender, RoutedEventArgs e)
        {
            mainGame.AButtonPress();
        }

        private void bButton_Click(object sender, RoutedEventArgs e)
        {
            mainGame.BButtonPress();
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            mainGame.CButtonPress();
        }
    }
}
