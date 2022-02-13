using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DigimonSimulator
{
    public enum DigimonId
    {
        V1Egg,
        Botamon,
        Koromon,
        Betamon,
        Agumon,
        Greymon,
        Devimon,
        Seadramon,
        Airdramon,
        Numemon,
        Meramon,
        MetalGreymon,
        BlitzGreymon,
        Tyrannomon
    }
    public class Digimon
    {
        public DigimonGame game;
        public DigimonSprite sprite;
        public DigimonId digimonID { get; set; }
        public int currentHunger { get; set; }
        public int currentStrength { get; set; }
        public int currenthealth { get; set; }
        public int currentWeight { get; set; }
        public int careMistakes { get; set; }
        public int timesInjured { get; set; }
        public int timesTrained { get; set; }
        public int timesOverfed { get; set; }
        public int totalTimeAlive { get; set; }
        public int totalVictories { get; set; }
        public int totalLoses { get; set; }
        public int digivolveChanceFromBattles { get; set; }
        public bool canDigivolve { get; set; }
        public int evolveTime { get; set; }
        public int maxHunger { get; set; }
        public int maxStrength { get; set; }
        public int maxHealth { get; set; }
        public int minWeight { get; set; }
        public int baseHitDamage { get; set; }
        public int dungTimeInterval { get; set; }
        public int numberOfDung { get; set; }
        public int sleepCareMistakeTimer { get; set; }
        public int hurtCareMistakeTimer { get; set; }
        public int hungerCareMistakeTimer { get; set; }
        public int strengthCareMistakeTimer { get; set; }
        public int forcedSleepTimer { get; set; }
        public int dungTimer { get; set; }
        public DateTime sleepTime { get; set; }
        public int secondsUntilSleep { get; set; }
        public bool isAsleep { get; set; }
        public bool isInBed { get; set; }
        public bool isHurt { get; set; }
        public bool isOverfeedable { get; set; }

        public Digimon()
        {

        }
        public Digimon(DigimonGame game, DigimonId digimonID)
        {
            this.game = game;
            SetupDigimon(digimonID);
            currentHunger = 1;
            currentStrength = 1;
            currenthealth = 1000;
            sleepCareMistakeTimer = -1;
            hurtCareMistakeTimer = -1;
            hungerCareMistakeTimer = -1;
            strengthCareMistakeTimer = -1;
            forcedSleepTimer = -1;
            dungTimer = 10;
            secondsUntilSleep = 600;
        }

        public void WakeupDigimon()
        {
            secondsUntilSleep = 600;
            isAsleep = false;
            isInBed = false;
            if (sleepCareMistakeTimer > -1)
            {
                sleepCareMistakeTimer = -1;
            }
        }

        public void AddBattleResult(bool isVictory)
        {
            if (isVictory)
            {
                totalVictories++;
                if (digivolveChanceFromBattles < 100)
                {
                    digivolveChanceFromBattles += 8;
                }
            }
            else
            {
                totalLoses++;
                if (digivolveChanceFromBattles > 0)
                {
                    digivolveChanceFromBattles -= 8;
                }
            }
        }

        public void LoseWeight(int amount)
        {
            if (currentWeight - amount < minWeight)
            {
                currentWeight = minWeight;
            }
            else
            {
                currentWeight -= amount;
            }
        }

        public void AddWeight()
        {
            if (currentWeight < 99)
            {
                currentWeight++;
            }
        }

        public void AddStrength()
        {
            if (currentStrength < maxStrength)
            {
                currentStrength += maxStrength / 4;
            }
            if (strengthCareMistakeTimer > -1)
            {
                strengthCareMistakeTimer = -1;
            }
        }

        public void AddCareMistake()
        {
            careMistakes++;
            if (careMistakes == 20)
            {
                KillDigimon();
            }
        }

        public void HurtDigimon()
        {
            timesInjured++;
            isHurt = true;
            game.pixelScreen.TurnOnNotificationIcon();
            Sounds.PlaySound(Sound.Notify);
            hurtCareMistakeTimer = 3600 * 6;
            if (timesInjured == 20)
            {
                KillDigimon();
            }
        }

        public void HealDigimon()
        {
            isHurt = false;
            hurtCareMistakeTimer = -1;
        }

        public void KillDigimon()
        {
            MenuScreens.DrawDeathScreen(game);
            game.currentDigimon = null;
            game.CurrentScreen = MenuScreen.DeathScreen;
            numberOfDung = 0;
        }

        public void DigimonFallAsleep()
        {
            isAsleep = true;
            sleepCareMistakeTimer = 600;
        }

        public bool IsActiveCareMistakeTimer()
        {
            if (sleepCareMistakeTimer > -1 || hurtCareMistakeTimer > 3600 * 6 - 600 || hungerCareMistakeTimer > 3600 * 6 - 600 || strengthCareMistakeTimer > 3600 * 6 - 600)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetWinPercent()
        {
            if (totalLoses + totalVictories == 0)
            {
                return 0;
            }
            else
            {
                float percent = (float)totalVictories / ((float)totalLoses + (float)totalVictories) * 100;
                return (int)percent;
            }
        }

        public bool IsWithinSleepingTime()
        {
            if (sleepTime.Hour < 7)
            {
                if (game.setTime.Hour < 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (game.setTime.Hour >= 7)
            {
                if (game.setTime.Hour >= sleepTime.Hour)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
            else
            {
                return true;
            }
            
        }

        public void SetupDigimon(DigimonId digimonID)
        {
            if (!Enum.IsDefined(typeof(DigimonId), digimonID))
            {
                throw new Exception();
            }

            switch (digimonID)
            {
                case DigimonId.V1Egg:
                    this.sprite = SpriteMaps.V1Egg();
                    this.digimonID = DigimonId.V1Egg;
                    canDigivolve = true;
                    evolveTime = 5;
                    break;

                case DigimonId.Botamon:
                    this.sprite = SpriteMaps.Botamon();
                    this.digimonID = DigimonId.Botamon;
                    maxHealth = 300;
                    maxHunger = 600;
                    maxStrength = 600;
                    baseHitDamage = 100;
                    canDigivolve = true;
                    dungTimeInterval = 100;
                    evolveTime = 600;
                    minWeight = 5;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Koromon:
                    this.sprite = SpriteMaps.Koromon();
                    this.digimonID = DigimonId.Koromon;
                    maxHealth = 500;
                    maxHunger = 3600;
                    maxStrength = 3600;
                    baseHitDamage = 200;
                    canDigivolve = true;
                    dungTimeInterval = 600;
                    evolveTime = 3600*6;
                    minWeight = 10;
                    sleepTime = DateTime.Parse("9:00:00 PM");
                    break;

                case DigimonId.Betamon:
                    this.sprite = SpriteMaps.Betamon();
                    this.digimonID = DigimonId.Betamon;
                    maxHealth = 800;
                    maxHunger = 6000;
                    maxStrength = 6000;
                    baseHitDamage = 200;
                    evolveTime = 3600 * 24;
                    canDigivolve = true;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("10:00:00 PM");
                    break;

                case DigimonId.Agumon:
                    this.sprite = SpriteMaps.Agumon();
                    this.digimonID = DigimonId.Agumon;
                    maxHealth = 800;
                    maxHunger = 6000;
                    maxStrength = 6000;
                    baseHitDamage = 200;
                    evolveTime = 3600 * 24;
                    canDigivolve = true;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("9:00:00 PM");
                    break;

                case DigimonId.Greymon:
                    this.sprite = SpriteMaps.Greymon();
                    this.digimonID = DigimonId.Greymon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 30;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Devimon:
                    this.sprite = SpriteMaps.Devimon();
                    this.digimonID = DigimonId.Devimon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 40;
                    sleepTime = DateTime.Parse("12:00:00 AM");
                    break;

                case DigimonId.Seadramon:
                    this.sprite = SpriteMaps.Seadramon();
                    this.digimonID = DigimonId.Seadramon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Airdramon:
                    this.sprite = SpriteMaps.Airdramon();
                    this.digimonID = DigimonId.Airdramon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Numemon:
                    this.sprite = SpriteMaps.Numemon();
                    this.digimonID = DigimonId.Numemon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 10;
                    sleepTime = DateTime.Parse("9:00:00 PM");
                    break;

                case DigimonId.Meramon:
                    this.sprite = SpriteMaps.Meramon();
                    this.digimonID = DigimonId.Meramon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 30;
                    sleepTime = DateTime.Parse("10:00:00 PM");
                    break;

                case DigimonId.MetalGreymon:
                    this.sprite = SpriteMaps.MetalGreymon();
                    this.digimonID = DigimonId.MetalGreymon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 40;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.BlitzGreymon:
                    this.sprite = SpriteMaps.BlitzGreymon();
                    this.digimonID = DigimonId.BlitzGreymon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 50;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Tyrannomon:
                    this.sprite = SpriteMaps.Tyrannomon();
                    this.digimonID = DigimonId.Tyrannomon;
                    maxHealth = 1000;
                    maxHunger = 3600 * 2;
                    maxStrength = 3600 * 2;
                    baseHitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;
            }
        }

        public void Digivolve()
        {
            Digimon evolveDigimon;
            switch (digimonID)
            {
                default:
                    evolveDigimon = new Digimon(game, DigimonId.Botamon);
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.V1Egg:
                    evolveDigimon = new Digimon(game, DigimonId.Botamon);
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.Botamon:
                    evolveDigimon = new Digimon(game, DigimonId.Koromon);
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.Koromon:
                    if (careMistakes >= 3)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Betamon);
                    }
                    else
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Agumon);
                    }
                    
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.Betamon:
                    if (careMistakes <= 2 && timesTrained >= 16)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Devimon);
                    }
                    else if (careMistakes >= 3 && timesOverfed <= 2 && timesTrained >= 8 && timesTrained <= 15)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Airdramon);
                    }
                    else if (careMistakes <= 2 && timesTrained <= 15)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Meramon);
                    }
                    else if (careMistakes >= 3 && timesOverfed >= 3 && timesTrained >= 8 && timesTrained <= 15)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Seadramon);
                    }
                    else
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Numemon);
                    }
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.Agumon:
                    if (careMistakes <= 2 && timesTrained >= 16)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Greymon);
                    }
                    else if (careMistakes <= 2 && timesTrained <= 15)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Devimon);
                    }
                    else if (careMistakes >= 3 && timesTrained >= 5 && timesTrained <= 15 && timesOverfed >= 3)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Tyrannomon);
                    }
                    else if (careMistakes >= 3 && timesTrained >= 16 && timesOverfed >= 3)
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Meramon);
                    }
                    else
                    {
                        evolveDigimon = new Digimon(game, DigimonId.Numemon);
                    }
                    game.animate.setupDigivolve(evolveDigimon);
                    break;
            }

            // Properties to reset after digivolving
            careMistakes = 0;
            timesInjured = 0;
            timesTrained = 0;
            timesOverfed = 0;
            totalLoses = 0;
            totalVictories = 0;
            digivolveChanceFromBattles = 0;

            // Ensure that current weight isn't lower than the new digimons minimum weight
            if (currentWeight < evolveDigimon.minWeight)
            {
                currentWeight = evolveDigimon.minWeight;
            }

        }
    }

}
