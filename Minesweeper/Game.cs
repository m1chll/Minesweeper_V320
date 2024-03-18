using System;

namespace Minesweeper
{
    public class Game
    {
        private string userName;
        private string difficulty;
        private Gameboard Gameboard;
        public GameStatus GameStatus { get; set; }
        private List<List<string>> GameboardUI { get; set; }
        public FieldInput CurrentFieldInput { get; set; }

        public void PlayGame()
        {
            Gameboard = new Gameboard();
            UI ui = new UI();
            string difficulty = ui.GetDifficulty();

            GameboardCreator gameboardCreator = new GameboardCreator();
            Gameboard = gameboardCreator.CreateGameboard(difficulty);

            GameStatus = GameStatus.Ongoing;

            while (GameStatus == GameStatus.Ongoing)
            {
                GameboardUI = Gameboard.GetGameboard();
                ui.PrintGame(GameboardUI);
                CurrentFieldInput = ui.GetFieldUpdate();
                Gameboard.UpdateFields(CurrentFieldInput);
            }
        }
    }
}
