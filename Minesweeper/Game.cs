using System;

namespace Minesweeper
{
    public class Game
    {
        private string userName;
        private string difficulty;
        private Gameboard gameboard;
        private GameStatus gameStatus;
        public FieldInput currentFieldInput { get; set; }

        public Game(string userName, string difficulty)
        {
            this.userName = userName;
            this.difficulty = difficulty;
        }

        public void PlayGame()
        {
            Console.WriteLine("Willkommen bei Minesweeper, " + userName + "!");
            Console.WriteLine("Schwierigkeitsgrad: " + difficulty);

            GameboardCreator gameboardCreator = new GameboardCreator();
            gameboard = gameboardCreator.CreateGameboard(difficulty);

            gameStatus = GameStatus.Ongoing;
            while (gameStatus == GameStatus.Ongoing)
            {
                PrintGameboard();
                ProcessPlayerInput();
                gameStatus = UpdateGameStatus();
            }

            EndGame();
        }

        private void PrintGameboard()
        {
            Console.WriteLine("Aktuelles Spielfeld:");
            var board = gameboard.GetGameboard();
            foreach (var row in board)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell + " ");
                }
                Console.WriteLine();
            }
        }

        private void ProcessPlayerInput()
        {
            Console.WriteLine("Bitte geben Sie Ihre Aktion ein (z.B. '1,2 reveal', '3,4 flag', '5,6 removeflag', 'pause', 'continue', 'stop', 'undo'):");
            string userInput = Console.ReadLine();


            string[] inputParts = userInput.Split(' ');
            if (inputParts.Length == 2)
            {
                string[] coordinates = inputParts[0].Split(',');
                if (coordinates.Length == 2 && int.TryParse(coordinates[0], out int x) && int.TryParse(coordinates[1], out int y))
                {
                    string action = inputParts[1].ToLower();

                    switch (action)
                    {
                        case "reveal":
                            currentFieldInput = new FieldInput(x, y, Action.Reveal);
                            break;
                        case "flag":
                            currentFieldInput = new FieldInput(x, y, Action.Flag);
                            break;
                        case "removeflag":
                            currentFieldInput = new FieldInput(x, y, Action.RemoveFlag);
                            break;
                        default:
                            Console.WriteLine("Ungültige Aktion.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Koordinaten.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabeformat.");
            }
        }

        private GameStatus UpdateGameStatus()
        {
      
            if (gameboard.IsGameOver())
            {
                return GameStatus.Lost;
            }


            // Hier könnte auch die Überprüfung auf Gewinn implementiert werden





            // Falls Spiel noch läuft
            return GameStatus.Ongoing;
        }


        private void EndGame()
        {
            if (gameStatus == GameStatus.Won)
            {
                Console.WriteLine("Glückwunsch, " + userName + "! Sie haben das Spiel gewonnen!");
            }
            else if (gameStatus == GameStatus.Lost)
            {
                Console.WriteLine("Game Over! Sie haben eine Mine getroffen.");
            }
            else if (gameStatus == GameStatus.Paused)
            {
                Console.WriteLine("Spiel pausiert.");
            }
        }
    }
}
