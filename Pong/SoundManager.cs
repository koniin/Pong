using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    public class SoundManager {
        private Dictionary<string, SoundEffect> sounds; 
        private Song music;
        private string songName;

        private bool soundEnabled = true;

        public SoundManager() {
            this.sounds = new Dictionary<string, SoundEffect>();
        }

        public ~SoundManager() {
            foreach (SoundEffect effect in sounds)
                effect.Dispose();

            sounds = null;
            music.Dispose();
        }

        public void UnloadAll() {
            foreach (string effect in sounds.Keys)
                Content.Unload<SoundEffect>(effect);

            Content.Unload<Song>(songName);
        }

        public void AddMusic(string name, bool isRepeating, float volume) {
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            songName = name;
            music = Content.Load<Song>(name);
        }

        public void AddSound(string name) {
            sounds.Add(name, Content.Load<SoundEffect>(name));
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
