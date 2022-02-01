using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;

namespace DigimonSimulator
{

    public enum Sound
    {
        Beep,
        Beep2,
        Attack,
        Step,
        Damage,
        Lose,
        Win, 
        Start,
        Defeat,
        Digivolve
    }
    public static class Sounds
    {
        private static bool IsMuted;
        private static SoundPlayer SoundPlayer;
     
        public static void MuteSound()
        {
            SoundPlayer.Stop();
            SoundPlayer.Dispose();
            SoundPlayer = null;
            IsMuted = true;
        }

        public static void SoundOn()
        {
            IsMuted = false;
        }

        public static bool IsMute()
        {
            if (IsMuted)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                else if (soundName == Sound.Beep2)
                {
                    Play(Properties.Resources.beep2);
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
                else if (soundName == Sound.Start)
                {
                    Play(Properties.Resources.se_start);
                }
                else if (soundName == Sound.Defeat)
                {
                    Play(Properties.Resources.se_defeat);
                }
                else if (soundName == Sound.Digivolve)
                {
                    Play(Properties.Resources.digivolve);
                }

            }
        }
    }
}
