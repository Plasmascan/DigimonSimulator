using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
        private int PixelSize;
        public Rectangle PixelShape;
        private Color onColor = Color.FromRgb(1, 35, 23);
        private Color offColor = Color.FromArgb(50, 1, 1, 1);
        private Color shadeColor = Color.FromArgb(150, 1, 1, 1);

        public Pixel(int x, int y, int locationX, int locationY, int pixelSize)
        {
            PixelShape = new Rectangle();
            PixelShape.Width = pixelSize;
            PixelShape.Height = pixelSize;
            PixelNoX = x;
            PixelNoY = y;
            PixelLocationX = locationX;
            PixelLocationY = locationY;
            PixelSize = pixelSize;
        }

        public void TurnOnPixel()
        {
            PixelShape.Fill = new SolidColorBrush(onColor);
            IsPixelOn = true;
        }

        public void TurnOffPixel()
        {
            PixelShape.Fill = new SolidColorBrush(offColor);
            IsPixelOn = false;
        }

        public void ShadePixel()
        {
            PixelShape.Fill = new SolidColorBrush(shadeColor);
            IsPixelOn = false;
        }

        public void TogglePixel()
        {
            if (IsPixelOn)
            {
                PixelShape.Fill = new SolidColorBrush(offColor);
                IsPixelOn = false;
            }
            else
            {
                PixelShape.Fill = new SolidColorBrush(onColor);
                IsPixelOn = true;
            }
        }

        public bool IsPixelClicked(int x, int y)
        {
            if (x >= PixelLocationX && x <= PixelLocationX + PixelSize && y >= PixelLocationY && y <= PixelLocationY + PixelSize)
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
        public int NumberOfYPixels;
        public int NumberOfXPixels;
        public int numberOfIcons = 9;
        private int PixelSize;
        private double PixelSpacing = 0.5;
        private Pixel[,] ScreenPixels;
        private Image[] MenuIcons;
        private Image notificationIcon;
        private double MenuIconOn = 1.0;
        private double MenuIconOff = 0.3;

        public PixelScreen(Canvas canvasScreen, int x, int y, int noPixelsY, int noPixelsX, int pixelSize)
        {
            CanvasScreen = canvasScreen;
            StartX = x;
            StartY = y;
            NumberOfYPixels = noPixelsY;
            NumberOfXPixels = noPixelsX;
            PixelSize = pixelSize;
        }

        public void SetupScreen()
        {
            // Setup pixels
            ScreenPixels = new Pixel[NumberOfYPixels, NumberOfXPixels];
            PixelSpacing += PixelSize;
            double YPixelLocation = StartY;
            double XPixelLocation;

            for (int yPixel = 0; yPixel < NumberOfYPixels; yPixel++, YPixelLocation += PixelSpacing)
            {
                XPixelLocation = StartX;
                for (int xPixel = 0; xPixel < NumberOfXPixels; xPixel++, XPixelLocation += PixelSpacing)
                {
                    Pixel pixel = new Pixel(xPixel, yPixel, (int)XPixelLocation, (int)YPixelLocation, PixelSize);
                    pixel.TurnOffPixel();
                    Canvas.SetLeft(pixel.PixelShape, XPixelLocation);
                    Canvas.SetTop(pixel.PixelShape, YPixelLocation);
                    CanvasScreen.Children.Add(pixel.PixelShape);
                    ScreenPixels[yPixel, xPixel] = pixel;
                }
            }

            SetupMenuIcons();
        }

        private void SetupMenuIcons()
        {
            // Setup menu icons
            MenuIcons = new Image[numberOfIcons];
            int menuYLocation = 1;
            int menuXLocation = 5;
            int spacing = 25;
            int iconWidth = 34;
            int iconHeight = 17;


            for (int i = 0, x = menuXLocation; i < numberOfIcons + 1; i++, x += spacing)
            {
                Image menuIcon = new Image();

                // Move to bottom of the screen and reset X coordinant
                if (i == 5)
                {
                    x = menuXLocation;
                    menuYLocation = 95;
                }

                if (i == 0)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/scales.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }

                else if (i == 1)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/food.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else if (i == 2) {
                    menuIcon.Source = new BitmapImage(new Uri("Images/trainingBag.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else if (i == 3)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/battleCup.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else if (i == 4)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/dung.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else if (i == 5)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/lightbulb.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else if (i == 6)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/bandage.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else if (i == 7)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/book.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else if (i == 8)
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/battle.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    MenuIcons[i] = menuIcon;
                }
                else
                {
                    menuIcon.Source = new BitmapImage(new Uri("Images/shout.png", UriKind.Relative));
                    menuIcon.Width = iconWidth;
                    menuIcon.Height = iconHeight;
                    menuIcon.Opacity = MenuIconOff;
                    Canvas.SetLeft(menuIcon, x);
                    Canvas.SetTop(menuIcon, menuYLocation);
                    CanvasScreen.Children.Add(menuIcon);
                    notificationIcon = menuIcon;
                }
               
            }
        }

        public void TurnOnNotificationIcon()
        {
            notificationIcon.Opacity = MenuIconOn;
        }

        public void TurnOffNotificationIcon()
        {
            notificationIcon.Opacity = MenuIconOff;
        }

        public void TurnMenuIconON(MenuScreen screen)
        {
            TurnOffAllIcons();

            if ((int)screen > -1 && (int)screen < numberOfIcons)
            {
                MenuIcons[(int)screen].Opacity = MenuIconOn;
            }
        }

        public void TurnOffAllIcons()
        {
            for (int i = 0; i < numberOfIcons; i++)
            {
                MenuIcons[i].Opacity = MenuIconOff;
            }
        }

        public void ClearScreen()
        {
            for (int y = 0; y < NumberOfYPixels; y++)
            {
                for (int x = 0; x < NumberOfXPixels; x++)
                {
                    ScreenPixels[y, x].TurnOffPixel();
                }
            }
        }

        public void ShadeScreen()
        {
            for (int y = 0; y < NumberOfYPixels; y++)
            {
                for (int x = 0; x < NumberOfXPixels; x++)
                {
                    ScreenPixels[y, x].ShadePixel();
                }
            }
        }

        public void InvertScreen()
        {
            for (int y = 0; y < NumberOfYPixels; y++)
            {
                for (int x = 0; x < NumberOfXPixels; x++)
                {
                    ScreenPixels[y, x].TogglePixel();
                }
            }
        }

        public void MirrorScreen()
        {
            Sprite mirrorScreen = new Sprite();
            mirrorScreen.SpriteHeight = NumberOfYPixels;
            mirrorScreen.SpriteWidth = NumberOfXPixels;
            bool[,] mirrorScreenSprite = new bool[NumberOfYPixels, NumberOfXPixels];

            for (int yPixel = 0; yPixel < NumberOfYPixels; yPixel++)
            {
                for (int xPixel = NumberOfXPixels - 1, mirrorX = 0; xPixel >= 0; xPixel--, mirrorX++)
                {
                    if (ScreenPixels[yPixel, xPixel].IsPixelOn)
                    {
                        mirrorScreenSprite[yPixel, mirrorX] = true;
                    }
                }
            }
            mirrorScreen.sprite = mirrorScreenSprite;
            ClearScreen();
            DrawSprite(mirrorScreen, 0, 0, false);
        }

        private bool isPixelOnScreen(int y, int x)
        {
            if (y >= 0 && y <= NumberOfYPixels - 1 && x >= 0 && x <= NumberOfXPixels - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PixelClick(int clickedX, int clixkedY)
        {
            for (int y = 0; y < NumberOfYPixels; y++)
            {
                for (int x = 0; x < NumberOfXPixels; x++)
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
            for (int y = digimon.SpriteY; y <  digimon.currentFrameHeight + digimon.SpriteY; y++)
            {
                for (int x = digimon.SpriteX; x < digimon.currentFrameWidth + digimon.SpriteX; x++)
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

        

        // Draws single sprite image to the screen
        public void DrawSprite(Sprite sprite, int x, int y, bool mirror)
        {
            sprite.SpriteX = x;
            sprite.SpriteY = y;

            if (!mirror)
            {
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
                            else
                            {
                                ScreenPixels[yPixels, xPixels].TurnOffPixel();
                            }
                        }
                    }
                }
            }
            
            else
            {
                for (int yPixels = y, spritePixelY = 0; spritePixelY < sprite.SpriteHeight; yPixels++, spritePixelY++)
                {
                    for (int xPixels = x, spritePixelX = sprite.SpriteWidth - 1; spritePixelX >= 0; xPixels++, spritePixelX--)
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
        }

        public void DrawDigimonFrame(Digimon digimon, SpriteFrame frameNo, bool mirror, bool fill, int moveToX, int offsetY)
        {
            ClearSprite(digimon.sprite);

            // frame to draw
            int spriteHeight, spriteWidth, moveToY;
            bool[,] frame;


            switch ((int)frameNo)
            {
                default:
                    frame = digimon.sprite.frame1;
                    spriteHeight = digimon.sprite.frame1Height;
                    spriteWidth = digimon.sprite.frame1Width;
                    break;

                case 1:
                    frame = digimon.sprite.frame2;
                    spriteHeight = digimon.sprite.frame2Height;
                    spriteWidth = digimon.sprite.frame2Width;
                    break;

                case 2:
                    frame = digimon.sprite.happyFrame;
                    spriteHeight = digimon.sprite.happyFrameHeight;
                    spriteWidth = digimon.sprite.happyFrameWidth;
                    break;

                case 3:
                    frame = digimon.sprite.eat1Frame;
                    spriteHeight = digimon.sprite.eat1FrameHeight;
                    spriteWidth = digimon.sprite.eat1FrameWidth;
                    break;

                case 4:
                    frame = digimon.sprite.eat2Frame;
                    spriteHeight = digimon.sprite.eat2FrameHeight;
                    spriteWidth = digimon.sprite.eat2FrameWidth;
                    break;

                case 5:
                    frame = digimon.sprite.rejectFrame;
                    spriteHeight = digimon.sprite.rejectFrameHeight;
                    spriteWidth = digimon.sprite.rejectFrameWidth;
                    break;

                case 6:
                    frame = digimon.sprite.attackFrame;
                    spriteHeight = digimon.sprite.attackFrameHeight;
                    spriteWidth = digimon.sprite.attackFrameWidth;
                    break;

                case 7:
                    frame = digimon.sprite.angryFrame;
                    spriteHeight = digimon.sprite.angryFrameHeight;
                    spriteWidth = digimon.sprite.angryFrameWidth;
                    break;

                case 8:
                    frame = digimon.sprite.hurt1Frame;
                    spriteHeight = digimon.sprite.hurt1FrameHeight;
                    spriteWidth = digimon.sprite.hurt1FrameWidth;
                    break;

            }

            // Keeps the digimon sprite touching the ground if the frame's height changes from frame to frame
            moveToY = NumberOfYPixels - spriteHeight + offsetY;

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
                            else if (fill)
                            {
                                ScreenPixels[yPixels, xPixels].TurnOffPixel();
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
                            else if (fill)
                            {
                                ScreenPixels[yPixels, xPixels].TurnOffPixel();
                            }
                        }
                    }
                }
            }

            // update digimon current location and height
            digimon.sprite.SpriteX = moveToX;
            digimon.sprite.SpriteY = moveToY;
            digimon.sprite.currentFrameHeight = spriteHeight;
            digimon.sprite.currentFrameWidth = spriteWidth;

        }

        public void GenerateSpriteCode(string spriteName, TextBox textBox)
        {
            string code = "";
            bool[,] croppedSprite;
            int spriteStartX = 1000, spriteEndX = 0;
            int spriteStartY = 1000, spriteEndY = 0;
            int spriteHeight, spriteWidth;
            bool isEmpty = true;

            // find the heighest and lowest pixel locations to crop the sprite and find the sprites height and width
            for (int y = 0; y < NumberOfYPixels; y++)
            {
                for (int x = 0; x < NumberOfXPixels; x++)
                {
                    if (ScreenPixels[y, x].IsPixelOn)
                    {
                        isEmpty = false;

                        if (x < spriteStartX)
                        {
                            spriteStartX = x;
                        }

                        if (x > spriteEndX)
                        {
                            spriteEndX = x;
                        }

                        if (y < spriteStartY)
                        {
                            spriteStartY = y;
                        }

                        if (y > spriteEndY)
                        {
                            spriteEndY = y;
                        }
                    }
                }
            }

            if (isEmpty)
            {
                return;
            }

            spriteHeight = spriteEndY - spriteStartY + 1;
            spriteWidth = spriteEndX - spriteStartX + 1;
            code += String.Format("Height = {0}\nWidth = {1}\n#region\n", spriteHeight, spriteWidth);
            // Crop and copy the sprite on the screen into a new bool 2d array
            croppedSprite = new bool[spriteHeight, spriteWidth];

            for (int y = spriteStartY; y <  spriteEndY + 1; y++)
            {
                for (int x = spriteStartX; x <  spriteEndX + 1; x++)
                {
                    if (ScreenPixels[y, x].IsPixelOn)
                    {
                        croppedSprite[y - spriteStartY, x - spriteStartX] = true;
                        code += String.Format("{0}[{1}, {2}] = true;\n", spriteName, y - spriteStartY, x - spriteStartX);
                    }
                }
            }
            code += "#endregion";
            textBox.Text = code;
        }

        public void PanScreen(int moveX, int moveY, bool moveOffScreen)
        {
            Sprite screenCopy = new Sprite();
            screenCopy.SpriteHeight = NumberOfYPixels;
            screenCopy.SpriteWidth = NumberOfXPixels;
            bool[,] screenSprite = new bool[NumberOfYPixels, NumberOfXPixels];
            for (int y = 0; y < NumberOfYPixels; y++)
            {
                for (int x = 0; x < NumberOfXPixels; x++)
                {
                    if (ScreenPixels[y, x].IsPixelOn)
                    {
                        screenSprite[y, x] = true;

                        if (!moveOffScreen)
                        {
                            // Ensure pixels are not moving off the pixelscreen
                            if (y == 0 && moveY < 0 || y == NumberOfYPixels - 1 && moveY > 0 || x == 0 && moveX < 0 || x == NumberOfXPixels - 1 && moveX > 0)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            screenCopy.sprite = screenSprite;
            ClearScreen();
            DrawSprite(screenCopy, moveX, moveY, false);

        }

        public void DrawNumbers(int x, int y, int number, bool isPercent)
        {
            int xDraw = x;
            int numberOfDigits;
            int[] Digits = new int[2];
            Sprite []DigitSprites = new Sprite[2];

            // Seperate digits from a number over 10 into an array
            if (number == 100 && isPercent)
            {
                DrawSprite(SpriteMaps.NumberOneSprite(), x - 6, y, false);
                DrawSprite(SpriteMaps.NumberZeroSprite(), x, y, false);
                DrawSprite(SpriteMaps.NumberZeroSprite(), x + 6, y, false);
                return;
            }

            if (number < 10)
            {
                xDraw += 6;
                numberOfDigits = 1;
                Digits[0] = number;
            }
            
            else if (number >= 99)
            {
                number = 99;
                Digits[0] = 9;
                Digits[1] = 9;
                numberOfDigits = 2;
            }
            else
            {
                Digits[0] = number / 10;
                Digits[1] = number % 10;
                numberOfDigits = 2;
            }

            for (int i = 0; i < numberOfDigits; i++)
            {
                switch (Digits[i])
                {
                    case 0:
                        DigitSprites[i] = SpriteMaps.NumberZeroSprite();
                        break;
                    case 1:
                        DigitSprites[i] = SpriteMaps.NumberOneSprite();
                        break;
                    case 2:
                        DigitSprites[i] = SpriteMaps.NumberTwoSprite();
                        break;
                    case 3:
                        DigitSprites[i] = SpriteMaps.NumberThreeSprite();
                        break;
                    case 4:
                        DigitSprites[i] = SpriteMaps.NumberFourSprite();
                        break;
                    case 5:
                        DigitSprites[i] = SpriteMaps.NumberFiveSprite();
                        break;
                    case 6:
                        DigitSprites[i] = SpriteMaps.NumberSixSprite();
                        break;
                    case 7:
                        DigitSprites[i] = SpriteMaps.NumberSevenSprite();
                        break;
                    case 8:
                        DigitSprites[i] = SpriteMaps.NumberEightSprite();
                        break;
                    case 9:
                        DigitSprites[i] = SpriteMaps.NumberNineSprite();
                        break;
                }
            }

            for (int i = 0, xLocation = xDraw; i < numberOfDigits; i++, xLocation += 6)
            {
                DrawSprite(DigitSprites[i], xLocation, y, false);
            }
            

        }
    }
}
