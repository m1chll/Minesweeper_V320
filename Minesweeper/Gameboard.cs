using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Gameboard
    {
        internal Field[,] fields;

        public int placedFlagsCount { get; set; }
        public List<List<string>> gameboard { get; set; }

        public Gameboard()
        {
            gameboard = new List<List<string>>();
        }

        public object GetState()
        {
            return fields.Clone();
        }

        public void CreateFields(int xSize, int ySize)
        {
            // Erstellung des Spielfeldes
            fields = new Field[xSize, ySize];
            for (int i = 0; i < xSize; i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < ySize; j++)
                {
                    fields[i, j] = new Field();
                    row.Add(fields[i, j].GetType());
                }
                gameboard.Add(row);
            }
        }

        public List<List<string>> GetGameboard()
        {
            // Rückgabe aktuelles Spielbrett
            return gameboard;
        }

        internal Gameboard Clone()
        {
            throw new NotImplementedException();
        }
    }
}
