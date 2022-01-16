﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DigimonSimulator
{
    public enum SpriteFrame
    {
        Walk,
        Walk2,
        Happy,
        Eat1,
        Eat2,
        Reject,
        Attack,
        Angry
        
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
        public int eat1FrameHeight;
        public int eat1FrameWidth;
        public int eat2FrameHeight;
        public int eat2FrameWidth;
        public int rejectFrameHeight;
        public int rejectFrameWidth;
        public int attackFrameHeight;
        public int attackFrameWidth;
        public int angryFrameHeight;
        public int angryFrameWidth;
        public int currentHunger = 1000;
        public int currentStrength = 1000;
        public int maxHunger = 1000;
        public int maxStrength = 1000;
        public Sprite projectileSprite;
        public bool[,] frame1;
        public bool[,] frame2;
        public bool[,] happyFrame;
        public bool[,] eat1Frame;
        public bool[,] eat2Frame;
        public bool[,] rejectFrame;
        public bool[,] attackFrame;
        public bool[,] angryFrame;
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

        public static Sprite ExplanationMarkSprite()
        {
            Sprite explanationMarkSprite = new Sprite();
            explanationMarkSprite.SpriteHeight = 8;
            explanationMarkSprite.SpriteWidth = 8;
            explanationMarkSprite.sprite = new bool[explanationMarkSprite.SpriteHeight, explanationMarkSprite.SpriteWidth];

            #region explanationMarkSprite
            explanationMarkSprite.sprite[0, 1] = true;
            explanationMarkSprite.sprite[0, 3] = true;
            explanationMarkSprite.sprite[0, 4] = true;
            explanationMarkSprite.sprite[0, 6] = true;
            explanationMarkSprite.sprite[1, 3] = true;
            explanationMarkSprite.sprite[1, 4] = true;
            explanationMarkSprite.sprite[2, 0] = true;
            explanationMarkSprite.sprite[2, 3] = true;
            explanationMarkSprite.sprite[2, 4] = true;
            explanationMarkSprite.sprite[2, 7] = true;
            explanationMarkSprite.sprite[3, 3] = true;
            explanationMarkSprite.sprite[3, 4] = true;
            explanationMarkSprite.sprite[4, 0] = true;
            explanationMarkSprite.sprite[4, 3] = true;
            explanationMarkSprite.sprite[4, 4] = true;
            explanationMarkSprite.sprite[4, 7] = true;
            explanationMarkSprite.sprite[6, 1] = true;
            explanationMarkSprite.sprite[6, 3] = true;
            explanationMarkSprite.sprite[6, 4] = true;
            explanationMarkSprite.sprite[6, 6] = true;
            explanationMarkSprite.sprite[7, 3] = true;
            explanationMarkSprite.sprite[7, 4] = true;
            #endregion

            return explanationMarkSprite;
        }

        public static Sprite ExplosionSmallSprite()
        {
            Sprite explosionSmallSprite = new Sprite();
            explosionSmallSprite.SpriteHeight = 9;
            explosionSmallSprite.SpriteWidth = 9;
            explosionSmallSprite.sprite = new bool[explosionSmallSprite.SpriteHeight, explosionSmallSprite.SpriteWidth];

            #region explosionSmallSprite
            explosionSmallSprite.sprite[0, 3] = true;
            explosionSmallSprite.sprite[1, 3] = true;
            explosionSmallSprite.sprite[1, 4] = true;
            explosionSmallSprite.sprite[2, 3] = true;
            explosionSmallSprite.sprite[2, 4] = true;
            explosionSmallSprite.sprite[2, 5] = true;
            explosionSmallSprite.sprite[3, 2] = true;
            explosionSmallSprite.sprite[3, 3] = true;
            explosionSmallSprite.sprite[3, 5] = true;
            explosionSmallSprite.sprite[3, 6] = true;
            explosionSmallSprite.sprite[3, 7] = true;
            explosionSmallSprite.sprite[4, 0] = true;
            explosionSmallSprite.sprite[4, 1] = true;
            explosionSmallSprite.sprite[4, 2] = true;
            explosionSmallSprite.sprite[4, 6] = true;
            explosionSmallSprite.sprite[4, 7] = true;
            explosionSmallSprite.sprite[4, 8] = true;
            explosionSmallSprite.sprite[5, 1] = true;
            explosionSmallSprite.sprite[5, 2] = true;
            explosionSmallSprite.sprite[5, 3] = true;
            explosionSmallSprite.sprite[5, 5] = true;
            explosionSmallSprite.sprite[5, 6] = true;
            explosionSmallSprite.sprite[6, 2] = true;
            explosionSmallSprite.sprite[6, 3] = true;
            explosionSmallSprite.sprite[6, 4] = true;
            explosionSmallSprite.sprite[6, 5] = true;
            explosionSmallSprite.sprite[7, 3] = true;
            explosionSmallSprite.sprite[7, 4] = true;
            explosionSmallSprite.sprite[8, 4] = true;
            #endregion

            return explosionSmallSprite;
        }

        public static Sprite ExplosionBigSprite()
        {
            Sprite explosionBigSprite = new Sprite();
            explosionBigSprite.SpriteHeight = 16;
            explosionBigSprite.SpriteWidth = 16;
            explosionBigSprite.sprite = new bool[explosionBigSprite.SpriteHeight, explosionBigSprite.SpriteWidth];

            #region explosionBigSprite
            explosionBigSprite.sprite[0, 1] = true;
            explosionBigSprite.sprite[0, 2] = true;
            explosionBigSprite.sprite[0, 9] = true;
            explosionBigSprite.sprite[0, 12] = true;
            explosionBigSprite.sprite[0, 13] = true;
            explosionBigSprite.sprite[1, 1] = true;
            explosionBigSprite.sprite[1, 2] = true;
            explosionBigSprite.sprite[1, 3] = true;
            explosionBigSprite.sprite[1, 4] = true;
            explosionBigSprite.sprite[1, 8] = true;
            explosionBigSprite.sprite[1, 11] = true;
            explosionBigSprite.sprite[1, 12] = true;
            explosionBigSprite.sprite[1, 13] = true;
            explosionBigSprite.sprite[2, 2] = true;
            explosionBigSprite.sprite[2, 4] = true;
            explosionBigSprite.sprite[2, 5] = true;
            explosionBigSprite.sprite[2, 6] = true;
            explosionBigSprite.sprite[2, 9] = true;
            explosionBigSprite.sprite[2, 10] = true;
            explosionBigSprite.sprite[2, 11] = true;
            explosionBigSprite.sprite[2, 13] = true;
            explosionBigSprite.sprite[3, 2] = true;
            explosionBigSprite.sprite[3, 3] = true;
            explosionBigSprite.sprite[3, 5] = true;
            explosionBigSprite.sprite[3, 6] = true;
            explosionBigSprite.sprite[3, 7] = true;
            explosionBigSprite.sprite[3, 8] = true;
            explosionBigSprite.sprite[3, 9] = true;
            explosionBigSprite.sprite[3, 12] = true;
            explosionBigSprite.sprite[4, 0] = true;
            explosionBigSprite.sprite[4, 2] = true;
            explosionBigSprite.sprite[4, 3] = true;
            explosionBigSprite.sprite[4, 7] = true;
            explosionBigSprite.sprite[4, 8] = true;
            explosionBigSprite.sprite[4, 11] = true;
            explosionBigSprite.sprite[4, 12] = true;
            explosionBigSprite.sprite[4, 14] = true;
            explosionBigSprite.sprite[5, 1] = true;
            explosionBigSprite.sprite[5, 3] = true;
            explosionBigSprite.sprite[5, 4] = true;
            explosionBigSprite.sprite[5, 10] = true;
            explosionBigSprite.sprite[5, 11] = true;
            explosionBigSprite.sprite[5, 12] = true;
            explosionBigSprite.sprite[6, 0] = true;
            explosionBigSprite.sprite[6, 1] = true;
            explosionBigSprite.sprite[6, 3] = true;
            explosionBigSprite.sprite[6, 4] = true;
            explosionBigSprite.sprite[6, 9] = true;
            explosionBigSprite.sprite[6, 10] = true;
            explosionBigSprite.sprite[6, 11] = true;
            explosionBigSprite.sprite[6, 12] = true;
            explosionBigSprite.sprite[6, 13] = true;
            explosionBigSprite.sprite[6, 14] = true;
            explosionBigSprite.sprite[6, 15] = true;
            explosionBigSprite.sprite[7, 2] = true;
            explosionBigSprite.sprite[7, 3] = true;
            explosionBigSprite.sprite[7, 5] = true;
            explosionBigSprite.sprite[7, 11] = true;
            explosionBigSprite.sprite[7, 14] = true;
            explosionBigSprite.sprite[8, 1] = true;
            explosionBigSprite.sprite[8, 2] = true;
            explosionBigSprite.sprite[8, 12] = true;
            explosionBigSprite.sprite[8, 13] = true;
            explosionBigSprite.sprite[9, 0] = true;
            explosionBigSprite.sprite[9, 1] = true;
            explosionBigSprite.sprite[9, 2] = true;
            explosionBigSprite.sprite[9, 3] = true;
            explosionBigSprite.sprite[9, 4] = true;
            explosionBigSprite.sprite[9, 10] = true;
            explosionBigSprite.sprite[9, 11] = true;
            explosionBigSprite.sprite[9, 12] = true;
            explosionBigSprite.sprite[10, 4] = true;
            explosionBigSprite.sprite[10, 6] = true;
            explosionBigSprite.sprite[10, 9] = true;
            explosionBigSprite.sprite[10, 10] = true;
            explosionBigSprite.sprite[11, 3] = true;
            explosionBigSprite.sprite[11, 4] = true;
            explosionBigSprite.sprite[11, 5] = true;
            explosionBigSprite.sprite[11, 7] = true;
            explosionBigSprite.sprite[11, 8] = true;
            explosionBigSprite.sprite[11, 10] = true;
            explosionBigSprite.sprite[11, 11] = true;
            explosionBigSprite.sprite[11, 14] = true;
            explosionBigSprite.sprite[12, 1] = true;
            explosionBigSprite.sprite[12, 3] = true;
            explosionBigSprite.sprite[12, 5] = true;
            explosionBigSprite.sprite[12, 6] = true;
            explosionBigSprite.sprite[12, 7] = true;
            explosionBigSprite.sprite[12, 8] = true;
            explosionBigSprite.sprite[12, 9] = true;
            explosionBigSprite.sprite[12, 11] = true;
            explosionBigSprite.sprite[12, 12] = true;
            explosionBigSprite.sprite[13, 1] = true;
            explosionBigSprite.sprite[13, 3] = true;
            explosionBigSprite.sprite[13, 4] = true;
            explosionBigSprite.sprite[13, 5] = true;
            explosionBigSprite.sprite[13, 6] = true;
            explosionBigSprite.sprite[13, 9] = true;
            explosionBigSprite.sprite[13, 10] = true;
            explosionBigSprite.sprite[13, 12] = true;
            explosionBigSprite.sprite[14, 0] = true;
            explosionBigSprite.sprite[14, 2] = true;
            explosionBigSprite.sprite[14, 3] = true;
            explosionBigSprite.sprite[14, 4] = true;
            explosionBigSprite.sprite[14, 11] = true;
            explosionBigSprite.sprite[14, 12] = true;
            explosionBigSprite.sprite[14, 13] = true;
            explosionBigSprite.sprite[15, 2] = true;
            explosionBigSprite.sprite[15, 6] = true;
            explosionBigSprite.sprite[15, 10] = true;
            explosionBigSprite.sprite[15, 13] = true;
            explosionBigSprite.sprite[15, 14] = true;
            #endregion

            return explosionBigSprite;
        }

        public static Sprite FullBrickWallSprite()
        {
            Sprite fullBrickWallSprite = new Sprite();
            fullBrickWallSprite.SpriteHeight = 16;
            fullBrickWallSprite.SpriteWidth = 8;
            fullBrickWallSprite.sprite = new bool[fullBrickWallSprite.SpriteHeight, fullBrickWallSprite.SpriteWidth];

            #region fullBrickWallSprite
            fullBrickWallSprite.sprite[0, 0] = true;
            fullBrickWallSprite.sprite[0, 1] = true;
            fullBrickWallSprite.sprite[0, 2] = true;
            fullBrickWallSprite.sprite[0, 3] = true;
            fullBrickWallSprite.sprite[0, 4] = true;
            fullBrickWallSprite.sprite[0, 5] = true;
            fullBrickWallSprite.sprite[0, 6] = true;
            fullBrickWallSprite.sprite[0, 7] = true;
            fullBrickWallSprite.sprite[1, 0] = true;
            fullBrickWallSprite.sprite[1, 4] = true;
            fullBrickWallSprite.sprite[1, 7] = true;
            fullBrickWallSprite.sprite[2, 0] = true;
            fullBrickWallSprite.sprite[2, 4] = true;
            fullBrickWallSprite.sprite[2, 7] = true;
            fullBrickWallSprite.sprite[3, 0] = true;
            fullBrickWallSprite.sprite[3, 1] = true;
            fullBrickWallSprite.sprite[3, 2] = true;
            fullBrickWallSprite.sprite[3, 3] = true;
            fullBrickWallSprite.sprite[3, 4] = true;
            fullBrickWallSprite.sprite[3, 5] = true;
            fullBrickWallSprite.sprite[3, 6] = true;
            fullBrickWallSprite.sprite[3, 7] = true;
            fullBrickWallSprite.sprite[4, 0] = true;
            fullBrickWallSprite.sprite[4, 2] = true;
            fullBrickWallSprite.sprite[4, 7] = true;
            fullBrickWallSprite.sprite[5, 0] = true;
            fullBrickWallSprite.sprite[5, 2] = true;
            fullBrickWallSprite.sprite[5, 7] = true;
            fullBrickWallSprite.sprite[6, 0] = true;
            fullBrickWallSprite.sprite[6, 1] = true;
            fullBrickWallSprite.sprite[6, 2] = true;
            fullBrickWallSprite.sprite[6, 3] = true;
            fullBrickWallSprite.sprite[6, 4] = true;
            fullBrickWallSprite.sprite[6, 5] = true;
            fullBrickWallSprite.sprite[6, 6] = true;
            fullBrickWallSprite.sprite[6, 7] = true;
            fullBrickWallSprite.sprite[7, 0] = true;
            fullBrickWallSprite.sprite[7, 4] = true;
            fullBrickWallSprite.sprite[7, 7] = true;
            fullBrickWallSprite.sprite[8, 0] = true;
            fullBrickWallSprite.sprite[8, 4] = true;
            fullBrickWallSprite.sprite[8, 7] = true;
            fullBrickWallSprite.sprite[9, 0] = true;
            fullBrickWallSprite.sprite[9, 1] = true;
            fullBrickWallSprite.sprite[9, 2] = true;
            fullBrickWallSprite.sprite[9, 3] = true;
            fullBrickWallSprite.sprite[9, 4] = true;
            fullBrickWallSprite.sprite[9, 5] = true;
            fullBrickWallSprite.sprite[9, 6] = true;
            fullBrickWallSprite.sprite[9, 7] = true;
            fullBrickWallSprite.sprite[10, 0] = true;
            fullBrickWallSprite.sprite[10, 2] = true;
            fullBrickWallSprite.sprite[10, 7] = true;
            fullBrickWallSprite.sprite[11, 0] = true;
            fullBrickWallSprite.sprite[11, 2] = true;
            fullBrickWallSprite.sprite[11, 7] = true;
            fullBrickWallSprite.sprite[12, 0] = true;
            fullBrickWallSprite.sprite[12, 1] = true;
            fullBrickWallSprite.sprite[12, 2] = true;
            fullBrickWallSprite.sprite[12, 3] = true;
            fullBrickWallSprite.sprite[12, 4] = true;
            fullBrickWallSprite.sprite[12, 5] = true;
            fullBrickWallSprite.sprite[12, 6] = true;
            fullBrickWallSprite.sprite[12, 7] = true;
            fullBrickWallSprite.sprite[13, 0] = true;
            fullBrickWallSprite.sprite[13, 4] = true;
            fullBrickWallSprite.sprite[13, 7] = true;
            fullBrickWallSprite.sprite[14, 0] = true;
            fullBrickWallSprite.sprite[14, 4] = true;
            fullBrickWallSprite.sprite[14, 7] = true;
            fullBrickWallSprite.sprite[15, 0] = true;
            fullBrickWallSprite.sprite[15, 1] = true;
            fullBrickWallSprite.sprite[15, 2] = true;
            fullBrickWallSprite.sprite[15, 3] = true;
            fullBrickWallSprite.sprite[15, 4] = true;
            fullBrickWallSprite.sprite[15, 5] = true;
            fullBrickWallSprite.sprite[15, 6] = true;
            fullBrickWallSprite.sprite[15, 7] = true;
            #endregion

            return fullBrickWallSprite;
        }

        public static Sprite BrockenBrickWallSprite()
        {
            Sprite brockenBrickWallSprite = new Sprite();
            brockenBrickWallSprite.SpriteHeight = 2;
            brockenBrickWallSprite.SpriteWidth = 7;
            brockenBrickWallSprite.sprite = new bool[brockenBrickWallSprite.SpriteHeight, brockenBrickWallSprite.SpriteWidth];

            #region brockenBrickWallSprite
            brockenBrickWallSprite.sprite[0, 4] = true;
            brockenBrickWallSprite.sprite[1, 0] = true;
            brockenBrickWallSprite.sprite[1, 3] = true;
            brockenBrickWallSprite.sprite[1, 4] = true;
            brockenBrickWallSprite.sprite[1, 6] = true;
            #endregion

            return brockenBrickWallSprite;
        }

        public static Sprite HalfBrickWallSprite()
        {
            Sprite halfBrickWallSprite = new Sprite();
            halfBrickWallSprite.SpriteHeight = 13;
            halfBrickWallSprite.SpriteWidth = 8;
            halfBrickWallSprite.sprite = new bool[halfBrickWallSprite.SpriteHeight, halfBrickWallSprite.SpriteWidth];

            #region halfBrickWallSprite
            halfBrickWallSprite.sprite[0, 0] = true;
            halfBrickWallSprite.sprite[0, 1] = true;
            halfBrickWallSprite.sprite[1, 0] = true;
            halfBrickWallSprite.sprite[1, 2] = true;
            halfBrickWallSprite.sprite[2, 0] = true;
            halfBrickWallSprite.sprite[2, 2] = true;
            halfBrickWallSprite.sprite[3, 0] = true;
            halfBrickWallSprite.sprite[3, 1] = true;
            halfBrickWallSprite.sprite[3, 2] = true;
            halfBrickWallSprite.sprite[3, 3] = true;
            halfBrickWallSprite.sprite[3, 4] = true;
            halfBrickWallSprite.sprite[3, 6] = true;
            halfBrickWallSprite.sprite[4, 0] = true;
            halfBrickWallSprite.sprite[4, 3] = true;
            halfBrickWallSprite.sprite[4, 5] = true;
            halfBrickWallSprite.sprite[4, 7] = true;
            halfBrickWallSprite.sprite[5, 0] = true;
            halfBrickWallSprite.sprite[5, 4] = true;
            halfBrickWallSprite.sprite[5, 7] = true;
            halfBrickWallSprite.sprite[6, 0] = true;
            halfBrickWallSprite.sprite[6, 1] = true;
            halfBrickWallSprite.sprite[6, 2] = true;
            halfBrickWallSprite.sprite[6, 3] = true;
            halfBrickWallSprite.sprite[6, 4] = true;
            halfBrickWallSprite.sprite[6, 5] = true;
            halfBrickWallSprite.sprite[6, 6] = true;
            halfBrickWallSprite.sprite[6, 7] = true;
            halfBrickWallSprite.sprite[7, 0] = true;
            halfBrickWallSprite.sprite[7, 2] = true;
            halfBrickWallSprite.sprite[7, 7] = true;
            halfBrickWallSprite.sprite[8, 0] = true;
            halfBrickWallSprite.sprite[8, 2] = true;
            halfBrickWallSprite.sprite[8, 7] = true;
            halfBrickWallSprite.sprite[9, 0] = true;
            halfBrickWallSprite.sprite[9, 1] = true;
            halfBrickWallSprite.sprite[9, 2] = true;
            halfBrickWallSprite.sprite[9, 3] = true;
            halfBrickWallSprite.sprite[9, 4] = true;
            halfBrickWallSprite.sprite[9, 5] = true;
            halfBrickWallSprite.sprite[9, 6] = true;
            halfBrickWallSprite.sprite[9, 7] = true;
            halfBrickWallSprite.sprite[10, 0] = true;
            halfBrickWallSprite.sprite[10, 4] = true;
            halfBrickWallSprite.sprite[10, 7] = true;
            halfBrickWallSprite.sprite[11, 0] = true;
            halfBrickWallSprite.sprite[11, 4] = true;
            halfBrickWallSprite.sprite[11, 7] = true;
            halfBrickWallSprite.sprite[12, 0] = true;
            halfBrickWallSprite.sprite[12, 1] = true;
            halfBrickWallSprite.sprite[12, 2] = true;
            halfBrickWallSprite.sprite[12, 3] = true;
            halfBrickWallSprite.sprite[12, 4] = true;
            halfBrickWallSprite.sprite[12, 5] = true;
            halfBrickWallSprite.sprite[12, 6] = true;
            halfBrickWallSprite.sprite[12, 7] = true;
            #endregion

            return halfBrickWallSprite;
        }

        public static Sprite QuarterBrickWallSprite()
        {
            Sprite quarterBrickWallSprite = new Sprite();
            quarterBrickWallSprite.SpriteHeight = 6;
            quarterBrickWallSprite.SpriteWidth = 8;
            quarterBrickWallSprite.sprite = new bool[quarterBrickWallSprite.SpriteHeight, quarterBrickWallSprite.SpriteWidth];

            #region quarterBrickWallSprite
            quarterBrickWallSprite.sprite[0, 1] = true;
            quarterBrickWallSprite.sprite[1, 0] = true;
            quarterBrickWallSprite.sprite[1, 2] = true;
            quarterBrickWallSprite.sprite[2, 0] = true;
            quarterBrickWallSprite.sprite[2, 1] = true;
            quarterBrickWallSprite.sprite[2, 2] = true;
            quarterBrickWallSprite.sprite[2, 3] = true;
            quarterBrickWallSprite.sprite[2, 5] = true;
            quarterBrickWallSprite.sprite[2, 6] = true;
            quarterBrickWallSprite.sprite[3, 0] = true;
            quarterBrickWallSprite.sprite[3, 4] = true;
            quarterBrickWallSprite.sprite[3, 6] = true;
            quarterBrickWallSprite.sprite[3, 7] = true;
            quarterBrickWallSprite.sprite[4, 0] = true;
            quarterBrickWallSprite.sprite[4, 3] = true;
            quarterBrickWallSprite.sprite[4, 4] = true;
            quarterBrickWallSprite.sprite[4, 7] = true;
            quarterBrickWallSprite.sprite[5, 0] = true;
            quarterBrickWallSprite.sprite[5, 1] = true;
            quarterBrickWallSprite.sprite[5, 2] = true;
            quarterBrickWallSprite.sprite[5, 3] = true;
            quarterBrickWallSprite.sprite[5, 4] = true;
            quarterBrickWallSprite.sprite[5, 5] = true;
            quarterBrickWallSprite.sprite[5, 6] = true;
            quarterBrickWallSprite.sprite[5, 7] = true;
            #endregion

            return quarterBrickWallSprite;
        }

        public static Sprite PowerUpSprite()
        {
            Sprite powerUpSprite = new Sprite();
            powerUpSprite.SpriteHeight = 2;
            powerUpSprite.SpriteWidth = 6;
            powerUpSprite.sprite = new bool[powerUpSprite.SpriteHeight, powerUpSprite.SpriteWidth];

            #region powerUpSprite
             powerUpSprite.sprite[0, 1] = true;
             powerUpSprite.sprite[0, 2] = true;
             powerUpSprite.sprite[0, 3] = true;
             powerUpSprite.sprite[0, 4] = true;
             powerUpSprite.sprite[1, 0] = true;
             powerUpSprite.sprite[1, 1] = true;
             powerUpSprite.sprite[1, 2] = true;
             powerUpSprite.sprite[1, 3] = true;
             powerUpSprite.sprite[1, 4] = true;
             powerUpSprite.sprite[1, 5] = true;
            #endregion

            return powerUpSprite;
        }

        public static Sprite AngryMarkSmallSprite()
        {
            Sprite angryMarkSmallSprite = new Sprite();
            angryMarkSmallSprite.SpriteHeight = 3;
            angryMarkSmallSprite.SpriteWidth = 3;
            angryMarkSmallSprite.sprite = new bool[angryMarkSmallSprite.SpriteHeight, angryMarkSmallSprite.SpriteWidth];

            #region angryMarkSmallSprite
            angryMarkSmallSprite.sprite[0, 1] = true;
            angryMarkSmallSprite.sprite[0, 2] = true;
            angryMarkSmallSprite.sprite[1, 1] = true;
            angryMarkSmallSprite.sprite[1, 2] = true;
            angryMarkSmallSprite.sprite[2, 0] = true;
            #endregion

            return angryMarkSmallSprite;
        }

        public static Sprite AngryMarkBigSprite()
        {
            Sprite angryMarkBigSprite = new Sprite();
            angryMarkBigSprite.SpriteHeight = 8;
            angryMarkBigSprite.SpriteWidth = 7;
            angryMarkBigSprite.sprite = new bool[angryMarkBigSprite.SpriteHeight, angryMarkBigSprite.SpriteWidth];

            #region angryMarkBigSprite
            angryMarkBigSprite.sprite[0, 3] = true;
            angryMarkBigSprite.sprite[0, 4] = true;
            angryMarkBigSprite.sprite[1, 3] = true;
            angryMarkBigSprite.sprite[1, 4] = true;
            angryMarkBigSprite.sprite[1, 5] = true;
            angryMarkBigSprite.sprite[1, 6] = true;
            angryMarkBigSprite.sprite[2, 2] = true;
            angryMarkBigSprite.sprite[2, 3] = true;
            angryMarkBigSprite.sprite[2, 4] = true;
            angryMarkBigSprite.sprite[2, 5] = true;
            angryMarkBigSprite.sprite[2, 6] = true;
            angryMarkBigSprite.sprite[3, 2] = true;
            angryMarkBigSprite.sprite[3, 3] = true;
            angryMarkBigSprite.sprite[3, 4] = true;
            angryMarkBigSprite.sprite[3, 5] = true;
            angryMarkBigSprite.sprite[4, 4] = true;
            angryMarkBigSprite.sprite[4, 5] = true;
            angryMarkBigSprite.sprite[5, 1] = true;
            angryMarkBigSprite.sprite[6, 0] = true;
            angryMarkBigSprite.sprite[6, 1] = true;
            angryMarkBigSprite.sprite[6, 2] = true;
            angryMarkBigSprite.sprite[7, 1] = true;
            #endregion

            return angryMarkBigSprite;
        }

        public static Sprite HappyMarkprite()
        {
            Sprite happyMarkprite = new Sprite();
            happyMarkprite.SpriteHeight = 8;
            happyMarkprite.SpriteWidth = 8;
            happyMarkprite.sprite = new bool[happyMarkprite.SpriteHeight, happyMarkprite.SpriteWidth];

            #region happyMarkprite
            happyMarkprite.sprite[0, 4] = true;
            happyMarkprite.sprite[1, 1] = true;
            happyMarkprite.sprite[1, 6] = true;
            happyMarkprite.sprite[2, 3] = true;
            happyMarkprite.sprite[2, 4] = true;
            happyMarkprite.sprite[3, 0] = true;
            happyMarkprite.sprite[3, 2] = true;
            happyMarkprite.sprite[3, 5] = true;
            happyMarkprite.sprite[3, 7] = true;
            happyMarkprite.sprite[4, 2] = true;
            happyMarkprite.sprite[4, 5] = true;
            happyMarkprite.sprite[5, 3] = true;
            happyMarkprite.sprite[5, 4] = true;
            happyMarkprite.sprite[6, 1] = true;
            happyMarkprite.sprite[6, 7] = true;
            happyMarkprite.sprite[7, 3] = true;
            happyMarkprite.sprite[7, 5] = true;
            #endregion

            return happyMarkprite;
        }

        public static Sprite ThunderProjectileSprite()
        {
            Sprite thunderProjectileSprite = new Sprite();
            thunderProjectileSprite.SpriteHeight = 7;
            thunderProjectileSprite.SpriteWidth = 8;
            thunderProjectileSprite.sprite = new bool[thunderProjectileSprite.SpriteHeight, thunderProjectileSprite.SpriteWidth];

            #region thunderAttackSprite
           thunderProjectileSprite.sprite[0, 7] = true;
           thunderProjectileSprite.sprite[1, 3] = true;
           thunderProjectileSprite.sprite[1, 6] = true;
           thunderProjectileSprite.sprite[1, 7] = true;
           thunderProjectileSprite.sprite[2, 2] = true;
           thunderProjectileSprite.sprite[2, 3] = true;
           thunderProjectileSprite.sprite[2, 5] = true;
           thunderProjectileSprite.sprite[2, 6] = true;
           thunderProjectileSprite.sprite[2, 7] = true;
           thunderProjectileSprite.sprite[3, 1] = true;
           thunderProjectileSprite.sprite[3, 2] = true;
           thunderProjectileSprite.sprite[3, 3] = true;
           thunderProjectileSprite.sprite[3, 4] = true;
           thunderProjectileSprite.sprite[3, 5] = true;
           thunderProjectileSprite.sprite[3, 6] = true;
           thunderProjectileSprite.sprite[4, 0] = true;
           thunderProjectileSprite.sprite[4, 1] = true;
           thunderProjectileSprite.sprite[4, 2] = true;
           thunderProjectileSprite.sprite[4, 3] = true;
           thunderProjectileSprite.sprite[4, 4] = true;
           thunderProjectileSprite.sprite[4, 5] = true;
           thunderProjectileSprite.sprite[5, 0] = true;
           thunderProjectileSprite.sprite[5, 1] = true;
           thunderProjectileSprite.sprite[5, 3] = true;
           thunderProjectileSprite.sprite[5, 4] = true;
           thunderProjectileSprite.sprite[6, 0] = true;
           thunderProjectileSprite.sprite[6, 3] = true;
            #endregion

            return thunderProjectileSprite;
        }

        public static Sprite FireBallProjectileSprite()
        {
            Sprite fireBallProjectileSprite = new Sprite();
            fireBallProjectileSprite.SpriteHeight = 8;
            fireBallProjectileSprite.SpriteWidth = 8;
            fireBallProjectileSprite.sprite = new bool[fireBallProjectileSprite.SpriteHeight, fireBallProjectileSprite.SpriteWidth];

            #region fireProjectileSprite
            fireBallProjectileSprite.sprite[0, 2] = true;
            fireBallProjectileSprite.sprite[0, 3] = true;
            fireBallProjectileSprite.sprite[0, 4] = true;
            fireBallProjectileSprite.sprite[0, 5] = true;
            fireBallProjectileSprite.sprite[0, 7] = true;
            fireBallProjectileSprite.sprite[1, 1] = true;
            fireBallProjectileSprite.sprite[1, 2] = true;
            fireBallProjectileSprite.sprite[1, 3] = true;
            fireBallProjectileSprite.sprite[2, 0] = true;
            fireBallProjectileSprite.sprite[2, 1] = true;
            fireBallProjectileSprite.sprite[2, 3] = true;
            fireBallProjectileSprite.sprite[2, 4] = true;
            fireBallProjectileSprite.sprite[2, 5] = true;
            fireBallProjectileSprite.sprite[2, 7] = true;
            fireBallProjectileSprite.sprite[3, 0] = true;
            fireBallProjectileSprite.sprite[3, 2] = true;
            fireBallProjectileSprite.sprite[3, 3] = true;
            fireBallProjectileSprite.sprite[3, 4] = true;
            fireBallProjectileSprite.sprite[3, 5] = true;
            fireBallProjectileSprite.sprite[3, 6] = true;
            fireBallProjectileSprite.sprite[4, 0] = true;
            fireBallProjectileSprite.sprite[4, 2] = true;
            fireBallProjectileSprite.sprite[4, 3] = true;
            fireBallProjectileSprite.sprite[4, 4] = true;
            fireBallProjectileSprite.sprite[4, 5] = true;
            fireBallProjectileSprite.sprite[4, 6] = true;
            fireBallProjectileSprite.sprite[5, 0] = true;
            fireBallProjectileSprite.sprite[5, 1] = true;
            fireBallProjectileSprite.sprite[5, 3] = true;
            fireBallProjectileSprite.sprite[5, 4] = true;
            fireBallProjectileSprite.sprite[5, 5] = true;
            fireBallProjectileSprite.sprite[5, 7] = true;
            fireBallProjectileSprite.sprite[6, 1] = true;
            fireBallProjectileSprite.sprite[6, 2] = true;
            fireBallProjectileSprite.sprite[6, 3] = true;
            fireBallProjectileSprite.sprite[7, 2] = true;
            fireBallProjectileSprite.sprite[7, 3] = true;
            fireBallProjectileSprite.sprite[7, 4] = true;
            fireBallProjectileSprite.sprite[7, 5] = true;
            fireBallProjectileSprite.sprite[7, 7] = true;
            #endregion

            return fireBallProjectileSprite;
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

        public static DigimonSprite Betamon()
        {
            DigimonSprite betamon = new DigimonSprite();
            betamon.projectileSprite = ThunderProjectileSprite();
            betamon.currentSpriteHeight = 12;
            betamon.frame1Height = 12;
            betamon.frame1Width = 16;
            betamon.frame2Height = 11;
            betamon.frame2Width = 16;
            betamon.happyFrameHeight = 15;
            betamon.happyFrameWidth = 16;
            betamon.eat1FrameHeight = 11;
            betamon.eat1FrameWidth = 16;
            betamon.eat2FrameHeight = 15;
            betamon.eat2FrameWidth = 16;
            betamon.rejectFrameHeight = 12;
            betamon.rejectFrameWidth = 16;
            betamon.attackFrameHeight = 15;
            betamon.attackFrameWidth = 16;
            betamon.angryFrameHeight = 15;
            betamon.angryFrameWidth = 16;

            betamon.frame1 = new bool[betamon.frame1Height, betamon.frame1Width];
            betamon.frame2 = new bool[betamon.frame2Height, betamon.frame2Width];
            betamon.happyFrame = new bool[betamon.happyFrameHeight, betamon.happyFrameWidth];
            betamon.eat1Frame = new bool[betamon.eat1FrameHeight, betamon.eat1FrameWidth];
            betamon.eat2Frame = new bool[betamon.eat2FrameHeight, betamon.eat2FrameWidth];
            betamon.rejectFrame = new bool[betamon.rejectFrameHeight, betamon.rejectFrameWidth];
            betamon.attackFrame = new bool[betamon.attackFrameHeight, betamon.attackFrameWidth];
            betamon.angryFrame = new bool[betamon.angryFrameHeight, betamon.angryFrameWidth];

            #region betamon frames
            //frame 1
            betamon.frame1[0, 3] = true;
            betamon.frame1[0, 4] = true;
            betamon.frame1[0, 5] = true;
            betamon.frame1[0, 6] = true;
            betamon.frame1[0, 7] = true;
            betamon.frame1[1, 3] = true;
            betamon.frame1[1, 8] = true;
            betamon.frame1[1, 9] = true;
            betamon.frame1[2, 4] = true;
            betamon.frame1[2, 10] = true;
            betamon.frame1[3, 4] = true;
            betamon.frame1[3, 6] = true;
            betamon.frame1[3, 7] = true;
            betamon.frame1[3, 8] = true;
            betamon.frame1[3, 9] = true;
            betamon.frame1[3, 11] = true;
            betamon.frame1[4, 3] = true;
            betamon.frame1[4, 5] = true;
            betamon.frame1[4, 10] = true;
            betamon.frame1[4, 11] = true;
            betamon.frame1[4, 12] = true;
            betamon.frame1[5, 2] = true;
            betamon.frame1[5, 9] = true;
            betamon.frame1[5, 10] = true;
            betamon.frame1[5, 13] = true;
            betamon.frame1[5, 14] = true;
            betamon.frame1[5, 15] = true;
            betamon.frame1[6, 1] = true;
            betamon.frame1[6, 3] = true;
            betamon.frame1[6, 6] = true;
            betamon.frame1[6, 8] = true;
            betamon.frame1[6, 12] = true;
            betamon.frame1[6, 13] = true;
            betamon.frame1[6, 15] = true;
            betamon.frame1[7, 1] = true;
            betamon.frame1[7, 3] = true;
            betamon.frame1[7, 6] = true;
            betamon.frame1[7, 11] = true;
            betamon.frame1[7, 14] = true;
            betamon.frame1[7, 15] = true;
            betamon.frame1[8, 1] = true;
            betamon.frame1[8, 14] = true;
            betamon.frame1[9, 1] = true;
            betamon.frame1[9, 10] = true;
            betamon.frame1[9, 12] = true;
            betamon.frame1[9, 15] = true;
            betamon.frame1[10, 0] = true;
            betamon.frame1[10, 2] = true;
            betamon.frame1[10, 3] = true;
            betamon.frame1[10, 4] = true;
            betamon.frame1[10, 5] = true;
            betamon.frame1[10, 6] = true;
            betamon.frame1[10, 9] = true;
            betamon.frame1[10, 10] = true;
            betamon.frame1[10, 11] = true;
            betamon.frame1[10, 15] = true;
            betamon.frame1[11, 0] = true;
            betamon.frame1[11, 1] = true;
            betamon.frame1[11, 2] = true;
            betamon.frame1[11, 3] = true;
            betamon.frame1[11, 6] = true;
            betamon.frame1[11, 7] = true;
            betamon.frame1[11, 8] = true;
            betamon.frame1[11, 9] = true;
            betamon.frame1[11, 11] = true;
            betamon.frame1[11, 12] = true;
            betamon.frame1[11, 13] = true;
            betamon.frame1[11, 14] = true;

            //Frame 2
            betamon.frame2[0, 3] = true;
            betamon.frame2[0, 4] = true;
            betamon.frame2[0, 5] = true;
            betamon.frame2[0, 6] = true;
            betamon.frame2[0, 7] = true;
            betamon.frame2[1, 3] = true;
            betamon.frame2[1, 8] = true;
            betamon.frame2[1, 9] = true;
            betamon.frame2[2, 4] = true;
            betamon.frame2[2, 10] = true;
            betamon.frame2[3, 4] = true;
            betamon.frame2[3, 6] = true;
            betamon.frame2[3, 7] = true;
            betamon.frame2[3, 8] = true;
            betamon.frame2[3, 9] = true;
            betamon.frame2[3, 11] = true;
            betamon.frame2[4, 3] = true;
            betamon.frame2[4, 5] = true;
            betamon.frame2[4, 10] = true;
            betamon.frame2[4, 11] = true;
            betamon.frame2[4, 12] = true;
            betamon.frame2[5, 2] = true;
            betamon.frame2[5, 9] = true;
            betamon.frame2[5, 10] = true;
            betamon.frame2[5, 13] = true;
            betamon.frame2[5, 14] = true;
            betamon.frame2[5, 15] = true;
            betamon.frame2[6, 1] = true;
            betamon.frame2[6, 3] = true;
            betamon.frame2[6, 6] = true;
            betamon.frame2[6, 8] = true;
            betamon.frame2[6, 12] = true;
            betamon.frame2[6, 13] = true;
            betamon.frame2[6, 15] = true;
            betamon.frame2[7, 1] = true;
            betamon.frame2[7, 3] = true;
            betamon.frame2[7, 6] = true;
            betamon.frame2[7, 11] = true;
            betamon.frame2[7, 14] = true;
            betamon.frame2[7, 15] = true;
            betamon.frame2[8, 1] = true;
            betamon.frame2[8, 14] = true;
            betamon.frame2[9, 0] = true;
            betamon.frame2[9, 1] = true;
            betamon.frame2[9, 6] = true;
            betamon.frame2[9, 10] = true;
            betamon.frame2[9, 11] = true;
            betamon.frame2[9, 15] = true;
            betamon.frame2[10, 0] = true;
            betamon.frame2[10, 1] = true;
            betamon.frame2[10, 2] = true;
            betamon.frame2[10, 3] = true;
            betamon.frame2[10, 4] = true;
            betamon.frame2[10, 5] = true;
            betamon.frame2[10, 6] = true;
            betamon.frame2[10, 7] = true;
            betamon.frame2[10, 8] = true;
            betamon.frame2[10, 9] = true;
            betamon.frame2[10, 10] = true;
            betamon.frame2[10, 11] = true;
            betamon.frame2[10, 12] = true;
            betamon.frame2[10, 13] = true;
            betamon.frame2[10, 14] = true;
            betamon.frame2[10, 15] = true;

            //happy frame
            betamon.happyFrame[0, 3] = true;
            betamon.happyFrame[0, 4] = true;
            betamon.happyFrame[0, 5] = true;
            betamon.happyFrame[0, 6] = true;
            betamon.happyFrame[0, 7] = true;
            betamon.happyFrame[1, 3] = true;
            betamon.happyFrame[1, 8] = true;
            betamon.happyFrame[2, 4] = true;
            betamon.happyFrame[2, 9] = true;
            betamon.happyFrame[3, 4] = true;
            betamon.happyFrame[3, 5] = true;
            betamon.happyFrame[3, 6] = true;
            betamon.happyFrame[3, 7] = true;
            betamon.happyFrame[3, 8] = true;
            betamon.happyFrame[3, 10] = true;
            betamon.happyFrame[4, 3] = true;
            betamon.happyFrame[4, 9] = true;
            betamon.happyFrame[4, 11] = true;
            betamon.happyFrame[5, 2] = true;
            betamon.happyFrame[5, 3] = true;
            betamon.happyFrame[5, 6] = true;
            betamon.happyFrame[5, 7] = true;
            betamon.happyFrame[5, 10] = true;
            betamon.happyFrame[5, 11] = true;
            betamon.happyFrame[6, 1] = true;
            betamon.happyFrame[6, 9] = true;
            betamon.happyFrame[6, 10] = true;
            betamon.happyFrame[6, 11] = true;
            betamon.happyFrame[6, 12] = true;
            betamon.happyFrame[7, 1] = true;
            betamon.happyFrame[7, 2] = true;
            betamon.happyFrame[7, 3] = true;
            betamon.happyFrame[7, 4] = true;
            betamon.happyFrame[7, 5] = true;
            betamon.happyFrame[7, 6] = true;
            betamon.happyFrame[7, 11] = true;
            betamon.happyFrame[7, 12] = true;
            betamon.happyFrame[8, 2] = true;
            betamon.happyFrame[8, 4] = true;
            betamon.happyFrame[8, 5] = true;
            betamon.happyFrame[8, 6] = true;
            betamon.happyFrame[8, 7] = true;
            betamon.happyFrame[8, 12] = true;
            betamon.happyFrame[8, 13] = true;
            betamon.happyFrame[8, 14] = true;
            betamon.happyFrame[8, 15] = true;
            betamon.happyFrame[9, 3] = true;
            betamon.happyFrame[9, 5] = true;
            betamon.happyFrame[9, 6] = true;
            betamon.happyFrame[9, 7] = true;
            betamon.happyFrame[9, 8] = true;
            betamon.happyFrame[9, 10] = true;
            betamon.happyFrame[9, 11] = true;
            betamon.happyFrame[9, 12] = true;
            betamon.happyFrame[9, 13] = true;
            betamon.happyFrame[9, 15] = true;
            betamon.happyFrame[10, 3] = true;
            betamon.happyFrame[10, 5] = true;
            betamon.happyFrame[10, 6] = true;
            betamon.happyFrame[10, 7] = true;
            betamon.happyFrame[10, 8] = true;
            betamon.happyFrame[10, 14] = true;
            betamon.happyFrame[10, 15] = true;
            betamon.happyFrame[11, 1] = true;
            betamon.happyFrame[11, 2] = true;
            betamon.happyFrame[11, 3] = true;
            betamon.happyFrame[11, 4] = true;
            betamon.happyFrame[11, 5] = true;
            betamon.happyFrame[11, 6] = true;
            betamon.happyFrame[11, 7] = true;
            betamon.happyFrame[11, 8] = true;
            betamon.happyFrame[11, 14] = true;
            betamon.happyFrame[12, 1] = true;
            betamon.happyFrame[12, 10] = true;
            betamon.happyFrame[12, 12] = true;
            betamon.happyFrame[12, 15] = true;
            betamon.happyFrame[13, 0] = true;
            betamon.happyFrame[13, 2] = true;
            betamon.happyFrame[13, 3] = true;
            betamon.happyFrame[13, 4] = true;
            betamon.happyFrame[13, 5] = true;
            betamon.happyFrame[13, 6] = true;
            betamon.happyFrame[13, 9] = true;
            betamon.happyFrame[13, 10] = true;
            betamon.happyFrame[13, 11] = true;
            betamon.happyFrame[13, 15] = true;
            betamon.happyFrame[14, 0] = true;
            betamon.happyFrame[14, 1] = true;
            betamon.happyFrame[14, 2] = true;
            betamon.happyFrame[14, 3] = true;
            betamon.happyFrame[14, 6] = true;
            betamon.happyFrame[14, 7] = true;
            betamon.happyFrame[14, 8] = true;
            betamon.happyFrame[14, 9] = true;
            betamon.happyFrame[14, 11] = true;
            betamon.happyFrame[14, 12] = true;
            betamon.happyFrame[14, 13] = true;
            betamon.happyFrame[14, 14] = true;

            //eat 
            betamon.eat1Frame[0, 3] = true;
            betamon.eat1Frame[0, 4] = true;
            betamon.eat1Frame[0, 5] = true;
            betamon.eat1Frame[0, 6] = true;
            betamon.eat1Frame[0, 7] = true;
            betamon.eat1Frame[1, 3] = true;
            betamon.eat1Frame[1, 8] = true;
            betamon.eat1Frame[1, 9] = true;
            betamon.eat1Frame[2, 4] = true;
            betamon.eat1Frame[2, 10] = true;
            betamon.eat1Frame[3, 4] = true;
            betamon.eat1Frame[3, 6] = true;
            betamon.eat1Frame[3, 7] = true;
            betamon.eat1Frame[3, 8] = true;
            betamon.eat1Frame[3, 9] = true;
            betamon.eat1Frame[3, 11] = true;
            betamon.eat1Frame[4, 3] = true;
            betamon.eat1Frame[4, 5] = true;
            betamon.eat1Frame[4, 10] = true;
            betamon.eat1Frame[4, 11] = true;
            betamon.eat1Frame[4, 12] = true;
            betamon.eat1Frame[5, 2] = true;
            betamon.eat1Frame[5, 7] = true;
            betamon.eat1Frame[5, 9] = true;
            betamon.eat1Frame[5, 10] = true;
            betamon.eat1Frame[5, 13] = true;
            betamon.eat1Frame[5, 14] = true;
            betamon.eat1Frame[5, 15] = true;
            betamon.eat1Frame[6, 1] = true;
            betamon.eat1Frame[6, 3] = true;
            betamon.eat1Frame[6, 6] = true;
            betamon.eat1Frame[6, 12] = true;
            betamon.eat1Frame[6, 13] = true;
            betamon.eat1Frame[6, 15] = true;
            betamon.eat1Frame[7, 1] = true;
            betamon.eat1Frame[7, 11] = true;
            betamon.eat1Frame[7, 14] = true;
            betamon.eat1Frame[7, 15] = true;
            betamon.eat1Frame[8, 1] = true;
            betamon.eat1Frame[8, 3] = true;
            betamon.eat1Frame[8, 4] = true;
            betamon.eat1Frame[8, 5] = true;
            betamon.eat1Frame[8, 14] = true;
            betamon.eat1Frame[9, 0] = true;
            betamon.eat1Frame[9, 1] = true;
            betamon.eat1Frame[9, 6] = true;
            betamon.eat1Frame[9, 10] = true;
            betamon.eat1Frame[9, 11] = true;
            betamon.eat1Frame[9, 15] = true;
            betamon.eat1Frame[10, 0] = true;
            betamon.eat1Frame[10, 1] = true;
            betamon.eat1Frame[10, 2] = true;
            betamon.eat1Frame[10, 3] = true;
            betamon.eat1Frame[10, 4] = true;
            betamon.eat1Frame[10, 5] = true;
            betamon.eat1Frame[10, 6] = true;
            betamon.eat1Frame[10, 7] = true;
            betamon.eat1Frame[10, 8] = true;
            betamon.eat1Frame[10, 9] = true;
            betamon.eat1Frame[10, 10] = true;
            betamon.eat1Frame[10, 11] = true;
            betamon.eat1Frame[10, 12] = true;
            betamon.eat1Frame[10, 13] = true;
            betamon.eat1Frame[10, 14] = true;
            betamon.eat1Frame[10, 15] = true;

            //eat2
            betamon.eat2Frame = betamon.happyFrame;

            //reject
            betamon.rejectFrame[0, 2] = true;
            betamon.rejectFrame[0, 3] = true;
            betamon.rejectFrame[0, 4] = true;
            betamon.rejectFrame[0, 5] = true;
            betamon.rejectFrame[0, 6] = true;
            betamon.rejectFrame[0, 7] = true;
            betamon.rejectFrame[1, 2] = true;
            betamon.rejectFrame[1, 8] = true;
            betamon.rejectFrame[1, 9] = true;
            betamon.rejectFrame[2, 3] = true;
            betamon.rejectFrame[2, 10] = true;
            betamon.rejectFrame[3, 3] = true;
            betamon.rejectFrame[3, 5] = true;
            betamon.rejectFrame[3, 6] = true;
            betamon.rejectFrame[3, 7] = true;
            betamon.rejectFrame[3, 8] = true;
            betamon.rejectFrame[3, 11] = true;
            betamon.rejectFrame[4, 3] = true;
            betamon.rejectFrame[4, 9] = true;
            betamon.rejectFrame[4, 10] = true;
            betamon.rejectFrame[4, 11] = true;
            betamon.rejectFrame[4, 12] = true;
            betamon.rejectFrame[5, 2] = true;
            betamon.rejectFrame[5, 8] = true;
            betamon.rejectFrame[5, 9] = true;
            betamon.rejectFrame[5, 10] = true;
            betamon.rejectFrame[5, 13] = true;
            betamon.rejectFrame[5, 14] = true;
            betamon.rejectFrame[5, 15] = true;
            betamon.rejectFrame[6, 1] = true;
            betamon.rejectFrame[6, 7] = true;
            betamon.rejectFrame[6, 12] = true;
            betamon.rejectFrame[6, 13] = true;
            betamon.rejectFrame[6, 15] = true;
            betamon.rejectFrame[7, 1] = true;
            betamon.rejectFrame[7, 4] = true;
            betamon.rejectFrame[7, 5] = true;
            betamon.rejectFrame[7, 11] = true;
            betamon.rejectFrame[7, 14] = true;
            betamon.rejectFrame[7, 15] = true;
            betamon.rejectFrame[8, 1] = true;
            betamon.rejectFrame[8, 14] = true;
            betamon.rejectFrame[9, 1] = true;
            betamon.rejectFrame[9, 7] = true;
            betamon.rejectFrame[9, 10] = true;
            betamon.rejectFrame[9, 12] = true;
            betamon.rejectFrame[9, 15] = true;
            betamon.rejectFrame[10, 0] = true;
            betamon.rejectFrame[10, 2] = true;
            betamon.rejectFrame[10, 3] = true;
            betamon.rejectFrame[10, 4] = true;
            betamon.rejectFrame[10, 5] = true;
            betamon.rejectFrame[10, 6] = true;
            betamon.rejectFrame[10, 9] = true;
            betamon.rejectFrame[10, 10] = true;
            betamon.rejectFrame[10, 11] = true;
            betamon.rejectFrame[10, 15] = true;
            betamon.rejectFrame[11, 0] = true;
            betamon.rejectFrame[11, 1] = true;
            betamon.rejectFrame[11, 2] = true;
            betamon.rejectFrame[11, 3] = true;
            betamon.rejectFrame[11, 6] = true;
            betamon.rejectFrame[11, 7] = true;
            betamon.rejectFrame[11, 8] = true;
            betamon.rejectFrame[11, 9] = true;
            betamon.rejectFrame[11, 11] = true;
            betamon.rejectFrame[11, 12] = true;
            betamon.rejectFrame[11, 13] = true;
            betamon.rejectFrame[11, 14] = true;

            //atttack
            betamon.attackFrame = betamon.happyFrame;

            //angry
            betamon.angryFrame[0, 3] = true;
            betamon.angryFrame[0, 4] = true;
            betamon.angryFrame[0, 5] = true;
            betamon.angryFrame[0, 6] = true;
            betamon.angryFrame[0, 7] = true;
            betamon.angryFrame[1, 3] = true;
            betamon.angryFrame[1, 8] = true;
            betamon.angryFrame[2, 4] = true;
            betamon.angryFrame[2, 9] = true;
            betamon.angryFrame[3, 4] = true;
            betamon.angryFrame[3, 5] = true;
            betamon.angryFrame[3, 6] = true;
            betamon.angryFrame[3, 7] = true;
            betamon.angryFrame[3, 8] = true;
            betamon.angryFrame[3, 10] = true;
            betamon.angryFrame[4, 3] = true;
            betamon.angryFrame[4, 9] = true;
            betamon.angryFrame[4, 11] = true;
            betamon.angryFrame[5, 2] = true;
            betamon.angryFrame[5, 3] = true;
            betamon.angryFrame[5, 8] = true;
            betamon.angryFrame[5, 10] = true;
            betamon.angryFrame[5, 11] = true;
            betamon.angryFrame[6, 1] = true;
            betamon.angryFrame[6, 7] = true;
            betamon.angryFrame[6, 8] = true;
            betamon.angryFrame[6, 10] = true;
            betamon.angryFrame[6, 11] = true;
            betamon.angryFrame[6, 12] = true;
            betamon.angryFrame[7, 1] = true;
            betamon.angryFrame[7, 2] = true;
            betamon.angryFrame[7, 3] = true;
            betamon.angryFrame[7, 4] = true;
            betamon.angryFrame[7, 5] = true;
            betamon.angryFrame[7, 6] = true;
            betamon.angryFrame[7, 12] = true;
            betamon.angryFrame[7, 13] = true;
            betamon.angryFrame[8, 2] = true;
            betamon.angryFrame[8, 4] = true;
            betamon.angryFrame[8, 6] = true;
            betamon.angryFrame[8, 7] = true;
            betamon.angryFrame[8, 8] = true;
            betamon.angryFrame[8, 13] = true;
            betamon.angryFrame[8, 14] = true;
            betamon.angryFrame[8, 15] = true;
            betamon.angryFrame[9, 3] = true;
            betamon.angryFrame[9, 4] = true;
            betamon.angryFrame[9, 5] = true;
            betamon.angryFrame[9, 6] = true;
            betamon.angryFrame[9, 7] = true;
            betamon.angryFrame[9, 8] = true;
            betamon.angryFrame[9, 9] = true;
            betamon.angryFrame[9, 11] = true;
            betamon.angryFrame[9, 12] = true;
            betamon.angryFrame[9, 13] = true;
            betamon.angryFrame[9, 15] = true;
            betamon.angryFrame[10, 3] = true;
            betamon.angryFrame[10, 5] = true;
            betamon.angryFrame[10, 7] = true;
            betamon.angryFrame[10, 9] = true;
            betamon.angryFrame[10, 14] = true;
            betamon.angryFrame[10, 15] = true;
            betamon.angryFrame[11, 1] = true;
            betamon.angryFrame[11, 2] = true;
            betamon.angryFrame[11, 3] = true;
            betamon.angryFrame[11, 4] = true;
            betamon.angryFrame[11, 5] = true;
            betamon.angryFrame[11, 6] = true;
            betamon.angryFrame[11, 7] = true;
            betamon.angryFrame[11, 8] = true;
            betamon.angryFrame[11, 9] = true;
            betamon.angryFrame[11, 14] = true;
            betamon.angryFrame[12, 1] = true;
            betamon.angryFrame[12, 10] = true;
            betamon.angryFrame[12, 12] = true;
            betamon.angryFrame[12, 15] = true;
            betamon.angryFrame[13, 0] = true;
            betamon.angryFrame[13, 2] = true;
            betamon.angryFrame[13, 3] = true;
            betamon.angryFrame[13, 4] = true;
            betamon.angryFrame[13, 5] = true;
            betamon.angryFrame[13, 6] = true;
            betamon.angryFrame[13, 9] = true;
            betamon.angryFrame[13, 10] = true;
            betamon.angryFrame[13, 11] = true;
            betamon.angryFrame[13, 15] = true;
            betamon.angryFrame[14, 0] = true;
            betamon.angryFrame[14, 1] = true;
            betamon.angryFrame[14, 2] = true;
            betamon.angryFrame[14, 3] = true;
            betamon.angryFrame[14, 6] = true;
            betamon.angryFrame[14, 7] = true;
            betamon.angryFrame[14, 8] = true;
            betamon.angryFrame[14, 9] = true;
            betamon.angryFrame[14, 11] = true;
            betamon.angryFrame[14, 12] = true;
            betamon.angryFrame[14, 13] = true;
            betamon.angryFrame[14, 14] = true;
            #endregion

            return betamon;
        }

        public static DigimonSprite Greymon()
        {
            DigimonSprite greymon = new DigimonSprite();
            greymon.projectileSprite = FireBallProjectileSprite();
            greymon.currentSpriteHeight = 16;
            greymon.frame1Height = 16;
            greymon.frame1Width = 16;
            greymon.frame2Height = 15;
            greymon.frame2Width = 16;
            greymon.happyFrameHeight = 16;
            greymon.happyFrameWidth = 16;
            greymon.eat1FrameHeight = 15;
            greymon.eat1FrameWidth = 16;
            greymon.eat2FrameHeight = 16;
            greymon.eat2FrameWidth = 16;
            greymon.rejectFrameHeight = 15;
            greymon.rejectFrameWidth = 16;
            greymon.attackFrameHeight = 16;
            greymon.attackFrameWidth = 16;
            greymon.angryFrameHeight = 16;
            greymon.angryFrameWidth = 16;

            greymon.frame1 = new bool[greymon.frame1Height, greymon.frame1Width];
            greymon.frame2 = new bool[greymon.frame2Height, greymon.frame2Width];
            greymon.happyFrame = new bool[greymon.happyFrameHeight, greymon.happyFrameWidth];
            greymon.eat1Frame = new bool[greymon.eat1FrameHeight, greymon.eat1FrameWidth];
            greymon.eat2Frame = new bool[greymon.eat2FrameHeight, greymon.eat2FrameWidth];
            greymon.rejectFrame = new bool[greymon.rejectFrameHeight, greymon.rejectFrameWidth];
            greymon.attackFrame = new bool[greymon.attackFrameHeight, greymon.attackFrameWidth];
            greymon.angryFrame = new bool[greymon.angryFrameHeight, greymon.angryFrameWidth];


            #region greymon frames
            //frame 1
            greymon.frame1[0, 5] = true;
            greymon.frame1[0, 6] = true;
            greymon.frame1[0, 7] = true;
            greymon.frame1[0, 8] = true;
            greymon.frame1[0, 9] = true;
            greymon.frame1[0, 12] = true;
            greymon.frame1[0, 13] = true;
            greymon.frame1[0, 14] = true;
            greymon.frame1[1, 0] = true;
            greymon.frame1[1, 1] = true;
            greymon.frame1[1, 4] = true;
            greymon.frame1[1, 10] = true;
            greymon.frame1[1, 11] = true;
            greymon.frame1[1, 14] = true;
            greymon.frame1[2, 0] = true;
            greymon.frame1[2, 2] = true;
            greymon.frame1[2, 3] = true;
            greymon.frame1[2, 4] = true;
            greymon.frame1[2, 7] = true;
            greymon.frame1[2, 8] = true;
            greymon.frame1[2, 13] = true;
            greymon.frame1[3, 0] = true;
            greymon.frame1[3, 1] = true;
            greymon.frame1[3, 6] = true;
            greymon.frame1[3, 7] = true;
            greymon.frame1[3, 10] = true;
            greymon.frame1[3, 11] = true;
            greymon.frame1[3, 12] = true;
            greymon.frame1[4, 0] = true;
            greymon.frame1[4, 4] = true;
            greymon.frame1[4, 11] = true;
            greymon.frame1[5, 0] = true;
            greymon.frame1[5, 1] = true;
            greymon.frame1[5, 2] = true;
            greymon.frame1[5, 3] = true;
            greymon.frame1[5, 4] = true;
            greymon.frame1[5, 5] = true;
            greymon.frame1[5, 11] = true;
            greymon.frame1[6, 1] = true;
            greymon.frame1[6, 12] = true;
            greymon.frame1[7, 2] = true;
            greymon.frame1[7, 3] = true;
            greymon.frame1[7, 4] = true;
            greymon.frame1[7, 5] = true;
            greymon.frame1[7, 6] = true;
            greymon.frame1[7, 12] = true;
            greymon.frame1[8, 4] = true;
            greymon.frame1[8, 10] = true;
            greymon.frame1[8, 13] = true;
            greymon.frame1[9, 2] = true;
            greymon.frame1[9, 3] = true;
            greymon.frame1[9, 8] = true;
            greymon.frame1[9, 9] = true;
            greymon.frame1[9, 13] = true;
            greymon.frame1[10, 1] = true;
            greymon.frame1[10, 3] = true;
            greymon.frame1[10, 7] = true;
            greymon.frame1[10, 13] = true;
            greymon.frame1[10, 14] = true;
            greymon.frame1[10, 15] = true;
            greymon.frame1[11, 1] = true;
            greymon.frame1[11, 3] = true;
            greymon.frame1[11, 7] = true;
            greymon.frame1[11, 11] = true;
            greymon.frame1[11, 13] = true;
            greymon.frame1[11, 15] = true;
            greymon.frame1[12, 2] = true;
            greymon.frame1[12, 3] = true;
            greymon.frame1[12, 8] = true;
            greymon.frame1[12, 9] = true;
            greymon.frame1[12, 10] = true;
            greymon.frame1[12, 13] = true;
            greymon.frame1[12, 15] = true;
            greymon.frame1[13, 1] = true;
            greymon.frame1[13, 2] = true;
            greymon.frame1[13, 4] = true;
            greymon.frame1[13, 10] = true;
            greymon.frame1[13, 14] = true;
            greymon.frame1[14, 0] = true;
            greymon.frame1[14, 2] = true;
            greymon.frame1[14, 5] = true;
            greymon.frame1[14, 6] = true;
            greymon.frame1[14, 7] = true;
            greymon.frame1[14, 8] = true;
            greymon.frame1[14, 9] = true;
            greymon.frame1[14, 11] = true;
            greymon.frame1[14, 13] = true;
            greymon.frame1[14, 15] = true;
            greymon.frame1[15, 0] = true;
            greymon.frame1[15, 1] = true;
            greymon.frame1[15, 2] = true;
            greymon.frame1[15, 3] = true;
            greymon.frame1[15, 4] = true;
            greymon.frame1[15, 5] = true;
            greymon.frame1[15, 6] = true;
            greymon.frame1[15, 9] = true;
            greymon.frame1[15, 10] = true;
            greymon.frame1[15, 11] = true;
            greymon.frame1[15, 12] = true;
            greymon.frame1[15, 13] = true;
            greymon.frame1[15, 14] = true;
            greymon.frame1[15, 15] = true;

            //Frame 2
            greymon.frame2[0, 5] = true;
            greymon.frame2[0, 6] = true;
            greymon.frame2[0, 7] = true;
            greymon.frame2[0, 8] = true;
            greymon.frame2[0, 9] = true;
            greymon.frame2[0, 12] = true;
            greymon.frame2[0, 13] = true;
            greymon.frame2[0, 14] = true;
            greymon.frame2[1, 0] = true;
            greymon.frame2[1, 1] = true;
            greymon.frame2[1, 4] = true;
            greymon.frame2[1, 10] = true;
            greymon.frame2[1, 11] = true;
            greymon.frame2[1, 14] = true;
            greymon.frame2[2, 0] = true;
            greymon.frame2[2, 2] = true;
            greymon.frame2[2, 3] = true;
            greymon.frame2[2, 4] = true;
            greymon.frame2[2, 7] = true;
            greymon.frame2[2, 8] = true;
            greymon.frame2[2, 13] = true;
            greymon.frame2[3, 0] = true;
            greymon.frame2[3, 1] = true;
            greymon.frame2[3, 6] = true;
            greymon.frame2[3, 7] = true;
            greymon.frame2[3, 10] = true;
            greymon.frame2[3, 11] = true;
            greymon.frame2[3, 12] = true;
            greymon.frame2[4, 0] = true;
            greymon.frame2[4, 4] = true;
            greymon.frame2[4, 11] = true;
            greymon.frame2[5, 0] = true;
            greymon.frame2[5, 1] = true;
            greymon.frame2[5, 2] = true;
            greymon.frame2[5, 3] = true;
            greymon.frame2[5, 4] = true;
            greymon.frame2[5, 5] = true;
            greymon.frame2[5, 11] = true;
            greymon.frame2[6, 1] = true;
            greymon.frame2[6, 12] = true;
            greymon.frame2[7, 2] = true;
            greymon.frame2[7, 3] = true;
            greymon.frame2[7, 4] = true;
            greymon.frame2[7, 5] = true;
            greymon.frame2[7, 6] = true;
            greymon.frame2[7, 12] = true;
            greymon.frame2[8, 4] = true;
            greymon.frame2[8, 13] = true;
            greymon.frame2[9, 1] = true;
            greymon.frame2[9, 2] = true;
            greymon.frame2[9, 3] = true;
            greymon.frame2[9, 9] = true;
            greymon.frame2[9, 10] = true;
            greymon.frame2[9, 13] = true;
            greymon.frame2[9, 14] = true;
            greymon.frame2[9, 15] = true;
            greymon.frame2[10, 0] = true;
            greymon.frame2[10, 3] = true;
            greymon.frame2[10, 8] = true;
            greymon.frame2[10, 13] = true;
            greymon.frame2[10, 15] = true;
            greymon.frame2[11, 0] = true;
            greymon.frame2[11, 3] = true;
            greymon.frame2[11, 8] = true;
            greymon.frame2[11, 12] = true;
            greymon.frame2[11, 13] = true;
            greymon.frame2[11, 15] = true;
            greymon.frame2[12, 1] = true;
            greymon.frame2[12, 2] = true;
            greymon.frame2[12, 4] = true;
            greymon.frame2[12, 9] = true;
            greymon.frame2[12, 10] = true;
            greymon.frame2[12, 11] = true;
            greymon.frame2[12, 14] = true;
            greymon.frame2[13, 0] = true;
            greymon.frame2[13, 2] = true;
            greymon.frame2[13, 5] = true;
            greymon.frame2[13, 9] = true;
            greymon.frame2[13, 11] = true;
            greymon.frame2[13, 13] = true;
            greymon.frame2[13, 15] = true;
            greymon.frame2[14, 0] = true;
            greymon.frame2[14, 1] = true;
            greymon.frame2[14, 2] = true;
            greymon.frame2[14, 3] = true;
            greymon.frame2[14, 4] = true;
            greymon.frame2[14, 5] = true;
            greymon.frame2[14, 6] = true;
            greymon.frame2[14, 7] = true;
            greymon.frame2[14, 8] = true;
            greymon.frame2[14, 9] = true;
            greymon.frame2[14, 10] = true;
            greymon.frame2[14, 11] = true;
            greymon.frame2[14, 12] = true;
            greymon.frame2[14, 13] = true;
            greymon.frame2[14, 14] = true;
            greymon.frame2[14, 15] = true;

            //happy frame
            greymon.happyFrame[0, 0] = true;
            greymon.happyFrame[0, 1] = true;
            greymon.happyFrame[0, 5] = true;
            greymon.happyFrame[0, 6] = true;
            greymon.happyFrame[0, 7] = true;
            greymon.happyFrame[0, 8] = true;
            greymon.happyFrame[0, 9] = true;
            greymon.happyFrame[0, 12] = true;
            greymon.happyFrame[0, 13] = true;
            greymon.happyFrame[0, 14] = true;
            greymon.happyFrame[1, 0] = true;
            greymon.happyFrame[1, 2] = true;
            greymon.happyFrame[1, 4] = true;
            greymon.happyFrame[1, 10] = true;
            greymon.happyFrame[1, 11] = true;
            greymon.happyFrame[1, 14] = true;
            greymon.happyFrame[2, 0] = true;
            greymon.happyFrame[2, 1] = true;
            greymon.happyFrame[2, 2] = true;
            greymon.happyFrame[2, 3] = true;
            greymon.happyFrame[2, 6] = true;
            greymon.happyFrame[2, 7] = true;
            greymon.happyFrame[2, 13] = true;
            greymon.happyFrame[3, 0] = true;
            greymon.happyFrame[3, 8] = true;
            greymon.happyFrame[3, 10] = true;
            greymon.happyFrame[3, 11] = true;
            greymon.happyFrame[3, 12] = true;
            greymon.happyFrame[4, 1] = true;
            greymon.happyFrame[4, 2] = true;
            greymon.happyFrame[4, 3] = true;
            greymon.happyFrame[4, 4] = true;
            greymon.happyFrame[4, 5] = true;
            greymon.happyFrame[4, 11] = true;
            greymon.happyFrame[5, 5] = true;
            greymon.happyFrame[5, 11] = true;
            greymon.happyFrame[6, 5] = true;
            greymon.happyFrame[6, 12] = true;
            greymon.happyFrame[7, 1] = true;
            greymon.happyFrame[7, 2] = true;
            greymon.happyFrame[7, 3] = true;
            greymon.happyFrame[7, 4] = true;
            greymon.happyFrame[7, 12] = true;
            greymon.happyFrame[8, 1] = true;
            greymon.happyFrame[8, 6] = true;
            greymon.happyFrame[8, 10] = true;
            greymon.happyFrame[8, 13] = true;
            greymon.happyFrame[9, 2] = true;
            greymon.happyFrame[9, 3] = true;
            greymon.happyFrame[9, 4] = true;
            greymon.happyFrame[9, 5] = true;
            greymon.happyFrame[9, 8] = true;
            greymon.happyFrame[9, 9] = true;
            greymon.happyFrame[9, 13] = true;
            greymon.happyFrame[10, 1] = true;
            greymon.happyFrame[10, 3] = true;
            greymon.happyFrame[10, 7] = true;
            greymon.happyFrame[10, 13] = true;
            greymon.happyFrame[10, 14] = true;
            greymon.happyFrame[10, 15] = true;
            greymon.happyFrame[11, 1] = true;
            greymon.happyFrame[11, 3] = true;
            greymon.happyFrame[11, 7] = true;
            greymon.happyFrame[11, 11] = true;
            greymon.happyFrame[11, 13] = true;
            greymon.happyFrame[11, 15] = true;
            greymon.happyFrame[12, 2] = true;
            greymon.happyFrame[12, 3] = true;
            greymon.happyFrame[12, 8] = true;
            greymon.happyFrame[12, 9] = true;
            greymon.happyFrame[12, 10] = true;
            greymon.happyFrame[12, 13] = true;
            greymon.happyFrame[12, 15] = true;
            greymon.happyFrame[13, 1] = true;
            greymon.happyFrame[13, 2] = true;
            greymon.happyFrame[13, 4] = true;
            greymon.happyFrame[13, 10] = true;
            greymon.happyFrame[13, 14] = true;
            greymon.happyFrame[14, 0] = true;
            greymon.happyFrame[14, 2] = true;
            greymon.happyFrame[14, 5] = true;
            greymon.happyFrame[14, 6] = true;
            greymon.happyFrame[14, 7] = true;
            greymon.happyFrame[14, 8] = true;
            greymon.happyFrame[14, 9] = true;
            greymon.happyFrame[14, 11] = true;
            greymon.happyFrame[14, 13] = true;
            greymon.happyFrame[14, 15] = true;
            greymon.happyFrame[15, 0] = true;
            greymon.happyFrame[15, 1] = true;
            greymon.happyFrame[15, 2] = true;
            greymon.happyFrame[15, 3] = true;
            greymon.happyFrame[15, 4] = true;
            greymon.happyFrame[15, 5] = true;
            greymon.happyFrame[15, 6] = true;
            greymon.happyFrame[15, 9] = true;
            greymon.happyFrame[15, 10] = true;
            greymon.happyFrame[15, 11] = true;
            greymon.happyFrame[15, 12] = true;
            greymon.happyFrame[15, 13] = true;
            greymon.happyFrame[15, 14] = true;
            greymon.happyFrame[15, 15] = true;

            //eat 
            greymon.eat1Frame = greymon.frame2;

            //eat2
            greymon.eat2Frame[0, 0] = true;
            greymon.eat2Frame[0, 1] = true;
            greymon.eat2Frame[0, 5] = true;
            greymon.eat2Frame[0, 6] = true;
            greymon.eat2Frame[0, 7] = true;
            greymon.eat2Frame[0, 8] = true;
            greymon.eat2Frame[0, 9] = true;
            greymon.eat2Frame[0, 12] = true;
            greymon.eat2Frame[0, 13] = true;
            greymon.eat2Frame[0, 14] = true;
            greymon.eat2Frame[1, 0] = true;
            greymon.eat2Frame[1, 2] = true;
            greymon.eat2Frame[1, 4] = true;
            greymon.eat2Frame[1, 10] = true;
            greymon.eat2Frame[1, 11] = true;
            greymon.eat2Frame[1, 14] = true;
            greymon.eat2Frame[2, 0] = true;
            greymon.eat2Frame[2, 1] = true;
            greymon.eat2Frame[2, 2] = true;
            greymon.eat2Frame[2, 3] = true;
            greymon.eat2Frame[2, 7] = true;
            greymon.eat2Frame[2, 8] = true;
            greymon.eat2Frame[2, 13] = true;
            greymon.eat2Frame[3, 0] = true;
            greymon.eat2Frame[3, 6] = true;
            greymon.eat2Frame[3, 7] = true;
            greymon.eat2Frame[3, 10] = true;
            greymon.eat2Frame[3, 11] = true;
            greymon.eat2Frame[3, 12] = true;
            greymon.eat2Frame[4, 1] = true;
            greymon.eat2Frame[4, 2] = true;
            greymon.eat2Frame[4, 3] = true;
            greymon.eat2Frame[4, 4] = true;
            greymon.eat2Frame[4, 11] = true;
            greymon.eat2Frame[5, 5] = true;
            greymon.eat2Frame[5, 11] = true;
            greymon.eat2Frame[6, 5] = true;
            greymon.eat2Frame[6, 12] = true;
            greymon.eat2Frame[7, 1] = true;
            greymon.eat2Frame[7, 2] = true;
            greymon.eat2Frame[7, 3] = true;
            greymon.eat2Frame[7, 4] = true;
            greymon.eat2Frame[7, 5] = true;
            greymon.eat2Frame[7, 12] = true;
            greymon.eat2Frame[8, 1] = true;
            greymon.eat2Frame[8, 6] = true;
            greymon.eat2Frame[8, 10] = true;
            greymon.eat2Frame[8, 13] = true;
            greymon.eat2Frame[9, 2] = true;
            greymon.eat2Frame[9, 3] = true;
            greymon.eat2Frame[9, 4] = true;
            greymon.eat2Frame[9, 5] = true;
            greymon.eat2Frame[9, 8] = true;
            greymon.eat2Frame[9, 9] = true;
            greymon.eat2Frame[9, 13] = true;
            greymon.eat2Frame[10, 1] = true;
            greymon.eat2Frame[10, 3] = true;
            greymon.eat2Frame[10, 7] = true;
            greymon.eat2Frame[10, 13] = true;
            greymon.eat2Frame[10, 14] = true;
            greymon.eat2Frame[10, 15] = true;
            greymon.eat2Frame[11, 1] = true;
            greymon.eat2Frame[11, 3] = true;
            greymon.eat2Frame[11, 7] = true;
            greymon.eat2Frame[11, 11] = true;
            greymon.eat2Frame[11, 13] = true;
            greymon.eat2Frame[11, 15] = true;
            greymon.eat2Frame[12, 2] = true;
            greymon.eat2Frame[12, 3] = true;
            greymon.eat2Frame[12, 8] = true;
            greymon.eat2Frame[12, 9] = true;
            greymon.eat2Frame[12, 10] = true;
            greymon.eat2Frame[12, 13] = true;
            greymon.eat2Frame[12, 15] = true;
            greymon.eat2Frame[13, 1] = true;
            greymon.eat2Frame[13, 2] = true;
            greymon.eat2Frame[13, 4] = true;
            greymon.eat2Frame[13, 10] = true;
            greymon.eat2Frame[13, 14] = true;
            greymon.eat2Frame[14, 0] = true;
            greymon.eat2Frame[14, 2] = true;
            greymon.eat2Frame[14, 5] = true;
            greymon.eat2Frame[14, 6] = true;
            greymon.eat2Frame[14, 7] = true;
            greymon.eat2Frame[14, 8] = true;
            greymon.eat2Frame[14, 9] = true;
            greymon.eat2Frame[14, 11] = true;
            greymon.eat2Frame[14, 13] = true;
            greymon.eat2Frame[14, 15] = true;
            greymon.eat2Frame[15, 0] = true;
            greymon.eat2Frame[15, 1] = true;
            greymon.eat2Frame[15, 2] = true;
            greymon.eat2Frame[15, 3] = true;
            greymon.eat2Frame[15, 4] = true;
            greymon.eat2Frame[15, 5] = true;
            greymon.eat2Frame[15, 6] = true;
            greymon.eat2Frame[15, 9] = true;
            greymon.eat2Frame[15, 10] = true;
            greymon.eat2Frame[15, 11] = true;
            greymon.eat2Frame[15, 12] = true;
            greymon.eat2Frame[15, 13] = true;
            greymon.eat2Frame[15, 14] = true;
            greymon.eat2Frame[15, 15] = true;

            //reject
            greymon.rejectFrame[0, 5] = true;
            greymon.rejectFrame[0, 6] = true;
            greymon.rejectFrame[0, 7] = true;
            greymon.rejectFrame[0, 8] = true;
            greymon.rejectFrame[0, 9] = true;
            greymon.rejectFrame[0, 12] = true;
            greymon.rejectFrame[0, 13] = true;
            greymon.rejectFrame[0, 14] = true;
            greymon.rejectFrame[1, 0] = true;
            greymon.rejectFrame[1, 1] = true;
            greymon.rejectFrame[1, 4] = true;
            greymon.rejectFrame[1, 10] = true;
            greymon.rejectFrame[1, 11] = true;
            greymon.rejectFrame[1, 14] = true;
            greymon.rejectFrame[2, 0] = true;
            greymon.rejectFrame[2, 2] = true;
            greymon.rejectFrame[2, 3] = true;
            greymon.rejectFrame[2, 4] = true;
            greymon.rejectFrame[2, 8] = true;
            greymon.rejectFrame[2, 13] = true;
            greymon.rejectFrame[3, 0] = true;
            greymon.rejectFrame[3, 1] = true;
            greymon.rejectFrame[3, 2] = true;
            greymon.rejectFrame[3, 7] = true;
            greymon.rejectFrame[3, 10] = true;
            greymon.rejectFrame[3, 11] = true;
            greymon.rejectFrame[3, 12] = true;
            greymon.rejectFrame[4, 0] = true;
            greymon.rejectFrame[4, 11] = true;
            greymon.rejectFrame[5, 0] = true;
            greymon.rejectFrame[5, 1] = true;
            greymon.rejectFrame[5, 2] = true;
            greymon.rejectFrame[5, 3] = true;
            greymon.rejectFrame[5, 4] = true;
            greymon.rejectFrame[5, 11] = true;
            greymon.rejectFrame[5, 13] = true;
            greymon.rejectFrame[5, 14] = true;
            greymon.rejectFrame[6, 1] = true;
            greymon.rejectFrame[6, 5] = true;
            greymon.rejectFrame[6, 6] = true;
            greymon.rejectFrame[6, 11] = true;
            greymon.rejectFrame[6, 12] = true;
            greymon.rejectFrame[6, 15] = true;
            greymon.rejectFrame[7, 0] = true;
            greymon.rejectFrame[7, 2] = true;
            greymon.rejectFrame[7, 3] = true;
            greymon.rejectFrame[7, 4] = true;
            greymon.rejectFrame[7, 7] = true;
            greymon.rejectFrame[7, 11] = true;
            greymon.rejectFrame[7, 15] = true;
            greymon.rejectFrame[8, 0] = true;
            greymon.rejectFrame[8, 4] = true;
            greymon.rejectFrame[8, 10] = true;
            greymon.rejectFrame[8, 14] = true;
            greymon.rejectFrame[9, 1] = true;
            greymon.rejectFrame[9, 3] = true;
            greymon.rejectFrame[9, 13] = true;
            greymon.rejectFrame[9, 14] = true;
            greymon.rejectFrame[9, 15] = true;
            greymon.rejectFrame[10, 2] = true;
            greymon.rejectFrame[10, 3] = true;
            greymon.rejectFrame[10, 13] = true;
            greymon.rejectFrame[10, 15] = true;
            greymon.rejectFrame[11, 3] = true;
            greymon.rejectFrame[11, 12] = true;
            greymon.rejectFrame[11, 13] = true;
            greymon.rejectFrame[11, 15] = true;
            greymon.rejectFrame[12, 1] = true;
            greymon.rejectFrame[12, 2] = true;
            greymon.rejectFrame[12, 4] = true;
            greymon.rejectFrame[12, 10] = true;
            greymon.rejectFrame[12, 11] = true;
            greymon.rejectFrame[12, 14] = true;
            greymon.rejectFrame[13, 0] = true;
            greymon.rejectFrame[13, 2] = true;
            greymon.rejectFrame[13, 5] = true;
            greymon.rejectFrame[13, 9] = true;
            greymon.rejectFrame[13, 11] = true;
            greymon.rejectFrame[13, 15] = true;
            greymon.rejectFrame[14, 0] = true;
            greymon.rejectFrame[14, 1] = true;
            greymon.rejectFrame[14, 2] = true;
            greymon.rejectFrame[14, 3] = true;
            greymon.rejectFrame[14, 4] = true;
            greymon.rejectFrame[14, 5] = true;
            greymon.rejectFrame[14, 6] = true;
            greymon.rejectFrame[14, 7] = true;
            greymon.rejectFrame[14, 8] = true;
            greymon.rejectFrame[14, 9] = true;
            greymon.rejectFrame[14, 10] = true;
            greymon.rejectFrame[14, 11] = true;
            greymon.rejectFrame[14, 12] = true;
            greymon.rejectFrame[14, 13] = true;
            greymon.rejectFrame[14, 14] = true;
            greymon.rejectFrame[14, 15] = true;

            //atttack
            greymon.attackFrame[0, 0] = true;
            greymon.attackFrame[0, 1] = true;
            greymon.attackFrame[0, 5] = true;
            greymon.attackFrame[0, 6] = true;
            greymon.attackFrame[0, 7] = true;
            greymon.attackFrame[0, 8] = true;
            greymon.attackFrame[0, 9] = true;
            greymon.attackFrame[0, 12] = true;
            greymon.attackFrame[0, 13] = true;
            greymon.attackFrame[0, 14] = true;
            greymon.attackFrame[1, 0] = true;
            greymon.attackFrame[1, 2] = true;
            greymon.attackFrame[1, 4] = true;
            greymon.attackFrame[1, 10] = true;
            greymon.attackFrame[1, 11] = true;
            greymon.attackFrame[1, 14] = true;
            greymon.attackFrame[2, 0] = true;
            greymon.attackFrame[2, 1] = true;
            greymon.attackFrame[2, 2] = true;
            greymon.attackFrame[2, 3] = true;
            greymon.attackFrame[2, 8] = true;
            greymon.attackFrame[2, 13] = true;
            greymon.attackFrame[3, 0] = true;
            greymon.attackFrame[3, 7] = true;
            greymon.attackFrame[3, 10] = true;
            greymon.attackFrame[3, 11] = true;
            greymon.attackFrame[3, 12] = true;
            greymon.attackFrame[4, 1] = true;
            greymon.attackFrame[4, 2] = true;
            greymon.attackFrame[4, 3] = true;
            greymon.attackFrame[4, 4] = true;
            greymon.attackFrame[4, 5] = true;
            greymon.attackFrame[4, 6] = true;
            greymon.attackFrame[4, 11] = true;
            greymon.attackFrame[5, 2] = true;
            greymon.attackFrame[5, 4] = true;
            greymon.attackFrame[5, 6] = true;
            greymon.attackFrame[5, 11] = true;
            greymon.attackFrame[6, 6] = true;
            greymon.attackFrame[6, 12] = true;
            greymon.attackFrame[7, 1] = true;
            greymon.attackFrame[7, 2] = true;
            greymon.attackFrame[7, 3] = true;
            greymon.attackFrame[7, 4] = true;
            greymon.attackFrame[7, 5] = true;
            greymon.attackFrame[7, 12] = true;
            greymon.attackFrame[8, 1] = true;
            greymon.attackFrame[8, 6] = true;
            greymon.attackFrame[8, 10] = true;
            greymon.attackFrame[8, 13] = true;
            greymon.attackFrame[9, 2] = true;
            greymon.attackFrame[9, 3] = true;
            greymon.attackFrame[9, 4] = true;
            greymon.attackFrame[9, 5] = true;
            greymon.attackFrame[9, 8] = true;
            greymon.attackFrame[9, 9] = true;
            greymon.attackFrame[9, 13] = true;
            greymon.attackFrame[10, 1] = true;
            greymon.attackFrame[10, 3] = true;
            greymon.attackFrame[10, 7] = true;
            greymon.attackFrame[10, 13] = true;
            greymon.attackFrame[10, 14] = true;
            greymon.attackFrame[10, 15] = true;
            greymon.attackFrame[11, 1] = true;
            greymon.attackFrame[11, 3] = true;
            greymon.attackFrame[11, 7] = true;
            greymon.attackFrame[11, 11] = true;
            greymon.attackFrame[11, 13] = true;
            greymon.attackFrame[11, 15] = true;
            greymon.attackFrame[12, 2] = true;
            greymon.attackFrame[12, 3] = true;
            greymon.attackFrame[12, 8] = true;
            greymon.attackFrame[12, 9] = true;
            greymon.attackFrame[12, 10] = true;
            greymon.attackFrame[12, 13] = true;
            greymon.attackFrame[12, 15] = true;
            greymon.attackFrame[13, 1] = true;
            greymon.attackFrame[13, 2] = true;
            greymon.attackFrame[13, 4] = true;
            greymon.attackFrame[13, 10] = true;
            greymon.attackFrame[13, 14] = true;
            greymon.attackFrame[14, 0] = true;
            greymon.attackFrame[14, 2] = true;
            greymon.attackFrame[14, 5] = true;
            greymon.attackFrame[14, 6] = true;
            greymon.attackFrame[14, 7] = true;
            greymon.attackFrame[14, 8] = true;
            greymon.attackFrame[14, 9] = true;
            greymon.attackFrame[14, 11] = true;
            greymon.attackFrame[14, 13] = true;
            greymon.attackFrame[14, 15] = true;
            greymon.attackFrame[15, 0] = true;
            greymon.attackFrame[15, 1] = true;
            greymon.attackFrame[15, 2] = true;
            greymon.attackFrame[15, 3] = true;
            greymon.attackFrame[15, 4] = true;
            greymon.attackFrame[15, 5] = true;
            greymon.attackFrame[15, 6] = true;
            greymon.attackFrame[15, 9] = true;
            greymon.attackFrame[15, 10] = true;
            greymon.attackFrame[15, 11] = true;
            greymon.attackFrame[15, 12] = true;
            greymon.attackFrame[15, 13] = true;
            greymon.attackFrame[15, 14] = true;
            greymon.attackFrame[15, 15] = true;

            //angry
            greymon.angryFrame = greymon.attackFrame;
            #endregion


            return greymon;
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
