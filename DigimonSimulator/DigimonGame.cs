using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DigimonSimulator
{
    public class DigimonGame
    {
        public PixelScreen pixelScreen;
        public DigimonSprite currentDigimon;
        private readonly DispatcherTimer _animationTimer = new DispatcherTimer(DispatcherPriority.Normal);
        public int counter = 10;

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 20, 20, 16, 32);
            pixelScreen.SetupScreen();
            currentDigimon = SpriteImages.GetElecmon();
            //pixelScreen.DrawDigimonSprite(currentDigimon, 4, counter);
            setTimer();

        }

        public void setTimer()
        {
            _animationTimer.Interval = TimeSpan.FromMilliseconds(400);
            _animationTimer.Tick += _animationTimer_Tick;
            _animationTimer.Start();
        }

        private void _animationTimer_Tick(object sender, EventArgs e)
        {
            //pixelScreen.ClearDigimonSprite(currentDigimon);
            //pixelScreen.DrawDigimonSprite(currentDigimon, counter++, 4);
            pixelScreen.DrawDigimonFrame(currentDigimon, 1, true, counter++);

        }

    }
}
