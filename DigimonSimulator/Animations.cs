using System;
using System.Collections.Generic;
using System.Text;

namespace DigimonSimulator
{
    public class Animations
    {
        private DigimonSprite Digimon;
        private PixelScreen PixelScreen;
        private int StepCounter = 0;

        public Animations(PixelScreen pixelScreen, DigimonSprite digimon)
        {
            Digimon = digimon;
            PixelScreen = pixelScreen;
        }

        public void resetStepAnimation()
        {
            StepCounter = 0;
            Digimon.SpriteX = PixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 18;
        }

        public void StepDigimon()
        {
            #region Animation
            if (StepCounter == 0 || StepCounter == 1)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, -2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 2)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 3)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, -2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 4)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 3, false, -1 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 5)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, 1 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 6)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 3, false, 0 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 7)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, 0 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 8)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , true, 0 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 9)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 10)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, 3 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 11)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 12)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 13)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , true, 1 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 14)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, 0 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 15)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, false, -4 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 16)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, 0 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 17)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, 3 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 18)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 19)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, -1 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 20)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 21)
            {

                PixelScreen.DrawDigimonFrame(Digimon, 3, true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 22)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, -2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 23)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 3, true, 2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 24)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, -2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 25)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, -2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 26)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, false, -3 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 27)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, false, -2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 28)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, false, -2 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 29)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, -1 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 30)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , true, 0 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 31)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 0, true, 3 + Digimon.SpriteX);
                StepCounter++;
                return;
            }
            if (StepCounter == 32)
            {
                PixelScreen.DrawDigimonFrame(Digimon, 2 , false, -1 + Digimon.SpriteX);
                StepCounter = 0;
                return;
            }
            #endregion
        }


    }
}
