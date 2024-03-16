using Minesweeper;
using System.Text;

namespace Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            Console.WriteLine("😊😘🤣😁💣👍✌");


            var game = new Game();
            game.Start();

        }
    }
}
