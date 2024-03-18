namespace Minesweeper
{
    public class FieldInput
    {
        public int X { get; }
        public int Y { get; }
        public UserAction ActionType { get; }
        public char Column { get; }
        public int Row { get; }

        public FieldInput(int x, int y, UserAction actionType)
        {
            X = x;
            Y = y;
            ActionType = actionType;
        }

    }

    public enum UserAction
    {
        Reveal,
        Flag,
        RemoveFlag
    }
}
