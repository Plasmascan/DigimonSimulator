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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            mainGame.InitializeGame(screenCanvas);
            pressedAButtonImage.Opacity = 0;
            pressedBButtonImage.Opacity = 0;
            pressedCButtonImage.Opacity = 0;
        }

        private void aButton_Click(object sender, RoutedEventArgs e)
        {
            //mainGame.AButtonPress();
            mainGame.animate.StopDigimonStateAnimation();
            mainGame.animate._animationTick.Start();
            mainGame.animate.animation = AnimationNo.Defeat;
        }

        private void bButton_Click(object sender, RoutedEventArgs e)
        {
            //mainGame.BButtonPress();
            mainGame.animate.Opponent.currenthealth = -1;
        }

        private void cButton_Click(object sender, RoutedEventArgs e)
        {
            //mainGame.CButtonPress();
            mainGame.currentDigimon.currenthealth = -1;
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            DrawWindow drawWindow = new DrawWindow();
            drawWindow.Show();
        }

        private void closeGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void muteUnmuteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (Sounds.IsMute())
            {
                Sounds.SoundOn();
                muteUnmuteMenuItem.Header = "Mute";
                muteUnmuteMenuItemIcon.Source = new BitmapImage(new Uri("mute.png", UriKind.Relative));
            }
            else
            {
                Sounds.MuteSound();
                muteUnmuteMenuItem.Header = "Unmute";
                muteUnmuteMenuItemIcon.Source = new BitmapImage(new Uri("unmute.png", UriKind.Relative));
            }
        }
        private void pinMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (pinMenuItem.IsChecked)
            {
                Topmost = true;
            }
            else
            {
                Topmost = false;
            }
        }

        private void debugMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /**
            mainGame.animate.StopDigimonStateAnimation();
            Digimon testDigimon = new Digimon(mainGame, DigimonId.Greymon);
            mainGame.animate.setupDigivolve(testDigimon);
            **/


            DrawWindow drawWindow = new DrawWindow();
            drawWindow.Show();

            //mainGame.currentDigimon.HurtDigimon();
            //mainGame.resetMainScreen();
            
            if (mainGame.currentDigimon != null)
            {
                //mainGame.currentDigimon.HurtDigimon();
                Debug.WriteLine("Care mistakes: " + mainGame.currentDigimon.careMistakes + " overfeed: " + mainGame.currentDigimon.timesOverfed + 
                    "\ncurrent hunger: " + mainGame.currentDigimon.currentHunger + " needed: " + mainGame.currentDigimon.maxHunger / 4 * 3);
                //mainGame.currentDigimon.KillDigimon();
            }
            //mainGame.currentDigimon.WakeupDigimon();
        }

        private void minimizeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainGame.animate._animationTick.IsEnabled)
            {
                mainGame.animate._animationTick.Stop();
            }
            else
            {
                mainGame.animate._animationTick.Start();
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            aButton.Visibility = Visibility.Visible;
            bButton.Visibility = Visibility.Visible;
            cButton.Visibility = Visibility.Visible;
            pauseButton.Visibility = Visibility.Visible;
            printButton.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            aButton.Visibility = Visibility.Hidden;
            bButton.Visibility = Visibility.Hidden;
            cButton.Visibility = Visibility.Hidden;
            pauseButton.Visibility = Visibility.Hidden;
            printButton.Visibility = Visibility.Hidden;
        }

        private void backgroundImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && !lockMenuItem.IsChecked)
            {
                this.DragMove();
            }

        }

    }
}
