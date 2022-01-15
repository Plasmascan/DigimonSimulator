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
                game.pixelScreen.DrawSprite(hungerSprite, 0, 0, false);

                for (int i = 0, hunger = 1, x = 0; i < 4; i++, hunger += 250, x += 8)
                {
                    if (game.currentDigimon.currentHunger < hunger)
                    {
                        game.pixelScreen.DrawSprite(emptyHeartSprite, x, 9, false);
                    }
                    else
                    {
                        game.pixelScreen.DrawSprite(fullHeartSprite, x, 9, false);
                    }
                }
            }

            if (SubMenuNo == 1)
            {
                Sprite strengthSprite = SpriteImages.StrengthSprite();
                Sprite fullHeartSprite = SpriteImages.FullHeartSprite();
                Sprite emptyHeartSprite = SpriteImages.EmptyHeartSprite();
                game.pixelScreen.DrawSprite(strengthSprite, 0, 0, false);

                for (int i = 0, strength = 1, x = 0; i < 4; i++, strength += 250, x += 8)
                {
                    if (game.currentDigimon.currentStrength < strength)
                    {
                        game.pixelScreen.DrawSprite(emptyHeartSprite, x, 9, false);
                    }
                    else
                    {
                        game.pixelScreen.DrawSprite(fullHeartSprite, x, 9, false);
                    }
                }
            }

        }

        public static void MainScreen(DigimonGame game)
        {
            game.pixelScreen.ClearScreen();
            game.animate.StartStepAnimation();
        }

        public static void drawFeedScreen(DigimonGame game, int SubMenuNo)
        {
            game.pixelScreen.ClearScreen();
            Sprite fullFoodSprite = SpriteImages.FullFoodSprite();
            Sprite fullVitaminSprite = SpriteImages.FullVitaminSprite();
            Sprite arrowSprite = SpriteImages.ArrowSprite();

            game.pixelScreen.DrawSprite(fullFoodSprite, 9, 0, true);
            game.pixelScreen.DrawSprite(fullVitaminSprite, 9, 8, false);

            // Move the arrow depending on selection in the feeding screen
            if (SubMenuNo == 0)
            {
                game.pixelScreen.DrawSprite(arrowSprite, 0, 1, false);
            }
            else
            {
                game.pixelScreen.DrawSprite(arrowSprite, 0, 8, false);
            }
        }
    }
}
