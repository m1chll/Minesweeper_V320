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
        /// <summary>
        /// Stopwatch used to track elapsed time during the game.
        /// </summary>
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

        /// <summary>
        /// Asks the user for the game difficulty (Hard, Medium, Easy).
        /// </summary>
        /// <returns>The selected difficulty level.</returns>
        public string GetDifficulty()
        {
            string difficulty = "";
            Regex validInput = new Regex("^[EMH]$"); // Regex für E, M, oder H

            while (!validInput.IsMatch(difficulty))
            {
                Console.WriteLine("Please enter your difficulty: ");
                Console.WriteLine("E = Easy");
                Console.WriteLine("M = Medium");
                Console.WriteLine("H = Hard");
                difficulty = Console.ReadLine().ToUpper(); // Großbuchstaben, um auf Groß-/Kleinschreibung nicht zu achten

                if (!validInput.IsMatch(difficulty))
                {
                    Console.WriteLine("Invalid input. Please enter E, M, or H.");
                }
            }

            return difficulty;
        }

        /// <summary>
        /// Stops the stopwatch and prints the elapsed time since it started.
        /// </summary>
        public void SetTime()
        {
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"Elapsed Time: {elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}");
        }

        /// <summary>
        /// Asks the user for field coordinates and action (Reveal, Flag, Remove Flag).
        /// </summary>
        /// <returns>The input field coordinates and action.</returns>
        public FieldInput GetFieldUpdate()
        {
            Console.WriteLine("Enter coordinates (row, column) and action (R for Reveal, F for Flag, RF for Remove Flag), e.g., 'A4R':");
            string input = Console.ReadLine().ToUpper(); // Convert Input to capital letter

            if (!CheckedFieldInput(input))
            {
                Console.WriteLine("Invalid input. Please try again.");
                return GetFieldUpdate(); // Recursive call to get valid input
            }

            char column = input[0];
            int row = int.Parse(input.Substring(1, input.Length - 2));
            string actionStr = input.Substring(input.Length - 1);

            // Convert the string representing the action to the corresponding UserAction enum value
            UserAction action;
            if (actionStr.Length == 1)
            {
                switch (actionStr[0])
                {
                    case 'R':
                        action = UserAction.Reveal;
                        break;
                    case 'F':
                        action = UserAction.Flag;
                        break;
                    default:
                        throw new ArgumentException("Invalid action character.");
                }
            }
            else if (actionStr.Equals("RF"))
            {
                action = UserAction.RemoveFlag;
            }
            else
            {
                throw new ArgumentException("Invalid action string.");
            }

            return new FieldInput(row, column, action);
        }



        /// <summary>
        /// Checks if the entered field input is valid.
        /// </summary>
        /// <param name="input">The input string to be checked.</param>
        /// <returns>True if the input is valid, otherwise false.</returns>
        public bool CheckedFieldInput(string input)
        {
            if (input.Length < 3)
                return false;

            if (!char.IsLetter(input[0]) || !char.IsDigit(input[1]))
                return false;

            char action = char.ToUpper(input[input.Length - 1]);
            if (action != 'R' && action != 'F' && action != 'D')
                return false;

            return true;
        }

        /// <summary>
        /// Prints the current game board.
        /// </summary>
        /// <param name="gameBoard">The game board to be printed.</param>
        public void PrintGame(List<List<string>> gameBoard)
        {
            PrintGameInformations(0, 0);
            PrintGameBoard(gameBoard);
        }

        /// <summary>
        /// Prints the number of bombs and flags.
        /// </summary>
        /// <param name="bombs">The number of bombs.</param>
        /// <param name="flags">The number of flags.</param>
        private void PrintGameInformations(int bombs, int flags)
        {
            Console.WriteLine($"Bombs: {bombs} Flags: {flags}");
        }

        // isch no chli schwer zum luege ob da stimmt wenn dhälfti vo de andere klasse no falsch sind

        /// <summary>
        /// Prints the game board.
        /// </summary>
        /// <param name="gameBoard">The game board to be printed.</param>
        private void PrintGameBoard(List<List<string>> gameBoard)
        {

            for (int i = 0; i < gameBoard.Count; i++)
            {
                for (int j = 0; j < gameBoard[i].Count; j++)
                {
                    Console.Write(gameBoard[i][j]);
                }
                Console.WriteLine();
            }
        }


        public void PrintGameWon()
        {
            Console.WriteLine("_________                                     __        .__          __  .__                     ._. _____.___.                                  ._.");
            Console.WriteLine("\\_   ___ \\  ____   ____    ________________ _/  |_ __ __|  | _____ _/  |_|__| ____   ____   _____| | \\__  |   | ____  __ __  __  _  ______   ____| |");
            Console.WriteLine("/    \\  \\/ /  _ \\ /    \\  / ___\\_  __ \\__  \\\\   __\\  |  \\  | \\__  \\\\   __\\  |/  _ \\ /    \\ /  ___/ |  /   |   |/  _ \\|  |  \\ \\ \\/ \\/ /  _ \\ /    \\ |");
            Console.WriteLine("\\     \\___(  <_> )   |  \\/ /_/  >  | \\/ __ \\|  | |  |  /  |__/ __ \\|  | |  (  <_> )   |  \\___ \\ |  \\____   (  <_> )  |  /  \\     (  <_> )   |  \\|");
            Console.WriteLine(" \\______  /\\____/|___|  /\\___  /|__|  (____  /__| |____/|____(____  /__| |__|\\____/|___|  /____  >__  / ______|\\____/|____/    \\/\\_/ \\____/|___|  /_");
            Console.WriteLine("        \\/            \\//_____/            \\/                     \\/                    \\/     \\/ \\/  \\/                                        \\/\\/ ");
        }

        public void PrintGameLost()
        {
            Console.WriteLine("  ________                        ________                    ._. _____.___.              .__    .__  __                     .__             ._.");
            Console.WriteLine(" /  _____/_____    _____   ____   \\_____  \\___  __ ___________| | \\__  |   | ____  __ __  |  |__ |__|/  |_  _____      _____ |__| ____   ____| |");
            Console.WriteLine("/   \\  ___\\__  \\  /     \\_/ __ \\   /   |   \\  \\/ // __ \\_  __ \\ |  /   |   |/  _ \\|  |  \\ |  |  \\|  \\   __\\ \\__  \\    /     \\|  |/    \\_/ __ \\ |");
            Console.WriteLine("\\    \\_\\  \\/ __ \\|  Y Y  \\  ___/  /    |    \\   /\\  ___/|  | \\/\\|  \\____   (  <_> )  |  / |   Y  \\  ||  |    / __ \\_ |  Y Y  \\  |   |  \\  ___/\\|");
            Console.WriteLine(" \\______  (____  /__|_|  /\\___  > \\_______  /\\_/  \\___  >__|   __  / ______|\\____/|____/  |___|  /__||__|   (____  / |__|_|  /__|___|  /\\___  >_");
            Console.WriteLine("        \\/     \\/      \\/     \\/          \\/          \\/       \\/  \\/                          \\/                \\/        \\/        \\/     \\/\\/");
        }
    }

}
