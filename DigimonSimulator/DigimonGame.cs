using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Text;
using System.Windows;
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
        MultiplayerOptions multiplayerOptionsWindow;
        public bool isMultiplayerOptionsOpen = false;
        public DateTime setTime;
        public bool isEgg = false;
        public bool isHost = true;
        public string connectIP = "124.180.83.106";
        public int hostPort = 13453;
        public int connectPort = 13453;

        public void InitializeGame(Canvas screen)
        {
            pixelScreen = new PixelScreen(screen, 0, 20, 16, 32, 4);
            pixelScreen.SetupScreen();
            animate = new Animations(this);
            setTime = DateTime.Now;
            LoadGame();
            setTimer();
        }

        public void LoadGame()
        {
            bool isLoaded = SaveLoad.DeserializeSaveData(this);

            if (isLoaded)
            {
                ResetMainScreen();
                if (currentDigimon.IsActiveCareMistakeTimer())
                {
                    pixelScreen.TurnOnNotificationIcon();
                    Sounds.PlaySound(Sound.Notify);
                }
            }
            else
            {
                SelectEgg();
            }
            
        }

        public void SelectEgg()
        {
            setTime = DateTime.Now;
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
                currentDigimon.totalTimeAlive++;
                setTime = setTime.AddSeconds(1);

                if (currentDigimon.forcedSleepTimer > -1)
                {
                    currentDigimon.forcedSleepTimer--;
                }

                // Digimon goes to toilet
                if (!currentDigimon.isAsleep && currentDigimon.numberOfDung != 4 && !animate.IsinAnimation && !currentDigimon.isHurt && !isEgg)
                {
                    currentDigimon.dungTimer--;
                    if (currentDigimon.dungTimer == 0)
                    {
                        currentDigimon.numberOfDung++;
                        currentDigimon.dungTimer = currentDigimon.dungTimeInterval;

                        // Digimon gets injured if 4 dungs are on screen

                        if (currentDigimon.numberOfDung == 4)
                        {
                            currentDigimon.HurtDigimon();
                            if (currentDigimon == null)
                            {
                                return;
                            }
                        }

                        if (CurrentScreen == MenuScreen.MainScreen && !animate.isEvolving)
                        {
                            ResetMainScreen();
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
                        Sounds.PlaySound(Sound.Notify);
                        animate.ResetAnimations();
                        animate.StartDigimonStateAnimation();
                    }
                }

                // automatically wake digimon up at 7am if the digimon hasn't been forced to sleep
                else if (!currentDigimon.IsWithinSleepingTime() && currentDigimon.isAsleep && currentDigimon.forcedSleepTimer == -1)
                {
                    currentDigimon.WakeupDigimon();
                    if (CurrentScreen == MenuScreen.MainScreen)
                    {
                        ResetMainScreen();
                    }
                }

                // countdown until a care mistake is reached
                if (currentDigimon.sleepCareMistakeTimer > -1)
                {
                    currentDigimon.sleepCareMistakeTimer--;
                    if (currentDigimon.sleepCareMistakeTimer == 0)
                    {
                        currentDigimon.AddCareMistake();
                        if (currentDigimon == null)
                        {
                            return;
                        }
                    }
                }

                // countdown until a care mistake is reached
                if (currentDigimon.hungerCareMistakeTimer > -1 && !isEgg)
                {
                    currentDigimon.hungerCareMistakeTimer--;
                    if (currentDigimon.hungerCareMistakeTimer == 3600*6 - 600)
                    {
                        currentDigimon.AddCareMistake();
                        if (currentDigimon == null)
                        {
                            return;
                        }
                    }
                    else if (currentDigimon.hungerCareMistakeTimer == 0)
                    {
                        currentDigimon.KillDigimon();
                        return;
                    }
                }

                // countdown until a care mistake is reached
                if (currentDigimon.strengthCareMistakeTimer > -1 && !isEgg)
                {
                    currentDigimon.strengthCareMistakeTimer--;
                    if (currentDigimon.strengthCareMistakeTimer == 3600 * 6 - 600)
                    {
                        currentDigimon.AddCareMistake();
                        if (currentDigimon == null)
                        {
                            return;
                        }
                    }
                    else if (currentDigimon.strengthCareMistakeTimer == 0)
                    {
                        currentDigimon.KillDigimon();
                        return;
                    }
                }

                // countdown until a care mistake is reached
                if (currentDigimon.hurtCareMistakeTimer > -1)
                {
                    currentDigimon.hurtCareMistakeTimer--;

                    if (currentDigimon.hurtCareMistakeTimer == 3600 * 6 - 600)
                    {
                        currentDigimon.AddCareMistake();
                        if (currentDigimon == null)
                        {
                            return;
                        }
                    }
                    else if (currentDigimon.hurtCareMistakeTimer == 0)
                    {
                        currentDigimon.KillDigimon();
                        return;
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

                // Hunger and strength depletes only when digimon is awake
                if (!currentDigimon.isAsleep && !isEgg)
                {
                    if (currentDigimon.currentHunger > -1)
                    {
                        currentDigimon.currentHunger--;

                        // Allow digimon to be overfed if the amount of hunger hearts has gone back down atleast 3 hearts
                        if (currentDigimon.currentHunger < currentDigimon.maxHunger / 4 * 3)
                        {
                            currentDigimon.isOverfeedable = true;
                        }
                    }

                    if (currentDigimon.currentStrength > -1)
                    {
                        currentDigimon.currentStrength--;
                    }

                    // if hunger reaches 0, care mistake timer is activated
                    if (currentDigimon.hungerCareMistakeTimer == -1 && currentDigimon.currentHunger == 0)
                    {
                        currentDigimon.hungerCareMistakeTimer = 3600 * 6;
                        pixelScreen.TurnOnNotificationIcon();
                        if (CurrentScreen == MenuScreen.MainScreen)
                        {
                            Sounds.PlaySound(Sound.Notify);
                        }
                    }

                    // if strength reaches 0, care mistake timer is activated
                    if (currentDigimon.strengthCareMistakeTimer == -1 && currentDigimon.currentStrength == 0)
                    {
                        currentDigimon.strengthCareMistakeTimer = 3600 * 6;
                        pixelScreen.TurnOnNotificationIcon();
                        if (CurrentScreen == MenuScreen.MainScreen)
                        {
                            Sounds.PlaySound(Sound.Notify);
                        }
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
                        ResetMainScreen();
                        SelectedMenu = MenuScreen.MainScreen;
                    }
                }

                

                // Light up call out icon while the digimon needs attention before a caremistake is obtained
                if (!currentDigimon.IsActiveCareMistakeTimer())
                {
                    pixelScreen.TurnOffNotificationIcon();
                }

                // Save game every minute
                if (setTime.Second % 60 == 0 && !isEgg)
                {
                    _gameTimer.Stop();
                    SaveLoad.SerializeSaveData(this);
                    _gameTimer.Start();
                    Debug.WriteLine("Saved");
                }
            }
        }

        public void AButtonPress()
        {
            if (!animate.isEvolving && animate.animation != AnimationNo.Reject)
            {
                if (CurrentScreen == MenuScreen.MainScreen && !isEgg)
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
                    if (SelectedSubMenuNo < 4)
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
                else if (CurrentScreen == MenuScreen.Training || CurrentScreen == MenuScreen.Battle || CurrentScreen == MenuScreen.BattleCup)
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
            if (!animate.isEvolving && animate.animation != AnimationNo.Reject)
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
                        if (currentDigimon.numberOfDung == 0 || currentDigimon.isAsleep)
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
                            currentDigimon.WakeupDigimon();
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

                    else if (SelectedMenu == MenuScreen.Battle)
                    {
                        if (isMultiplayerOptionsOpen)
                        {
                            multiplayerOptionsWindow.Focus();
                        }
                        else if (currentDigimon.isInBed)
                        {
                            Sounds.PlaySound(Sound.Beep2);
                        }
                        else if (currentDigimon.isHurt || animate.battleLogic.isPendingCancel)
                        {
                            Sounds.PlaySound(Sound.Beep);
                            animate.StopDigimonStateAnimation();
                            animate.SetupRejectAnimation();
                        }
                        else
                        {
                            if (connectIP == string.Empty)
                            {
                                OpenMultiplayerOptions();
                            }
                            else
                            {
                                currentDigimon.WakeupDigimon();
                                animate.StopDigimonStateAnimation();
                                Sounds.PlaySound(Sound.Beep);
                                CurrentScreen = MenuScreen.Battle;
                                animate.SetupConnect();
                            }
                        }

                    }
                }
                else if (CurrentScreen == MenuScreen.StatScreen)
                {
                    // Goes through the different screen in stats
                    TimeoutMenuScreen = 0;
                    Sounds.PlaySound(Sound.Beep);
                    MenuScreens.DrawStats(this, SelectedSubMenuNo);

                    if (SelectedSubMenuNo < 4)
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
                        currentDigimon.AddWeight();

                        // Deactivate hunger or strength care mistake timer
                        if (SelectedSubMenuNo == 0)
                        {
                            currentDigimon.hungerCareMistakeTimer = -1;
                        }
                        else
                        {
                            currentDigimon.strengthCareMistakeTimer = -1;
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

                        ResetMainScreen();
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
                            ResetMainScreen();
                        }
                        else
                        {
                            currentDigimon.isAsleep = true;
                            currentDigimon.isInBed = true;
                            currentDigimon.forcedSleepTimer = 10800;
                            ResetMainScreen();
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
                    ResetMainScreen();
                }
                else if (CurrentScreen == MenuScreen.DeathScreen)
                {
                    SelectEgg();
                }
            }
        }

        public void CButtonPress()
        {
            if (!animate.isEvolving && animate.animation != AnimationNo.Happy && animate.animation != AnimationNo.Angry && animate.animation != AnimationNo.Reject
                && animate.animation != AnimationNo.Flush && animate.animation != AnimationNo.Victory && animate.animation != AnimationNo.Defeat
                && CurrentScreen != MenuScreen.EggSelection && CurrentScreen != MenuScreen.DeathScreen)
            {
                if (CurrentScreen != MenuScreen.MainScreen)
                {
                    Sounds.PlaySound(Sound.Beep);
                    ResetMainScreen();
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

        public void ResetMainScreen()
        {
            MenuScreens.MainScreen(this);
            CurrentScreen = MenuScreen.MainScreen;
            SelectedSubMenuNo = 0;
            CurrentSubMenu = 0;
            TimeoutSelectedMenu = 0;
            TimeoutMenuScreen = 0;
            animate.ResetAnimations();

            if (animate.battleLogic.isConnecting)
            {
                animate.battleLogic.isPendingCancel = true;
            }

            if (animate.battleLogic.isHostActive)
            {
                animate.battleLogic.isHostActive = false;
                animate.battleLogic.CloseTCPConnections();
                animate.battleLogic.battleFound = false;
            }
        }

        public void OpenMultiplayerOptions()
        {
            if (!isMultiplayerOptionsOpen)
            {
                isMultiplayerOptionsOpen = true;
                multiplayerOptionsWindow = new MultiplayerOptions(this);
                multiplayerOptionsWindow.Show();
            }
            else
            {
                multiplayerOptionsWindow.Focus();
            }
           
        }

    }
}
