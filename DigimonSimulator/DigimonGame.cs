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
        public Digimon currentDigimon;
        public Animations animate;
        public readonly DispatcherTimer _gameTimer = new DispatcherTimer(DispatcherPriority.Normal);
        public int TimeoutSelectedMenu = 0;
        public MenuScreen CurrentScreen = MenuScreen.MainScreen;
        public MenuScreen SelectedMenu = MenuScreen.MainScreen;
        public int SelectedSubMenuNo = 0;
        public int CurrentSubMenu = 0;
        public int gameElapsedSeconds = 0;
        public int gameElapsedMinutes = 0;
        public int gameElapsedHours = 0;
        public int gameCurrentSecond;
        public int gameCurrentMinute;
        public int gameCurrentHour;
        public bool isEvolutionReady = false;

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 0, 20, 16, 32, 4);
            pixelScreen.SetupScreen();
            currentDigimon = new Digimon(this, DigimonId.Betamon);
            animate = new Animations(this);
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
            gameElapsedSeconds++;
            gameCurrentSecond = gameElapsedSeconds % 60;
            gameCurrentMinute = gameElapsedSeconds / 60 % 60;
            gameElapsedMinutes = gameElapsedSeconds / 60;
            gameElapsedHours = gameElapsedMinutes / 60;
            currentDigimon.totalTimeAlive++;

            if (currentDigimon.canDigivolve)
            {
                currentDigimon.evolveTime--;
            }

            if (!animate.isEvolving && !animate.IsinAnimation)
            {
                if (CurrentScreen == MenuScreen.MainScreen && currentDigimon.evolveTime < 1 && currentDigimon.canDigivolve)
                {
                    animate.StopStepAnimation();
                    currentDigimon.Digivolve();
                }
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
            if (!animate.isEvolving)
            {
                if (CurrentScreen == MenuScreen.MainScreen)
                {
                    TimeoutSelectedMenu = 0;
                    Sounds.PlaySound(Sound.Beep);
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
                    Sounds.PlaySound(Sound.Beep);
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
                    Sounds.PlaySound(Sound.Beep);
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
                else if (CurrentScreen == MenuScreen.BattleCup)
                {
                    if (!animate.IsinAnimation && animate.powerUpReady)
                    {
                        animate.powerUpTraining();
                    }
                }
            }
        }

        public void BButtonPress()
        {
            if (!animate.isEvolving)
            {
                if (CurrentScreen == MenuScreen.MainScreen)
                {
                    if (SelectedMenu == MenuScreen.StatScreen)
                    {
                        Sounds.PlaySound(Sound.Beep);
                        animate.StopStepAnimation();
                        CurrentScreen = MenuScreen.StatScreen;
                        MenuScreens.DrawStats(this, SelectedSubMenuNo);
                        SelectedSubMenuNo++;
                    }
                    else if (SelectedMenu == MenuScreen.FeedScreen)
                    {
                        Sounds.PlaySound(Sound.Beep);
                        animate.StopStepAnimation();
                        CurrentScreen = MenuScreen.FeedScreen;
                        MenuScreens.drawFeedScreen(this, 0);
                    }
                    else if (SelectedMenu == MenuScreen.Training)
                    {
                        animate.StopStepAnimation();
                        Sounds.PlaySound(Sound.Beep);
                        CurrentScreen = MenuScreen.Training;
                        animate.SetupTraining();
                    }
                    else if (SelectedMenu == MenuScreen.BattleCup)
                    {
                        animate.StopStepAnimation();
                        Sounds.PlaySound(Sound.Beep);
                        CurrentScreen = MenuScreen.BattleCup;
                        animate.SetupBattleCup();
                    }
                }
                else if (CurrentScreen == MenuScreen.StatScreen)
                {
                    // Goes through the different screen in stats
                    Sounds.PlaySound(Sound.Beep);
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
                        if (animate.animation == AnimationNo.Eat)
                        {
                            Sounds.PlaySound(Sound.Beep);
                            MenuScreens.drawFeedScreen(this, SelectedSubMenuNo);
                            CurrentSubMenu = 0;
                            animate.ResetAnimations();
                        }
                    }

                    else
                    {
                        Sounds.PlaySound(Sound.Beep);
                        animate.SetupEatAnimation(SelectedSubMenuNo);
                        CurrentSubMenu = 1;
                    }
                }
                else if (CurrentScreen == MenuScreen.Training)
                {
                    // stuff when already in training screen
                }
            }
        }

        public void CButtonPress()
        {
            if (!animate.isEvolving)
            {
                if (CurrentScreen != MenuScreen.MainScreen)
                {
                    Sounds.PlaySound(Sound.Beep);
                    resetMainScreen();

                }
                else if (CurrentScreen == MenuScreen.MainScreen && SelectedMenu != MenuScreen.MainScreen)
                {
                    Sounds.PlaySound(Sound.Beep);
                    pixelScreen.TurnOffAllIcons();
                    SelectedMenu = MenuScreen.MainScreen;
                }
            }
        }

        public void resetMainScreen()
        {
            MenuScreens.MainScreen(this);
            CurrentScreen = MenuScreen.MainScreen;
            SelectedSubMenuNo = 0;
            CurrentSubMenu = 0;
            TimeoutSelectedMenu = 0;
            animate.ResetAnimations();
        }

    }
}
