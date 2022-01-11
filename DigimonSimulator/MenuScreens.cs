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
        public static void DrawStats(DigimonGame game)
        {
            game._animationTimer.Stop();
            game.pixelScreen.ClearScreen();
        }

        public static void MainScreen(DigimonGame game)
        {
            game.pixelScreen.ClearScreen();
            game.animate.resetStepAnimation();
            game.animate.StepDigimon();
            game._animationTimer.Start();
        }
    }
}
