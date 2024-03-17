using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    public class GameboardCreator
    {
        private Gameboard Gameboard { get; set; }

        private Dictionary<string, IStrategy> difficultyStrategies = new Dictionary<string, IStrategy>
    {
        { "E", new StrategyEasy() },
        { "M", new StrategyMedium() },
        { "H", new StrategyHard() }
    };

        public Gameboard CreateGameboard(string difficultyString)
        {
            if (!difficultyStrategies.ContainsKey(difficultyString))
            {
                throw new ArgumentException("Ungültiger Schwierigkeitsgrad.");
            }

            IStrategy difficulty = difficultyStrategies[difficultyString];

            Gameboard = new Gameboard();
            Gameboard.fields = new Field[difficulty.xSize, difficulty.ySize];

            // Platzieren Bomben entsprechend Strategie
            Random random = new Random();
            int bombsPlaced = 0;
            while (bombsPlaced < difficulty.numberOfBombs)
            {
                int x = random.Next(difficulty.xSize);
                int y = random.Next(difficulty.ySize);

                if (!Gameboard.fields[x, y].isBomb)
                {
                    Gameboard.fields[x, y].isBomb = true;
                    bombsPlaced++;
                }
            }

            // Anzahl von Bomben in der Nähe jedes Feldes
            for (int i = 0; i < difficulty.xSize; i++)
            {
                for (int j = 0; j < difficulty.ySize; j++)
                {
                    if (!Gameboard.fields[i, j].isBomb)
                    {
                        Gameboard.fields[i, j].bombsAround = CalculateBombsAround(Gameboard, i, j);
                    }
                }
            }

            return Gameboard;
        }

        private int CalculateBombsAround(Gameboard gameboard, int x, int y)
        {
            int bombsAround = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < gameboard.fields.GetLength(0) && j >= 0 && j < gameboard.fields.GetLength(1) &&
                        gameboard.fields[i, j].isBomb)
                    {
                        bombsAround++;
                    }
                }
            }

            return bombsAround;
        }
    }


}