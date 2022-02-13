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
            drawScreen = new PixelScreen(screenCanvas, 20, 30, 16, 32, 10);
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
            drawScreen.PanScreen(0, -1, false);
        }

        private void panDownButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.PanScreen(0, 1, false);
        }

        private void panLeftButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.PanScreen(-1, 0, false);
        }

        private void panRightButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.PanScreen(1, 0, false);
        }

        private void mirrorScreenButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.MirrorScreen();
        }

        private void loadSpriteButton_Click(object sender, RoutedEventArgs e)
        {
            bool isDigimon = true;
            if (isDigimon)
            {
                Digimon digimon = new Digimon(null, DigimonId.Tyrannomon);
                int startX = drawScreen.NumberOfXPixels - (digimon.sprite.frame1Width / 2) - 16;
                drawScreen.DrawDigimonFrame(digimon, SpriteFrame.Happy, false, true, startX, 0);
            }
            else
            {
                Sprite sprite = new Sprite();
                sprite = SpriteMaps.BlackSkullMarkSprite();
                drawScreen.DrawSprite(sprite, 10, 0, false);
            }
        }

        private void invertScreenButton_Click(object sender, RoutedEventArgs e)
        {
            drawScreen.InvertScreen();
        }
    }
}
