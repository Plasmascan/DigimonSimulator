using System;
using System.Collections.Generic;
using System.Text;

namespace DigimonSimulator
{
    public class Sprite
    {
        private int SpriteHeight;
        private int SpriteWidth;
        private bool[,] sprite;
    }

    public class DigimonSprite
    {
        public int SpriteHeight;
        public int SpriteWidth;
        public bool[,] frame1;
        private bool[,] frame2;
        private bool[,] image3;
   

    }
    public static class SpriteImages
    {
        public static DigimonSprite GetElecmon()
        {
            DigimonSprite Elecmon = new DigimonSprite();
            Elecmon.SpriteHeight = 12;
            Elecmon.SpriteWidth = 16;
            Elecmon.frame1 = new bool[Elecmon.SpriteHeight, Elecmon.SpriteWidth];

            #region Elecmon.frame1
            Elecmon.frame1[0, 1] = true;
            Elecmon.frame1[0, 2] = true;
            Elecmon.frame1[0, 9] = true;
            Elecmon.frame1[0, 10] = true;
            Elecmon.frame1[1, 1] = true;
            Elecmon.frame1[1, 3] = true;
            Elecmon.frame1[1, 8] = true;
            Elecmon.frame1[1, 10] = true;
            Elecmon.frame1[1, 13] = true;
            Elecmon.frame1[2, 2] = true;
            Elecmon.frame1[2, 4] = true;
            Elecmon.frame1[2, 7] = true;
            Elecmon.frame1[2, 9] = true;
            Elecmon.frame1[2, 12] = true;
            Elecmon.frame1[2, 13] = true;
            Elecmon.frame1[3, 2] = true;
            Elecmon.frame1[3, 5] = true;
            Elecmon.frame1[3, 6] = true;
            Elecmon.frame1[3, 9] = true;
            Elecmon.frame1[3, 11] = true;
            Elecmon.frame1[3, 13] = true;
            Elecmon.frame1[3, 15] = true;
            Elecmon.frame1[4, 3] = true;
            Elecmon.frame1[4, 4] = true;
            Elecmon.frame1[4, 6] = true;
            Elecmon.frame1[4, 8] = true;
            Elecmon.frame1[4, 9] = true;
            Elecmon.frame1[4, 10] = true;
            Elecmon.frame1[4, 11] = true;
            Elecmon.frame1[4, 13] = true;
            Elecmon.frame1[4, 14] = true;
            Elecmon.frame1[4, 15] = true;
            Elecmon.frame1[5, 2] = true;
            Elecmon.frame1[5, 9] = true;
            Elecmon.frame1[5, 10] = true;
            Elecmon.frame1[5, 11] = true;
            Elecmon.frame1[5, 12] = true;
            Elecmon.frame1[5, 13] = true;
            Elecmon.frame1[5, 15] = true;
            Elecmon.frame1[6, 1] = true;
            Elecmon.frame1[6, 3] = true;
            Elecmon.frame1[6, 6] = true;
            Elecmon.frame1[6, 11] = true;
            Elecmon.frame1[6, 12] = true;
            Elecmon.frame1[6, 13] = true;
            Elecmon.frame1[6, 15] = true;
            Elecmon.frame1[7, 1] = true;
            Elecmon.frame1[7, 3] = true;
            Elecmon.frame1[7, 6] = true;
            Elecmon.frame1[7, 13] = true;
            Elecmon.frame1[7, 14] = true;
            Elecmon.frame1[8, 1] = true;
            Elecmon.frame1[8, 14] = true;
            Elecmon.frame1[9, 1] = true;
            Elecmon.frame1[9, 10] = true;
            Elecmon.frame1[9, 12] = true;
            Elecmon.frame1[9, 15] = true;
            Elecmon.frame1[10, 0] = true;
            Elecmon.frame1[10, 2] = true;
            Elecmon.frame1[10, 3] = true;
            Elecmon.frame1[10, 4] = true;
            Elecmon.frame1[10, 5] = true;
            Elecmon.frame1[10, 6] = true;
            Elecmon.frame1[10, 9] = true;
            Elecmon.frame1[10, 10] = true;
            Elecmon.frame1[10, 11] = true;
            Elecmon.frame1[10, 15] = true;
            Elecmon.frame1[11, 0] = true;
            Elecmon.frame1[11, 1] = true;
            Elecmon.frame1[11, 2] = true;
            Elecmon.frame1[11, 3] = true;
            Elecmon.frame1[11, 6] = true;
            Elecmon.frame1[11, 7] = true;
            Elecmon.frame1[11, 8] = true;
            Elecmon.frame1[11, 9] = true;
            Elecmon.frame1[11, 11] = true;
            Elecmon.frame1[11, 12] = true;
            Elecmon.frame1[11, 13] = true;
            Elecmon.frame1[11, 14] = true;
            #endregion

            return Elecmon;
        }
    }
}
