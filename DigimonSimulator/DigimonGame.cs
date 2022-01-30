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
        public int TimeoutMenuScreen = 0;
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
        public DateTime setTime;
        public int numberOfDung = 0;
        public bool isEgg = false;

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 0, 20, 16, 32, 4);
            pixelScreen.SetupScreen();
            //currentDigimon = new Digimon(this, DigimonId.Agumon);
            animate = new Animations(this);
            //animate.StartDigimonStateAnimation();
            setTime = DateTime.Now;
            SelectEgg();
            setTimer();
        }

        public void SelectEgg()
        {
            currentDigimon = null;
            CurrentScreen = MenuScreen.EggSelection;
            MenuScreens.DrawEggSelectionScreen(this);
        }

        public void setTimer()
        {
            _gameTimer.Interval = TimeSpan.FromSeconds(1);
            _gameTimer.Tick += _gameTimer_Tick;
            _gameTimer.Start();
        }

        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            if (currentDigimon != null)
            {
                gameElapsedSeconds++;
                gameCurrentSecond = gameElapsedSeconds % 60;
                gameCurrentMinute = gameElapsedSeconds / 60 % 60;
                gameElapsedMinutes = gameElapsedSeconds / 60;
                gameElapsedHours = gameElapsedMinutes / 60;
                currentDigimon.totalTimeAlive++;
                setTime = setTime.AddSeconds(1);

                // Force digimon to sleep

                if (currentDigimon.forcedSleepTimer > -1)
                {
                    currentDigimon.forcedSleepTimer--;
                }

                // Digimon goes to toilet
                if (!currentDigimon.isAsleep && numberOfDung != 4 && !animate.IsinAnimation && !currentDigimon.isHurt && !isEgg)
                {
                    currentDigimon.dungTimer--;
                    if (currentDigimon.dungTimer == 0)
                    {
                        numberOfDung++;
                        currentDigimon.dungTimer = currentDigimon.dungTimeInterval;

                        // Digimon gets injured if 4 dungs are on screen

                        if (numberOfDung == 4)
                        {
                            currentDigimon.HurtDigimon();
                            pixelScreen.TurnOnNotificationIcon();
                            Sounds.PlaySound(Sound.Step); // change with notification sound when imlemented

                        }

                        if (CurrentScreen == MenuScreen.MainScreen && !animate.isEvolving)
                        {
                            resetMainScreen();
                        }
                    }

                }

                // set digimon to sleep
                if (currentDigimon.IsWithinSleepingTime() && currentDigimon.secondsUntilSleep == 0 && !currentDigimon.isAsleep && !currentDigimon.isHurt && !isEgg)
                {
                    if (CurrentScreen == MenuScreen.MainScreen && !animate.isEvolving && !animate.IsinAnimation)
                    {
                        currentDigimon.DigimonFallAsleep();
                        pixelScreen.TurnOnNotificationIcon();
                        Sounds.PlaySound(Sound.Step);
                        animate.ResetAnimations();
                        animate.StartDigimonStateAnimation();
                        currentDigimon.hungerCareMistakeTimer = -1;
                    }
                }

                // automatically wake digimon up at 7am if the digimon hasn't been forced to sleep
                else if (!currentDigimon.IsWithinSleepingTime() && currentDigimon.isAsleep && currentDigimon.forcedSleepTimer == -1)
                {
                    currentDigimon.WakeupDigimon();
                    if (CurrentScreen == MenuScreen.MainScreen)
                    {
                        resetMainScreen();
                    }
                }

                // countdown until a care mistake is reached
                if (currentDigimon.sleepCareMistakeTimer > -1)
                {
                    currentDigimon.sleepCareMistakeTimer--;
                    if (currentDigimon.sleepCareMistakeTimer == 0)
                    {
                        currentDigimon.careMistakes++;
                    }
                }

                // countdown until a care mistake is reached
                if (currentDigimon.hungerCareMistakeTimer > -1 && !isEgg)
                {
                    currentDigimon.hungerCareMistakeTimer--;
                    if (currentDigimon.hungerCareMistakeTimer == 0)
                    {
                        currentDigimon.careMistakes++;
                    }
                }

                // countdown until a care mistake is reached
                if (currentDigimon.hurtCareMistakeTimer > -1)
                {
                    currentDigimon.hurtCareMistakeTimer--;

                    if (currentDigimon.hurtCareMistakeTimer == 0)
                    {
                        currentDigimon.careMistakes++;
                    }
                }

                // used to keep digimon awake within sleeping time if woken up
                if (currentDigimon.secondsUntilSleep > 0)
                {
                    currentDigimon.secondsUntilSleep--;
                }


                // Evolution timer continues only when digimon is awake
                if (currentDigimon.canDigivolve && !currentDigimon.isAsleep)
                {
                    currentDigimon.evolveTime--;
                }


                // Digivolve only when on mainscreen
                if (!animate.isEvolving && !animate.IsinAnimation)
                {
                    if (CurrentScreen == MenuScreen.MainScreen && currentDigimon.evolveTime < 1 && currentDigimon.canDigivolve)
                    {
                        animate.StopDigimonStateAnimation();
                        currentDigimon.Digivolve();
                    }
                }

                // Hunger depletes only when digimon is awake
                if (!currentDigimon.isAsleep && !isEgg)
                {
                    if (currentDigimon.currentHunger > -1)
                    {
                        currentDigimon.currentHunger--;
                    }

                    // if hunger reaches 0, care mistake timer is activated
                    if (currentDigimon.hungerCareMistakeTimer == -1 && currentDigimon.currentHunger == 0)
                    {
                        currentDigimon.hungerCareMistakeTimer = 600;
                        pixelScreen.TurnOnNotificationIcon();
                        if (CurrentScreen == MenuScreen.MainScreen)
                        {
                            Sounds.PlaySound(Sound.Step);
                        }
                    }
                    if (currentDigimon.currentStrength > -1 && !isEgg)
                    {
                        currentDigimon.currentStrength--;
                    }
                }

                // reset selected menu after 10 seconds if on main screen
                if (CurrentScreen == MenuScreen.MainScreen && SelectedMenu != MenuScreen.MainScreen)
                {
                    TimeoutSelectedMenu++;
                    if (TimeoutSelectedMenu == 10)
                    {
                        pixelScreen.TurnOffAllIcons();
                        SelectedMenu = MenuScreen.MainScreen;
                        TimeoutSelectedMenu = 0;
                    }
                }

                // Go back to mainscreen after 10 seconds if inactive
                else if (CurrentScreen == MenuScreen.FeedScreen || CurrentScreen == MenuScreen.StatScreen)
                {
                    TimeoutMenuScreen++;
                    if (TimeoutMenuScreen == 10)
                    {
                        pixelScreen.TurnOffAllIcons();
                        resetMainScreen();
                        SelectedMenu = MenuScreen.MainScreen;
                    }
                }

                // Light up call out icon while the digimon needs attention before a caremistake is obtained
                if (!currentDigimon.IsActiveCareMistakeTimer())
                {
                    pixelScreen.TurnOffNotificationIcon();
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
                    TimeoutMenuScreen = 0;
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
                    TimeoutMenuScreen = 0;
                    if (SelectedSubMenuNo == 1)
                    {
                        SelectedSubMenuNo--;
                    }
                    else
                    {
                        SelectedSubMenuNo++;
                    }
                    MenuScreens.DrawFeedScreen(this, SelectedSubMenuNo);
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
                else if (CurrentScreen == MenuScreen.Lights && CurrentSubMenu == 0)
                {
                    Sounds.PlaySound(Sound.Beep);
                    TimeoutMenuScreen = 0;
                    if (SelectedSubMenuNo == 1)
                    {
                        SelectedSubMenuNo--;
                    }
                    else
                    {
                        SelectedSubMenuNo++;
                    }
                    MenuScreens.DrawLightsScreen(this, SelectedSubMenuNo);
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
                        animate.StopDigimonStateAnimation();
                        CurrentScreen = MenuScreen.StatScreen;
                        MenuScreens.DrawStats(this, SelectedSubMenuNo);
                        SelectedSubMenuNo++;
                    }
                    else if (SelectedMenu == MenuScreen.FeedScreen)
                    {
                        if (currentDigimon.isInBed)
                        {
                            Sounds.PlaySound(Sound.Beep2);
                        }
                        else if (currentDigimon.isHurt)
                        {
                            Sounds.PlaySound(Sound.Beep);
                            animate.StopDigimonStateAnimation();
                            animate.SetupRejectAnimation();
                        }
                        else
                        {
                            Sounds.PlaySound(Sound.Beep);
                            animate.StopDigimonStateAnimation();
                            CurrentScreen = MenuScreen.FeedScreen;
                            MenuScreens.DrawFeedScreen(this, 0);
                        }
                    }
                    else if (SelectedMenu == MenuScreen.Training)
                    {
                        if (currentDigimon.isInBed)
                        {
                            Sounds.PlaySound(Sound.Beep2);
                        }
                        else if (currentDigimon.isHurt)
                        {
                            Sounds.PlaySound(Sound.Beep);
                            animate.StopDigimonStateAnimation();
                            animate.SetupRejectAnimation();
                        }
                        else
                        {
                            currentDigimon.WakeupDigimon();
                            animate.StopDigimonStateAnimation();
                            Sounds.PlaySound(Sound.Beep);
                            CurrentScreen = MenuScreen.Training;
                            animate.SetupTraining();
                        }
                        
                    }
                    else if (SelectedMenu == MenuScreen.BattleCup)
                    {
                        if (currentDigimon.isInBed)
                        {
                            Sounds.PlaySound(Sound.Beep2);
                        }
                        else if (currentDigimon.isHurt)
                        {
                            Sounds.PlaySound(Sound.Beep);
                            animate.StopDigimonStateAnimation();
                            animate.SetupRejectAnimation();
                        }
                        else
                        {
                            currentDigimon.WakeupDigimon(); // Move this where the battlecup screen select will start ####
                            animate.StopDigimonStateAnimation();
                            Sounds.PlaySound(Sound.Beep);
                            CurrentScreen = MenuScreen.BattleCup;
                            animate.SetupBattleCup();
                        }
                       
                    }
                    else if (SelectedMenu == MenuScreen.Lights)
                    {
                        Sounds.PlaySound(Sound.Beep);
                        animate.StopDigimonStateAnimation();
                        CurrentScreen = MenuScreen.Lights;
                        MenuScreens.DrawLightsScreen(this, 0);
                    }

                    else if (SelectedMenu == MenuScreen.Flush && !animate.IsinAnimation)
                    {
                        if (numberOfDung == 0 || currentDigimon.isAsleep)
                        {
                            Sounds.PlaySound(Sound.Beep2);
                        }
                        else
                        {
                            //setup dung flush animation
                            Sounds.PlaySound(Sound.Beep);
                            CurrentScreen = MenuScreen.Flush;
                            animate.StopDigimonStateAnimation();
                            animate.SetupFlushAnimation();
                        }
                    }

                    else if (SelectedMenu == MenuScreen.Medical)
                    {
                        Sounds.PlaySound(Sound.Beep);
                        if (currentDigimon.isAsleep)
                        {
                            Sounds.PlaySound(Sound.Beep2);
                        }
                        else if (currentDigimon.isHurt)
                        {
                            CurrentScreen = MenuScreen.Medical;
                            currentDigimon.HealDigimon();
                            animate.StopDigimonStateAnimation();
                            animate.SetupAngry();
                        }
                        else
                        {
                            CurrentScreen = MenuScreen.Medical;
                            animate.StopDigimonStateAnimation();
                            animate.SetupRejectAnimation();
                        }
                    }
                }
                else if (CurrentScreen == MenuScreen.StatScreen)
                {
                    // Goes through the different screen in stats
                    TimeoutMenuScreen = 0;
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
                    TimeoutMenuScreen = 0;
                    if (CurrentSubMenu == 1)
                    {
                        if (animate.animation == AnimationNo.Eat)
                        {
                            Sounds.PlaySound(Sound.Beep);
                            MenuScreens.DrawFeedScreen(this, SelectedSubMenuNo);
                            CurrentSubMenu = 0;
                            animate.ResetAnimations();
                        }
                    }

                    else
                    {
                        Sounds.PlaySound(Sound.Beep);
                        currentDigimon.WakeupDigimon();

                        // Deactivate hunger care mistake timer
                        if (SelectedSubMenuNo == 0)
                        {
                            currentDigimon.hungerCareMistakeTimer = -1;
                        }
                        animate.SetupEatAnimation(SelectedSubMenuNo);
                        CurrentSubMenu = 1;
                    }
                }

                else if (CurrentScreen == MenuScreen.Lights)
                {
                    if (SelectedSubMenuNo == 0)
                    {
                        if (currentDigimon.isAsleep)
                        {
                            currentDigimon.WakeupDigimon();
                        }

                        resetMainScreen();
                    }

                    else
                    {
                        if (currentDigimon.isAsleep)
                        {
                            currentDigimon.isInBed = true;
                            if (currentDigimon.sleepCareMistakeTimer > -1)
                            {
                                currentDigimon.sleepCareMistakeTimer = -1;
                            }
                            resetMainScreen();
                        }
                        else
                        {
                            currentDigimon.isAsleep = true;
                            currentDigimon.isInBed = true;
                            currentDigimon.forcedSleepTimer = 10800;
                            resetMainScreen();
                        }
                    }
                }

                else if (CurrentScreen == MenuScreen.Training)
                {
                    // stuff when already in training screen
                }

                else if (CurrentScreen == MenuScreen.EggSelection)
                {
                    Sounds.PlaySound(Sound.Beep);
                    isEgg = true;
                    currentDigimon = new Digimon(this, DigimonId.V1Egg);
                    resetMainScreen();
                }
            }
        }

        public void CButtonPress()
        {
            if (!animate.isEvolving && animate.animation != AnimationNo.Happy && animate.animation != AnimationNo.Angry && animate.animation != AnimationNo.Flush && CurrentScreen != MenuScreen.EggSelection)
            {
                if (CurrentScreen != MenuScreen.MainScreen)
                {
                    Sounds.PlaySound(Sound.Beep);
                    resetMainScreen();

                }
                else if (CurrentScreen == MenuScreen.MainScreen && SelectedMenu != MenuScreen.MainScreen)
                {
                    // Deselected menu item on main screen
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
            TimeoutMenuScreen = 0;
            animate.ResetAnimations();
        }

    }
}
