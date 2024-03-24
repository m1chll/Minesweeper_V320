using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class SoundPlayer
    {
        public string startGameSoundPath { get; set; }
        public string exitGameSoundPath { get; set; }
        public string gameOverSoundPath { get; set; }
        public string gameWonSoundPath { get; set; }

        public void PlaySound(string soundPath)
        {
            if (!string.IsNullOrEmpty(soundPath))
            {
                //using (var player = new System.Media.SoundPlayer(soundPath))
                {
                    //player.Play();
                }
            }
            else
            {
                // Falls Pfad leer/ungültig
                throw new ArgumentException("Der Soundpfad ist ungültig oder leer");
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

        public void Startgame()
        {
            PlaySound(@"Sounds/StartGame.mp3");
        }

        public void AlmostReady()
        {
            PlaySound(@"Sounds/FinishHim.mp3");
        }

    }
}
