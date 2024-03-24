using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class GameboardCaretaker
    {
        private Stack<Gameboard> history = new Stack<Gameboard>();

        public void SaveState(Gameboard gameboard)
        {
            // Deep clone the gameboard and save its state
            history.Push(gameboard.Clone());
        }

        public Gameboard Undo(int steps = 1)
        {
            if (steps <= 0)
            {
                throw new ArgumentException("Number of steps to undo must be positive.");
            }

            if (history.Count == 0)
            {
                throw new InvalidOperationException("No states to undo.");
            }

            // Pop the specified number of states from the stack
            Gameboard currentState = null;
            for (int i = 0; i < steps; i++)
            {
                currentState = history.Pop();
            }

            return currentState;
        }
    }
}
