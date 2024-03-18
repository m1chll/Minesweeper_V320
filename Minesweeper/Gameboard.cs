using System;
using System.Collections.Generic;
using System.Data;

namespace Minesweeper
{
    public class Gameboard
    {
        public int XSize { get; set; }
        public int YSize { get; set; } 

        public int placedFlagsCount { get; set; }
        public List<List<Field>> Fields { get; set; }
        public List<List<string>> gameboard { get; set; }  

        public void CreateFields(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;

            // Erstellung des Spielfeldes
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    Fields[i][j] = new Field();
                }
            }
        }

        public List<List<string>> GetGameboard()
        {
            for (int i = 0; i < XSize; i++)
            {
                for (int j = 0; j < YSize; j++)
                {
                    if (Fields[i][j].IsVisible == true && Fields[i][j].HasFlag)
                    {
                        gameboard[i][j] = "🚩";
                    }
                    else if(Fields[i][j].IsVisible)
                    {
                        gameboard[i][j] = Convert.ToString(Fields[i][j].BombsAround);
                    }
                    else
                    {
                        gameboard[i][j] = "🧱";
                    }
                }
            }
            return gameboard;
        }

        public GameStatus UpdateFields(FieldInput fieldInput)
        {

            if(fieldInput.ActionType == UserAction.Reveal)
            {
                if (Fields[fieldInput.X][fieldInput.Y].isBomb)
                {
                    return GameStatus.Lost;
                }
            }

        }

        internal Gameboard Clone()
        {
            throw new NotImplementedException();
        }

        private void RevealFieldsArround(int xCoordinate, int yCoordinate)
        {

        }
    }
}
