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

        public FieldInput(int row, char column, char action)
        {
            Row = row;
            Column = column;
            ActionType = GetActionType(action);
        }

        private UserAction GetActionType(char action)
        {
            switch (char.ToLower(action))
            {
                case 'r':
                    return UserAction.Reveal;
                case 'f':
                    return UserAction.Flag;
                case 'u':
                    return UserAction.RemoveFlag;
                default:
                    throw new ArgumentException("Ungültige Aktion.");
            }
        }
    }

    public enum UserAction
    {
        Reveal,
        Flag,
        RemoveFlag
    }
}
