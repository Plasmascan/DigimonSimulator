using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for DrawWindow.xaml
    /// </summary>
    public partial class DrawWindow : Window
    {
        PixelScreen drawScreen;
        public DrawWindow()
        {
            InitializeComponent();
            drawScreen = new PixelScreen(screenCanvas, 20, 30, 16, 32);
            drawScreen.SetupScreen();
        }

        private void generateCodeButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.GenerateSpriteCode(spriteNameTextbox.Text.ToString(), codeTextbox);
        }

        private void screenCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int x = (int)e.GetPosition(screenCanvas).X;
            int y = (int)e.GetPosition(screenCanvas).Y;
            drawScreen.PixelClick(x, y);
        }

        private void panUpButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.PanScreen(0, -1);
        }

        private void panDownButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.PanScreen(0, 1);
        }

        private void panLeftButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.PanScreen(-1, 0);
        }

        private void panRightButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.PanScreen(1, 0);
        }

        private void mirrorScreenButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.MirrorScreen();
        }

        private void loadSpriteButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDigimon = false;
            if (isDigimon)
            {
                DigimonSprite digimon = new DigimonSprite();
                digimon = SpriteImages.Greymon();
                int startX = drawScreen.NumberOfXPixels - (digimon.frame1Width / 2) - 16;
                drawScreen.DrawDigimonFrame(digimon, SpriteFrame.Eat2, false, startX, 0);
            }
            else
            {
                Sprite sprite = new Sprite();
                sprite = SpriteImages.FireBallProjectileSprite();
                drawScreen.DrawSprite(sprite, 0, 0, false);
            }
        }
    }
}
