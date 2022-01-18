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
            mainGame.InitializeGame(screenCanvas);
            pressedAButtonImage.Opacity = 0;
            pressedBButtonImage.Opacity = 0;
            pressedCButtonImage.Opacity = 0;
        }

        private void mouseLeftButtonClick(object sender, MouseButtonEventArgs e)
        {
            int x = (int)e.GetPosition(screenCanvas).X;
            int y = (int)e.GetPosition(screenCanvas).Y;
            mainGame.pixelScreen.PixelClick(x, y);
            //Debug.Write("x: " + e.GetPosition(this).X + " y: " + (int)e.GetPosition(screenCanvas).Y);
        }

        private void aButton_Click(object sender, RoutedEventArgs e)
        {
            //mainGame.AButtonPress();
            mainGame.animate.StopStepAnimation();
            mainGame.animate.SetupBattleCup();
        }

        private void bButton_Click(object sender, RoutedEventArgs e)
        {
            //mainGame.BButtonPress();
            //mainGame.animate.Opponent.health = -1;
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            //mainGame.CButtonPress();
            //mainGame.currentDigimon.health = -1;
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            DrawWindow drawWindow = new DrawWindow();
            drawWindow.Show();
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainGame._gameTimer.IsEnabled)
            {
                mainGame._gameTimer.Stop();
            }
            else
            {
                mainGame._gameTimer.Start();
            }
        }

        private void pressedAButtonImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainGame.AButtonPress();
            pressedAButtonImage.Opacity = 1;
        }

        private void pressedAButtonImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pressedAButtonImage.Opacity = 0;
        }

        private void pressedAButtonImage_MouseLeave(object sender, MouseEventArgs e)
        {
            pressedAButtonImage.Opacity = 0;
        }

        private void pressedBButtonImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainGame.BButtonPress();
            pressedBButtonImage.Opacity = 1;
        }

        private void pressedBButtonImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pressedBButtonImage.Opacity = 0;
        }

        private void pressedBButtonImage_MouseLeave(object sender, MouseEventArgs e)
        {
            pressedBButtonImage.Opacity = 0;
        }

        private void pressedCButtonImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mainGame.CButtonPress();
            pressedCButtonImage.Opacity = 1;
        }

        private void pressedCButtonImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            pressedCButtonImage.Opacity = 0;
        }

        private void pressedCButtonImage_MouseLeave(object sender, MouseEventArgs e)
        {
            pressedCButtonImage.Opacity = 0;
        }
    }
}
