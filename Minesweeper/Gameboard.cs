using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Gameboard
    {

        public int placedFlagsCount { get; set; }
        public List<List<Field>> Fields { get; set; }
        public List<List<string>> gameboard { get; set; }
        public bool IsGameOver { get; set; }

        public Gameboard()
        {
            gameboard = new List<List<string>>();
        }

        public void CreateFields(int xSize, int ySize)
        {
            // Erstellung des Spielfeldes
            for (int i = 0; i < xSize; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < ySize; j++)
                {
                    Fields[i][j] = new Field();
                    row.Add(Fields[i][j].GetType());
                }
                gameboard.Add(row);
            }
        }

        public List<List<string>> GetGameboard()
        {
           
            return gameboard;
        }

        internal Gameboard Clone()
        {
            throw new NotImplementedException();
        }
    }
}
