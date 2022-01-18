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
        training,
        happy,
        angry,
        battle
    }

    public class Animations
    {
        private DigimonSprite Digimon;
        private DigimonGame Game;
        private int StepCounter = 0;
        private int animationCounter = -1;
        private int GameTickSpeed = 500;
        public int powerUp = 0;
        private Sprite EatItemFull;
        private Sprite EatItemHalf;
        private Sprite EatItemEmpty;
        private Sprite ExplainationMark = SpriteImages.ExplanationMarkSprite();
        private Sprite Explosion;
        private Sprite BrickWall;
        private Sprite HappyMark = SpriteImages.HappyMarkSprite();
        private Sprite AngryMark;
        public bool IsinAnimation = false;
        public bool powerUpReady = false;
        public readonly DispatcherTimer _animationTick = new DispatcherTimer(DispatcherPriority.Send);
        public readonly DispatcherTimer _stepTimer = new DispatcherTimer(DispatcherPriority.Normal);
        public AnimationNo animation = AnimationNo.noAnimation;

        public Animations(DigimonGame game)
        {
            Game = game;
            Digimon = game.currentDigimon;
            _animationTick.Tick += _animation_Tick;
            _stepTimer.Tick += _stepTimer_Tick;
            _stepTimer.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
        }

        private void _stepTimer_Tick(object sender, EventArgs e)
        {
            StepDigimon();
        }

        private void _animation_Tick(object sender, EventArgs e)
        {
            animationCounter++;
            if (animation == AnimationNo.eat)
            {
                PlayEatingAnimation();
            }

            else if (animation == AnimationNo.reject)
            {
                PlayRejectAnimation();
            }

            else if (animation == AnimationNo.angry)
            {
                PlayAngry();
            }

            else if (animation == AnimationNo.happy)
            {
                PlayHappy();
            }

            else if (animation == AnimationNo.training)
            {
                PlayTrainingAnimation();
            }

            else if (animation == AnimationNo.battle)
            {
                PlayBattleAnimation();
            }
        }

        public void StartStepAnimation()
        {
            StepCounter = 0;
            Digimon.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 18;
            StepDigimon();
            _stepTimer.Start();
        }

        public void StopStepAnimation()
        {
            _stepTimer.Stop();
        }

        public void ResetAnimations()
        {
            _animationTick.Stop();
            animationCounter = -1;
            powerUp = 0;
            Digimon.health = 1000;
            animation = AnimationNo.noAnimation;
            BrickWall = SpriteImages.FullBrickWallSprite();
            IsinAnimation = false;
            powerUpReady = false;
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
                SetupRejectAnimation();
                return;
            }

            // setup food item eating animation
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
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();

        }

        public void SetupRejectAnimation()
        {
            animation = AnimationNo.reject;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, true, Digimon.SpriteX, 0);
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayRejectAnimation()
        {
            switch (animationCounter)
            {
                default:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, false, Digimon.SpriteX, 0);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, true, Digimon.SpriteX, 0);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, false, Digimon.SpriteX, 0);
                    break;

                case 3:
                    ResetAnimations();
                    Game.CurrentSubMenu = 0;
                    MenuScreens.drawFeedScreen(Game, Game.SelectedSubMenuNo);
                    break;
            }
        }

        private void PlayEatingAnimation()
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
                    ResetAnimations();
                    Game.CurrentSubMenu = 0;
                    MenuScreens.drawFeedScreen(Game, Game.SelectedSubMenuNo);
                    break;
            }
        }

        public void SetupTraining()
        {
            Game.pixelScreen.ClearScreen();
            int startX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.frame1Width / 2) - 8;
            //ExplainationMark = SpriteImages.ExplanationMarkSprite();
            Digimon.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, startX, 0);
            animation = AnimationNo.training;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayTrainingAnimation()
        {
            switch (animationCounter)
            {
                case 0:
                    Game.pixelScreen.DrawSprite(ExplainationMark, 8, 0, false);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX, 0);
                    Sounds.PlaySound(Sound.Step);
                    break;

                case 1:
                    Game.pixelScreen.ClearSprite(ExplainationMark);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                    powerUpReady = true;
                    Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - 2, false);
                    break;

                // Jump the digimon backwards and then move forwards and attack
                case 6:
                    IsinAnimation = true;
                    Game.pixelScreen.ClearScreen();
                    Digimon.projectileSprite.SpriteX = 8;
                    Digimon.projectileSprite.SpriteY = 0;
                    _animationTick.Interval = TimeSpan.FromMilliseconds(55);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                    break;

                case 7:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -1);
                    break;

                case 8:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -2);
                    break;

                case 9:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -1);
                    break;

                case 10:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, 0);
                    break;

                case 11:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX - 1, 0);
                    break;

                case 12:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX - 1, 0);
                    break;

                // Start shooting the digimon's projectile
                case 13:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX - 1, 0);
                    Sounds.PlaySound(Sound.Attack);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    break;


                case 14:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX - 1, 0);
                    break;

                // start 2nd screen: draw brick wall and move the projectiles position
                case 35:
                    Game.pixelScreen.ClearScreen();
                    BrickWall = SpriteImages.FullBrickWallSprite();
                    Game.pixelScreen.DrawSprite(BrickWall, 0, 0, false);
                    Digimon.projectileSprite.SpriteX = Game.pixelScreen.NumberOfXPixels + 2;
                    break;

                // Projectile hits wall
                case 61:
                    Sounds.PlaySound(Sound.Damage);
                    Game.pixelScreen.ClearSprite(BrickWall);
                    Game.pixelScreen.ClearSprite(Digimon.projectileSprite);
                    Explosion = SpriteImages.ExplosionBigSprite();
                    Game.pixelScreen.DrawSprite(Explosion, 0, 0, false);
                    break;

                case 66:
                    Game.pixelScreen.ClearSprite(Explosion);
                    Explosion = SpriteImages.ExplosionSmallSprite();
                    Game.pixelScreen.DrawSprite(Explosion, 3, 3, false);
                    break;

                case 71:
                    Game.pixelScreen.ClearSprite(Explosion);
                    Explosion = SpriteImages.ExplosionBigSprite();
                    Game.pixelScreen.DrawSprite(Explosion, 0, 0, false);
                    break;

                // show corrisponding broken wall depending on power
                case 76:
                    Game.pixelScreen.ClearSprite(Explosion);

                    if (powerUp >= 13)
                    {
                        BrickWall = SpriteImages.BrockenBrickWallSprite();
                        Game.pixelScreen.DrawSprite(BrickWall, 0, Game.pixelScreen.NumberOfYPixels - BrickWall.SpriteHeight, false);
                    }
                    else if (powerUp >= 11)
                    {
                        BrickWall = SpriteImages.QuarterBrickWallSprite();
                        Game.pixelScreen.DrawSprite(BrickWall, 0, Game.pixelScreen.NumberOfYPixels - BrickWall.SpriteHeight, false);
                    }
                    else if (powerUp >= 9)
                    {
                        BrickWall = SpriteImages.HalfBrickWallSprite();
                        Game.pixelScreen.DrawSprite(BrickWall, 0, Game.pixelScreen.NumberOfYPixels - BrickWall.SpriteHeight, false);
                    }
                    else
                    {
                        BrickWall = SpriteImages.FullBrickWallSprite();
                        Game.pixelScreen.DrawSprite(BrickWall, 0, 0, false);
                    }
                    break;

                case 110:
                    if (powerUp >= 11)
                    {
                        SetupHappy();
                    }
                    else
                    {
                        SetupAngry();
                    }
                    break;
            }

            // Continue moving the digimon's projectile
            if (animationCounter > 14 && animationCounter < 61)
            {
                Game.pixelScreen.ClearSprite(Digimon.projectileSprite);
                Digimon.projectileSprite.SpriteX--;
                Game.pixelScreen.DrawSprite(Digimon.projectileSprite, Digimon.projectileSprite.SpriteX, 8 - Digimon.projectileSprite.SpriteHeight, false);
            }
        }

        public void SetupAngry()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            Digimon.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 16;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, Digimon.SpriteX, 0);
            AngryMark = SpriteImages.AngryMarkSmallSprite();
            Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
            Sounds.PlaySound(Sound.Lose);
            animation = AnimationNo.angry;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayAngry()
        {
            switch (animationCounter)
            {
                default:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Angry, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkBigSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 7, 0, false);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkSmallSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Angry, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkBigSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 7, 0, false);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkSmallSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Angry, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkBigSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 7, 0, false);
                    break;

                case 6:
                    ResetAnimations();
                    Game.resetMainScreen();
                    break;
            }
        }

        public void SetupHappy()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            Digimon.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 16;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, Digimon.SpriteX, 0);
            Sounds.PlaySound(Sound.Win);
            animation = AnimationNo.happy;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayHappy()
        {
            switch (animationCounter)
            {
                default:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(HappyMark);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(HappyMark);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, Digimon.SpriteX, 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 6:
                    ResetAnimations();
                    Game.resetMainScreen();
                    break;
            }
        }

        public void powerUpTraining()
        {
            powerUp++;
            if (powerUp == 3)
            {
                Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - (2 * 2), false);
            }
            if (powerUp == 5)
            {
                Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - (2 * 3), false);
            }
            if (powerUp == 7)
            {
                Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - (2 * 4), false);
            }
            if (powerUp == 9)
            {
                // half brick wall SAD
                Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - (2 * 5), false);
            }
            if (powerUp == 11)
            {
                // quater HAPPY
                Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - (2 * 6), false);
            }
            if (powerUp == 13)
            {
                Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - (2 * 7), false);
            }

        }


        DigimonSprite Oponent = SpriteImages.Betamon();
        int hitPower;
        Random rnd = new Random();
        public void SetupBattleCup()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            int startX = Game.pixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 8;
            IsinAnimation = true;
            Oponent.SpriteX = 8 - (Oponent.frame1Width / 2);
            Oponent.health = 1000;
            Digimon.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Walk2, true, Oponent.SpriteX, 0);
            Sounds.PlaySound(Sound.Start);
            animation = AnimationNo.battle;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayBattleAnimation()
        {
            switch (animationCounter)
            {
                // First screen show both digimon
                case 0:
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Attack, true, Oponent.SpriteX, 0);

                    break;

                case 1:
                    Game.pixelScreen.ClearSprite(Oponent);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX, 0);
                    break;

                case 3:
                    Game.pixelScreen.ClearSprite(Digimon);
                    Game.pixelScreen.DrawSprite(SpriteImages.BattleSprite(), 0, 0, false);
                    break;

                // start powering up
                case 6:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                    break;

                case 7:
                    Game.pixelScreen.DrawSprite(ExplainationMark, 8, 0, false);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX, 0);
                    Sounds.PlaySound(Sound.Step);
                    break;

                case 8:
                    Game.pixelScreen.ClearSprite(ExplainationMark);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                    powerUpReady = true;
                    IsinAnimation = false;
                    Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - 2, false);
                    break;
                
                // jump the digimon back and prepair to attack
                case 13:
                    IsinAnimation = true;
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX, 0);
                    break;

                case 14:
                    _animationTick.Interval = TimeSpan.FromMilliseconds(65);
                    Game.pixelScreen.ClearScreen();

                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -1);
                    break;

                case 15:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -2);
                    break;

                case 17:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, -1);
                    break;

                case 18:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX + 1, 0);
                    break;

                case 20:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX - 1, 0);
                    break;

                // Start attacking
                case 21:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, Digimon.SpriteX - 1, 0);
                    Digimon.projectileSprite.SpriteX = 8;
                    Digimon.projectileSprite.SpriteY = 0;
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    Sounds.PlaySound(Sound.Attack);
                    hitPower = rnd.Next(1, 100);
                    // ROLL
                    break;
                
                // oponent screen start
                case 40:
                    Digimon.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.frame1Width / 2) - 8; // reset owned digimon's X coordinant
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Walk2, true, 0, 0);
                    Digimon.projectileSprite.SpriteX = Game.pixelScreen.NumberOfXPixels + Digimon.projectileSprite.SpriteWidth;
                    break;

                // start oponent Hit or Defend. TODO: use digimon's hurt sprite
                case 63:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullSprite(), 0, 0, false);
                    Sounds.PlaySound(Sound.Damage);
                    //
                    break;

                case 68:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.WhiteSkullSprite(), 0, 0, false);
                    //
                    break;

                case 73:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Angry, true, Oponent.SpriteX, 0);
                    //
                    break;

                case 90:
                    _animationTick.Interval = TimeSpan.FromMilliseconds(65);
                    Game.pixelScreen.ClearScreen();

                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Walk2, true, Oponent.SpriteX - 1, -1);
                    break;

                case 91:
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Walk2, true, Oponent.SpriteX - 1, -2);
                    break;

                case 93:
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Walk2, true, Oponent.SpriteX - 1, -1);
                    break;

                case 94:
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Walk2, true, Oponent.SpriteX - 1, 0);
                    break;

                case 96:
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Walk2, true, Oponent.SpriteX + 1, 0);
                    break;

                // Start attacking
                case 97:
                    Game.pixelScreen.DrawDigimonFrame(Oponent, SpriteFrame.Attack, true, Oponent.SpriteX + 1, 0);
                    Oponent.projectileSprite.SpriteX = 16;
                    Oponent.projectileSprite.SpriteY = 0;
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    Sounds.PlaySound(Sound.Attack);
                    hitPower = rnd.Next(1, 100);
                    // ROLL
                    break;

                // own digimon screen start
                case 116:
                    Oponent.SpriteX = 8 - (Oponent.frame1Width / 2); // reset oponents digimon X Coordanints
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, Digimon.SpriteX, 0);
                    Oponent.projectileSprite.SpriteX = -Oponent.projectileSprite.SpriteWidth - 8;
                    break;

                // hit or defend start
                case 139:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullSprite(), 0, 0, false);
                    Sounds.PlaySound(Sound.Damage);
                    //
                    break;

                case 144:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.WhiteSkullSprite(), 0, 0, false);
                    //
                    break;

                case 149:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Angry, false, Digimon.SpriteX, 0);
                    //
                    break;

                case 166:
                    animationCounter = 13;
                    break;

                case 200:
                    ResetAnimations();
                    Game.resetMainScreen();
                    break;
            }

            if (animationCounter > 21 && animationCounter < 63)
            {
                Game.pixelScreen.ClearSprite(Digimon.projectileSprite);
                Digimon.projectileSprite.SpriteX--;
                Game.pixelScreen.DrawSprite(Digimon.projectileSprite, Digimon.projectileSprite.SpriteX, 8 - Digimon.projectileSprite.SpriteHeight, false);
            }

            else if (animationCounter > 97 && animationCounter < 139)
            {
                Game.pixelScreen.ClearSprite(Oponent.projectileSprite);
                Oponent.projectileSprite.SpriteX++;
                Game.pixelScreen.DrawSprite(Oponent.projectileSprite, Oponent.projectileSprite.SpriteX, 8 - Oponent.projectileSprite.SpriteHeight, true);
            }
        }

    }
}
