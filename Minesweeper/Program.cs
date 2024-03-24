using Minesweeper;
using System.Runtime.InteropServices;
using System.Text;

namespace Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game Game = new Game(); 
            Game.PlayGame();
        }
    }
}
