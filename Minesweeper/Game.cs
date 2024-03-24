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
        private string userName;
        private string difficulty;
        private Gameboard Gameboard;
        private GameboardCaretaker GameboardCaretaker;

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
                GameStatus = Gameboard.UpdateFields(CurrentFieldInput);
            }
            if (GameStatus == GameStatus.Lost)
            {
                UI.PrintGameLost();
            }
            else if (GameStatus == GameStatus.Won)
            {
                UI.PrintGameWon();
            }
        }

        private void ValidateUserInput()
        {
            if (CurrentFieldInput.GamePause == true)
            {
                GameStatus = GameStatus.Paused;
                UI.MakePause();
                GameStatus = GameStatus.Ongoing;
                CurrentFieldInput = UI.GetFieldUpdate();
            }
            if (CurrentFieldInput.Undo == true)
            {
                var prevState = GameboardCaretaker.RestoreState();
                if (prevState != null)
                {
                    Gameboard = prevState;
                    GameStatus = GameStatus.Ongoing;
                }
            }
            else
            {
                GameStatus = Gameboard.UpdateFields(CurrentFieldInput);
            }
        }
    }
}
