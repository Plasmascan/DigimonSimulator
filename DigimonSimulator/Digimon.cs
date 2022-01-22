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
        public int currentHunger = 700;
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

        public Digimon(DigimonGame game, DigimonId digimonID)
        {
            this.game = game;
            SetupDigimon(digimonID);
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
                    break;

                case DigimonId.Betamon:
                    this.sprite = SpriteImages.Betamon();
                    this.digimonID = DigimonId.Betamon;
                    maxHealth = 800;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 200;
                    evolveTime = 6;
                    canDigivolve = true;
                    break;

                case DigimonId.Greymon:
                    this.sprite = SpriteImages.Greymon();
                    this.digimonID = DigimonId.Greymon;
                    maxHealth = 1000;
                    maxHunger = 1000;
                    maxStrength = 1000;
                    hitDamage = 300;
                    canDigivolve = false;
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
