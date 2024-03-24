using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class GameboardCaretaker
    {
        private Stack<Gameboard> mementos = new Stack<Gameboard>();

        public void SaveState(Gameboard gameboard)
        {
            mementos.Push(gameboard);
        }

        public Gameboard RestoreState()
        {
            if (mementos.Count > 0)
            {
                return mementos.Pop();
            }
            return null;
        }
    }


}
