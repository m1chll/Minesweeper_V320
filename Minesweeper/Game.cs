using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Transactions;

namespace Minesweeper
{
    /// <summary>
    /// Represents a Minesweeper game.
    /// </summary>
    public class Game
    {
        private string difficulty;
        private Gameboard Gameboard;
        private GameboardCaretaker GameboardCaretaker;
        private SoundPlayer soundPlayer; // Neues Feld für den SoundPlayer

        /// <summary>
        /// Gets or sets the status of the game.
        /// </summary>
        public GameStatus GameStatus { get; set; }

        private List<List<string>> GameboardUI { get; set; }

        private UI UI { get; set; }

        /// <summary>
        /// Gets or sets the current field input for the game.
        /// </summary>
        public FieldInput CurrentFieldInput { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            soundPlayer = new SoundPlayer(); // Initialisierung des SoundPlayers
        }

        /// <summary>
        /// Plays the Minesweeper game.
        /// </summary>
        public void PlayGame()
        {
            Gameboard = new Gameboard();
            UI = new UI();
            UI.PrintStartScreen();
            string difficulty = UI.GetDifficulty();
            GameboardCaretaker = new GameboardCaretaker();

            GameboardCreator gameboardCreator = new GameboardCreator();
            Gameboard = gameboardCreator.CreateGameboard(difficulty);

            GameStatus = GameStatus.Ongoing;

            while (GameStatus == GameStatus.Ongoing)
            {
                GameboardUI = Gameboard.GetGameboard();
                UI.PrintGame(GameboardUI, Gameboard.BombCount, Gameboard.FlagCount);
                GameboardCaretaker.SaveState(Gameboard);
                CurrentFieldInput = UI.GetFieldUpdate();
                ValidateUserInput();               
            }
            if (GameStatus == GameStatus.Lost)
            {
                soundPlayer.LoseSound(); // Sound für Verlieren abspielen
                UI.PrintGameLost();
            }
            else if (GameStatus == GameStatus.Won)
            {
                soundPlayer.WinSound(); // Sound für Gewinnen abspielen
                UI.PrintGameWon();
            }
        }

        private void ValidateUserInput()
        {
            if (CurrentFieldInput.ActionType == FieldInput.UserAction.Pause)
            {
                GameStatus = GameStatus.Paused;
                soundPlayer.PauseGame(); // Sound für Pausieren abspielen
                UI.MakePause();
                GameStatus = GameStatus.Ongoing;
                CurrentFieldInput = UI.GetFieldUpdate();
            }
            if (CurrentFieldInput.ActionType == FieldInput.UserAction.Undo)
            {
                var prevState = GameboardCaretaker.RestoreState();
                if (prevState != null)
                {
                    Gameboard = prevState;
                }
            }
            else
            {
                GameStatus = Gameboard.UpdateFields(CurrentFieldInput);
            }
        }
    }
}
