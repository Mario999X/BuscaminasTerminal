﻿using System;
namespace TerminalMinesweeper
{
	public class Minesweeper
	{
		private const int MINE = 1;

		private const int EMPTY = 0;

		private int mines;

		private bool[,] board;

		private int[,] playerBoard;

		private bool gameOver = false;

		private bool gameWin = false;


		public Minesweeper(int boardLenght,int boardHeight, int mines)
		{
			board = new bool[boardLenght, boardHeight];
			playerBoard = new int[boardLenght, boardHeight];

			this.mines = mines;
		}

		public void Game()
		{

			GenerateBoard(mines);

			while (!gameOver || !gameWin)
			{
				ShowBoard();

				Console.WriteLine("Enter a ROW number: ");
				int row = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a COLUMN number: ");
                int column = Convert.ToInt32(Console.ReadLine());

				if (playerBoard[row, column] == MINE)
				{
					gameOver = true;

					board[row, column] = true;
				}
				else
				{
					board[row, column] = true;
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
			for(int row = 0; row < board.GetLength(0); row++)
			{
				for (int column = 0; column < board.GetLength(1); column++)
				{
					if (board[row, column])
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
