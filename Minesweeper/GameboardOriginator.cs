using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameboardOriginator
    {
        private Gameboard state;

        public GameboardOriginator(Gameboard initialState)
        {
            state = initialState;
        }

        public void SetState(Gameboard newState)
        {
            state = newState;
        }

        public Gameboard GetState()
        {
            return state;
        }
    }


}
