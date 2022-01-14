﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DigimonSimulator
{
    public enum SpriteFrame
    {
        Walk,
        Walk2,
        Happy
        
    }
    public class Sprite
    {
        public int SpriteX;
        public int SpriteY;
        public int SpriteHeight;
        public int SpriteWidth;
        public bool[,] sprite;
    }

    public class DigimonSprite
    {
        public int SpriteX;
        public int SpriteY;
        public int currentSpriteHeight;
        public int frame1Height;
        public int frame1Width;
        public int frame2Height;
        public int frame2Width;
        public int happyFrameHeight;
        public int happyFrameWidth;
        public int currentHunger = 1000;
        public int currentStrength = 1000;
        public int maxHunger = 1000;
        public int maxStrength = 1000;
        public bool[,] frame1;
        public bool[,] frame2;
        public bool[,] happyFrame;
        // to do - add max hunger and strength to the setup functions
    }

    public static class SpriteImages
    {
        public static Sprite HungerSprite()
        {
            Sprite hungerSprite = new Sprite();
            hungerSprite.SpriteHeight = 8;
            hungerSprite.SpriteWidth = 24;
            hungerSprite.sprite = new bool[hungerSprite.SpriteHeight, hungerSprite.SpriteWidth];

            #region hungerSprite.sprite
            hungerSprite.sprite[0, 0] = true;
            hungerSprite.sprite[0, 3] = true;
            hungerSprite.sprite[1, 0] = true;
            hungerSprite.sprite[1, 3] = true;
            hungerSprite.sprite[2, 0] = true;
            hungerSprite.sprite[2, 3] = true;
            hungerSprite.sprite[2, 5] = true;
            hungerSprite.sprite[2, 7] = true;
            hungerSprite.sprite[2, 9] = true;
            hungerSprite.sprite[2, 10] = true;
            hungerSprite.sprite[2, 11] = true;
            hungerSprite.sprite[2, 13] = true;
            hungerSprite.sprite[2, 14] = true;
            hungerSprite.sprite[2, 15] = true;
            hungerSprite.sprite[2, 17] = true;
            hungerSprite.sprite[2, 19] = true;
            hungerSprite.sprite[2, 21] = true;
            hungerSprite.sprite[2, 23] = true;
            hungerSprite.sprite[3, 0] = true;
            hungerSprite.sprite[3, 1] = true;
            hungerSprite.sprite[3, 2] = true;
            hungerSprite.sprite[3, 3] = true;
            hungerSprite.sprite[3, 5] = true;
            hungerSprite.sprite[3, 7] = true;
            hungerSprite.sprite[3, 9] = true;
            hungerSprite.sprite[3, 11] = true;
            hungerSprite.sprite[3, 13] = true;
            hungerSprite.sprite[3, 15] = true;
            hungerSprite.sprite[3, 17] = true;
            hungerSprite.sprite[3, 18] = true;
            hungerSprite.sprite[3, 21] = true;
            hungerSprite.sprite[3, 23] = true;
            hungerSprite.sprite[4, 0] = true;
            hungerSprite.sprite[4, 3] = true;
            hungerSprite.sprite[4, 5] = true;
            hungerSprite.sprite[4, 7] = true;
            hungerSprite.sprite[4, 9] = true;
            hungerSprite.sprite[4, 11] = true;
            hungerSprite.sprite[4, 13] = true;
            hungerSprite.sprite[4, 15] = true;
            hungerSprite.sprite[4, 17] = true;
            hungerSprite.sprite[4, 21] = true;
            hungerSprite.sprite[4, 23] = true;
            hungerSprite.sprite[5, 0] = true;
            hungerSprite.sprite[5, 3] = true;
            hungerSprite.sprite[5, 5] = true;
            hungerSprite.sprite[5, 7] = true;
            hungerSprite.sprite[5, 9] = true;
            hungerSprite.sprite[5, 11] = true;
            hungerSprite.sprite[5, 13] = true;
            hungerSprite.sprite[5, 14] = true;
            hungerSprite.sprite[5, 15] = true;
            hungerSprite.sprite[5, 17] = true;
            hungerSprite.sprite[5, 22] = true;
            hungerSprite.sprite[5, 23] = true;
            hungerSprite.sprite[6, 0] = true;
            hungerSprite.sprite[6, 3] = true;
            hungerSprite.sprite[6, 5] = true;
            hungerSprite.sprite[6, 6] = true;
            hungerSprite.sprite[6, 7] = true;
            hungerSprite.sprite[6, 9] = true;
            hungerSprite.sprite[6, 11] = true;
            hungerSprite.sprite[6, 15] = true;
            hungerSprite.sprite[6, 17] = true;
            hungerSprite.sprite[6, 23] = true;
            hungerSprite.sprite[7, 13] = true;
            hungerSprite.sprite[7, 14] = true;
            hungerSprite.sprite[7, 15] = true;
            hungerSprite.sprite[7, 21] = true;
            hungerSprite.sprite[7, 22] = true;
            #endregion

            return hungerSprite;
        }

        public static Sprite StrengthSprite()
        {
            Sprite strengthSprite = new Sprite();
            strengthSprite.SpriteHeight = 8;
            strengthSprite.SpriteWidth = 32;
            strengthSprite.sprite = new bool[strengthSprite.SpriteHeight, strengthSprite.SpriteWidth];

            #region StrengthSprite
            strengthSprite.sprite[0, 1] = true;
            strengthSprite.sprite[0, 2] = true;
            strengthSprite.sprite[0, 29] = true;
            strengthSprite.sprite[1, 0] = true;
            strengthSprite.sprite[1, 3] = true;
            strengthSprite.sprite[1, 6] = true;
            strengthSprite.sprite[1, 26] = true;
            strengthSprite.sprite[1, 29] = true;
            strengthSprite.sprite[2, 0] = true;
            strengthSprite.sprite[2, 5] = true;
            strengthSprite.sprite[2, 6] = true;
            strengthSprite.sprite[2, 7] = true;
            strengthSprite.sprite[2, 9] = true;
            strengthSprite.sprite[2, 11] = true;
            strengthSprite.sprite[2, 13] = true;
            strengthSprite.sprite[2, 14] = true;
            strengthSprite.sprite[2, 15] = true;
            strengthSprite.sprite[2, 17] = true;
            strengthSprite.sprite[2, 18] = true;
            strengthSprite.sprite[2, 19] = true;
            strengthSprite.sprite[2, 21] = true;
            strengthSprite.sprite[2, 22] = true;
            strengthSprite.sprite[2, 23] = true;
            strengthSprite.sprite[2, 25] = true;
            strengthSprite.sprite[2, 26] = true;
            strengthSprite.sprite[2, 27] = true;
            strengthSprite.sprite[2, 29] = true;
            strengthSprite.sprite[2, 30] = true;
            strengthSprite.sprite[2, 31] = true;
            strengthSprite.sprite[3, 1] = true;
            strengthSprite.sprite[3, 2] = true;
            strengthSprite.sprite[3, 6] = true;
            strengthSprite.sprite[3, 9] = true;
            strengthSprite.sprite[3, 10] = true;
            strengthSprite.sprite[3, 13] = true;
            strengthSprite.sprite[3, 15] = true;
            strengthSprite.sprite[3, 17] = true;
            strengthSprite.sprite[3, 19] = true;
            strengthSprite.sprite[3, 21] = true;
            strengthSprite.sprite[3, 23] = true;
            strengthSprite.sprite[3, 26] = true;
            strengthSprite.sprite[3, 29] = true;
            strengthSprite.sprite[3, 31] = true;
            strengthSprite.sprite[4, 3] = true;
            strengthSprite.sprite[4, 6] = true;
            strengthSprite.sprite[4, 9] = true;
            strengthSprite.sprite[4, 13] = true;
            strengthSprite.sprite[4, 14] = true;
            strengthSprite.sprite[4, 15] = true;
            strengthSprite.sprite[4, 17] = true;
            strengthSprite.sprite[4, 19] = true;
            strengthSprite.sprite[4, 21] = true;
            strengthSprite.sprite[4, 23] = true;
            strengthSprite.sprite[4, 26] = true;
            strengthSprite.sprite[4, 29] = true;
            strengthSprite.sprite[4, 31] = true;
            strengthSprite.sprite[5, 0] = true;
            strengthSprite.sprite[5, 3] = true;
            strengthSprite.sprite[5, 6] = true;
            strengthSprite.sprite[5, 9] = true;
            strengthSprite.sprite[5, 13] = true;
            strengthSprite.sprite[5, 17] = true;
            strengthSprite.sprite[5, 19] = true;
            strengthSprite.sprite[5, 21] = true;
            strengthSprite.sprite[5, 22] = true;
            strengthSprite.sprite[5, 23] = true;
            strengthSprite.sprite[5, 26] = true;
            strengthSprite.sprite[5, 29] = true;
            strengthSprite.sprite[5, 31] = true;
            strengthSprite.sprite[6, 1] = true;
            strengthSprite.sprite[6, 2] = true;
            strengthSprite.sprite[6, 6] = true;
            strengthSprite.sprite[6, 9] = true;
            strengthSprite.sprite[6, 13] = true;
            strengthSprite.sprite[6, 14] = true;
            strengthSprite.sprite[6, 15] = true;
            strengthSprite.sprite[6, 17] = true;
            strengthSprite.sprite[6, 19] = true;
            strengthSprite.sprite[6, 23] = true;
            strengthSprite.sprite[6, 26] = true;
            strengthSprite.sprite[6, 29] = true;
            strengthSprite.sprite[6, 31] = true;
            strengthSprite.sprite[7, 21] = true;
            strengthSprite.sprite[7, 22] = true;
            strengthSprite.sprite[7, 23] = true;
            #endregion

            return strengthSprite;
        }

        public static Sprite FullHeartSprite()
        {
            Sprite fullHeartSprite = new Sprite();
            fullHeartSprite.SpriteHeight = 7;
            fullHeartSprite.SpriteWidth = 7;
            fullHeartSprite.sprite = new bool[fullHeartSprite.SpriteHeight, fullHeartSprite.SpriteWidth];

            #region fullHeart
            fullHeartSprite.sprite[0, 1] = true;
            fullHeartSprite.sprite[0, 2] = true;
            fullHeartSprite.sprite[0, 4] = true;
            fullHeartSprite.sprite[0, 5] = true;
            fullHeartSprite.sprite[1, 0] = true;
            fullHeartSprite.sprite[1, 2] = true;
            fullHeartSprite.sprite[1, 3] = true;
            fullHeartSprite.sprite[1, 4] = true;
            fullHeartSprite.sprite[1, 5] = true;
            fullHeartSprite.sprite[1, 6] = true;
            fullHeartSprite.sprite[2, 0] = true;
            fullHeartSprite.sprite[2, 2] = true;
            fullHeartSprite.sprite[2, 3] = true;
            fullHeartSprite.sprite[2, 4] = true;
            fullHeartSprite.sprite[2, 5] = true;
            fullHeartSprite.sprite[2, 6] = true;
            fullHeartSprite.sprite[3, 0] = true;
            fullHeartSprite.sprite[3, 1] = true;
            fullHeartSprite.sprite[3, 2] = true;
            fullHeartSprite.sprite[3, 3] = true;
            fullHeartSprite.sprite[3, 4] = true;
            fullHeartSprite.sprite[3, 5] = true;
            fullHeartSprite.sprite[3, 6] = true;
            fullHeartSprite.sprite[4, 1] = true;
            fullHeartSprite.sprite[4, 2] = true;
            fullHeartSprite.sprite[4, 3] = true;
            fullHeartSprite.sprite[4, 4] = true;
            fullHeartSprite.sprite[4, 5] = true;
            fullHeartSprite.sprite[5, 2] = true;
            fullHeartSprite.sprite[5, 3] = true;
            fullHeartSprite.sprite[5, 4] = true;
            fullHeartSprite.sprite[6, 3] = true;
            #endregion

            return fullHeartSprite;
        }

        public static Sprite EmptyHeartSprite()
        {
            Sprite emptyHeartSprite = new Sprite();
            emptyHeartSprite.SpriteHeight = 7;
            emptyHeartSprite.SpriteWidth = 7;
            emptyHeartSprite.sprite = new bool[emptyHeartSprite.SpriteHeight, emptyHeartSprite.SpriteWidth];

            #region emptyHeart
            emptyHeartSprite.sprite[0, 1] = true;
            emptyHeartSprite.sprite[0, 2] = true;
            emptyHeartSprite.sprite[0, 4] = true;
            emptyHeartSprite.sprite[0, 5] = true;
            emptyHeartSprite.sprite[1, 0] = true;
            emptyHeartSprite.sprite[1, 3] = true;
            emptyHeartSprite.sprite[1, 6] = true;
            emptyHeartSprite.sprite[2, 0] = true;
            emptyHeartSprite.sprite[2, 6] = true;
            emptyHeartSprite.sprite[3, 0] = true;
            emptyHeartSprite.sprite[3, 6] = true;
            emptyHeartSprite.sprite[4, 1] = true;
            emptyHeartSprite.sprite[4, 5] = true;
            emptyHeartSprite.sprite[5, 2] = true;
            emptyHeartSprite.sprite[5, 4] = true;
            emptyHeartSprite.sprite[6, 3] = true;
            #endregion

            return emptyHeartSprite;
        }

        public static Sprite FullFoodSprite()
        {
            Sprite fullFoodSprite = new Sprite();
            fullFoodSprite.SpriteHeight = 8;
            fullFoodSprite.SpriteWidth = 8;
            fullFoodSprite.sprite = new bool[fullFoodSprite.SpriteHeight, fullFoodSprite.SpriteWidth];

            #region fullFood
            fullFoodSprite.sprite[0, 0] = true;
            fullFoodSprite.sprite[0, 1] = true;
            fullFoodSprite.sprite[1, 0] = true;
            fullFoodSprite.sprite[1, 2] = true;
            fullFoodSprite.sprite[1, 3] = true;
            fullFoodSprite.sprite[1, 4] = true;
            fullFoodSprite.sprite[2, 1] = true;
            fullFoodSprite.sprite[2, 3] = true;
            fullFoodSprite.sprite[2, 5] = true;
            fullFoodSprite.sprite[3, 1] = true;
            fullFoodSprite.sprite[3, 2] = true;
            fullFoodSprite.sprite[3, 3] = true;
            fullFoodSprite.sprite[3, 4] = true;
            fullFoodSprite.sprite[3, 6] = true;
            fullFoodSprite.sprite[4, 1] = true;
            fullFoodSprite.sprite[4, 2] = true;
            fullFoodSprite.sprite[4, 3] = true;
            fullFoodSprite.sprite[4, 4] = true;
            fullFoodSprite.sprite[4, 5] = true;
            fullFoodSprite.sprite[4, 6] = true;
            fullFoodSprite.sprite[5, 2] = true;
            fullFoodSprite.sprite[5, 3] = true;
            fullFoodSprite.sprite[5, 4] = true;
            fullFoodSprite.sprite[5, 5] = true;
            fullFoodSprite.sprite[5, 6] = true;
            fullFoodSprite.sprite[6, 3] = true;
            fullFoodSprite.sprite[6, 4] = true;
            fullFoodSprite.sprite[6, 5] = true;
            fullFoodSprite.sprite[6, 7] = true;
            fullFoodSprite.sprite[7, 6] = true;
            fullFoodSprite.sprite[7, 7] = true;
            #endregion

            return fullFoodSprite;
        }

        public static Sprite HalfFoodSprite()
        {
            Sprite halfFoodSprite = new Sprite();
            halfFoodSprite.SpriteHeight = 8;
            halfFoodSprite.SpriteWidth = 8;
            halfFoodSprite.sprite = new bool[halfFoodSprite.SpriteHeight, halfFoodSprite.SpriteWidth];

            #region halfFood
            halfFoodSprite.sprite[0, 0] = true;
            halfFoodSprite.sprite[0, 1] = true;
            halfFoodSprite.sprite[1, 0] = true;
            halfFoodSprite.sprite[1, 2] = true;
            halfFoodSprite.sprite[1, 3] = true;
            halfFoodSprite.sprite[2, 1] = true;
            halfFoodSprite.sprite[2, 2] = true;
            halfFoodSprite.sprite[2, 3] = true;
            halfFoodSprite.sprite[2, 4] = true;
            halfFoodSprite.sprite[3, 1] = true;
            halfFoodSprite.sprite[3, 2] = true;
            halfFoodSprite.sprite[3, 4] = true;
            halfFoodSprite.sprite[4, 2] = true;
            halfFoodSprite.sprite[4, 3] = true;
            halfFoodSprite.sprite[4, 5] = true;
            halfFoodSprite.sprite[5, 4] = true;
            halfFoodSprite.sprite[5, 6] = true;
            halfFoodSprite.sprite[6, 5] = true;
            halfFoodSprite.sprite[6, 7] = true;
            halfFoodSprite.sprite[7, 6] = true;
            halfFoodSprite.sprite[7, 7] = true;
            #endregion

            return halfFoodSprite;
        }

        public static Sprite EmptyFoodSprite()
        {
            Sprite EmptyFoodSprite = new Sprite();
            EmptyFoodSprite.SpriteHeight = 8;
            EmptyFoodSprite.SpriteWidth = 8;
            EmptyFoodSprite.sprite = new bool[EmptyFoodSprite.SpriteHeight, EmptyFoodSprite.SpriteWidth];

            #region EmptyFoodSprite
            EmptyFoodSprite.sprite[0, 0] = true;
            EmptyFoodSprite.sprite[0, 1] = true;
            EmptyFoodSprite.sprite[1, 0] = true;
            EmptyFoodSprite.sprite[1, 2] = true;
            EmptyFoodSprite.sprite[2, 1] = true;
            EmptyFoodSprite.sprite[2, 3] = true;
            EmptyFoodSprite.sprite[3, 2] = true;
            EmptyFoodSprite.sprite[3, 4] = true;
            EmptyFoodSprite.sprite[4, 3] = true;
            EmptyFoodSprite.sprite[4, 5] = true;
            EmptyFoodSprite.sprite[5, 4] = true;
            EmptyFoodSprite.sprite[5, 6] = true;
            EmptyFoodSprite.sprite[6, 5] = true;
            EmptyFoodSprite.sprite[6, 7] = true;
            EmptyFoodSprite.sprite[7, 6] = true;
            EmptyFoodSprite.sprite[7, 7] = true;
            #endregion

            return EmptyFoodSprite;
        }

        public static Sprite FullVitaminSprite()
        {
            Sprite fullVitaminSprite = new Sprite();
            fullVitaminSprite.SpriteHeight = 8;
            fullVitaminSprite.SpriteWidth = 8;
            fullVitaminSprite.sprite = new bool[fullVitaminSprite.SpriteHeight, fullVitaminSprite.SpriteWidth];

            #region fullVitamin
            fullVitaminSprite.sprite[0, 4] = true;
            fullVitaminSprite.sprite[0, 5] = true;
            fullVitaminSprite.sprite[0, 6] = true;
            fullVitaminSprite.sprite[1, 3] = true;
            fullVitaminSprite.sprite[1, 6] = true;
            fullVitaminSprite.sprite[1, 7] = true;
            fullVitaminSprite.sprite[2, 2] = true;
            fullVitaminSprite.sprite[2, 4] = true;
            fullVitaminSprite.sprite[2, 5] = true;
            fullVitaminSprite.sprite[2, 6] = true;
            fullVitaminSprite.sprite[2, 7] = true;
            fullVitaminSprite.sprite[3, 1] = true;
            fullVitaminSprite.sprite[3, 3] = true;
            fullVitaminSprite.sprite[3, 4] = true;
            fullVitaminSprite.sprite[3, 5] = true;
            fullVitaminSprite.sprite[3, 6] = true;
            fullVitaminSprite.sprite[3, 7] = true;
            fullVitaminSprite.sprite[4, 0] = true;
            fullVitaminSprite.sprite[4, 4] = true;
            fullVitaminSprite.sprite[4, 5] = true;
            fullVitaminSprite.sprite[4, 6] = true;
            fullVitaminSprite.sprite[5, 0] = true;
            fullVitaminSprite.sprite[5, 5] = true;
            fullVitaminSprite.sprite[6, 0] = true;
            fullVitaminSprite.sprite[6, 4] = true;
            fullVitaminSprite.sprite[7, 1] = true;
            fullVitaminSprite.sprite[7, 2] = true;
            fullVitaminSprite.sprite[7, 3] = true;
            #endregion

            return fullVitaminSprite;
        }

        public static Sprite HalfVitaminSprite()
        {
            Sprite halfVitaminSprite = new Sprite();
            halfVitaminSprite.SpriteHeight = 5;
            halfVitaminSprite.SpriteWidth = 5;
            halfVitaminSprite.sprite = new bool[halfVitaminSprite.SpriteHeight, halfVitaminSprite.SpriteWidth];

            #region halfVitamin
            halfVitaminSprite.sprite[0, 1] = true;
            halfVitaminSprite.sprite[0, 2] = true;
            halfVitaminSprite.sprite[1, 0] = true;
            halfVitaminSprite.sprite[1, 1] = true;
            halfVitaminSprite.sprite[1, 3] = true;
            halfVitaminSprite.sprite[2, 0] = true;
            halfVitaminSprite.sprite[2, 2] = true;
            halfVitaminSprite.sprite[2, 4] = true;
            halfVitaminSprite.sprite[3, 0] = true;
            halfVitaminSprite.sprite[3, 3] = true;
            halfVitaminSprite.sprite[3, 4] = true;
            halfVitaminSprite.sprite[4, 1] = true;
            halfVitaminSprite.sprite[4, 2] = true;
            halfVitaminSprite.sprite[4, 3] = true;
            #endregion

            return halfVitaminSprite;
        }

        public static Sprite EmptyVitaminSprite()
        {
            Sprite EmptyVitaminSprite = new Sprite();
            EmptyVitaminSprite.SpriteHeight = 0;
            EmptyVitaminSprite.SpriteWidth = 0;
            EmptyVitaminSprite.sprite = new bool[EmptyVitaminSprite.SpriteHeight, EmptyVitaminSprite.SpriteWidth];

            #region EmptyVitaminSprite

            #endregion

            return EmptyVitaminSprite;
        }

        public static Sprite ArrowSprite()
        {
            Sprite arrowSprite = new Sprite();
            arrowSprite.SpriteHeight = 7;
            arrowSprite.SpriteWidth = 6;
            arrowSprite.sprite = new bool[arrowSprite.SpriteHeight, arrowSprite.SpriteWidth];

            #region arrow
            arrowSprite.sprite[0, 2] = true;
            arrowSprite.sprite[1, 2] = true;
            arrowSprite.sprite[1, 3] = true;
            arrowSprite.sprite[2, 0] = true;
            arrowSprite.sprite[2, 1] = true;
            arrowSprite.sprite[2, 2] = true;
            arrowSprite.sprite[2, 3] = true;
            arrowSprite.sprite[2, 4] = true;
            arrowSprite.sprite[3, 0] = true;
            arrowSprite.sprite[3, 1] = true;
            arrowSprite.sprite[3, 2] = true;
            arrowSprite.sprite[3, 3] = true;
            arrowSprite.sprite[3, 4] = true;
            arrowSprite.sprite[3, 5] = true;
            arrowSprite.sprite[4, 0] = true;
            arrowSprite.sprite[4, 1] = true;
            arrowSprite.sprite[4, 2] = true;
            arrowSprite.sprite[4, 3] = true;
            arrowSprite.sprite[4, 4] = true;
            arrowSprite.sprite[5, 2] = true;
            arrowSprite.sprite[5, 3] = true;
            arrowSprite.sprite[6, 2] = true;
            #endregion

            return arrowSprite;
        }

        public static DigimonSprite Elecmon()
        {
            DigimonSprite elecmon = new DigimonSprite();
            elecmon.currentSpriteHeight = 12;
            elecmon.frame1Height = 12;
            elecmon.frame1Width = 16;
            elecmon.frame2Height = 10;
            elecmon.frame2Width = 16;
            elecmon.happyFrameHeight = 16;
            elecmon.happyFrameWidth = 16;

            elecmon.frame1 = new bool[elecmon.frame1Height, elecmon.frame1Width];
            elecmon.frame2 = new bool[elecmon.frame2Height, elecmon.frame2Width];
            elecmon.happyFrame = new bool[elecmon.happyFrameHeight, elecmon.happyFrameWidth];

            #region elecmon frames
            //frame 1
            elecmon.frame1[0, 1] = true;
            elecmon.frame1[0, 2] = true;
            elecmon.frame1[0, 9] = true;
            elecmon.frame1[0, 10] = true;
            elecmon.frame1[1, 1] = true;
            elecmon.frame1[1, 3] = true;
            elecmon.frame1[1, 8] = true;
            elecmon.frame1[1, 10] = true;
            elecmon.frame1[1, 13] = true;
            elecmon.frame1[2, 2] = true;
            elecmon.frame1[2, 4] = true;
            elecmon.frame1[2, 7] = true;
            elecmon.frame1[2, 9] = true;
            elecmon.frame1[2, 12] = true;
            elecmon.frame1[2, 13] = true;
            elecmon.frame1[3, 2] = true;
            elecmon.frame1[3, 5] = true;
            elecmon.frame1[3, 6] = true;
            elecmon.frame1[3, 9] = true;
            elecmon.frame1[3, 11] = true;
            elecmon.frame1[3, 13] = true;
            elecmon.frame1[3, 15] = true;
            elecmon.frame1[4, 3] = true;
            elecmon.frame1[4, 4] = true;
            elecmon.frame1[4, 6] = true;
            elecmon.frame1[4, 8] = true;
            elecmon.frame1[4, 9] = true;
            elecmon.frame1[4, 10] = true;
            elecmon.frame1[4, 11] = true;
            elecmon.frame1[4, 13] = true;
            elecmon.frame1[4, 14] = true;
            elecmon.frame1[4, 15] = true;
            elecmon.frame1[5, 2] = true;
            elecmon.frame1[5, 9] = true;
            elecmon.frame1[5, 10] = true;
            elecmon.frame1[5, 11] = true;
            elecmon.frame1[5, 12] = true;
            elecmon.frame1[5, 13] = true;
            elecmon.frame1[5, 15] = true;
            elecmon.frame1[6, 1] = true;
            elecmon.frame1[6, 3] = true;
            elecmon.frame1[6, 6] = true;
            elecmon.frame1[6, 11] = true;
            elecmon.frame1[6, 12] = true;
            elecmon.frame1[6, 13] = true;
            elecmon.frame1[6, 15] = true;
            elecmon.frame1[7, 1] = true;
            elecmon.frame1[7, 3] = true;
            elecmon.frame1[7, 6] = true;
            elecmon.frame1[7, 13] = true;
            elecmon.frame1[7, 14] = true;
            elecmon.frame1[8, 1] = true;
            elecmon.frame1[8, 14] = true;
            elecmon.frame1[9, 1] = true;
            elecmon.frame1[9, 10] = true;
            elecmon.frame1[9, 12] = true;
            elecmon.frame1[9, 15] = true;
            elecmon.frame1[10, 0] = true;
            elecmon.frame1[10, 2] = true;
            elecmon.frame1[10, 3] = true;
            elecmon.frame1[10, 4] = true;
            elecmon.frame1[10, 5] = true;
            elecmon.frame1[10, 6] = true;
            elecmon.frame1[10, 9] = true;
            elecmon.frame1[10, 10] = true;
            elecmon.frame1[10, 11] = true;
            elecmon.frame1[10, 15] = true;
            elecmon.frame1[11, 0] = true;
            elecmon.frame1[11, 1] = true;
            elecmon.frame1[11, 2] = true;
            elecmon.frame1[11, 3] = true;
            elecmon.frame1[11, 6] = true;
            elecmon.frame1[11, 7] = true;
            elecmon.frame1[11, 8] = true;
            elecmon.frame1[11, 9] = true;
            elecmon.frame1[11, 11] = true;
            elecmon.frame1[11, 12] = true;
            elecmon.frame1[11, 13] = true;
            elecmon.frame1[11, 14] = true;
            
            //Frame 2
            elecmon.frame2[0, 0] = true;
            elecmon.frame2[0, 1] = true;
            elecmon.frame2[0, 2] = true;
            elecmon.frame2[0, 10] = true;
            elecmon.frame2[0, 11] = true;
            elecmon.frame2[0, 13] = true;
            elecmon.frame2[1, 1] = true;
            elecmon.frame2[1, 3] = true;
            elecmon.frame2[1, 4] = true;
            elecmon.frame2[1, 8] = true;
            elecmon.frame2[1, 9] = true;
            elecmon.frame2[1, 11] = true;
            elecmon.frame2[1, 12] = true;
            elecmon.frame2[1, 13] = true;
            elecmon.frame2[2, 2] = true;
            elecmon.frame2[2, 5] = true;
            elecmon.frame2[2, 6] = true;
            elecmon.frame2[2, 7] = true;
            elecmon.frame2[2, 10] = true;
            elecmon.frame2[2, 11] = true;
            elecmon.frame2[2, 13] = true;
            elecmon.frame2[2, 15] = true;
            elecmon.frame2[3, 2] = true;
            elecmon.frame2[3, 3] = true;
            elecmon.frame2[3, 4] = true;
            elecmon.frame2[3, 6] = true;
            elecmon.frame2[3, 8] = true;
            elecmon.frame2[3, 9] = true;
            elecmon.frame2[3, 10] = true;
            elecmon.frame2[3, 11] = true;
            elecmon.frame2[3, 13] = true;
            elecmon.frame2[3, 14] = true;
            elecmon.frame2[3, 15] = true;
            elecmon.frame2[4, 2] = true;
            elecmon.frame2[4, 9] = true;
            elecmon.frame2[4, 10] = true;
            elecmon.frame2[4, 11] = true;
            elecmon.frame2[4, 12] = true;
            elecmon.frame2[4, 13] = true;
            elecmon.frame2[4, 15] = true;
            elecmon.frame2[5, 1] = true;
            elecmon.frame2[5, 3] = true;
            elecmon.frame2[5, 6] = true;
            elecmon.frame2[5, 11] = true;
            elecmon.frame2[5, 12] = true;
            elecmon.frame2[5, 13] = true;
            elecmon.frame2[5, 15] = true;
            elecmon.frame2[6, 1] = true;
            elecmon.frame2[6, 3] = true;
            elecmon.frame2[6, 6] = true;
            elecmon.frame2[6, 13] = true;
            elecmon.frame2[6, 14] = true;
            elecmon.frame2[7, 1] = true;
            elecmon.frame2[7, 15] = true;
            elecmon.frame2[8, 0] = true;
            elecmon.frame2[8, 1] = true;
            elecmon.frame2[8, 6] = true;
            elecmon.frame2[8, 10] = true;
            elecmon.frame2[8, 11] = true;
            elecmon.frame2[8, 15] = true;
            elecmon.frame2[9, 0] = true;
            elecmon.frame2[9, 1] = true;
            elecmon.frame2[9, 2] = true;
            elecmon.frame2[9, 3] = true;
            elecmon.frame2[9, 4] = true;
            elecmon.frame2[9, 5] = true;
            elecmon.frame2[9, 6] = true;
            elecmon.frame2[9, 7] = true;
            elecmon.frame2[9, 8] = true;
            elecmon.frame2[9, 9] = true;
            elecmon.frame2[9, 10] = true;
            elecmon.frame2[9, 11] = true;
            elecmon.frame2[9, 12] = true;
            elecmon.frame2[9, 13] = true;
            elecmon.frame2[9, 14] = true;
            elecmon.frame2[9, 15] = true;

            //happy frame
            elecmon.happyFrame[0, 2] = true;
            elecmon.happyFrame[0, 9] = true;
            elecmon.happyFrame[1, 2] = true;
            elecmon.happyFrame[1, 3] = true;
            elecmon.happyFrame[1, 8] = true;
            elecmon.happyFrame[1, 9] = true;
            elecmon.happyFrame[2, 2] = true;
            elecmon.happyFrame[2, 4] = true;
            elecmon.happyFrame[2, 7] = true;
            elecmon.happyFrame[2, 9] = true;
            elecmon.happyFrame[2, 13] = true;
            elecmon.happyFrame[3, 2] = true;
            elecmon.happyFrame[3, 4] = true;
            elecmon.happyFrame[3, 7] = true;
            elecmon.happyFrame[3, 9] = true;
            elecmon.happyFrame[3, 12] = true;
            elecmon.happyFrame[3, 13] = true;
            elecmon.happyFrame[4, 2] = true;
            elecmon.happyFrame[4, 3] = true;
            elecmon.happyFrame[4, 4] = true;
            elecmon.happyFrame[4, 5] = true;
            elecmon.happyFrame[4, 6] = true;
            elecmon.happyFrame[4, 9] = true;
            elecmon.happyFrame[4, 11] = true;
            elecmon.happyFrame[4, 13] = true;
            elecmon.happyFrame[5, 2] = true;
            elecmon.happyFrame[5, 10] = true;
            elecmon.happyFrame[5, 13] = true;
            elecmon.happyFrame[6, 1] = true;
            elecmon.happyFrame[6, 2] = true;
            elecmon.happyFrame[6, 3] = true;
            elecmon.happyFrame[6, 6] = true;
            elecmon.happyFrame[6, 7] = true;
            elecmon.happyFrame[6, 10] = true;
            elecmon.happyFrame[6, 12] = true;
            elecmon.happyFrame[6, 15] = true;
            elecmon.happyFrame[7, 1] = true;
            elecmon.happyFrame[7, 11] = true;
            elecmon.happyFrame[7, 12] = true;
            elecmon.happyFrame[7, 14] = true;
            elecmon.happyFrame[7, 15] = true;
            elecmon.happyFrame[8, 1] = true;
            elecmon.happyFrame[8, 2] = true;
            elecmon.happyFrame[8, 3] = true;
            elecmon.happyFrame[8, 4] = true;
            elecmon.happyFrame[8, 5] = true;
            elecmon.happyFrame[8, 6] = true;
            elecmon.happyFrame[8, 7] = true;
            elecmon.happyFrame[8, 12] = true;
            elecmon.happyFrame[8, 13] = true;
            elecmon.happyFrame[8, 15] = true;
            elecmon.happyFrame[9, 2] = true;
            elecmon.happyFrame[9, 4] = true;
            elecmon.happyFrame[9, 5] = true;
            elecmon.happyFrame[9, 6] = true;
            elecmon.happyFrame[9, 7] = true;
            elecmon.happyFrame[9, 8] = true;
            elecmon.happyFrame[9, 12] = true;
            elecmon.happyFrame[9, 13] = true;
            elecmon.happyFrame[9, 15] = true;
            elecmon.happyFrame[10, 3] = true;
            elecmon.happyFrame[10, 5] = true;
            elecmon.happyFrame[10, 6] = true;
            elecmon.happyFrame[10, 7] = true;
            elecmon.happyFrame[10, 8] = true;
            elecmon.happyFrame[10, 13] = true;
            elecmon.happyFrame[10, 15] = true;
            elecmon.happyFrame[11, 3] = true;
            elecmon.happyFrame[11, 5] = true;
            elecmon.happyFrame[11, 6] = true;
            elecmon.happyFrame[11, 7] = true;
            elecmon.happyFrame[11, 8] = true;
            elecmon.happyFrame[11, 14] = true;
            elecmon.happyFrame[12, 1] = true;
            elecmon.happyFrame[12, 2] = true;
            elecmon.happyFrame[12, 3] = true;
            elecmon.happyFrame[12, 4] = true;
            elecmon.happyFrame[12, 5] = true;
            elecmon.happyFrame[12, 6] = true;
            elecmon.happyFrame[12, 7] = true;
            elecmon.happyFrame[12, 8] = true;
            elecmon.happyFrame[12, 15] = true;
            elecmon.happyFrame[13, 1] = true;
            elecmon.happyFrame[13, 10] = true;
            elecmon.happyFrame[13, 12] = true;
            elecmon.happyFrame[13, 15] = true;
            elecmon.happyFrame[14, 0] = true;
            elecmon.happyFrame[14, 2] = true;
            elecmon.happyFrame[14, 3] = true;
            elecmon.happyFrame[14, 4] = true;
            elecmon.happyFrame[14, 5] = true;
            elecmon.happyFrame[14, 6] = true;
            elecmon.happyFrame[14, 9] = true;
            elecmon.happyFrame[14, 10] = true;
            elecmon.happyFrame[14, 11] = true;
            elecmon.happyFrame[14, 15] = true;
            elecmon.happyFrame[15, 0] = true;
            elecmon.happyFrame[15, 1] = true;
            elecmon.happyFrame[15, 2] = true;
            elecmon.happyFrame[15, 3] = true;
            elecmon.happyFrame[15, 6] = true;
            elecmon.happyFrame[15, 7] = true;
            elecmon.happyFrame[15, 8] = true;
            elecmon.happyFrame[15, 9] = true;
            elecmon.happyFrame[15, 11] = true;
            elecmon.happyFrame[15, 12] = true;
            elecmon.happyFrame[15, 13] = true;
            elecmon.happyFrame[15, 14] = true;
            #endregion

            return elecmon;
        }

        public static DigimonSprite Botamon()
        {
            DigimonSprite botamon = new DigimonSprite();
            botamon.currentSpriteHeight = 6;
            botamon.frame1Height = 6;
            botamon.frame1Width = 8;
            botamon.frame2Height = 5;
            botamon.frame2Width = 8;
            botamon.happyFrameHeight = 8;
            botamon.happyFrameWidth = 6;

            botamon.frame1 = new bool[botamon.frame1Height, botamon.frame1Width];
            botamon.frame2 = new bool[botamon.frame2Height, botamon.frame2Width];
            botamon.happyFrame = new bool[botamon.happyFrameHeight, botamon.happyFrameWidth];

            #region elecmon frames
            //frame 1
            botamon.frame1[0, 2] = true;
            botamon.frame1[0, 5] = true;
            botamon.frame1[1, 1] = true;
            botamon.frame1[1, 2] = true;
            botamon.frame1[1, 3] = true;
            botamon.frame1[1, 4] = true;
            botamon.frame1[1, 5] = true;
            botamon.frame1[1, 6] = true;
            botamon.frame1[2, 1] = true;
            botamon.frame1[2, 3] = true;
            botamon.frame1[2, 4] = true;
            botamon.frame1[2, 6] = true;
            botamon.frame1[3, 1] = true;
            botamon.frame1[3, 2] = true;
            botamon.frame1[3, 3] = true;
            botamon.frame1[3, 4] = true;
            botamon.frame1[3, 5] = true;
            botamon.frame1[3, 6] = true;
            botamon.frame1[4, 1] = true;
            botamon.frame1[4, 2] = true;
            botamon.frame1[4, 5] = true;
            botamon.frame1[4, 6] = true;
            botamon.frame1[5, 0] = true;
            botamon.frame1[5, 1] = true;
            botamon.frame1[5, 2] = true;
            botamon.frame1[5, 3] = true;
            botamon.frame1[5, 4] = true;
            botamon.frame1[5, 5] = true;
            botamon.frame1[5, 6] = true;
            botamon.frame1[5, 7] = true;

            //Frame 2
            botamon.frame2[0, 2] = true;
            botamon.frame2[0, 5] = true;
            botamon.frame2[1, 2] = true;
            botamon.frame2[1, 3] = true;
            botamon.frame2[1, 4] = true;
            botamon.frame2[1, 5] = true;
            botamon.frame2[2, 1] = true;
            botamon.frame2[2, 3] = true;
            botamon.frame2[2, 4] = true;
            botamon.frame2[2, 5] = true;
            botamon.frame2[2, 6] = true;
            botamon.frame2[3, 1] = true;
            botamon.frame2[3, 2] = true;
            botamon.frame2[3, 3] = true;
            botamon.frame2[3, 4] = true;
            botamon.frame2[3, 6] = true;
            botamon.frame2[4, 0] = true;
            botamon.frame2[4, 1] = true;
            botamon.frame2[4, 2] = true;
            botamon.frame2[4, 3] = true;
            botamon.frame2[4, 4] = true;
            botamon.frame2[4, 5] = true;
            botamon.frame2[4, 6] = true;
            botamon.frame2[4, 7] = true;

            //happy frame
            botamon.happyFrame[0, 1] = true;
            botamon.happyFrame[0, 4] = true;
            botamon.happyFrame[1, 1] = true;
            botamon.happyFrame[1, 2] = true;
            botamon.happyFrame[1, 3] = true;
            botamon.happyFrame[1, 4] = true;
            botamon.happyFrame[2, 0] = true;
            botamon.happyFrame[2, 2] = true;
            botamon.happyFrame[2, 3] = true;
            botamon.happyFrame[2, 5] = true;
            botamon.happyFrame[3, 0] = true;
            botamon.happyFrame[3, 1] = true;
            botamon.happyFrame[3, 2] = true;
            botamon.happyFrame[3, 3] = true;
            botamon.happyFrame[3, 4] = true;
            botamon.happyFrame[3, 5] = true;
            botamon.happyFrame[4, 0] = true;
            botamon.happyFrame[4, 1] = true;
            botamon.happyFrame[4, 4] = true;
            botamon.happyFrame[4, 5] = true;
            botamon.happyFrame[5, 0] = true;
            botamon.happyFrame[5, 1] = true;
            botamon.happyFrame[5, 4] = true;
            botamon.happyFrame[5, 5] = true;
            botamon.happyFrame[6, 0] = true;
            botamon.happyFrame[6, 1] = true;
            botamon.happyFrame[6, 2] = true;
            botamon.happyFrame[6, 3] = true;
            botamon.happyFrame[6, 4] = true;
            botamon.happyFrame[6, 5] = true;
            botamon.happyFrame[7, 1] = true;
            botamon.happyFrame[7, 2] = true;
            botamon.happyFrame[7, 3] = true;
            botamon.happyFrame[7, 4] = true;
            #endregion

            return botamon;
        }
    }
}
