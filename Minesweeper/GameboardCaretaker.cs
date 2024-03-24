using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class GameboardCaretaker
    {
        private Stack<GameboardMemento> mementos = new Stack<GameboardMemento>();

        public void SaveState(Gameboard gameboard)
        {
            mementos.Push(new GameboardMemento(gameboard.Fields));
        }

        public List<List<Field>> RestoreState()
        {
            if (mementos.Count > 0)
            {
                return mementos.Pop().State;
            }
            return null;
        }
    }

}
