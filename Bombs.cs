using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            CreateMatrix(matrix);

            string[] bombCoordinates = Console.ReadLine().Split();

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int[] coordinates = bombCoordinates[i].Split(',').Select(int.Parse).ToArray();

                Explode(coordinates[0], coordinates[1], matrix);
            }

            int countAlive = matrix.Cast<int>().Where(x => x > 0).Count();
            int sum = matrix.Cast<int>().Where(x => x > 0).Sum();

            Console.WriteLine($"Alive cells: {countAlive}");
            Console.WriteLine($"Sum: {sum}");

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($"{matrix[r, c]} ");
                }
                Console.WriteLine();
            }

        }
        static void CreateMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        static bool IsValid(int[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }
        static void Explode(int x, int y, int[,] matrix)
        {
            if (matrix[x, y] > 0)
            {
                int bombPower = matrix[x, y];

                PositionsBoom(x - 1, y - 1, bombPower, matrix);
                PositionsBoom(x - 1, y, bombPower, matrix);
                PositionsBoom(x - 1, y + 1, bombPower, matrix);
                PositionsBoom(x, y - 1, bombPower, matrix);
                PositionsBoom(x, y + 1, bombPower, matrix);
                PositionsBoom(x + 1, y - 1, bombPower, matrix);
                PositionsBoom(x + 1, y, bombPower, matrix);
                PositionsBoom(x + 1, y + 1, bombPower, matrix);

                matrix[x, y] = 0;
            }
        }

        static void PositionsBoom(int posRow, int posCol, int bombPower, int[,] matrix)
        {
            if (IsValid(matrix, posRow, posCol) && matrix[posRow, posCol] > 0)
            {
                matrix[posRow, posCol] -= bombPower;
            }
        }
    }
}
