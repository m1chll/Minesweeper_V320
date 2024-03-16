using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameboardCreator
    {
        private Gameboard Gameboard { get; set; }

        public Gameboard CreateGameboard(string difficultyString)
        {
            IStrategy difficulty;
            switch (difficultyString)
            {
                case "H":
                    difficulty = new StrategyHard();
                    break;
                case "M":
                    difficulty = new StrategyHard();
                    break;
                case "E":
                    difficulty = new StrategyHard();
                    break;
            }

            Gameboard = new Gameboard();




            return Gameboard;
        }
    }
}
