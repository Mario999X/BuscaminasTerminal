namespace TerminalMinesweeper
{
	public class Minesweeper
	{
        // We prepare the constants that differentiate empty cells from those with mines.
        private const int MINE = 1;

		private const int EMPTY = 0;

        // We prepare the variables to work with the cells in game.
        private int cellsDiscovered = 0;

		private int remainingCells;

        // We prepare the variable for the number of mines choose by the user.
        private int mines;

        // -- BOARDS --

        // This array will be filled with all values ​​in false, when they become true, the value will be shown to the user.
        private bool[,] logicBoard;

        // This panel will be filled with the declared constants of the class EMPTY and MINE.
		// This information will not be revealed to the user until they manually discover each value in the array.
        private int[,] playerBoard;

        // Boolean values ​​to declare the end of the game.
        private bool gameOver = false;

		private bool gameWin = false;

		// Main constructor of the class.
		public Minesweeper(int boardLenght,int boardHeight, int mines)
		{
			logicBoard = new bool[boardLenght, boardHeight];
			playerBoard = new int[boardLenght, boardHeight];

			this.mines = mines;
		}

		// Main function to play.
		public void Game()
		{

            GenerateBoard(mines);

            // -- MAIN LOOP OF THE GAME --

            while (!gameOver && !gameWin)
			{

				Console.WriteLine("\n----------\n");

                remainingCells = playerBoard.Length - cellsDiscovered;

                Console.WriteLine("\nRemaining cells: " + remainingCells + "\n");


                ShowBoard();


				Console.WriteLine("\nEnter a ROW number: ");
				int row = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nEnter a COLUMN number: ");
                int column = Convert.ToInt32(Console.ReadLine());

				try
				{
                    if (playerBoard[row, column] == MINE)
                    {
                        gameOver = true;

                        logicBoard[row, column] = true;

                    }
                    else if (logicBoard[row, column])
                    {
                        Console.WriteLine("\nCell already visited... try another one!");
                    }
                    else
                    {
                        logicBoard[row, column] = true;
                        cellsDiscovered++;

                        if (remainingCells == mines)
                        {
                            gameWin = true;
                        }
                    }

                } catch (IndexOutOfRangeException)
				{
                    Console.WriteLine("\nPlease enter a valid position...");
                }
				
            }

			// -- END OF THE GAME --

			if (gameOver)
			{
				Console.WriteLine("You have stepped on a mine... | GAME OVER");
			}

			if (gameWin)
			{
				Console.WriteLine("You have secured the zone... | YOU WIN");
			}


            ShowBoard();

        }

		// Function to generate the board and insert the selected mines by the player.
		private void GenerateBoard(int mines)
		{
			int n = 0;

			Random r = new();

			while(n < mines)
			{
				int row = r.Next(0, playerBoard.GetLength(0));

                int column = r.Next(0, playerBoard.GetLength(1));


				if (playerBoard[row, column] == EMPTY)
				{
                    playerBoard[row, column] = MINE;
					n++;
				}

            }
        }

        // Function to show a representation of the board to the player.
        // S = Safe || D = Dead || ? = Unknown
        private void ShowBoard()
		{
			for(int row = 0; row < logicBoard.GetLength(0); row++)
			{
				for (int column = 0; column < logicBoard.GetLength(1); column++)
				{
					if (logicBoard[row, column])
					{
						if (playerBoard[row, column] == EMPTY)
						{
							Console.Write(" | S | ");
						}
						else
						{
							Console.Write(" | D | ");
						}
					}
					else
					{
						Console.Write(" | ? | ");
					}
				}
				Console.WriteLine("\n");
            }
		}
	}
}

