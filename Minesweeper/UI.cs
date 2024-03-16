using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks.Sources;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Media;

namespace Minesweeper
{
    public class UI
    {
        public Stopwatch stopwatch = new Stopwatch();
        public void PrintStartScreen()
        {
            string input;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("         ______   __  __  ____    ____    __      __  ____    ____    ____    ____    ____       ");
            Console.WriteLine(" /'\\_/`\\/\\__  _\\ /\\ \\ /\\ \\ /\\  _`\\ /\\  _`\\ /\\ \\  __/\\ \\ /\\  _`\\ /\\  _`\\ /\\  _`\\ /\\  _`\\     ");
            Console.WriteLine("/\\      \\/_/\\ \\/ \\ \\ `\\\\ \\ \\ \\L\\_\\ \\,\\L\\_\\ \\ \\/\\ \\ \\ \\ \\ \\L\\_\\ \\ \\L\\_\\ \\ \\L\\ \\ \\ \\L\\_\\ \\ \\L\\ \\   ");
            Console.WriteLine("\\ \\ \\__\\ \\ \\ \\ \\  \\ \\ , ` \\ \\  _\\L\\/_\\__ \\\\ \\ \\ \\ \\ \\ \\ \\  _\\L\\ \\  _\\L\\ \\ ,__/\\ \\  _\\L\\ \\ ,  /   ");
            Console.WriteLine(" \\ \\ \\_/\\ \\ \\_\\ \\__\\ \\ \\`\\ \\ \\ \\L\\ \\/\\ \\L\\ \\ \\ \\_/ \\_\\ \\ \\ \\L\\ \\ \\ \\L\\ \\ \\ \\/  \\ \\ \\L\\ \\ \\ \\\\ \\  ");
            Console.WriteLine("  \\ \\_\\\\ \\_\\/\\_____\\\\ \\_\\ \\_\\ \\____/\\ `\\____\\ `\\___x___/\\ \\____/\\ \\____/\\ \\_\\   \\ \\____/\\ \\_\\ \\_\\");
            Console.WriteLine("   \\/_/ \\/_/\\/_____/ \\/_/\\/_/\\/___/  \\/_____/'\\/__/\\__/  \\/___/  \\/___/  \\/_/    \\/___/  \\/_/\\/_/");
            Console.WriteLine("                                                                                                 ");
            Console.WriteLine("                                                                                                 ");

            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Instructions:");
            Console.WriteLine("   1. You can decide what size you want your gameboard to be but it must be a square. Typing a single number is enough.");
            Console.WriteLine("   2. After, you'll be presented with a grid of covered cells.");
            Console.WriteLine("   3. Enter coordinates (row, column) to reveal a cell or flag it.");
            Console.WriteLine("   4. After the coordinates of the field, type:");
            Console.WriteLine("     '- R' to Reveal.'");
            Console.WriteLine("     '- F' to set a Flag.'");
            Console.WriteLine("     '- RF' to set Remove a Flag.'");
            Console.WriteLine("     '- Example: \"a4r\"'");
            Console.WriteLine("   5. Numbers indicate how many adjacent cells contain mines.");
            Console.WriteLine("   6. Be careful! If you reveal a mine, the game ends.");
            Console.WriteLine("   7. You win by setting a flag on all covered mines. ;)");
            Console.WriteLine("   8. As soon as you enter the size you want your gameboard to be, a stopwatch starts. So think fast!");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Legend:");
            Console.WriteLine("   - '■' represents a covered cell.");
            Console.WriteLine("   - 'M' is a mine.");
            Console.WriteLine("   - 'P' is a flag marking a potential mine.");
            Console.WriteLine("   - Numbers indicate how many mines are adjacent to that cell.");
            Console.WriteLine("-----------------------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("Press 1 to start");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Clear();
                    break;
                }
            }
            Console.Clear();
        }

        public string GetDifficulty()
        {
            string difficulty;
            Console.WriteLine("Please enter your difficulty: ");
            Console.WriteLine("H = Hard");
            Console.WriteLine("M = Medium");
            Console.WriteLine("E = Easy");
            difficulty = Console.ReadLine();    
            return difficulty;
        }

        public void SetTime()
        {
            // Implementierung hier
        }

        public FieldInput GetFieldUpdate()
        {
            // Implementierung hier
            return null;
        }

        public bool CheckedFieldInput(string input)
        {
            // Implementierung hier
            return false;
        }

        public void PrintGame(List<List<string>> gameBoard)
        {
            
        }

        private void PrintGameInformations(int bombs, int flags)
        {
            // Implementierung hier
        }

        private void PrintGameBoard(List<List<string>> gameBoard)
        {
            // Implementierung hier
        }

        public void PrintGameWon()
        {
            
        }

        public void PrintGameLost()
        {
            // Implementierung hier
        }
    }

}
