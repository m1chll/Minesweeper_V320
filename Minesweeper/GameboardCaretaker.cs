using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameboardCaretaker
    {
        private Stack<Gameboard> history = new Stack<Gameboard>();

        public void SaveState(Gameboard gameboard)
        {
            history.Push(gameboard.Clone());
        }

        public Gameboard Undo()
        {
            if (history.Count == 0)
            {
                return null;
            }
            // Return last saved state 
            return history.Pop();
        }
    }
}
