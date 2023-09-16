using System;
namespace TerminalMinesweeper
{
	public class Minesweeper
	{
		private const int MINE = 1;

		private const int EMPTY = 0;

		private int cellsDiscovered = 0;

		private int remainingCells;

		private int mines;

		private bool[,] logicBoard;

		private int[,] playerBoard;

		private bool gameOver = false;

		private bool gameWin = false;


		public Minesweeper(int boardLenght,int boardHeight, int mines)
		{
			logicBoard = new bool[boardLenght, boardHeight];
			playerBoard = new int[boardLenght, boardHeight];

			this.mines = mines;
		}

		public void Game()
		{

            GenerateBoard(mines);

			while (!gameOver && !gameWin)
			{

                remainingCells = playerBoard.Length - cellsDiscovered;

                Console.WriteLine("\nRemaining cells " + remainingCells + "\n");

                ShowBoard();

				Console.WriteLine("\nEnter a ROW number: ");
				int row = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nEnter a COLUMN number: ");
                int column = Convert.ToInt32(Console.ReadLine());

				if (playerBoard[row, column] == MINE)
				{
					gameOver = true;

					logicBoard[row, column] = true;
				} else if (logicBoard[row, column])
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
            }

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

