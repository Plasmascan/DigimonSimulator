using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DigimonSimulator
{
    public enum DigimonId
    {
        Egg,
        Botamon,
        Betamon,
        Greymon
    }
    public class Digimon
    {
        public DigimonGame game;
        public DigimonId digimonID;
        public DigimonSprite sprite;
        public int currentHunger = 5;
        public int currentStrength = 300;
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
        public int secondsUntilSleep = 20;
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
                careMistakes++;
                sleepCareMistakeTimer = -1;
            }
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
                default:
                    this.sprite = SpriteImages.Botamon();
                    this.digimonID = DigimonId.Botamon;
                    maxHealth = 500;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 100;
                    canDigivolve = true;
                    dungTimeInterval = 100;
                    sleepTime  = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Egg:
                    Debug.WriteLine("Egg");
                    break;

                case DigimonId.Botamon:
                    this.sprite = SpriteImages.Botamon();
                    this.digimonID = DigimonId.Botamon;
                    maxHealth = 500;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 100;
                    canDigivolve = true;
                    dungTimeInterval = 100;
                    sleepTime = DateTime.Parse("11:00:00 PM");
                    break;

                case DigimonId.Betamon:
                    this.sprite = SpriteImages.Betamon();
                    this.digimonID = DigimonId.Betamon;
                    maxHealth = 800;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 200;
                    evolveTime = 9;
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
            }
        }

        public void Digivolve()
        {
            Digimon evolveDigimon;
            switch (digimonID)
            {
                case DigimonId.Egg:
                    break;

                case DigimonId.Botamon:
                    break;

                case DigimonId.Betamon:
                    evolveDigimon = new Digimon(game, DigimonId.Greymon);
                    game.animate.setupDigivolve(evolveDigimon);
                    // call digivolv animation
                    break;
            }

        }
    }

}
