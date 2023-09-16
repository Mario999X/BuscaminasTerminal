namespace TerminalMinesweeper
{
    class App
    {
        public static void Main()
        {
            Minesweeper minesweeper = new(3, 3, 1 );

            minesweeper.Game();
        }
    }
}
