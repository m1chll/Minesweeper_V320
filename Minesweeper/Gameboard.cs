using System;
using System.Collections.Generic;
using System.Data;

namespace Minesweeper
{
    public class Gameboard
    {
        public int XSize { get; set; }
        public int YSize { get; set; } 

        public int FlagCount { get; set; }
        public int BombCount { get; set; }

        public int Rows { get { return Fields.Count; } } // Anzahl der Zeilen
        public int Columns { get { return Fields.Count > 0 ? Fields[0].Count : 0; } } // Anzahl der Spalten

        public List<List<Field>> Fields { get; set; }
        public List<List<string>> gameboard { get; set; }

        public void CreateFields(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;

            // Initialisieren der äußeren Liste
            Fields = new List<List<Field>>();

            // Erstellung des Spielfeldes
            for (int i = 0; i < XSize; i++)
            {
                // Erstellen und Initialisieren einer inneren Liste für jede Reihe
                List<Field> row = new List<Field>();

                for (int j = 0; j < YSize; j++)
                {
                    // Hinzufügen eines neuen Field-Objekts zu jeder inneren Liste
                    row.Add(new Field());
                }

                // Hinzufügen der inneren Liste zur äußeren Liste
                Fields.Add(row);
            }
        }


        public List<List<string>> GetGameboard()
        {
            // Initialisieren der äußeren Liste
            gameboard = new List<List<string>>();

            for (int i = 0; i < XSize; i++)
            {
                // Erstellen und Initialisieren einer inneren Liste für jede Reihe
                List<string> row = new List<string>();

                for (int j = 0; j < YSize; j++)
                {
                    // Hinzufügen des Wertes jedes Feldes zur inneren Liste
                    // Achten Sie darauf, dass GetValue() einen entsprechenden String-Wert für jedes Feld zurückgibt
                    row.Add(Fields[i][j].GetValue());
                }

                // Hinzufügen der inneren Liste zur äußeren Liste
                gameboard.Add(row);
            }

            return gameboard;
        }


        public GameStatus UpdateFields(FieldInput fieldInput)
        {

            if(fieldInput.ActionType == FieldInput.UserAction.Reveal)
            {
                if (Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].IsBomb)
                {
                    return GameStatus.Lost;
                }
                else if (!Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].HasFlag && !Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].IsVisible)
                {
                    RevealFields(fieldInput.XCoordinate, fieldInput.YCoordinate);
                    return GameStatus.Ongoing;
                }
            } 
            else if(fieldInput.ActionType == FieldInput.UserAction.Flag && FlagCount < BombCount - 1)
            {
                if(!Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].IsVisible)
                {
                    Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].HasFlag = true;
                    FlagCount++;
                    return GameStatus.Ongoing;
                }
            }
            else if(fieldInput.ActionType == FieldInput.UserAction.Flag && FlagCount == BombCount - 1)
            {
                if (!Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].IsVisible)
                {
                    Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].HasFlag = true;
                    FlagCount++;
                    return GameStatus.Won;
                }
            }
            else if(fieldInput.ActionType == FieldInput.UserAction.RemoveFlag)
            {
                if (Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].HasFlag)
                {
                    Fields[fieldInput.XCoordinate][fieldInput.YCoordinate].HasFlag = false;
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
            if (Fields[xCoordinate][yCoordinate].HasFlag || Fields[xCoordinate][yCoordinate].IsBomb)
            {
                return;
            }

            Fields[xCoordinate][yCoordinate].IsVisible = true;


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
