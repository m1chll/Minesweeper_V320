using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Gameboard
    {
        public object state;
        internal Field[,] fields;

        public int placedFlagsCount { get; set; }
        public List<List<string>> gameboard { get; set; }

        public emento ConcreteMemento(object state)
        {
            // Implementierung hier
            return null;
        }

        public object GetState()
        {
            // Implementierung hier
            return null;
        }

        public void CreateFields()
        {
            // Implementierung hier
        }

        public List<List<string>> GetGameboard()
        {
            // Implementierung hier
            return null;
        }
    }
}
