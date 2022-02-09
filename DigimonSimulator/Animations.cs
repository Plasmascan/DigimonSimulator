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
        BattleCup,
        Attack,
        OponentAttack,
        DigimonDamaged,
        OpponentDamaged,
        DigimonDodge,
        OpponentDodge,
        Victory,
        Defeat,
        Digivolve,
        EggHatch,
        Flush,
        Battle
    }

    public class Animations
    {
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
        private Sprite[] Dungs;
        public bool IsinAnimation = false;
        public bool powerUpReady = false;
        public bool isInBattle = false;
        public readonly DispatcherTimer _animationTick = new DispatcherTimer(DispatcherPriority.Send);
        public readonly DispatcherTimer _digimonStateTimer = new DispatcherTimer(DispatcherPriority.Normal);
        public AnimationNo animation = AnimationNo.NoAnimation;

        public Animations(DigimonGame game)
        {
            Game = game;
            _animationTick.Tick += _animation_Tick;
            _digimonStateTimer.Tick += _digimonStateTimer_Tick;
            _digimonStateTimer.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);

            Dungs = new Sprite[4];
            for (int i = 0; i < 4; i++)
            {
                Dungs[i] = SpriteImages.DungSprite();
            }

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

            else if (animation == AnimationNo.BattleCup)
            {
                PlayBattleCupAnimation();
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
            else if (animation == AnimationNo.Digivolve)
            {
                PlayDigivolve();
            }
            else if (animation == AnimationNo.Flush)
            {
                PlayFlushAnimation();
            }

            else if (animation == AnimationNo.EggHatch)
            {
                PlayEggHatching();
            }

            else if (animation == AnimationNo.Battle)
            {
                PlayBattle();
            }
        }

        private int XOffset = 0;
        private bool switchDung;
        public void SetupDung()
        {
            if (Game.numberOfDung == 1)
            {
                Dungs[0].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth;
                Dungs[0].SpriteY = Game.pixelScreen.NumberOfYPixels - Dungs[0].SpriteHeight;
                XOffset = Dungs[0].SpriteWidth;
            }

            else if (Game.numberOfDung == 2)
            {
                Dungs[0].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth;
                Dungs[0].SpriteY = Game.pixelScreen.NumberOfYPixels - Dungs[0].SpriteHeight;

                Dungs[1].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth;
                Dungs[1].SpriteY = 0;

                XOffset = Dungs[0].SpriteWidth;
            }

            else if (Game.numberOfDung == 3)
            {

                Dungs[0].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth * 2;
                Dungs[0].SpriteY = Game.pixelScreen.NumberOfYPixels - Dungs[0].SpriteHeight;

                Dungs[1].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth * 2;
                Dungs[1].SpriteY = 0;

                Dungs[2].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth;
                Dungs[2].SpriteY = Game.pixelScreen.NumberOfYPixels - Dungs[0].SpriteHeight;

                XOffset = Dungs[0].SpriteWidth * 2;
            }

            else if (Game.numberOfDung == 4)
            {
                Dungs[0].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth * 2;
                Dungs[0].SpriteY = Game.pixelScreen.NumberOfYPixels - Dungs[0].SpriteHeight;

                Dungs[1].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth * 2;
                Dungs[1].SpriteY = 0;

                Dungs[2].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth;
                Dungs[2].SpriteY = Game.pixelScreen.NumberOfYPixels - Dungs[0].SpriteHeight;

                Dungs[3].SpriteX = Game.pixelScreen.NumberOfXPixels - Dungs[0].SpriteWidth;
                Dungs[3].SpriteY = 0;


                XOffset = Dungs[0].SpriteWidth * 2;
            }
        }

        public void StartDigimonStateAnimation()
        {
            StepCounter = 0;
            switchDung = false;
            int maxFrameWidth;

            if (Game.numberOfDung == 0)
            {
                XOffset = 0;
            }
            else
            {
                SetupDung();
            }
            SetupDung();

            if (Game.isEgg)
            {
                Game.currentDigimon.sprite.SpriteX = GetMiddleX(Game.currentDigimon.sprite.frame1Width) - XOffset;
            }
            else if (!Game.currentDigimon.isAsleep && !Game.currentDigimon.isHurt)
            {
                // Get the biggest walk frame width
                if (Game.currentDigimon.sprite.frame2Width > Game.currentDigimon.sprite.frame1Width)
                {
                    maxFrameWidth = Game.currentDigimon.sprite.frame2Width;
                }
                else
                {
                    maxFrameWidth = Game.currentDigimon.sprite.frame1Width;
                }

                Game.pixelScreen.ClearSprite(Game.currentDigimon.sprite);
                Game.currentDigimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (maxFrameWidth / 2) - 18 - XOffset;
            }
            else 
            {
                Game.pixelScreen.ClearSprite(Game.currentDigimon.sprite);
                Game.currentDigimon.sprite.SpriteX = GetMiddleX(Game.currentDigimon.sprite.hurt1FrameWidth) - XOffset;
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
            Game.currentDigimon.currenthealth = Game.currentDigimon.maxHealth;
            animation = AnimationNo.NoAnimation;
            BrickWall = SpriteImages.FullBrickWallSprite();
            IsinAnimation = false;
            powerUpReady = false;
            secondProjectile = null;
            isEvolving = false;
            isInBattle = false;
        }

        private Sprite ZSprite = new Sprite();
        private Sprite BedSprite = SpriteImages.BedSprite();
        private Sprite hurtSkull = new Sprite();
        public void StepDigimon()
        {
            Sprite tempDung;
            if (Game.numberOfDung > 0)
            {
                switchDung = !switchDung;
                for (int i = 0; i < Game.numberOfDung; i++)
                {
                    Game.pixelScreen.ClearSprite(Dungs[i]);
                    
                    // switch between dung frame 1 and 2
                    if (switchDung)
                    {
                        tempDung = SpriteImages.Dung2Sprite();
                    }
                    else
                    {
                        tempDung = SpriteImages.DungSprite();
                    }

                    Dungs[i].sprite = tempDung.sprite;
                    Game.pixelScreen.DrawSprite(Dungs[i], Dungs[i].SpriteX, Dungs[i].SpriteY, false);
                }
            }

            if (Game.isEgg)
            {
                
                if (StepCounter == 0)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    StepCounter++;

                }
                else if (StepCounter == 1)
                {
                    
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, GetMiddleX(Game.currentDigimon.sprite.frame2Width), 0);
                    StepCounter = 0;
                }
                return;
            }

            #region Animation
            else if (!Game.currentDigimon.isAsleep && !Game.currentDigimon.isHurt)
            {
                if (StepCounter == 0 || StepCounter == 1)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, -2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 2)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 3)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, -2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 4)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, -1 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 5)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, 1 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 6)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, 0 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 7)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, 0 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 8)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, true, true, 0 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 9)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 10)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, 3 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 11)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 12)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 13)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, true, true, 1 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 14)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, 0 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 15)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, -4 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 16)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, 0 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 17)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, 3 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 18)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 19)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, -1 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 20)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 21)
                {

                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 22)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, -2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 23)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, true, true, 2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 24)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, -2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 25)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, -2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 26)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, -3 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 27)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, -2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 28)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, -2 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 29)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, -1 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 30)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, true, true, 0 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 31)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, true, true, 3 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;
                    return;
                }
                if (StepCounter == 32)
                {
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, -1 + Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter = 0;
                    return;
                }
            }

            if (Game.currentDigimon.isHurt && !Game.currentDigimon.isInBed)
            {
                if (StepCounter == 0)
                {
                    Game.pixelScreen.ClearSprite(hurtSkull);
                    hurtSkull = SpriteImages.WhiteSkullMarkSprite();
                    Game.pixelScreen.DrawSprite(hurtSkull, 25 - XOffset, 1, false);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter++;

                }
                else if (StepCounter == 1)
                {
                    Game.pixelScreen.ClearSprite(hurtSkull);
                    hurtSkull = SpriteImages.BlackSkullMarkSprite();
                    Game.pixelScreen.DrawSprite(hurtSkull, 25 - XOffset, 1, false);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    StepCounter = 0;
                }
            }

            #endregion
            else if (Game.currentDigimon.isAsleep)
            {
                if (StepCounter == 0)
                {
                    Game.pixelScreen.ClearSprite(ZSprite);

                    if (Game.currentDigimon.isInBed)
                    {
                        Game.pixelScreen.ClearSprite(BedSprite);
                    }

                    ZSprite = SpriteImages.BigZSprite();
                    Game.pixelScreen.DrawSprite(ZSprite, 24 - XOffset, 2, false);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, Game.currentDigimon.sprite.SpriteX, 0);

                    // draw bed over sprite
                    if (Game.currentDigimon.isInBed)
                    {
                        Game.pixelScreen.DrawSprite(BedSprite, 7 - XOffset, Game.pixelScreen.NumberOfYPixels - BedSprite.SpriteHeight, false);
                    }

                    StepCounter++;
                }
                else if (StepCounter == 1)
                {
                    Game.pixelScreen.ClearSprite(ZSprite);

                    if (Game.currentDigimon.isInBed)
                    {
                        Game.pixelScreen.ClearSprite(BedSprite);
                    }

                    ZSprite = SpriteImages.SmallZSprite();
                    Game.pixelScreen.DrawSprite(ZSprite, 24 - XOffset, 2, false);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, Game.currentDigimon.sprite.SpriteX, 0);

                    // Draw bed over sprite
                    if (Game.currentDigimon.isInBed)
                    {
                        Game.pixelScreen.DrawSprite(BedSprite, 8 - XOffset, Game.pixelScreen.NumberOfYPixels - BedSprite.SpriteHeight, false);
                    }

                    StepCounter = 0;
                }
                
            }
        }

        public void SetupEatAnimation(int choice)
        {
            int addHungerAmounter = Game.currentDigimon.maxHunger / 15, addStrengthAmount = Game.currentDigimon.maxStrength / 15;
            Game.currentDigimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 16;
            Game.pixelScreen.ClearScreen();

            // setup the rejection animation when trying to eat while the digimon is full
            if (choice == 0 && Game.currentDigimon.currentHunger > Game.currentDigimon.maxHunger)
            {
                // Add to overfeed amount and disable overfeeding
                if (Game.currentDigimon.isOverfeedable)
                {
                    Game.currentDigimon.isOverfeedable = false;
                    Game.currentDigimon.timesOverfed++;
                }
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
                Game.currentDigimon.currentHunger += addHungerAmounter;
            }
            else
            {
                EatItemFull = SpriteImages.FullVitaminSprite();
                EatItemHalf = SpriteImages.HalfVitaminSprite();
                EatItemEmpty = SpriteImages.EmptyVitaminSprite();
                if (Game.currentDigimon.currentStrength < Game.currentDigimon.maxStrength + Game.currentDigimon.maxStrength / 12)
                {
                    Game.currentDigimon.currentStrength += addStrengthAmount;
                }
            }

            Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Eat1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
            Game.pixelScreen.DrawSprite(EatItemFull, 0, 0, false);
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();

        }

        public void SetupRejectAnimation()
        {
            animation = AnimationNo.Reject;
            IsinAnimation = true;
            Game.pixelScreen.ClearScreen();
            Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Reject, true, true, GetMiddleX(Game.currentDigimon.sprite.rejectFrameWidth), 0);
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayRejectAnimation()
        {
            switch (animationCounter)
            {
                default:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Reject, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Reject, true, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Reject, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    ResetAnimations();
                    Game.CurrentSubMenu = 0;
                    if (Game.CurrentScreen == MenuScreen.FeedScreen)
                    {
                        MenuScreens.DrawFeedScreen(Game, Game.SelectedSubMenuNo);
                    }
                    else
                    {
                        Game.resetMainScreen();
                    }
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
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Eat2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Eat1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    Game.pixelScreen.ClearSprite(EatItemFull);
                    Game.pixelScreen.DrawSprite(EatItemHalf, 0, Game.pixelScreen.NumberOfYPixels - EatItemHalf.SpriteHeight, false);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Eat2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Eat1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
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
            Game.currentDigimon.sprite.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, startX, 0);
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
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    Sounds.PlaySound(Sound.Step);
                    break;

                case 1:
                    Game.pixelScreen.ClearSprite(ExplainationMark);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    powerUpReady = true;
                    Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - 2, false);
                    break;

                // Jump the digimon backwards and then move forwards and attack
                case 6:
                    IsinAnimation = true;
                    Game.pixelScreen.ClearScreen();
                    Game.currentDigimon.sprite.projectileSprite.SpriteX = 8;
                    Game.currentDigimon.sprite.projectileSprite.SpriteY = 0;
                    _animationTick.Interval = TimeSpan.FromMilliseconds(55);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 7:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -1);
                    break;

                case 8:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -2);
                    break;

                case 9:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -1);
                    break;

                case 10:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, 0);
                    break;

                case 11:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                case 12:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                // Start shooting the digimon's projectile
                case 13:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    Sounds.PlaySound(Sound.Attack);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    break;


                case 14:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    if (powerUp >= 11)
                    {
                        SetupSecondProjectile(Game.currentDigimon);
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
                    Game.currentDigimon.sprite.projectileSprite.SpriteX = Game.pixelScreen.NumberOfXPixels + 2;
                    if (secondProjectile != null)
                    {
                        secondProjectile.SpriteX = Game.pixelScreen.NumberOfXPixels + 2;
                    }
                    break;

                // Projectile hits wall
                case 61:
                    Sounds.PlaySound(Sound.Damage);
                    Game.pixelScreen.ClearSprite(BrickWall);
                    Game.pixelScreen.ClearSprite(Game.currentDigimon.sprite.projectileSprite);
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
                    Game.currentDigimon.LoseWeight(1);
                    if (powerUp >= 11)
                    {
                        SetupHappy();
                        Game.currentDigimon.timesTrained++;
                        Game.currentDigimon.AddStrength();
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
                Game.pixelScreen.ClearSprite(Game.currentDigimon.sprite.projectileSprite);
                Game.currentDigimon.sprite.projectileSprite.SpriteX--;
                Game.pixelScreen.DrawSprite(Game.currentDigimon.sprite.projectileSprite, Game.currentDigimon.sprite.projectileSprite.SpriteX, 8 - Game.currentDigimon.sprite.projectileSprite.SpriteHeight, false);
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
            IsinAnimation = true;
            Game.currentDigimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 16;
            Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, Game.currentDigimon.sprite.SpriteX, 0);
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
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Angry, false, true, GetMiddleX(Game.currentDigimon.sprite.angryFrameWidth), 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkBigSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 7, 0, false);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkSmallSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Angry, false, true, GetMiddleX(Game.currentDigimon.sprite.angryFrameWidth), 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkBigSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 7, 0, false);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    Game.pixelScreen.ClearSprite(AngryMark);
                    AngryMark = SpriteImages.AngryMarkSmallSprite();
                    Game.pixelScreen.DrawSprite(AngryMark, Game.pixelScreen.NumberOfXPixels - 6, 5, false);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Angry, false, true, GetMiddleX(Game.currentDigimon.sprite.angryFrameWidth), 0);
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
            IsinAnimation = true;
            Game.currentDigimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 16;
            Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, Game.currentDigimon.sprite.SpriteX, 0);
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
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, GetMiddleX(Game.currentDigimon.sprite.happyFrameWidth), 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    Game.pixelScreen.ClearSprite(HappyMark);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, GetMiddleX(Game.currentDigimon.sprite.happyFrameWidth), 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    Game.pixelScreen.ClearSprite(HappyMark);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, GetMiddleX(Game.currentDigimon.sprite.happyFrameWidth), 0);
                    Game.pixelScreen.DrawSprite(HappyMark, Game.pixelScreen.NumberOfXPixels - HappyMark.SpriteWidth, 0, false);
                    break;

                case 6:
                    //ResetAnimations();
                    Game.resetMainScreen();
                    break;
            }
        }

        private Sprite FlushSprite;
        public void SetupFlushAnimation()
        {
            ResetAnimations();
            IsinAnimation = true;
            FlushSprite = SpriteImages.FlushSprite();
            animation = AnimationNo.Flush;
            Game.pixelScreen.DrawSprite(FlushSprite, Game.pixelScreen.NumberOfXPixels - XOffset, -FlushSprite.SpriteHeight, false);
            _animationTick.Interval = TimeSpan.FromMilliseconds(35);
            _animationTick.Start();
        }

        private void MoveFlush()
        {
            

            for (int i = 0; i < Game.numberOfDung; i++)
            {
                if (Game.numberOfDung == 1)
                {
                    if (animationCounter > 7)
                    {
                        Game.pixelScreen.ClearSprite(Dungs[i]);
                        Game.pixelScreen.DrawSprite(Dungs[i], Dungs[i].SpriteX, Dungs[i].SpriteY + 1, false);
                    }
                }
                else
                {
                    Game.pixelScreen.ClearSprite(Dungs[i]);
                    Game.pixelScreen.DrawSprite(Dungs[i], Dungs[i].SpriteX, Dungs[i].SpriteY + 1, false);
                }
                
            }
            Game.pixelScreen.ClearSprite(FlushSprite);
            Game.pixelScreen.DrawSprite(FlushSprite, FlushSprite.SpriteX, FlushSprite.SpriteY + 1, false);
        }

        private void PlayFlushAnimation()
        {
            if (animationCounter < 25)
            {
                MoveFlush();
            }
            else
            {
                Game.numberOfDung = 0;
                SetupHappy();
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
        //int hitPower, doubleAttack;
        int damage;

        //Random rnd = new Random();
        public BattleLogic Battle;
        public void SetupBattleCup()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            int startX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 8;
            IsinAnimation = true;
            Opponent = new Digimon(Game, DigimonId.Betamon);
            Battle = new BattleLogic(Game);
            Battle.GenerateBattle();
            Opponent = new Digimon(Game, DigimonId.Betamon);
            Opponent.currenthealth = Opponent.maxHealth;
            Opponent.sprite.SpriteX = 8 - (Opponent.sprite.frame1Width / 2);
            Game.currentDigimon.sprite.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX, 0);
            Sounds.PlaySound(Sound.Start);

            animation = AnimationNo.BattleCup;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        public void SetupMultiplayer()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            int startX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 8;
            IsinAnimation = true;
            Opponent.currenthealth = Opponent.maxHealth;
            Opponent.sprite.SpriteX = 8 - (Opponent.sprite.frame1Width / 2);
            Game.currentDigimon.sprite.SpriteX = startX;
            Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX, 0);
            Sounds.PlaySound(Sound.Start);
            animation = AnimationNo.BattleCup;
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        public void SetupBattle()
        {
            Game.pixelScreen.ClearScreen();
            ResetAnimations();
            int startX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 8;
            IsinAnimation = true;
            Game.currentDigimon.sprite.SpriteX = startX;
            animation = AnimationNo.Battle;
            Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
            Battle = new BattleLogic(Game);
            _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
            _animationTick.Start();
        }

        private void PlayBattle()
        {
            switch (animationCounter)
            {
                case 0:
                    Game.pixelScreen.DrawSprite(ExplainationMark, 8, 0, false);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    Sounds.PlaySound(Sound.Step);
                    break;

                case 1:
                    Game.pixelScreen.ClearSprite(ExplainationMark);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    powerUpReady = true;
                    IsinAnimation = false;
                    Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - 2, false);
                    break;

                case 6:
                    powerUpReady = false;
                    Game.pixelScreen.DrawSprite(SpriteImages.BattleSprite(), 0, 0, false);
                    animationCounter = -1;
                    _animationTick.Stop();
                    if (!Game.isHost)
                    {
                        Battle.ConnectBattle();
                    }
                    else
                    {
                        Battle.HostBattle();
                    }
                    
                    break;
            }
        }

        public void PlayBattleCupAnimation()
        {
            switch (animationCounter)
            {
                // First screen show both digimon
                case 0:
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Attack, true, true, Opponent.sprite.SpriteX, 0);

                    break;

                case 1:
                    Game.pixelScreen.ClearSprite(Opponent.sprite);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    Game.pixelScreen.ClearSprite(Game.currentDigimon.sprite);
                    Game.pixelScreen.DrawSprite(SpriteImages.BattleSprite(), 0, 0, false);
                    break;

                // start powering up
                case 6:
                    //Skip powerup for multiplayer
                    if (Game.CurrentScreen == MenuScreen.Battle)
                    {
                        // Set the host to have the first turn
                        if (Game.isHost)
                        {
                            Game.pixelScreen.ClearScreen();
                            Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                            animationCounter = -1;
                            animation = AnimationNo.Attack;
                            break;
                        }
                        else
                        {
                            Game.pixelScreen.ClearScreen();
                            Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, Opponent.sprite.SpriteX, 0);
                            animationCounter = -1;
                            animation = AnimationNo.OponentAttack;
                            break;
                        }
                    }
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 7:
                    Game.pixelScreen.DrawSprite(ExplainationMark, 8, 0, false);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    Sounds.PlaySound(Sound.Step);
                    break;

                case 8:
                    Game.pixelScreen.ClearSprite(ExplainationMark);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    powerUpReady = true;
                    IsinAnimation = false;
                    Game.pixelScreen.DrawSprite(SpriteImages.PowerUpSprite(), 9, Game.pixelScreen.NumberOfYPixels - 2, false);
                    break;
                
                // jump the digimon back and prepair to attack
                case 13:
                    IsinAnimation = true;
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX, 0);
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

                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -1);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -2);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -1);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    break;

                case 10:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                case 11:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                // Start attacking
                case 12:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Attack, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    Game.currentDigimon.sprite.projectileSprite.SpriteX = 8;
                    Game.currentDigimon.sprite.projectileSprite.SpriteY = 0;
                    //_animationTick.Interval = TimeSpan.FromMilliseconds(47);
                    Sounds.PlaySound(Sound.Attack);
                    //hitPower = rnd.Next(1, 100);
                    //doubleAttack = rnd.Next(1, 100);

                    // shoot two projectiles
                    if (Battle.turns[Battle.turnIndex].isDoubleShot)
                    {
                        SetupSecondProjectile(Game.currentDigimon);
                        damage = Game.currentDigimon.hitDamage * 2;
                    }
                    else
                    {
                        secondProjectile = null;
                        damage = Game.currentDigimon.hitDamage;
                    }
                    // ROLL
                    break;

                // oponent screen start
                case 31:
                    Game.currentDigimon.sprite.SpriteX = Game.pixelScreen.NumberOfXPixels - (Game.currentDigimon.sprite.frame1Width / 2) - 8; // reset owned digimon's X coordinant
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Opponent, SpriteFrame.Walk2, true, true, 0, 0);
                    DrawHealthBar(Opponent);
                    Game.currentDigimon.sprite.projectileSprite.SpriteX = Game.pixelScreen.NumberOfXPixels + Game.currentDigimon.sprite.projectileSprite.SpriteWidth;
                    if (secondProjectile != null)
                    {
                        secondProjectile.SpriteX = Game.pixelScreen.NumberOfXPixels + secondProjectile.SpriteWidth;
                    }
                    break;

                // start oponent Hit or Dodge.
                case 54:
                    // if hit
                    animationCounter = -1;
                    if (Battle.turns[Battle.turnIndex].isHit)
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
                Game.pixelScreen.ClearSprite(Game.currentDigimon.sprite.projectileSprite);
                Game.currentDigimon.sprite.projectileSprite.SpriteX--;
                Game.pixelScreen.DrawSprite(Game.currentDigimon.sprite.projectileSprite, Game.currentDigimon.sprite.projectileSprite.SpriteX, 8 - Game.currentDigimon.sprite.projectileSprite.SpriteHeight, false);
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
                    //hitPower = rnd.Next(1, 100);
                    //doubleAttack = rnd.Next(1, 100);

                    // shoot two projectiles
                    if (Battle.turns[Battle.turnIndex].isDoubleShot)
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
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    DrawHealthBar(Game.currentDigimon);
                    Opponent.sprite.projectileSprite.SpriteX = -Opponent.sprite.projectileSprite.SpriteWidth - 8;
                    if (secondProjectile != null)
                    {
                        secondProjectile.SpriteX = -Opponent.sprite.projectileSprite.SpriteWidth - 8;
                    }
                    break;

                // hit or Dodge start
                case 54:
                    animationCounter = -1;
                    if (Battle.turns[Battle.turnIndex].isHit)
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
                        DrawHealthBar(Game.currentDigimon);
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
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    DrawHealthBar(Game.currentDigimon);
                    break;

                case 15:
                    Game.currentDigimon.currenthealth -= damage;
                    DrawHealthBar(Game.currentDigimon);
                    break;

                case 20:
                    Game.currentDigimon.currenthealth += damage;
                    DrawHealthBar(Game.currentDigimon);
                    break;

                case 25:
                    Game.currentDigimon.currenthealth -= damage;
                    DrawHealthBar(Game.currentDigimon);
                    break;

                // stand digimon back up
                case 35:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    if (Game.currentDigimon.currenthealth < 1)
                    {
                        _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
                        animationCounter = -1;
                        animation = AnimationNo.Defeat;
                        Game.currentDigimon.AddBattleResult(false);
                    }
                    
                    break;

                case 50:
                    if (Battle.turns[Battle.turnIndex].isBattleEnded)
                    {
                        if (Game.currentDigimon.currenthealth > Opponent.currenthealth)
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Victory;
                            Game.currentDigimon.AddBattleResult(true);
                        }
                        else
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Defeat;
                            Game.currentDigimon.AddBattleResult(false);
                        }
                    }
                    else if (Game.currentDigimon.currenthealth > 0)
                    {
                        animationCounter = -1;
                        Battle.turnIndex++;
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
                    if (Battle.turns[Battle.turnIndex].isBattleEnded)
                    {
                        if (Game.currentDigimon.currenthealth > Opponent.currenthealth)
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Victory;
                            Game.currentDigimon.AddBattleResult(true);
                        }
                        else
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Defeat;
                            Game.currentDigimon.AddBattleResult(false);
                        }
                    }
                    else if (Opponent.currenthealth > 0)
                    {
                        animationCounter = -1;
                        Battle.turnIndex++;
                        animation = AnimationNo.OponentAttack;
                    }
                    else
                    {
                        animationCounter = -1;
                        animation = AnimationNo.Victory;
                        Game.currentDigimon.AddBattleResult(true);
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
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -1);
                    DrawHealthBar(Game.currentDigimon);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -2);
                    DrawHealthBar(Game.currentDigimon);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, -1);
                    DrawHealthBar(Game.currentDigimon);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX + 1, 0);
                    DrawHealthBar(Game.currentDigimon);
                    break;

                case 12:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                case 14:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                case 16:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                case 18:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk2, false, true, Game.currentDigimon.sprite.SpriteX - 1, 0);
                    break;

                case 24:
                    if (Battle.turns[Battle.turnIndex].isBattleEnded)
                    {
                        if (Game.currentDigimon.currenthealth > Opponent.currenthealth)
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Victory;
                            Game.currentDigimon.AddBattleResult(true);
                        }
                        else
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Defeat;
                            Game.currentDigimon.AddBattleResult(false);
                        }
                    }
                    else
                    {
                        animationCounter = -1;
                        Battle.turnIndex++;
                        animation = AnimationNo.Attack;
                    }
                    
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
                    if (Battle.turns[Battle.turnIndex].isBattleEnded)
                    {
                        if (Game.currentDigimon.currenthealth > Opponent.currenthealth)
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Victory;
                            Game.currentDigimon.AddBattleResult(true);
                        }
                        else
                        {
                            animationCounter = -1;
                            animation = AnimationNo.Defeat;
                            Game.currentDigimon.AddBattleResult(false);
                        }
                    }
                    else
                    {
                        animationCounter = -1;
                        Battle.turnIndex++;
                        animation = AnimationNo.OponentAttack;
                    }
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
                    Game.currentDigimon.sprite.SpriteX = GetMiddleX(Game.currentDigimon.sprite.frame1Width);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
                    break;

                case 1:
                    Sounds.PlaySound(Sound.Win);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, GetMiddleX(Game.currentDigimon.sprite.happyFrameWidth), 0);
                    DrawVictoryMarks();
                    break;

                case 2:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    break;

                case 3:
                    Sounds.PlaySound(Sound.Win);
                    DrawVictoryMarks();
                    break;

                case 4:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, true, Game.currentDigimon.sprite.SpriteX, 0);
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
                    Game.currentDigimon.sprite.SpriteX = GetMiddleX(Game.currentDigimon.sprite.frame1Width);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed + 260); // slowdown timer to sync the sounds
                    break;

                case 1:
                    Sounds.PlaySound(Sound.Lose);
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, GetMiddleX(Game.currentDigimon.sprite.hurt1FrameWidth), 0);
                    DrawDefeatMarks();
                    break;

                case 2:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed); // speed timer back up to normal
                    break;

                case 3:
                    Sounds.PlaySound(Sound.Defeat);
                    DrawDefeatMarks();
                    break;

                case 4:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Hurt1, false, true, Game.currentDigimon.sprite.SpriteX, 0);
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
            if (Game.isEgg)
            {
                animation = AnimationNo.EggHatch;
                _animationTick.Interval = TimeSpan.FromMilliseconds(80);
            }
            else
            {
                animation = AnimationNo.Digivolve;
                _animationTick.Interval = TimeSpan.FromMilliseconds(120);
            }
            evolvedDigimon = newDigimon;
            _animationTick.Start();
        }

        public bool isEvolving = false;
        public void PlayDigivolve()
        {
            switch (animationCounter)
            {
                case 0:
                    isEvolving = true;
                    IsinAnimation = true;
                    Sounds.PlaySound(Sound.Digivolve);
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 1:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 2:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 3:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 4:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 5:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 6:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 7:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                // Start evolved digimon frames
                case 8:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(evolvedDigimon.sprite.frame1Width), 0);
                    break;

                case 9:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(evolvedDigimon.sprite.frame1Width), 0);
                    break;

                case 10:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(evolvedDigimon.sprite.frame1Width), 0);
                    break;

                case 11:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(evolvedDigimon.sprite.frame1Width), 0);
                    break;

                case 12:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(evolvedDigimon.sprite.frame1Width), 0);
                    break;

                case 13:
                    Game.pixelScreen.ShadeScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(evolvedDigimon.sprite.frame1Width), 0);
                    break;

                case 14:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(evolvedDigimon, SpriteFrame.Walk, false, false, GetMiddleX(evolvedDigimon.sprite.frame1Width), 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
                    break;

                case 17:
                    Game.currentDigimon.SetupDigimon(evolvedDigimon.digimonID);
                    Game.resetMainScreen();
                    break;
            }
        }

        public void PlayEggHatching()
        {
            switch (animationCounter)
            {
                case 0:
                    isEvolving = true;
                    IsinAnimation = true;
                    Sounds.PlaySound(Sound.Digivolve);
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, true, GetMiddleX(Game.currentDigimon.sprite.frame1Width), 0);
                    break;

                case 1:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 2:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 3:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 4:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 5:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 6:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 7:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 8:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 9:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 10:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 11:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 12:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 13:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 14:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 15:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 16:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 17:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 18:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 19:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 20:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 21:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 22:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 23:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 24:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 25:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 26:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 27:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 28:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 29:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;

                case 30:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 31:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX + 2, 0);
                    break;

                case 32:
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Walk, false, false, Game.currentDigimon.sprite.SpriteX - 2, 0);
                    break;


                case 33:
                    Game.pixelScreen.ClearScreen();
                    Game.pixelScreen.DrawDigimonFrame(Game.currentDigimon, SpriteFrame.Happy, false, false, GetMiddleX(Game.currentDigimon.sprite.happyFrameWidth), 0);
                    _animationTick.Interval = TimeSpan.FromMilliseconds(GameTickSpeed);
                    break;

                case 36:
                    Game.currentDigimon.SetupDigimon(evolvedDigimon.digimonID);
                    Game.isEgg = false;
                    Game.resetMainScreen();
                    break;
            }
        }

    }
}
