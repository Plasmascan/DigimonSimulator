﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;

namespace DigimonSimulator
{

    public enum Sound
    {
        Beep,
        Attack,
        Step,
        Damage,
        Lose,
        Win, 
        empty
    }
    public static class Sounds
    {
        private static bool IsMuted;
        private static SoundPlayer SoundPlayer;
     
        public static void MuteSound()
        {
            IsMuted = true;
        }

        public static void SoundOn()
        {
            IsMuted = false;
        }

        private static void Play(Stream stream)
        {
            if (SoundPlayer != null)
            {
                SoundPlayer.Stop();
                SoundPlayer.Dispose();
                SoundPlayer = null;
            }

            if (stream == null)
            {
                return;
            }

            SoundPlayer = new SoundPlayer(stream);
            SoundPlayer.Play();
        }

        public static void PlaySound(Sound soundName)
        {
            if (!IsMuted)
            {

                if (soundName == Sound.Beep)
                {
                    Play(Properties.Resources.beep);
                }
                else if (soundName == Sound.Attack)
                {
                    Play(Properties.Resources.se_attack);
                }
                else if (soundName == Sound.Step)
                {
                    Play(Properties.Resources.se_step);
                }
                else if (soundName == Sound.Damage)
                {
                    Play(Properties.Resources.se_damage);
                }
                else if (soundName == Sound.Lose)
                {
                    Play(Properties.Resources.se_lose);
                }
                else if (soundName == Sound.Win)
                {
                    Play(Properties.Resources.se_win);
                }
                
            }
        }
    }
}
