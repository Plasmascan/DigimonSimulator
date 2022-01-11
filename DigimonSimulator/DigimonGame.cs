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
        public readonly DispatcherTimer _animationTimer = new DispatcherTimer(DispatcherPriority.Normal);
        private int GameTickSpeed = 478;
        private int ScreenNo = 0;
        private int SelectedMenuNo = -1;
        private int SubMenuNo = 0;

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 20, 30, 16, 32);
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
            animate.StepDigimon();
        }

        public void AButtonPress()
        {
            if (ScreenNo == 0)
            {
                if (SelectedMenuNo == -1)
                {
                    pixelScreen.TurnMenuIconON(0);
                    SelectedMenuNo = 0;
                }
                else if (SelectedMenuNo == pixelScreen.numberOfIcons - 1)
                {
                    pixelScreen.TurnOffAllIcons();
                    SelectedMenuNo = -1;
                }
                else
                {
                    SelectedMenuNo++;
                    pixelScreen.TurnMenuIconON(SelectedMenuNo);
                }
            }
        }

        public void BButtonPress()
        {
            if (ScreenNo == 0)
            {
                if (SelectedMenuNo == 0)
                {
                    MenuScreens.drawStats(this);
                }
            }
        }

        public void CButtonPress()
        {

        }

    }
}
