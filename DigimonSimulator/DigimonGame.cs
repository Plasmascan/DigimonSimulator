using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
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
        public int TimeoutSelectedMenu = 0;
        public MenuScreen CurrentScreen = MenuScreen.MainScreen;
        public MenuScreen SelectedMenu = MenuScreen.MainScreen;
        public int SelectedSubMenuNo = 0;
        public int CurrentSubMenu = 0;
        SoundPlayer beepSound = new SoundPlayer("../../../resources/beep.wav");

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 0, 40, 16, 32);
            pixelScreen.SetupScreen();
            currentDigimon = SpriteImages.Betamon();
            animate = new Animations(this, currentDigimon);
            animate.StartStepAnimation();
            setTimer();

        }

        public void setTimer()
        {
            _gameTimer.Interval = TimeSpan.FromSeconds(1);
            _gameTimer.Tick += _gameTimer_Tick;
            _gameTimer.Start();
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            
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
                if (TimeoutSelectedMenu == 5)
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
                beepSound.Play();
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
            else if (CurrentScreen == MenuScreen.StatScreen)
            {
                beepSound.Play();
                MenuScreens.DrawStats(this, SelectedSubMenuNo);
                if (SelectedSubMenuNo < 2)
                {
                    SelectedSubMenuNo++;
                }
                else
                {
                    SelectedSubMenuNo = 0;
                }
            }
            else if (CurrentScreen == MenuScreen.FeedScreen && CurrentSubMenu == 0)
            {
                beepSound.Play();
                if (SelectedSubMenuNo == 1)
                {
                    SelectedSubMenuNo--;
                }
                else
                {
                    SelectedSubMenuNo++;
                }
                MenuScreens.drawFeedScreen(this, SelectedSubMenuNo);
            }
            else if (CurrentScreen == MenuScreen.Training)
            {
                if (!animate.IsinAnimation && animate.powerUpReady)
                {
                    animate.powerUpTraining();
                }
            }
        }

        public void BButtonPress()
        {
            if (CurrentScreen == MenuScreen.MainScreen)
            {
                if (SelectedMenu == MenuScreen.StatScreen)
                {
                    beepSound.Play();
                    animate.StopStepAnimation();
                    CurrentScreen = MenuScreen.StatScreen;
                    MenuScreens.DrawStats(this, SelectedSubMenuNo);
                    SelectedSubMenuNo++;
                }
                else if (SelectedMenu == MenuScreen.FeedScreen)
                {
                    beepSound.Play();
                    animate.StopStepAnimation();
                    CurrentScreen = MenuScreen.FeedScreen;
                    MenuScreens.drawFeedScreen(this, 0);
                }
                else if (SelectedMenu == MenuScreen.Training)
                {
                    animate.StopStepAnimation();
                    beepSound.Play();
                    CurrentScreen = MenuScreen.Training;
                    animate.setupTraining();
                }
            }
            else if (CurrentScreen == MenuScreen.StatScreen)
            {
                // Goes through the different screen in stats
                beepSound.Play();
                MenuScreens.DrawStats(this, SelectedSubMenuNo);

                if (SelectedSubMenuNo < 2)
                {
                    SelectedSubMenuNo++;
                }
                else
                {
                    SelectedSubMenuNo = 0;
                }
            }

            else if (CurrentScreen == MenuScreen.FeedScreen)
            {
                if (CurrentSubMenu == 1)
                {
                    if (animate.animation == AnimationNo.eat)
                    {
                        beepSound.Play();
                        MenuScreens.drawFeedScreen(this, SelectedSubMenuNo);
                        CurrentSubMenu = 0;
                        animate.resetAnimations();
                    }
                }

                else
                {
                    beepSound.Play();
                    animate.SetupEatAnimation(SelectedSubMenuNo);
                    CurrentSubMenu = 1;
                }
            }
            else if (CurrentScreen == MenuScreen.Training)
            {
                // stuff when already in training screen
            }
        }

        public void CButtonPress()
        {
            if (CurrentScreen != MenuScreen.MainScreen)
            {
                beepSound.Play();
                resetMainScreen();

            }
            else if (CurrentScreen == MenuScreen.MainScreen && SelectedMenu != MenuScreen.MainScreen)
            {
                beepSound.Play();
                pixelScreen.TurnOffAllIcons();
                SelectedMenu = MenuScreen.MainScreen;
            }
        }

        public void resetMainScreen()
        {
            MenuScreens.MainScreen(this);
            CurrentScreen = MenuScreen.MainScreen;
            SelectedSubMenuNo = 0;
            CurrentSubMenu = 0;
            TimeoutSelectedMenu = 0;
            animate.resetAnimations();
        }

    }
}
