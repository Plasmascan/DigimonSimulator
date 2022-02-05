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
        public DigimonId digimonID;
        public DigimonSprite sprite;
        public int currentHunger = 1;
        public int currentStrength = 1;
        public int currenthealth = 1000;
        public int currentWeight = 0;
        public int careMistakes = 0;
        public int timesInjured = 0;
        public int timesTrained = 0;
        public int timesOverfed = 0;
        public int totalTimeAlive;
        public bool canDigivolve;
        public int evolveTime;
        public int maxHunger;
        public int maxStrength;
        public int maxHealth;
        public int minWeight;
        public int hitDamage;
        public int dungTimeInterval;
        public int sleepCareMistakeTimer = -1;
        public int hurtCareMistakeTimer = -1;
        public int hungerCareMistakeTimer = -1;
        public int strengthCareMistakeTimer = -1;
        public int forcedSleepTimer = -1;
        public int dungTimer = 10;
        public DateTime sleepTime;
        public int secondsUntilSleep = 600;
        public bool isAsleep = false;
        public bool isInBed = false;
        public bool isHurt = false;
        public bool isOverfeedable = true;

        public Digimon(DigimonGame game, DigimonId digimonID)
        {
            this.game = game;
            SetupDigimon(digimonID);
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
            switch (digimonID)
            {
                case DigimonId.V1Egg:
                    this.sprite = SpriteImages.V1Egg();
                    this.digimonID = DigimonId.V1Egg;
                    canDigivolve = true;
                    evolveTime = 5;
                    break;

                case DigimonId.Botamon:
                    this.sprite = SpriteImages.Botamon();
                    this.digimonID = DigimonId.Botamon;
                    maxHealth = 300;
                    maxHunger = 200;
                    maxStrength = 200;
                    hitDamage = 100;
                    canDigivolve = true;
                    dungTimeInterval = 100;
                    evolveTime = 600;
                    minWeight = 5;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Koromon:
                    this.sprite = SpriteImages.Koromon();
                    this.digimonID = DigimonId.Koromon;
                    maxHealth = 500;
                    maxHunger = 400;
                    maxStrength = 400;
                    hitDamage = 200;
                    canDigivolve = true;
                    dungTimeInterval = 600;
                    evolveTime = 3600*6;
                    minWeight = 10;
                    sleepTime = DateTime.Parse("9:00:00 PM");
                    break;

                case DigimonId.Betamon:
                    this.sprite = SpriteImages.Betamon();
                    this.digimonID = DigimonId.Betamon;
                    maxHealth = 800;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 200;
                    evolveTime = 3600 * 24;
                    canDigivolve = true;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("10:00:00 PM");
                    break;

                case DigimonId.Agumon:
                    this.sprite = SpriteImages.Agumon();
                    this.digimonID = DigimonId.Agumon;
                    maxHealth = 800;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 200;
                    evolveTime = 3600 * 24;
                    canDigivolve = true;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("9:00:00 PM");
                    break;

                case DigimonId.Greymon:
                    this.sprite = SpriteImages.Greymon();
                    this.digimonID = DigimonId.Greymon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 30;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Devimon:
                    this.sprite = SpriteImages.Devimon();
                    this.digimonID = DigimonId.Devimon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 40;
                    sleepTime = DateTime.Parse("12:00:00 AM");
                    break;

                case DigimonId.Seadramon:
                    this.sprite = SpriteImages.Seadramon();
                    this.digimonID = DigimonId.Seadramon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Airdramon:
                    this.sprite = SpriteImages.Airdramon();
                    this.digimonID = DigimonId.Airdramon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 20;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Numemon:
                    this.sprite = SpriteImages.Numemon();
                    this.digimonID = DigimonId.Numemon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 10;
                    sleepTime = DateTime.Parse("9:00:00 PM");
                    break;

                case DigimonId.Meramon:
                    this.sprite = SpriteImages.Meramon();
                    this.digimonID = DigimonId.Meramon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 30;
                    sleepTime = DateTime.Parse("10:00:00 PM");
                    break;

                case DigimonId.MetalGreymon:
                    this.sprite = SpriteImages.MetalGreymon();
                    this.digimonID = DigimonId.MetalGreymon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 40;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.BlitzGreymon:
                    this.sprite = SpriteImages.BlitzGreymon();
                    this.digimonID = DigimonId.BlitzGreymon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    minWeight = 50;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Tyrannomon:
                    this.sprite = SpriteImages.Tyrannomon();
                    this.digimonID = DigimonId.Tyrannomon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
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

            // Ensure that current weight isn't lower than the new digimons minimum weight
            if (currentWeight < evolveDigimon.minWeight)
            {
                currentWeight = evolveDigimon.minWeight;
            }

        }
    }

}
