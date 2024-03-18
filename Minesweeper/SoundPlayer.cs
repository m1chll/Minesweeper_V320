using NAudio.Wave;
using System;

namespace Minesweeper
{
    public class SoundPlayer
    {
        public string StartGameSoundPath { get; set; }
        public string ExitGameSoundPath { get; set; }
        public string GameOverSoundPath { get; set; }
        public string GameWonSoundPath { get; set; }

        private WaveOutEvent outputDevice;

        public SoundPlayer()
        {
            outputDevice = new WaveOutEvent();
        }

        public void PlaySound(string soundPath)
        {
            if (!string.IsNullOrEmpty(soundPath))
            {
                try
                {
                    var audioFileReader = new AudioFileReader(soundPath);
                    outputDevice.Init(audioFileReader);
                    outputDevice.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing sound: {ex.Message}");
                }
            }
            else
            {
                throw new ArgumentException("The sound path is invalid or empty");
            }
        }

        public void WinSound()
        {
            PlaySound(@"Sounds/GameWon.mp3");
        }

        public void LoseSound()
        {
            PlaySound(@"Sounds/GameLost.mp3");
        }

        public void PauseGame()
        {
            PlaySound(@"Sounds/PauseSound.mp3");
        }

        public void StartGame()
        {
            PlaySound(@"Sounds/StartGame.mp3");
        }

        public void AlmostReady()
        {
            PlaySound(@"Sounds/FinishHim.mp3");
        }
    }
}
