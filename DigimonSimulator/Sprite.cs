using System;
using System.Collections.Generic;
using System.Text;

namespace DigimonSimulator
{
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
        public bool[,] frame1;
        public bool[,] frame2;
        public bool[,] happyFrame;
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
    }
}
