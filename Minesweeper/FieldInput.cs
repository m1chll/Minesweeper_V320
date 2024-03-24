namespace Minesweeper
{
    /// <summary>
    /// Represents user input for a field in the Minesweeper game.
    /// </summary>
    public class FieldInput
    {
        public int X { get; }
        public int Y { get; }
        public UserAction ActionType { get; }

        /// <summary>
        /// Gets the column identifier of the field.
        /// </summary>
        public char Column { get; }

        /// <summary>
        /// Gets the row identifier of the field.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldInput"/> class with specified coordinates and action type.
        /// </summary>
        /// <param name="x">The X-coordinate of the field.</param>
        /// <param name="y">The Y-coordinate of the field.</param>
        /// <param name="actionType">The type of action to perform on the field.</param>
        public FieldInput(int x, int y, UserAction actionType)
        {
            X = x;
            Y = y;
            ActionType = actionType;
        }
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
}
