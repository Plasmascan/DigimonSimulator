using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows.Threading;

namespace DigimonSimulator
{
    public enum AnimationNo
    {
        noAnimation,
        eat,
        reject,
        training

    }

    public class Animations
    {
        private DigimonSprite Digimon;
        private DigimonGame Game;
        private int StepCounter = 0;
        private int animationCounter = -1;
        private Sprite EatItemFull;
        private Sprite EatItemHalf;
        private Sprite EatItemEmpty;
        private Sprite ExplainationMark;
        public readonly DispatcherTimer _animationTick = new DispatcherTimer(DispatcherPriority.Normal);
        public AnimationNo animation = AnimationNo.noAnimation;
        SoundPlayer attackSound = new SoundPlayer("../../../resources/se_attack.wav");
        SoundPlayer stepSound = new SoundPlayer("../../../resources/se_step.wav");

        public Animations(DigimonGame pixelScreen, DigimonSprite digimon)
        {
            Digimon = digimon;
            Game = pixelScreen;
            _animationTick.Tick += _animation_Tick;
        }

        private void _animation_Tick(object sender, EventArgs e)
        {
            animationCounter++;
            if (animation == AnimationNo.eat)
            {
                switch (animationCounter)
                {
                    default:
                        Game.pixelScreen.ClearSprite(EatItemFull);
                        Game.pixelScreen.DrawSprite(EatItemFull, 0, 8, false);
                        EatItemFull.SpriteY = 8;
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat2, false, Digimon.SpriteX, 0);
                        break;

                    case 1:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat1, false, Digimon.SpriteX, 0);
                        Game.pixelScreen.ClearSprite(EatItemFull);
                        Game.pixelScreen.DrawSprite(EatItemHalf, 0, Game.pixelScreen.NumberOfYPixels - EatItemHalf.SpriteHeight, false);
                        break;

                    case 2:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat2, false, Digimon.SpriteX, 0);
                        break;

                    case 3:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat1, false, Digimon.SpriteX, 0);
                        Game.pixelScreen.ClearSprite(EatItemHalf);
                        Game.pixelScreen.DrawSprite(EatItemEmpty, 0, Game.pixelScreen.NumberOfYPixels - EatItemEmpty.SpriteHeight, false);
                        break;

                    case 4:
                        resetAnimations();
                        Game.CurrentSubMenu = 0;
                        MenuScreens.drawFeedScreen(Game, Game.SelectedSubMenuNo);
                        break;
                }
            }

            else if (animation == AnimationNo.reject)
            {
                switch (animationCounter)
                {
                    default:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, true, Digimon.SpriteX, 0);
                        break;

                    case 1:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, false, Digimon.SpriteX, 0);
                        break;

                    case 2:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, true, Digimon.SpriteX, 0);
                        break;

                    case 3:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, false, Digimon.SpriteX, 0);
                        break;

                    case 4:
                        resetAnimations();
                        Game.CurrentSubMenu = 0;
                        MenuScreens.drawFeedScreen(Game, Game.SelectedSubMenuNo);
                        break;
                }
            }

            else if (animation == AnimationNo.training)
            {
                switch (animationCounter)
                {
                    case 0:
                        Game.pixelScreen.DrawSprite(ExplainationMark, 8, 0, false);
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX, 0);
                        stepSound.Play();
                        break;

                    case 1:
                        Game.pixelScreen.ClearSprite(ExplainationMark);
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                        break;

                    case 6:
                        Digimon.projectileSprite.SpriteX = 8;
                        Digimon.projectileSprite.SpriteY = 0;
                        _animationTick.Interval = TimeSpan.FromMilliseconds(45);
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                        break;

                    case 7:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -1);
                        break;

                    case 8:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -1);
                        break;

                    case 9:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, 0);
                        break;

                    case 10:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX - 1, 0);
                        break;

                    case 11:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX - 1, 0);
                        break;

                    case 12:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX - 1, 0);
                        break;

                    case 15:
                        Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX, 0);
                        attackSound.Play();
                        break;

                    case 40:
                        Game.resetMainScreen();
                        break;

                }


                if (animationCounter > 15)
                {
                    Game.pixelScreen.ClearSprite(Digimon.projectileSprite);
                    Digimon.projectileSprite.SpriteX--;
                    Game.pixelScreen.DrawSprite(Digimon.projectileSprite, Digimon.projectileSprite.SpriteX, 0, false);
                }
               

            }
        }

            public void resetStepAnimation()
        {
            StepCounter = 0;
            Digimon.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 18;
        }

        public void resetAnimations()
        {
            animationCounter = -1;
            animation = AnimationNo.noAnimation;
            _animationTick.Stop();

        }

        public void StepDigimon()
        {
            #region Animation
            if (StepCounter == 0 || StepCounter == 1)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, -2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 2)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2 , true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 3)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, -2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 4)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, -1 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 5)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, 1 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 6)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, 0 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 7)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, 0 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 8)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, 0 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 9)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 10)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, 3 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 11)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 12)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 13)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, 1 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 14)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, 0 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 15)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, -4 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 16)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, 0 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 17)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, 3 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 18)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 19)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, -1 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 20)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 21)
            {

                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 22)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, -2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 23)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, true, 2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 24)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, -2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 25)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, -2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 26)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, -3 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 27)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, -2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 28)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, -2 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 29)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, -1 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 30)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, 0 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 31)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, 3 + Digimon.SpriteX, 0);
                StepCounter++;
                return;
            }
            if (StepCounter == 32)
            {
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, -1 + Digimon.SpriteX, 0);
                StepCounter = 0;
                return;
            }
            #endregion
        }

        public void SetupEatAnimation(int choice)
        {
            int addHungerAmounter = 50, addStrengthAmount = 50;
            Digimon.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 16;
            Game.pixelScreen.ClearScreen();

            // setup the rejection animation when trying to eat while the digimon is full
            if (choice == 0 && Digimon.currentHunger > Digimon.maxHunger)
            {
                animation = AnimationNo.reject;
                Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, false, Digimon.SpriteX, 0);
                _animationTick.Interval = TimeSpan.FromMilliseconds(478);
                _animationTick.Start();
                return;
            }

            // setup eating animation
            animation = AnimationNo.eat;
            if (choice == 0)
            {
                EatItemFull = SpriteImages.FullFoodSprite();
                EatItemHalf = SpriteImages.HalfFoodSprite();
                EatItemEmpty = SpriteImages.EmptyFoodSprite();
                Digimon.currentHunger += addHungerAmounter;
            }
            else
            {
                EatItemFull = SpriteImages.FullVitaminSprite();
                EatItemHalf = SpriteImages.HalfVitaminSprite();
                EatItemEmpty = SpriteImages.EmptyVitaminSprite();
                if (Digimon.currentStrength < Digimon.maxStrength)
                {
                    Digimon.currentStrength += addStrengthAmount;
                }
            }

            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat1, false, Digimon.SpriteX, 0);
            Game.pixelScreen.DrawSprite(EatItemFull, 0, 0, false);
            _animationTick.Interval = TimeSpan.FromMilliseconds(478);
            _animationTick.Start();

        }

        public void setupTraining()
        {
            Game.pixelScreen.ClearScreen();
            int startX = Game.pixelScreen.NumberOfXPixels - Digimon.frame2Width;
            ExplainationMark = SpriteImages.ExplanationMarkSprite();
            Digimon.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, startX, 0);
            animation = AnimationNo.training;
            _animationTick.Interval = TimeSpan.FromMilliseconds(478);
            _animationTick.Start();
        }

    }
}
