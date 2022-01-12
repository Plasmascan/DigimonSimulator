using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DigimonSimulator
{
    public class Pixel
    {
        private int PixelNoX;
        private int PixelNoY;
        private int PixelLocationX;
        private int PixelLocationY;
        public bool IsPixelOn = false;
        private int PixelWidth = 10;
        private int PixelHeight = 10;
        public Rectangle PixelShape;

        public Pixel(int x, int y, int locationX, int locationY)
        {
            PixelShape = new Rectangle();
            PixelShape.Width = PixelWidth;
            PixelShape.Height = PixelHeight;
            PixelNoX = x;
            PixelNoY = y;
            PixelLocationX = locationX;
            PixelLocationY = locationY;
        }

        public void TurnOnPixel()
        {
            PixelShape.Fill = new SolidColorBrush(Colors.Black);
            IsPixelOn = true;
        }

        public void TurnOffPixel()
        {
            PixelShape.Fill = new SolidColorBrush(SystemColors.ScrollBarColor);
            IsPixelOn = false;
        }

        public void TogglePixel()
        {
            if (IsPixelOn)
            {
                PixelShape.Fill = new SolidColorBrush(SystemColors.ScrollBarColor);
                IsPixelOn = false;
            }
            else
            {
                PixelShape.Fill = new SolidColorBrush(Colors.Black);
                IsPixelOn = true;
            }
        }

        public bool IsPixelClicked(int x, int y)
        {
            if (x >= PixelLocationX && x <= PixelLocationX + PixelWidth && y >= PixelLocationY && y <= PixelLocationY + PixelHeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class PixelScreen
    {
        private Canvas CanvasScreen;
        private int StartX;
        private int StartY;
        public int NoPixelsY;
        public int NoPixelsX;
        public int numberOfIcons = 6;
        private int PixelSpacing = 11;
        private Pixel[,] ScreenPixels;
        private Rectangle[] MenuIcons;
        private Color PixelColorOff = SystemColors.ScrollBarColor;
        private Color PixelColorOn = Colors.Black;

        public PixelScreen(Canvas canvasScreen, int x, int y, int noPixelsY, int noPixelsX)
        {
            CanvasScreen = canvasScreen;
            StartX = x;
            StartY = y;
            NoPixelsY = noPixelsY;
            NoPixelsX = noPixelsX;
        }

        public void SetupScreen()
        {
            // Setup pixels
            ScreenPixels = new Pixel[NoPixelsY, NoPixelsX];

            for (int yPixel = 0, topPixelLocation = StartY; yPixel < NoPixelsY; yPixel++, topPixelLocation += PixelSpacing)
            {
                for (int xPixel = 0, leftPixelLocation = StartX; xPixel < NoPixelsX; xPixel++, leftPixelLocation += PixelSpacing)
                {
                    Pixel pixel = new Pixel(xPixel, yPixel, leftPixelLocation, topPixelLocation);
                    pixel.TurnOffPixel();
                    Canvas.SetLeft(pixel.PixelShape, leftPixelLocation);
                    Canvas.SetTop(pixel.PixelShape, topPixelLocation);
                    CanvasScreen.Children.Add(pixel.PixelShape);
                    ScreenPixels[yPixel, xPixel] = pixel;
                }
            }

            // Setup menu icons
            MenuIcons = new Rectangle[numberOfIcons];

            for (int i = 0, x = 20; i < numberOfIcons; i++, x += 40)
            {
                Rectangle menu = new Rectangle();
                menu.Width = 20;
                menu.Height = 20;
                menu.Fill = new SolidColorBrush(PixelColorOff);
                Canvas.SetLeft(menu, x);
                Canvas.SetTop(menu, 0);
                CanvasScreen.Children.Add(menu);
                MenuIcons[i] = menu;
            }
        }

        public void TurnMenuIconON(MenuScreen screen)
        {
            TurnOffAllIcons();

            if ((int)screen > -1 && (int)screen < numberOfIcons)
            {
                MenuIcons[(int)screen].Fill = new SolidColorBrush(PixelColorOn);
            }
        }

        public void TurnOffAllIcons()
        {
            for (int i = 0; i < numberOfIcons; i++)
            {
                MenuIcons[i].Fill = new SolidColorBrush(PixelColorOff);
            }
        }

        public void ClearScreen()
        {
            for (int y = 0; y < NoPixelsY; y++)
            {
                for (int x = 0; x < NoPixelsX; x++)
                {
                    ScreenPixels[y, x].TurnOffPixel();
                }
            }
        }

        private bool isPixelOnScreen(int y, int x)
        {
            if (y >= 0 && y <= NoPixelsY - 1 && x >= 0 && x <= NoPixelsX - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void pixelClick(int clickedX, int clixkedY)
        {
            for (int y = 0; y < NoPixelsY; y++)
            {
                for (int x = 0; x < NoPixelsX; x++)
                {
                    if (ScreenPixels[y, x].IsPixelClicked(clickedX, clixkedY))
                    {
                        ScreenPixels[y, x].TogglePixel();
                        return;
                    }
                }
            }
        }

        // Clears a digimon sprite from the screen
        public void ClearSprite(DigimonSprite digimon)
        {
            for (int y = digimon.SpriteY; y <  digimon.currentSpriteHeight + digimon.SpriteY; y++)
            {
                for (int x = digimon.SpriteX; x < digimon.frame1Width + digimon.SpriteX; x++)
                {
                    if (isPixelOnScreen(y, x))
                    {
                        if (ScreenPixels[y, x].IsPixelOn)
                        {
                            ScreenPixels[y, x].TurnOffPixel();
                        }
                    }
                }
            }
        }

        // Clears a single image from the screen
        public void ClearSprite(Sprite sprite)
        {
            for (int y = sprite.SpriteY; y < sprite.SpriteHeight + sprite.SpriteY; y++)
            {
                for (int x = sprite.SpriteX; x < sprite.SpriteWidth + sprite.SpriteX; x++)
                {
                    if (isPixelOnScreen(y, x))
                    {
                        if (ScreenPixels[y, x].IsPixelOn)
                        {
                            ScreenPixels[y, x].TurnOffPixel();
                        }
                    }
                }
            }
        }

        // Draws a single image from a digimon
        public void DrawSprite(DigimonSprite digimon, int x, int y)
        {
            digimon.SpriteX = x;
            digimon.SpriteY = y;

            for (int yPixels = y, digimonPixelY = 0; digimonPixelY < digimon.frame1Height; yPixels++, digimonPixelY++)
            {
                for (int xPixels = x, digimonPixelX = 0; digimonPixelX < digimon.frame1Width; xPixels++, digimonPixelX++)
                {
                    if (isPixelOnScreen(yPixels, xPixels))
                    {
                        
                        if (digimon.frame1[digimonPixelY, digimonPixelX])
                        {
                            ScreenPixels[yPixels, xPixels].TurnOnPixel();
                        }
                    }
                }
            }
        }

        // Draws single sprite image to the screen
        public void DrawSprite(Sprite sprite, int x, int y)
        {
            sprite.SpriteX = x;
            sprite.SpriteY = y;

            for (int yPixels = y, spritePixelY = 0; spritePixelY < sprite.SpriteHeight; yPixels++, spritePixelY++)
            {
                for (int xPixels = x, spritePixelX = 0; spritePixelX < sprite.SpriteWidth; xPixels++, spritePixelX++)
                {
                    if (isPixelOnScreen(yPixels, xPixels))
                    {

                        if (sprite.sprite[spritePixelY, spritePixelX])
                        {
                            ScreenPixels[yPixels, xPixels].TurnOnPixel();
                        }
                    }
                }
            }
        }

        public void DrawDigimonFrame(DigimonSprite digimon, int frameNo, bool mirror, int moveToX)
        {
            ClearSprite(digimon);

            // frame to draw
            int spriteHeight, spriteWidth, moveToY;
            bool[,] frame;


            switch (frameNo)
            {
                default:
                    frame = digimon.frame1;
                    spriteHeight = digimon.frame1Height;
                    spriteWidth = digimon.frame1Width;
                    break;

                case 2:
                    frame = digimon.frame2;
                    spriteHeight = digimon.frame2Height;
                    spriteWidth = digimon.frame2Width;
                    break;

                case 3:
                    frame = digimon.happyFrame;
                    spriteHeight = digimon.happyFrameHeight;
                    spriteWidth = digimon.happyFrameWidth;
                    break;

            }

            // Keeps the digimon sprite touching the ground if the frame's height changes from frame to frame
            moveToY = NoPixelsY - spriteHeight;

            if (!mirror)
            {
                for (int yPixels = moveToY, digimonPixelY = 0; digimonPixelY < spriteHeight; yPixels++, digimonPixelY++)
                {
                    for (int xPixels = moveToX, digimonPixelX = 0; digimonPixelX < spriteWidth; xPixels++, digimonPixelX++)
                    {
                        if (isPixelOnScreen(yPixels, xPixels))
                        {

                            if (frame[digimonPixelY, digimonPixelX])
                            {
                                ScreenPixels[yPixels, xPixels].TurnOnPixel();
                            }
                        }
                    }
                }
            }

            else
            {
                for (int yPixels = moveToY, digimonPixelY = 0; digimonPixelY < spriteHeight; yPixels++, digimonPixelY++)
                {
                    for (int xPixels = moveToX, digimonPixelX = spriteWidth - 1; digimonPixelX >= 0; xPixels++, digimonPixelX--)
                    {
                        if (isPixelOnScreen(yPixels, xPixels))
                        {

                            if (frame[digimonPixelY, digimonPixelX])
                            {
                                ScreenPixels[yPixels, xPixels].TurnOnPixel();
                            }
                        }
                    }
                }
            }

            // update digimon current location and height
            digimon.SpriteX = moveToX;
            digimon.SpriteY = moveToY;
            digimon.currentSpriteHeight = spriteHeight;

        }
    }
}
