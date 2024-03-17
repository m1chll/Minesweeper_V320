using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper {
    public class GameboardCreator
    {
        private Gameboard Gameboard { get; set; } = new Gameboard();

        public Gameboard CreateGameboard(string difficultyString)
        {


            IStrategy difficulty; 

            switch (difficultyString)
            {
                case "H":
                    difficulty = new StrategyHard();
                    break;
                case "M":
                    difficulty = new StrategyMedium();
                    break;
                default:
                    difficulty = new StrategyEasy();
                    break;
            }



            Gameboard.CreateFields(difficulty.XSize, difficulty.YSize);

            // Platzieren Bomben entsprechend Strategie
            Random random = new Random();
            int bombsPlaced = 0;
            while (bombsPlaced < difficulty.NumberOfBombs)
            {
                int x = random.Next(difficulty.XSize);
                int y = random.Next(difficulty.YSize);

                if (!Gameboard.Fields[x][y].isBomb)
                {
                    Gameboard.Fields[x][y].isBomb = true;
                    bombsPlaced++;
                }
            }

            // Anzahl von Bomben in der Nähe jedes Feldes
            for (int i = 0; i < difficulty.XSize; i++)
            {
                for (int j = 0; j < difficulty.YSize; j++)
                {
                    if (!Gameboard.Fields[i][j].isBomb)
                    {
                        Gameboard.Fields[i][j].bombsAround = CalculateBombsAround(i, j);
                    }
                }
            }

            return Gameboard;
        }

        private int CalculateBombsAround(int x, int y)
        {
            int bombsAround = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < Gameboard.Fields.Count && j >= 0 && j < Gameboard.Fields[i].Count && Gameboard.Fields[i][j].isBomb)
                    {
                        bombsAround++;
                    }
                }
            }
            return bombsAround;
        }
    }


}