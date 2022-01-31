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
        Numemon
    }
    public class Digimon
    {
        public DigimonGame game;
        public DigimonId digimonID;
        public DigimonSprite sprite;
        public int currentHunger = 5;
        public int currentStrength = 5;
        public int currenthealth = 1000;
        public int careMistakes = 0;
        public int injuries = 0;
        public int totalTimeAlive;
        public bool canDigivolve;
        public int evolveTime;
        public int maxHunger;
        public int maxStrength;
        public int maxHealth;
        public int hitDamage;
        public int dungTimeInterval;
        public int sleepCareMistakeTimer = -1;
        public int hurtCareMistakeTimer = -1;
        public int hungerCareMistakeTimer = -1;
        public int dungCareMistakeTimer = -1;
        public int forcedSleepTimer = -1;
        public int dungTimer = 10;
        public DateTime sleepTime;
        public int secondsUntilSleep = 600;
        public bool isAsleep = false;
        public bool isInBed = false;
        public bool isHurt = false;

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

        public void HurtDigimon()
        {
            isHurt = true;
            hurtCareMistakeTimer = 600;
        }

        public void HealDigimon()
        {
            isHurt = false;
            hurtCareMistakeTimer = -1;
        }

        public void DigimonFallAsleep()
        {
            isAsleep = true;
            sleepCareMistakeTimer = 600;
        }

        public bool IsActiveCareMistakeTimer()
        {
            if (sleepCareMistakeTimer == -1 && hurtCareMistakeTimer == -1 && dungCareMistakeTimer == -1 && hungerCareMistakeTimer == -1)
            {
                return false;
            }
            else
            {
                return true;
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
                    evolveTime = 3600*4;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Betamon:
                    this.sprite = SpriteImages.Betamon();
                    this.digimonID = DigimonId.Betamon;
                    maxHealth = 800;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 200;
                    evolveTime = 15;
                    canDigivolve = true;
                    dungTimeInterval = 3600;
                    sleepTime = DateTime.Parse("10:00:00 PM");
                    break;

                case DigimonId.Agumon:
                    this.sprite = SpriteImages.Agumon();
                    this.digimonID = DigimonId.Agumon;
                    maxHealth = 800;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 200;
                    evolveTime = 10000;
                    canDigivolve = false;
                    dungTimeInterval = 3600;
                    sleepTime = DateTime.Parse("10:00:00 PM");
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
                    sleepTime = DateTime.Parse("12:00:00 AM");
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
                    sleepTime = DateTime.Parse("12:00:00 AM");
                    break;
            }
        }

        public void Digivolve()
        {
            Digimon evolveDigimon;
            switch (digimonID)
            {
                case DigimonId.V1Egg:
                    evolveDigimon = new Digimon(game, DigimonId.Botamon);
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.Botamon:
                    evolveDigimon = new Digimon(game, DigimonId.Koromon);
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.Koromon:
                    evolveDigimon = new Digimon(game, DigimonId.Agumon);
                    game.animate.setupDigivolve(evolveDigimon);
                    break;

                case DigimonId.Betamon:
                    evolveDigimon = new Digimon(game, DigimonId.Greymon);
                    game.animate.setupDigivolve(evolveDigimon);
                    break;
            }

            careMistakes = 0;
            injuries = 0;
        }
    }

}
