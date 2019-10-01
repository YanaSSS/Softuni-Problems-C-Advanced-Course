using System;
using System.Linq;
using System.Collections.Generic;

namespace Snake_Moves
{
    class Program
    {
        static void Main()
        {

            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            Queue<char> snakeString = new Queue<char>(input.ToCharArray());

            char[,] theSnake = new char[dimensions[0], dimensions[1]];

            for (int row = 0; row < theSnake.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < theSnake.GetLength(1); col++)
                    {
                        char snakeMove = snakeString.Dequeue();
                        snakeString.Enqueue(snakeMove);
                        theSnake[row, col] = snakeMove;
                    }
                }

                else
                {
                    for (int col = theSnake.GetLength(1) - 1; col >= 0; col--)
                    {
                        char snakeMove = snakeString.Dequeue();
                        snakeString.Enqueue(snakeMove);
                        theSnake[row, col] = snakeMove;
                    }
                }
            }

            for (int row = 0; row < theSnake.GetLength(0); row++)
            {
                for (int col = 0; col < theSnake.GetLength(1); col++)
                {
                    Console.Write(theSnake[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

