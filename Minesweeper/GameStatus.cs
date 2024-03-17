namespace Minesweeper
{
    internal class GameStatus
    {
        public static GameStatus Won { get; internal set; }
        public static GameStatus Lost { get; internal set; }
        public static GameStatus Paused { get; internal set; }
        public static GameStatus Ongoing { get; internal set; }
    }
}