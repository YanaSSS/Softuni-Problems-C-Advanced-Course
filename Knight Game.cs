using System;
using System.Linq;

namespace Knight_Game
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            CreateMatrix(board);

            int removedKnights = 0;
            int rowUnderAttack = 0;
            int colUnderAttack = 0;

            while (true)
            {
                int maxattacks = 0;                

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int attack = 0;

                        if (board[row, col] == 'K')
                        {
                            attack = CountAttacks(board, row, col);
                            if (attack > maxattacks)
                            {
                                maxattacks = attack;
                                rowUnderAttack = row;
                                colUnderAttack = col;
                            }
                        }
                    }
                }

                if (maxattacks > 0)
                {
                    board[rowUnderAttack, colUnderAttack] = '0';
                    removedKnights++;
                }

                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }


        }

        static void CreateMatrix(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }
        }

        static bool IsValid(char[,] board, int row, int col)
        {
            return row >= 0
                && row < board.GetLength(0)
                && col >= 0
                && col < board.GetLength(1);
        }

        static int CountAttacks(char[,] board, int row, int col)
        {
            int attacks = 0;
            if (IsValid(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
            {
                attacks++;
            }
            if (IsValid(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
            {
                attacks++;
            }
            if (IsValid(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
            {
                attacks++;
            }
            if (IsValid(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
            {
                attacks++;
            }
            if (IsValid(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
            {
                attacks++;
            }
            if (IsValid(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
            {
                attacks++;
            }
            if (IsValid(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
            {
                attacks++;
            }
            if (IsValid(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }
    }
}
