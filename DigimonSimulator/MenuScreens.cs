using System;
using System.Collections.Generic;
using System.Text;

namespace DigimonSimulator
{
    public enum MenuScreen{
        MainScreen = -1,
        StatScreen = 0 ,
        FeedScreen = 1,
        Training = 2,
        Screen4 = 3,
        Screen5 = 4,
    }

    public static class MenuScreens
    {
        public static void DrawStats(DigimonGame game, int SubMenuNo)
        {
            game.pixelScreen.ClearScreen();

            if (SubMenuNo == 0)
            {
                Sprite hungerSprite = SpriteImages.HungerSprite();
                Sprite fullHeartSprite = SpriteImages.FullHeartSprite();
                Sprite emptyHeartSprite = SpriteImages.EmptyHeartSprite();
                game.pixelScreen.DrawSprite(hungerSprite, 0, 0);

                for (int i = 0, hunger = 1, x = 0; i < 4; i++, hunger += 250, x += 8)
                {
                    if (game.currentDigimon.currentHunger < hunger)
                    {
                        game.pixelScreen.DrawSprite(emptyHeartSprite, x, 9);
                    }
                    else
                    {
                        game.pixelScreen.DrawSprite(fullHeartSprite, x, 9);
                    }
                }
            }

            if (SubMenuNo == 1)
            {
                Sprite strengthSprite = SpriteImages.StrengthSprite();
                Sprite fullHeartSprite = SpriteImages.FullHeartSprite();
                Sprite emptyHeartSprite = SpriteImages.EmptyHeartSprite();
                game.pixelScreen.DrawSprite(strengthSprite, 0, 0);

                for (int i = 0, strength = 1, x = 0; i < 4; i++, strength += 250, x += 8)
                {
                    if (game.currentDigimon.currentStrength < strength)
                    {
                        game.pixelScreen.DrawSprite(emptyHeartSprite, x, 9);
                    }
                    else
                    {
                        game.pixelScreen.DrawSprite(fullHeartSprite, x, 9);
                    }
                }
            }

        }

        public static void MainScreen(DigimonGame game)
        {
            game.pixelScreen.ClearScreen();
            game.animate.resetStepAnimation();
            game.animate.StepDigimon();
            game.stepSprite = true;
        }
    }
}
