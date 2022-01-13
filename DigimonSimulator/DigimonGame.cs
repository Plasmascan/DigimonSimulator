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
        public readonly DispatcherTimer _gameTimer = new DispatcherTimer(DispatcherPriority.Normal);
        public bool stepSprite;
        private int GameTickSpeed = 478;
        private int TimeoutSelectedMenu = 0;
        private MenuScreen CurrentScreen = MenuScreen.MainScreen;
        private MenuScreen SelectedMenu = MenuScreen.MainScreen;
        private int SubMenuNo = 0;

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 20, 30, 16, 32);
            pixelScreen.SetupScreen();
            currentDigimon = SpriteImages.Elecmon();
            animate = new Animations(pixelScreen, currentDigimon);
            animate.resetStepAnimation();
            stepSprite = true;
            setTimer();

        }

        public void setTimer()
        {
            _gameTimer.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _gameTimer.Tick += _gameTimer_Tick;
            _gameTimer.Start();
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            if (stepSprite)
            {
                animate.StepDigimon();
            }
            if (currentDigimon.currentHunger > -1)
            {
                currentDigimon.currentHunger--;
            }
            if (currentDigimon.currentStrength > -1)
            {
                currentDigimon.currentStrength--;
            }

            // reset selected menu after ?ms if on main screen
            if (CurrentScreen == MenuScreen.MainScreen && SelectedMenu!= MenuScreen.MainScreen)
            {
                TimeoutSelectedMenu++;
                if (TimeoutSelectedMenu == 10)
                {
                    pixelScreen.TurnOffAllIcons();
                    SelectedMenu = MenuScreen.MainScreen;
                    TimeoutSelectedMenu = 0;
                }
            }

        }

        public void AButtonPress()
        {

            if (CurrentScreen == MenuScreen.MainScreen)
            {
                TimeoutSelectedMenu = 0;
                if (SelectedMenu == MenuScreen.MainScreen)
                {
                    pixelScreen.TurnMenuIconON(MenuScreen.StatScreen);
                    SelectedMenu = MenuScreen.StatScreen;
                }
                else if ((int)SelectedMenu == pixelScreen.numberOfIcons - 1)
                {
                    pixelScreen.TurnOffAllIcons();
                    SelectedMenu = MenuScreen.MainScreen;
                }
                else
                {
                    SelectedMenu++;
                    pixelScreen.TurnMenuIconON(SelectedMenu);
                }
            }
        }

        public void BButtonPress()
        {
            if (CurrentScreen == MenuScreen.MainScreen)
            {
                if (SelectedMenu == MenuScreen.StatScreen)
                {
                    stepSprite = false;
                    CurrentScreen = MenuScreen.StatScreen;
                    MenuScreens.DrawStats(this, SubMenuNo);
                    SubMenuNo++;
                }
            }
            else if (CurrentScreen == MenuScreen.StatScreen)
            {
                MenuScreens.DrawStats(this, SubMenuNo);
                if (SubMenuNo < 2)
                {
                    SubMenuNo++;
                }
                else
                {
                    SubMenuNo = 0;
                }
            }
        }

        public void CButtonPress()
        {
            if (CurrentScreen != MenuScreen.MainScreen)
            {
                MenuScreens.MainScreen(this);
                CurrentScreen = MenuScreen.MainScreen;
                SubMenuNo = 0;
            }
            else
            {
                pixelScreen.TurnOffAllIcons();
                SelectedMenu = MenuScreen.MainScreen;
            }
        }

    }
}
