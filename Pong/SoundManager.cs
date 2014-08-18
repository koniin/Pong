using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Pong
{
    public class SoundManager {
        private Dictionary<string, SoundEffect> sounds; 
        private Song music;
        private string songName;
        private ContentManager contentManager;

        private bool soundEnabled = true;

        public SoundManager(ContentManager contentManager) {
            this.contentManager = contentManager;
            this.sounds = new Dictionary<string, SoundEffect>();
        }

        ~SoundManager() {
            foreach (SoundEffect effect in sounds.Values)
                effect.Dispose();

            sounds = null;
            music.Dispose();
        }

        public void AddMusic(string name, bool isRepeating, float volume) {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            songName = name;
            music = contentManager.Load<Song>(name);
        }

        public void AddSound(string name) {
            sounds.Add(name, contentManager.Load<SoundEffect>(name));
        }

        public void PlayMusic() {
            if (!soundEnabled)
                return;

            try
            {
                MediaPlayer.Play(music);
            }
            catch (Exception e)
            {
                MediaPlayer.Play(music);
            }    
        }

        public void StopMusic() {
            MediaPlayer.Stop();
        }

        public void EnableSound(bool enable) {
            soundEnabled = enable;
        }

        public void Play(string name) {
            if (!soundEnabled)
                return;

            sounds[name].Play();
        }
    }
}
