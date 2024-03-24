using NAudio.Wave;
using System;

namespace Minesweeper
{
    /// <summary>
    /// Represents a sound player for playing audio cues in the Minesweeper game.
    /// </summary>
    public class SoundPlayer
    {
        /// <summary>
        /// Gets or sets the file path for the sound played at the start of the game.
        /// </summary>
        public string StartGameSoundPath { get; set; }

        /// <summary>
        /// Gets or sets the file path for the sound played when exiting the game.
        /// </summary>
        public string ExitGameSoundPath { get; set; }

        /// <summary>
        /// Gets or sets the file path for the sound played when the game is over.
        /// </summary>
        public string GameOverSoundPath { get; set; }

        /// <summary>
        /// Gets or sets the file path for the sound played when the game is won.
        /// </summary>
        public string GameWonSoundPath { get; set; }

        private WaveOutEvent outputDevice;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoundPlayer"/> class.
        /// </summary>
        public SoundPlayer()
        {
            outputDevice = new WaveOutEvent();
        }

        /// <summary>
        /// Plays the sound specified by the given path.
        /// </summary>
        /// <param name="soundPath">The file path of the sound to play.</param>
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

        /// <summary>
        /// Plays the sound for winning the game.
        /// </summary>
        public void WinSound()
        {
            PlaySound(@"Sounds/GameWon.mp3");
        }

        /// <summary>
        /// Plays the sound for losing the game.
        /// </summary>
        public void LoseSound()
        {
            PlaySound(@"Sounds/GameLost.mp3");
        }

        /// <summary>
        /// Plays the sound for pausing the game.
        /// </summary>
        public void PauseGame()
        {
            PlaySound(@"Sounds/PauseSound.mp3");
        }

        /// <summary>
        /// Plays the sound for starting the game.
        /// </summary>
        public void StartGame()
        {
            PlaySound(@"Sounds/StartGame.mp3");
        }

        /// <summary>
        /// Plays the sound indicating the game is almost ready.
        /// </summary>
        public void AlmostReady()
        {
            PlaySound(@"Sounds/FinishHim.mp3");
        }
    }
}
