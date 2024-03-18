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
                    gameboard[i][j] = Fields[i][j].GetValue();
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
                else if (!Fields[fieldInput.X][fieldInput.Y].HasFlag && !Fields[fieldInput.X][fieldInput.Y].IsVisible)
                {
                    RevealFields(fieldInput.X, fieldInput.Y);
                    return GameStatus.Ongoing;
                }
            }
            else if(fieldInput.ActionType == UserAction.Flag)
            {
                if(!Fields[fieldInput.X][fieldInput.Y].IsVisible)
                {
                    Fields[fieldInput.X][fieldInput.Y].HasFlag = true;
                    return GameStatus.Ongoing;
                }
            }
            else if(fieldInput.ActionType == UserAction.RemoveFlag)
            {
                if (Fields[fieldInput.X][fieldInput.Y].HasFlag)
                {
                    Fields[fieldInput.X][fieldInput.Y].HasFlag = false;
                    return GameStatus.Ongoing;
                }

            }
            return GameStatus.Ongoing;


        }

        internal Gameboard Clone()
        {
            throw new NotImplementedException();
        }

        private void RevealFields(int xCoordinate, int yCoordinate)
        {
            Fields[xCoordinate][yCoordinate].IsVisible = true;

            if (Fields[xCoordinate][yCoordinate].HasFlag || Fields[xCoordinate][yCoordinate].IsBomb || Fields[xCoordinate][yCoordinate].IsVisible)
            {
                return;
            }

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0) continue;

                    int newX = xCoordinate + x;
                    int newY = yCoordinate + y;

                    if (newX >= 0 && newX < XSize && newY >= 0 && newY < YSize)
                    {
                        if (!Fields[newX][newY].IsBomb && !Fields[newX][newY].HasFlag && !Fields[newX][newY].IsVisible)
                        {
                            RevealFields(newX, newY);
                        }
                    }
                }
            }
        }
    }
}
