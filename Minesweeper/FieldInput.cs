using System;
using System.Text.RegularExpressions;

namespace Minesweeper
{
    /// <summary>
    /// Represents user input for a field in the Minesweeper game.
    /// </summary>
    public class FieldInput
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        public UserAction ActionType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldInput"/> class with specified coordinates and action type.
        /// </summary>
        /// <param name="x">The X-coordinate of the field.</param>
        /// <param name="y">The Y-coordinate of the field.</param>
        /// <param name="actionType">The type of action to perform on the field.</param>
        public FieldInput(int x, int y, UserAction actionType)
        {
            XCoordinate = x;
            YCoordinate = y;
            ActionType = actionType;
        }

        /// <summary>
        /// Represents the possible actions a user can perform on a field in the Minesweeper game.
        /// </summary>
        public enum UserAction
        {
            /// <summary>
            /// Reveals the content of the field.
            /// </summary>
            Reveal,

            /// <summary>
            /// Places a flag on the field.
            /// </summary>
            Flag,

            /// <summary>
            /// Removes a flag from the field.
            /// </summary>
            RemoveFlag
        }

        /// <summary>
        /// Checks if the entered field input is valid.
        /// </summary>
        /// <param name="input">The input string to be checked.</param>
        /// <returns>True if the input is valid, otherwise false.</returns>
        public static bool CheckFieldInput(string input)
        {
            if (input.Length < 3)
                return false;

            if (!char.IsLetter(input[0]))
                return false;

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (!char.IsDigit(input[i]))
                    return false;
            }

            char action = char.ToUpper(input[input.Length - 1]);
            if (action != 'R' && action != 'F' && action != 'D')
                return false;

            return true;
        }
    }
}
