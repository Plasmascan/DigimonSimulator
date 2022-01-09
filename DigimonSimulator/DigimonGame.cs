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
        public Animations animate;
        private readonly DispatcherTimer _animationTimer = new DispatcherTimer(DispatcherPriority.Normal);
        private int GameTickSpeed = 478;

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 20, 20, 16, 32);
            pixelScreen.SetupScreen();
            currentDigimon = SpriteImages.GetElecmon();
            animate = new Animations(pixelScreen, currentDigimon);
            animate.resetStepAnimation();
            setTimer();

        }

        public void setTimer()
        {
            _animationTimer.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTimer.Tick += _animationTimer_Tick;
            _animationTimer.Start();
        }

        private void _animationTimer_Tick(object sender, EventArgs e)
        {
            //pixelScreen.DrawDigimonFrame(currentDigimon, 1, true, counter++);
            animate.StepDigimon();
        }

    }
}
