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
        BattleCup = 3,
        Flush = 4,
        Lights = 5,
        Medical = 6,
        History = 7,
        Battle = 8,
        EggSelection = 9,
        DeathScreen = 10
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

                for (int i = 0, hunger = 0, x = 0; i < 4; i++, hunger += game.currentDigimon.maxHunger / 4, x += 8)
                {
                    if (game.currentDigimon.currentHunger <= hunger)
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

                for (int i = 0, strength = 0, x = 0; i < 4; i++, strength += game.currentDigimon.maxStrength / 4, x += 8)
                {
                    if (game.currentDigimon.currentStrength <= strength)
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

        public static void DrawEggSelectionScreen(DigimonGame game)
        {
            Digimon Egg = new Digimon(game, DigimonId.V1Egg);
            Sprite selectTriangleSprite = SpriteImages.SelectTriangleSprite();
            Egg.sprite.SpriteX = game.pixelScreen.NumberOfXPixels / 2 - (Egg.sprite.frame1Width / 2);
            game.pixelScreen.DrawDigimonFrame(Egg, SpriteFrame.Walk, false, true, Egg.sprite.SpriteX, 0);
            game.pixelScreen.DrawSprite(selectTriangleSprite, 0, 5, false);
            game.pixelScreen.DrawSprite(selectTriangleSprite, game.pixelScreen.NumberOfXPixels - selectTriangleSprite.SpriteWidth, 5, true);
        }

        public static void MainScreen(DigimonGame game)
        {
            game.pixelScreen.ClearScreen();
            game.animate.StartDigimonStateAnimation();
        }

        public static void DrawFeedScreen(DigimonGame game, int SubMenuNo)
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

        public static void DrawLightsScreen(DigimonGame game, int SubMenuNo)
        {
            game.pixelScreen.ClearScreen();
            Sprite wakeSprite = SpriteImages.WakeSprite();
            Sprite sleepSprite = SpriteImages.SleepSprite();
            Sprite arrowSprite = SpriteImages.ArrowSprite();

            game.pixelScreen.DrawSprite(wakeSprite, 9, 1, false);
            game.pixelScreen.DrawSprite(sleepSprite, 9, 9, false);

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

        public static void DrawDeathScreen(DigimonGame game)
        {
            game.resetMainScreen();
            game.SelectedMenu = MenuScreen.MainScreen;
            game.pixelScreen.TurnOffAllIcons();
            game.pixelScreen.TurnOffNotificationIcon();
            Sprite grave = SpriteImages.GraveSprite();
            game.animate.StopDigimonStateAnimation();
            game.pixelScreen.ClearScreen();
            game.pixelScreen.DrawSprite(grave, game.pixelScreen.NumberOfXPixels / 2 - grave.SpriteWidth / 2, 0, false);
        }
    }
}
