using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class FieldInput
    {
        // Schnell erstellt für das UI

        public int Row { get; }
        public char Column { get; }
        public char Action { get; }

        public FieldInput(int row, char column, char action)
        {
            Row = row;
            Column = column;
            Action = action;
        }
    }
}
