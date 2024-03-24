using System;

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

        /// <summary>
        /// Gets or sets the status of the game.
        /// </summary>
        public GameStatus GameStatus { get; set; }

        private List<List<string>> GameboardUI { get; set; }

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
            UI ui = new UI();
            ui.PrintStartScreen();
            string difficulty = ui.GetDifficulty();

            GameboardCreator gameboardCreator = new GameboardCreator();
            Gameboard = gameboardCreator.CreateGameboard(difficulty);

            GameStatus = GameStatus.Ongoing;

            while (GameStatus == GameStatus.Ongoing)
            {
                GameboardUI = Gameboard.GetGameboard();
                ui.PrintGame(GameboardUI);
                CurrentFieldInput = ui.GetFieldUpdate();
                GameStatus = Gameboard.UpdateFields(CurrentFieldInput);
            }
            if (GameStatus == GameStatus.Lost)

            {
                ui.PrintGameLost();
            }
        }
    }
}
