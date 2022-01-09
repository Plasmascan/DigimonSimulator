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
        private bool IsPixelOn = false;
        private int PixelWidth = 10;
        private int PixelHeight = 10;
        public Rectangle PixelShape;

        public Pixel(int x, int y, int locationX, int locationY)
        {
            PixelShape = new Rectangle();
            PixelShape.Width = 10;
            PixelShape.Height = 10;
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
        private int NoPixelsY;
        private int NoPixelsX;
        private int PixelSpacing = 11;
        private Pixel[,] screenPixels;
        private Color PixelColorOff = SystemColors.ScrollBarColor;
        private Color PixelColorOn = SystemColors.ScrollBarColor;

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
            screenPixels = new Pixel[NoPixelsY, NoPixelsX];

            for (int yPixel = 0, topPixelLocation = StartY; yPixel < NoPixelsY; yPixel++, topPixelLocation += PixelSpacing)
            {
                for (int xPixel = 0, leftPixelLocation = StartX; xPixel < NoPixelsX; xPixel++, leftPixelLocation += PixelSpacing)
                {
                    Pixel pixel = new Pixel(xPixel, yPixel, leftPixelLocation, topPixelLocation);
                    pixel.TurnOffPixel();
                    Canvas.SetLeft(pixel.PixelShape, leftPixelLocation);
                    Canvas.SetTop(pixel.PixelShape, topPixelLocation);
                    CanvasScreen.Children.Add(pixel.PixelShape);
                    screenPixels[yPixel, xPixel] = pixel;
                }
            }

        }

        public void ClearScreen()
        {
            for (int y = 0; y < NoPixelsY; y++)
            {
                for (int x = 0; x < NoPixelsX; x++)
                {
                    screenPixels[y, x].TurnOffPixel();
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
                    if (screenPixels[y, x].IsPixelClicked(clickedX, clixkedY))
                    {
                        screenPixels[y, x].TogglePixel();
                        return;
                    }
                }
            }
        }
        public void DrawDigimonSprite(DigimonSprite digimon, int x, int y)
        {
            for (int yPixels = y, digimonPixelY = 0; digimonPixelY < digimon.SpriteHeight; yPixels++, digimonPixelY++)
            {
                for (int xPixels = x, digimonPixelX = 0; digimonPixelX < digimon.SpriteWidth; xPixels++, digimonPixelX++)
                {
                    if (isPixelOnScreen(yPixels, xPixels))
                    {
                        
                        if (digimon.frame1[digimonPixelY, digimonPixelX])
                        {
                            screenPixels[yPixels, xPixels].TurnOnPixel();
                        }
                    }
                }
            }
        }
    }
}
