namespace TerminalMinesweeper
{
    class App
    {
        public static void Main()
        {
            Minesweeper minesweeper = new(5, 5, 1 );

            minesweeper.Game();
        }
    }
}
