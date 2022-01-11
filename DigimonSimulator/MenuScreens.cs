using System;
using System.Collections.Generic;
using System.Text;

namespace DigimonSimulator
{
    public static class MenuScreens
    {
        public static void drawStats(DigimonGame game)
        {
            game._animationTimer.Stop();
            game.pixelScreen.ClearScreen();
        }
    }
}
