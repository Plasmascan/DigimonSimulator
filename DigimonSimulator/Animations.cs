using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Text;
using System.Windows.Threading;

namespace DigimonSimulator
{
    public enum AnimationNo
    {
        NoAnimation,
        Eat,
        Reject,
        Training,
        Happy,
        Angry,
        Battle,
        Attack,
        OponentAttack,
        DigimonDamaged,
        OpponentDamaged,
        DigimonDodge,
        OpponentDodge,
        Victory,
        Defeat,
        Digivolve
    }

    public class Animations
    {
        private Digimon Digimon;
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
        public readonly DispatcherTimer _digimonStateTimer = new DispatcherTimer(DispatcherPriority.Normal);
        public AnimationNo animation = AnimationNo.NoAnimation;

        public Animations(DigimonGame game)
        {
            Game = game;
            Digimon = game.currentDigimon;
            _animationTick.Tick += _animation_Tick;
            _digimonStateTimer.Tick += _digimonStateTimer_Tick;
            _digimonStateTimer.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
        }

        private void _digimonStateTimer_Tick(object sender, EventArgs e)
        {
            StepDigimon();
        }

        private void _animation_Tick(object sender, EventArgs e)
        {
            animationCounter++;
            if (animation == AnimationNo.Eat)
            {
                PlayEatingAnimation();
            }

            else if (animation == AnimationNo.Reject)
            {
                PlayRejectAnimation();
            }

            else if (animation == AnimationNo.Angry)
            {
                PlayAngry();
            }

            else if (animation == AnimationNo.Happy)
            {
                PlayHappy();
            }

            else if (animation == AnimationNo.Training)
            {
                PlayTrainingAnimation();
            }

            else if (animation == AnimationNo.Battle)
            {
                PlayBattleAnimation();
            }

            else if (animation == AnimationNo.Attack)
            {
                DigimonAttack();
            }
            else if (animation == AnimationNo.OponentAttack)
            {
                OpponentDigimonAttack();
            }
            else if (animation == AnimationNo.DigimonDamaged)
            {
                DigimonDamaged();
            }
            else if (animation == AnimationNo.OpponentDamaged)
            {
                OpponentDamaged();
            }
            else if (animation == AnimationNo.DigimonDodge)
            {
                DigimonDodge();
            }
            
            else if (animation == AnimationNo.OpponentDodge)
            {
                OpponentDigimonDodge();
            }

            else if (animation == AnimationNo.Victory)
            {
                PlayVictory();
            }
            else if (animation == AnimationNo.Defeat)
            {
                PlayDefeat();
            }
            else if ( animation == AnimationNo.Digivolve)
            {
                PlayDigivolve();
            }
        }

        public void StartDigimonStateAnimation()
        {
            StepCounter = 0;
            if (!Digimon.isAsleep)
            {
                Game.pixelScreen.ClearSprite(Digimon.sprite);
                Digimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.frame1Width / 2) - 18;
            }
            else if (Digimon.isAsleep)
            {
                Game.pixelScreen.ClearSprite(Digimon.sprite);
                Digimon.sprite.SpriteX = GetMiddleX(Digimon.sprite.hurt1FrameWidth);
            }
            StepDigimon();
            _digimonStateTimer.Start();
        }

        public void StopDigimonStateAnimation()
        {
            _digimonStateTimer.Stop();
        }

        public void ResetAnimations()
        {
            _animationTick.Stop();
            animationCounter = -1;
            powerUp = 0;
            Digimon.currenthealth = Digimon.maxHealth;
            animation = AnimationNo.NoAnimation;
            BrickWall = SpriteImages.FullBrickWallSprite();
            IsinAnimation = false;
            powerUpReady = false;
            secondProjectile = null;
            isEvolving = false;
        }

        private Sprite ZSprite = new Sprite();
        private Sprite BedSprite = SpriteImages.BedSprite();
        public void StepDigimon()
        {
            #region Animation
            if (!Digimon.isAsleep)
            {
                if (StepCounter == 0 || StepCounter == 1)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, -2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 2)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 3)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, -2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 4)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, -1 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 5)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, 1 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 6)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, 0 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 7)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, 0 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 8)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, true, 0 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 9)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 10)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, 3 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 11)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 12)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 13)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, true, 1 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 14)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, 0 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 15)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, -4 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 16)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, 0 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 17)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, 3 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 18)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 19)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, -1 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 20)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 21)
                {

                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 22)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, -2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 23)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, true, true, 2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 24)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, -2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 25)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, -2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 26)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, -3 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 27)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, -2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 28)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, -2 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 29)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, -1 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 30)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, true, true, 0 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 31)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, true, true, 3 + Digimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 32)
                {
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, -1 + Digimon.sprite.SpriteX, 0);
                    StepCounter = 0;
                    return;
                }
            }
            #endregion
            else if (Digimon.isAsleep)
            {
                if (StepCounter == 0)
                {
                    Game.pixelScreen.ClearSprite(ZSprite);

                    if (Digimon.isInBed)
                    {
                        Game.pixelScreen.ClearSprite(BedSprite);
                    }

                    ZSprite = SpriteImages.BigZSprite();
                    Game.pixelScreen.DrawSprite(ZSprite, 24, 2, false);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Hurt1, false, true, Digimon.sprite.SpriteX, 0);

                    // draw bed over sprite
                    if (Digimon.isInBed)
                    {
                        Game.pixelScreen.DrawSprite(BedSprite, 7, Game.pixelScreen.NumberOfYPixels - BedSprite.SpriteHeight, false);
                    }

                    StepCounter++;
                }
                else if (StepCounter == 1)
                {
                    Game.pixelScreen.ClearSprite(ZSprite);

                    if (Digimon.isInBed)
                    {
                        Game.pixelScreen.ClearSprite(BedSprite);
                    }

                    ZSprite = SpriteImages.SmallZSprite();
                    Game.pixelScreen.DrawSprite(ZSprite, 24, 2, false);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Hurt1, false, true, Digimon.sprite.SpriteX, 0);

                    // Draw bed over sprite
                    if (Digimon.isInBed)
                    {
                        Game.pixelScreen.DrawSprite(BedSprite, 8, Game.pixelScreen.NumberOfYPixels - BedSprite.SpriteHeight, false);
                    }

                    StepCounter = 0;
                }
                
            }
        }

        public void SetupEatAnimation(int choice)
        {
            int addHungerAmounter = 50, addStrengthAmount = 50;
            Digimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.frame1Width / 2) - 16;
            Game.pixelScreen.ClearScreen();

            // setup the rejection animation when trying to eat while the digimon is full
            if (choice == 0 && Digimon.currentHunger > Digimon.maxHunger)
            {
                SetupRejectAnimation();
                return;
            }

            // setup food item eating animation
            animation = AnimationNo.Eat;
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

            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat1, false, true, Digimon.sprite.SpriteX, 0);
            Game.pixelScreen.DrawSprite(EatItemFull, 0, 0, false);
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();

        }

        public void SetupRejectAnimation()
        {
            animation = AnimationNo.Reject;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, true, true, Digimon.sprite.SpriteX, 0);
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayRejectAnimation()
        {
            switch (animationCounter)
            {
                default:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, true, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Reject, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    ResetAnimations();
                    Game.CurrentSubMenu = 0;
                    MenuScreens.DrawFeedScreen(Game, Game.SelectedSubMenuNo);
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
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat2, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat1, false, true, Digimon.sprite.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(EatItemFull);
                    Game.pixelScreen.DrawSprite(EatItemHalf, 0, Game.pixelScreen.NumberOfYPixels - EatItemHalf.SpriteHeight, false);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat2, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Eat1, false, true, Digimon.sprite.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(EatItemHalf);
                    Game.pixelScreen.DrawSprite(EatItemEmpty, 0, Game.pixelScreen.NumberOfYPixels - EatItemEmpty.SpriteHeight, false);
                    break;

                case 4:
                    ResetAnimations();
                    Game.CurrentSubMenu = 0;
                    MenuScreens.DrawFeedScreen(Game, Game.SelectedSubMenuNo);
                    break;
            }
        }

        public void SetupTraining()
        {
            Game.pixelScreen.ClearScreen();
            int startX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 8;
            //ExplainationMark = SpriteImages.ExplanationMarkSprite();
            Digimon.sprite.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, startX, 0);
            animation = AnimationNo.Training;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayTrainingAnimation()
        {
            switch (animationCounter)
            {
                case 0:
                    Game.pixelScreen.DrawSprite(ExplainationMark, 8, 0, false);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, true, Digimon.sprite.SpriteX, 0);
                    Sounds.PlaySound(Sound.Step);
                    break;

                case 1:
                    Game.pixelScreen.ClearSprite(ExplainationMark);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX, 0);
                    powerUpReady = true;
                    Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - 2, false);
                    break;

                // Jump the digimon backwards and then move forwards and attack
                case 6:
                    IsinAnimation = true;
                    Game.pixelScreen.ClearScreen();
                    Digimon.sprite.projectileSprite.SpriteX = 8;
                    Digimon.sprite.projectileSprite.SpriteY = 0;
                    _animationTick.Interval = TimeSpan.FromMilliseconds(55);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 7:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -1);
                    break;

                case 8:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -2);
                    break;

                case 9:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -1);
                    break;

                case 10:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, 0);
                    break;

                case 11:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                case 12:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                // Start shooting the digimon's projectile
                case 13:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, true, Digimon.sprite.SpriteX - 1, 0);
                    Sounds.PlaySound(Sound.Attack);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    break;


                case 14:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, true, Digimon.sprite.SpriteX - 1, 0);
                    if (powerUp >= 11)
                    {
                        SetupSecondProjectile(Digimon);
                    }
                    else
                    {
                        secondProjectile = null;
                    }
                    break;

                // start 2nd screen: draw brick wall and move the projectiles position
                case 35:
                    Game.pixelScreen.ClearScreen();
                    BrickWall = SpriteImages.FullBrickWallSprite();
                    Game.pixelScreen.DrawSprite(BrickWall, 0, 0, false);
                    Digimon.sprite.projectileSprite.SpriteX = Game.pixelScreen.NumberOfXPixels + 2;
                    if (secondProjectile != null)
                    {
                        secondProjectile.SpriteX = Game.pixelScreen.NumberOfXPixels + 2;
                    }
                    break;

                // Projectile hits wall
                case 61:
                    Sounds.PlaySound(Sound.Damage);
                    Game.pixelScreen.ClearSprite(BrickWall);
                    Game.pixelScreen.ClearSprite(Digimon.sprite.projectileSprite);
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
                Game.pixelScreen.ClearSprite(Digimon.sprite.projectileSprite);
                Digimon.sprite.projectileSprite.SpriteX--;
                Game.pixelScreen.DrawSprite(Digimon.sprite.projectileSprite, Digimon.sprite.projectileSprite.SpriteX, 8 - Digimon.sprite.projectileSprite.SpriteHeight, false);
                if (powerUp >= 11)
                {
                    Game.pixelScreen.ClearSprite(secondProjectile);
                    secondProjectile.SpriteX--;
                    Game.pixelScreen.DrawSprite(secondProjectile, secondProjectile.SpriteX, secondProjectile.SpriteY, false);
                }
            }
        }

        public void SetupAngry()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            Digimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.frame1Width / 2) - 16;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX, 0);
            AngryMark = SpriteImages.AngryMarkSmallSprite();
            Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
            Sounds.PlaySound(Sound.Lose);
            animation = AnimationNo.Angry;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayAngry()
        {
            switch (animationCounter)
            {
                default:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Angry, false, true, Digimon.sprite.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkBigSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 7, 0, false);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkSmallSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Angry, false, true, Digimon.sprite.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkBigSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 7, 0, false);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkSmallSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Angry, false, true, Digimon.sprite.SpriteX, 0);
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
            Digimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.frame1Width / 2) - 16;
            Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX, 0);
            Sounds.PlaySound(Sound.Win);
            animation = AnimationNo.Happy;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        // Returns the X value required to position a sprite in the middle of the screen
        private int GetMiddleX(int spriteWidth)
        {
            int middleX = Game.pixelScreen.NumberOfXPixels - (spriteWidth / 2) - 16;
            return middleX;
        }

        private void PlayHappy()
        {
            switch (animationCounter)
            {
                default:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, GetMiddleX(Digimon.sprite.happyFrameWidth), 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    Game.pixelScreen.ClearSprite(HappyMark);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, GetMiddleX(Digimon.sprite.happyFrameWidth), 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    Game.pixelScreen.ClearSprite(HappyMark);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, GetMiddleX(Digimon.sprite.happyFrameWidth), 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 6:
                    //ResetAnimations();
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


        public Digimon Opponent;
        //SpriteImages.Betamon();
        private Sprite secondProjectile;
        int hitPower, doubleAttack, damage;
        Random rnd = new Random();
        public void SetupBattleCup()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            int startX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.frame1Width / 2) - 8;
            IsinAnimation = true;
            Opponent = new Digimon(Game, DigimonId.Greymon);
            Opponent.sprite.SpriteX = 8 - (Opponent.sprite.frame1Width / 2);
            Digimon.sprite.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX, 0);
            Sounds.PlaySound(Sound.Start);
            animation = AnimationNo.Battle;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayBattleAnimation()
        {
            switch (animationCounter)
            {
                // First screen show both digimon
                case 0:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Attack, true, true, Opponent.sprite.SpriteX, 0);

                    break;

                case 1:
                    Game.pixelScreen.ClearSprite(Opponent.sprite);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    Game.pixelScreen.ClearSprite(Digimon.sprite);
                    Game.pixelScreen.DrawSprite(SpriteImages.BattleSprite(), 0, 0, false);
                    break;

                // start powering up
                case 6:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 7:
                    Game.pixelScreen.DrawSprite(ExplainationMark, 8, 0, false);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, true, Digimon.sprite.SpriteX, 0);
                    Sounds.PlaySound(Sound.Step);
                    break;

                case 8:
                    Game.pixelScreen.ClearSprite(ExplainationMark);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX, 0);
                    powerUpReady = true;
                    IsinAnimation = false;
                    Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - 2, false);
                    break;
                
                // jump the digimon back and prepair to attack
                case 13:
                    IsinAnimation = true;
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 14:
                    animationCounter = -1;
                    animation = AnimationNo.Attack;
                    break;
                
            }

            
        }

        private void SetupSecondProjectile(Digimon digimon)
        {
            secondProjectile = new Sprite();
            secondProjectile.sprite = digimon.sprite.projectileSprite.sprite;
            secondProjectile.SpriteHeight = digimon.sprite.projectileSprite.SpriteHeight;
            secondProjectile.SpriteWidth = digimon.sprite.projectileSprite.SpriteWidth;
            secondProjectile.SpriteX = 8;
            secondProjectile.SpriteY = 8;
        }

        private void DigimonAttack()
        {
            animation = AnimationNo.Attack;
            switch (animationCounter)
            {
                case 0:
                    _animationTick.Interval = TimeSpan.FromMilliseconds(90);
                    Game.pixelScreen.ClearScreen();

                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -1);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -2);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -1);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    break;

                case 10:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                case 11:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                // Start attacking
                case 12:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Attack, false, true, Digimon.sprite.SpriteX, 0);
                    Digimon.sprite.projectileSprite.SpriteX = 8;
                    Digimon.sprite.projectileSprite.SpriteY = 0;
                    //_animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    Sounds.PlaySound(Sound.Attack);
                    hitPower = rnd.Next(1, 100);
                    doubleAttack = rnd.Next(1, 100);

                    // shoot two projectiles
                    if (doubleAttack > 50)
                    {
                        SetupSecondProjectile(Digimon);
                        damage = Digimon.hitDamage * 2;
                    }
                    else
                    {
                        secondProjectile = null;
                        damage = Digimon.hitDamage;
                    }
                    // ROLL
                    break;

                // oponent screen start
                case 31:
                    Digimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.frame1Width / 2) - 8; // reset owned digimon's X coordinant
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, 0, 0);
                    DrawHealthBar(Opponent);
                    Digimon.sprite.projectileSprite.SpriteX = Game.pixelScreen.NumberOfXPixels + Digimon.sprite.projectileSprite.SpriteWidth;
                    if (secondProjectile != null)
                    {
                        secondProjectile.SpriteX = Game.pixelScreen.NumberOfXPixels + secondProjectile.SpriteWidth;
                    }
                    break;

                // start oponent Hit or Dodge.
                case 54:
                    // if hit
                    animationCounter = -1;
                    if (hitPower > 40)
                    {
                        animation = AnimationNo.OpponentDamaged;
                        //Opponent.currenthealth -= 500;
                    }
                    else
                    {
                        animation = AnimationNo.OpponentDodge;
                    }
                    break;
            }
            if (animationCounter > 12 && animationCounter < 54)
            {
                if (secondProjectile != null)
                {
                    Game.pixelScreen.ClearSprite(secondProjectile);
                    secondProjectile.SpriteX--;
                    Game.pixelScreen.DrawSprite(secondProjectile, secondProjectile.SpriteX, secondProjectile.SpriteY, false);
                    if (animationCounter > 31)
                    {
                        DrawHealthBar(Opponent);
                    }
                }
                Game.pixelScreen.ClearSprite(Digimon.sprite.projectileSprite);
                Digimon.sprite.projectileSprite.SpriteX--;
                Game.pixelScreen.DrawSprite(Digimon.sprite.projectileSprite, Digimon.sprite.projectileSprite.SpriteX, 8 - Digimon.sprite.projectileSprite.SpriteHeight, false);
            }
        }

        public void OpponentDigimonAttack()
        {
            animation = AnimationNo.OponentAttack;
            switch (animationCounter)
            {
                case 0:
                    _animationTick.Interval = TimeSpan.FromMilliseconds(90);
                    Game.pixelScreen.ClearScreen();

                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, -1);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, -2);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, -1);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    break;

                case 10:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX + 1, 0);
                    break;

                case 11:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX + 1, 0);
                    break;

                // Start attacking
                case 12:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Attack, true, true, Opponent.sprite.SpriteX, 0);
                    Opponent.sprite.projectileSprite.SpriteX = 16;
                    Opponent.sprite.projectileSprite.SpriteY = 0;
                    //_animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    Sounds.PlaySound(Sound.Attack);
                    hitPower = rnd.Next(1, 100);
                    doubleAttack = rnd.Next(1, 100);

                    // shoot two projectiles
                    if (doubleAttack > 50)
                    {
                        SetupSecondProjectile(Opponent);
                        secondProjectile.SpriteX = 16;
                        damage = Opponent.hitDamage * 2;
                    }
                    else
                    {
                        secondProjectile = null;
                        damage = Opponent.hitDamage;
                    }
                    // ROLL
                    break;

                // own digimon screen start
                case 31:
                    Opponent.sprite.SpriteX = 8 - (Opponent.sprite.frame1Width / 2); // reset oponents digimon X Coordanints
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX, 0);
                    DrawHealthBar(Digimon);
                    Opponent.sprite.projectileSprite.SpriteX = -Opponent.sprite.projectileSprite.SpriteWidth - 8;
                    if (secondProjectile != null)
                    {
                        secondProjectile.SpriteX = -Opponent.sprite.projectileSprite.SpriteWidth - 8;
                    }
                    break;

                // hit or Dodge start
                case 54:
                    animationCounter = -1;
                    if (hitPower > 40)
                    {
                        animation = AnimationNo.DigimonDamaged;
                        //Digimon.currenthealth -= 500;
                    }
                    else
                    {
                        animation = AnimationNo.DigimonDodge;
                    }
                    break;
            }

            if (animationCounter > 12 && animationCounter < 54)
            {
                if (secondProjectile != null)
                {
                    Game.pixelScreen.ClearSprite(secondProjectile);
                    secondProjectile.SpriteX++;
                    Game.pixelScreen.DrawSprite(secondProjectile, secondProjectile.SpriteX, secondProjectile.SpriteY, true);
                    if (animationCounter > 31)
                    {
                        DrawHealthBar(Digimon);
                    }
                }
                Game.pixelScreen.ClearSprite(Opponent.sprite.projectileSprite);
                Opponent.sprite.projectileSprite.SpriteX++;
                Game.pixelScreen.DrawSprite(Opponent.sprite.projectileSprite, Opponent.sprite.projectileSprite.SpriteX, 8 - Opponent.sprite.projectileSprite.SpriteHeight, true);
            }
        }

        private void DigimonDamaged()
        {
            switch (animationCounter)
            {
                case 0:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullSprite(), 0, 0, false);
                    Sounds.PlaySound(Sound.Damage);
                    //
                    break;

                case 5:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.WhiteSkullSprite(), 0, 0, false);
                    //
                    break;

                case 10:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Hurt1, false, true, Digimon.sprite.SpriteX, 0);
                    DrawHealthBar(Digimon);
                    break;

                case 15:
                    Digimon.currenthealth -= damage;
                    DrawHealthBar(Digimon);
                    break;

                case 20:
                    Digimon.currenthealth += damage;
                    DrawHealthBar(Digimon);
                    break;

                case 25:
                    Digimon.currenthealth -= damage;
                    DrawHealthBar(Digimon);
                    break;

                // stand digimon back up
                case 35:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX, 0);
                    if (Digimon.currenthealth < 1)
                    {
                        _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
                        animationCounter = -1;
                        animation = AnimationNo.Defeat;
                    }
                    
                    break;

                case 50:
                    if (Digimon.currenthealth > 0)
                    {
                        animationCounter = -1;
                        animation = AnimationNo.Attack;
                    }
                    
                    break;
            }
        }

        private void OpponentDamaged()
        {
            switch (animationCounter)
            {
                case 0:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullSprite(), 0, 0, false);
                    Sounds.PlaySound(Sound.Damage);
                    //
                    break;

                case 5:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawSprite(SpriteImages.WhiteSkullSprite(), 0, 0, false);
                    //
                    break;

                case 10:
                    // if hit
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Hurt1, true, true, Opponent.sprite.SpriteX, 0);
                    DrawHealthBar(Opponent);
                    //
                    break;

                case 15:
                    Opponent.currenthealth -= damage;
                    DrawHealthBar(Opponent);
                    break;

                case 20:
                    Opponent.currenthealth += damage;
                    DrawHealthBar(Opponent);
                    break;

                case 25:
                    Opponent.currenthealth -= damage;
                    DrawHealthBar(Opponent);
                    break;

                case 35:
                    if (Opponent.currenthealth > 0)
                    {
                        Game.pixelScreen.ClearScreen();
                        Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX, 0);
                    }
                    break;

                case 50:
                    if (Opponent.currenthealth > 0)
                    {
                        animationCounter = -1;
                        animation = AnimationNo.OponentAttack;
                    }
                    else
                    {
                        animationCounter = -1;
                        animation = AnimationNo.Victory;
                    }
                    break;
            }
        }

        private void DigimonDodge()
        {
            switch (animationCounter)
            {
                case 0:
                    _animationTick.Interval = TimeSpan.FromMilliseconds(80);
                    Game.pixelScreen.ClearScreen();
                    Sounds.PlaySound(Sound.Step);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -1);
                    DrawHealthBar(Digimon);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -2);
                    DrawHealthBar(Digimon);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, -1);
                    DrawHealthBar(Digimon);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX + 1, 0);
                    DrawHealthBar(Digimon);
                    break;

                case 12:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                case 14:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                case 16:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                case 18:
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk2, false, true, Digimon.sprite.SpriteX - 1, 0);
                    break;

                case 24:
                    animationCounter = -1;
                    animation = AnimationNo.Attack;
                    break;
            }
        }

        private void OpponentDigimonDodge()
        {
            switch (animationCounter)
            {
                case 0:
                    _animationTick.Interval = TimeSpan.FromMilliseconds(80);
                    Game.pixelScreen.ClearScreen();
                    Sounds.PlaySound(Sound.Step);
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, -1);
                    DrawHealthBar(Opponent);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, -2);
                    DrawHealthBar(Opponent);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, -1);
                    DrawHealthBar(Opponent);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX - 1, 0);
                    DrawHealthBar(Opponent);
                    break;

                case 12:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk, true, true, Opponent.sprite.SpriteX + 1, 0);
                    break;

                case 14:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX + 1, 0);
                    break;

                case 16:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk, true, true, Opponent.sprite.SpriteX + 1, 0);
                    break;

                case 18:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX + 1, 0);
                    break;

                case 24:
                    animationCounter = -1;
                    animation = AnimationNo.OponentAttack;
                    break;
            }
        }

        // Draw health bar and show amount of damage taken, each bar is represented by the digimon's max health divided by 10
        private void DrawHealthBar(Digimon digimonHealth)
        {
            int damageTaken = digimonHealth.maxHealth - digimonHealth.currenthealth;
            Game.pixelScreen.DrawSprite(SpriteImages.HealthBarSprite(), 0, Game.pixelScreen.NumberOfYPixels - 4, false);
            for (int i = 0, damageTest = digimonHealth.maxHealth / 10, drawX = 1; i < 10; i++, damageTest += digimonHealth.maxHealth / 10, drawX += 3)
            {
                if (damageTaken > damageTest)
                {
                    Game.pixelScreen.DrawSprite(SpriteImages.BarSprite(), drawX, Game.pixelScreen.NumberOfYPixels - 3, false);
                }
                if (digimonHealth.currenthealth < 1)
                {
                    Game.pixelScreen.DrawSprite(SpriteImages.BarSprite(), 28, Game.pixelScreen.NumberOfYPixels - 3, false);
                    Game.pixelScreen.DrawSprite(SpriteImages.BarSprite(), 30, Game.pixelScreen.NumberOfYPixels - 3, false);
                }

            }
        }

        private void DrawVictoryMarks()
        {
            Game.pixelScreen.DrawSprite(SpriteImages.HappyMarkSprite(), Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
            Game.pixelScreen.DrawSprite(SpriteImages.HappyMarkSprite(), Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, Game.pixelScreen.NumberOfYPixels - HappyMark.SpriteHeight, false);
            Game.pixelScreen.DrawSprite(SpriteImages.HappyMarkSprite(), 0, 0, false);
            Game.pixelScreen.DrawSprite(SpriteImages.HappyMarkSprite(), 0, Game.pixelScreen.NumberOfYPixels - HappyMark.SpriteHeight, false);
        }

        private void PlayVictory()
        {
            switch (animationCounter)
            {
                case 0:
                    Game.pixelScreen.ClearScreen();
                    Digimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.frame1Width / 2) - 16;
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
                    break;

                case 1:
                    Sounds.PlaySound(Sound.Win);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, Digimon.sprite.SpriteX, 0);
                    DrawVictoryMarks();
                    break;

                case 2:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    Sounds.PlaySound(Sound.Win);
                    DrawVictoryMarks();
                    break;

                case 4:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Happy, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 5:
                    Sounds.PlaySound(Sound.Win);
                    DrawVictoryMarks();
                    break;

                case 8:
                    Game.resetMainScreen();
                    break;
            }
        }

        private void DrawDefeatMarks()
        {
            Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullMarkSprite(), Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth + 1, 1, false);
            Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullMarkSprite(), Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth + 1, Game.pixelScreen.NumberOfYPixels - HappyMark.SpriteHeight + 1, false);
            Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullMarkSprite(), 0, 1, false);
            Game.pixelScreen.DrawSprite(SpriteImages.BlackSkullMarkSprite(), 0, Game.pixelScreen.NumberOfYPixels - HappyMark.SpriteHeight + 1, false);
        }

        private void PlayDefeat()
        {
            switch (animationCounter)
            {
                case 0:
                    Game.pixelScreen.ClearScreen();
                    Digimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Digimon.sprite.hurt1FrameWidth / 2) - 16;
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, Digimon.sprite.SpriteX, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed + 260); // slowdown timer to sync the sounds
                    break;

                case 1:
                    Sounds.PlaySound(Sound.Lose);
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Hurt1, false, true, Digimon.sprite.SpriteX, 0);
                    DrawDefeatMarks();
                    break;

                case 2:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Hurt1, false, true, Digimon.sprite.SpriteX, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed); // speed timer back up to normal
                    break;

                case 3:
                    Sounds.PlaySound(Sound.Defeat);
                    DrawDefeatMarks();
                    break;

                case 4:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Hurt1, false, true, Digimon.sprite.SpriteX, 0);
                    break;

                case 5:
                    Sounds.PlaySound(Sound.Defeat);
                    DrawDefeatMarks();
                    break;

                case 7:
                    _animationTick.Interval = TimeSpan.FromMilliseconds(25);
                    break;

                case 8:
                    Game.pixelScreen.PanScreen(-1, 0, true);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 31, 0, false);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 31, Game.pixelScreen.NumberOfYPixels - 8, false);
                    break;

                case 9:
                    Game.pixelScreen.PanScreen(-1, 0, true);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 30, 0, false);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 30, Game.pixelScreen.NumberOfYPixels - 8, false);
                    break;

                case 10:
                    Game.pixelScreen.PanScreen(-1, 0, true);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 29, 0, false);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 29, Game.pixelScreen.NumberOfYPixels - 8, false);
                    break;

                case 11:
                    Game.pixelScreen.PanScreen(-1, 0, true);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 28, 0, false);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 28, Game.pixelScreen.NumberOfYPixels - 8, false);
                    break;

                case 12:
                    Game.pixelScreen.PanScreen(-1, 0, true);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 27, 0, false);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 27, Game.pixelScreen.NumberOfYPixels - 8, false);
                    break;

                case 13:
                    Game.pixelScreen.PanScreen(-1, 0, true);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 26, 0, false);
                    Game.pixelScreen.DrawSprite(SpriteImages.WaveProjectileSprite(), 26, Game.pixelScreen.NumberOfYPixels - 8, false);
                    break;

                case 55:
                    Game.resetMainScreen();
                    break;
            }

            if (animationCounter > 13 && animationCounter < 55)
            {
                Game.pixelScreen.PanScreen(-1, 0, true);
            }
        }

        Digimon evolvedDigimon;

        public void setupDigivolve(Digimon newDigimon)
        {
            animation = AnimationNo.Digivolve;
            evolvedDigimon = newDigimon;
            _animationTick.Interval = TimeSpan.FromMilliseconds(120);
            _animationTick.Start();
        }

        public bool isEvolving = false;
        public void PlayDigivolve()
        {
            switch (animationCounter)
            {
                case 0:
                    isEvolving = true;
                    Sounds.PlaySound(Sound.Digivolve);
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, true, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 1:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 2:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 3:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 4:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 5:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 6:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 7:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Digimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                // Start evolved digimon frames
                case 8:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 9:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 10:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 11:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 12:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 13:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    break;

                case 14:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Digimon.sprite.frame1Width), 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
                    break;

                case 17:
                    Game.currentDigimon.SetupDigimon(evolvedDigimon.digimonID);
                    Game.resetMainScreen();
                    break;
            }
        }

    }
}
