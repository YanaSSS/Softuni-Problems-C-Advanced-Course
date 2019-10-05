using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];

            int startRow = -1;
            int startCol = -1;
            int coalOnField = 0;

            string[] commands = Console.ReadLine().Split();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if (field[row, col] == 'c')
                    {
                        coalOnField++;
                    }

                }
            }

            int currentRow = startRow;
            int currentCol = startCol;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];
                if (command == "left")
                {

                    if (currentCol > 0)
                    {
                        currentCol--;
                        coalOnField = CountCoal(currentRow, currentCol, field, coalOnField);
                    }
                }

                else if (command == "right")
                {
                    if (currentCol < field.GetLength(1) - 1)
                    {
                        currentCol++;
                        coalOnField = CountCoal(currentRow, currentCol, field, coalOnField);
                    }
                }

                else if (command == "up")
                {
                    if (currentRow > 0)
                    {
                        currentRow--;
                        coalOnField = CountCoal(currentRow, currentCol, field, coalOnField);
                    }
                }

                else if (command == "down")
                {
                    if (currentRow < field.GetLength(0) - 1)
                    {
                        currentRow++;
                        coalOnField = CountCoal(currentRow, currentCol, field, coalOnField);
                    }
                }
            }

            if (coalOnField > 0 && field[currentRow, currentCol] != 'e')
            {
                Console.WriteLine($"{coalOnField} coals left. ({currentRow}, {currentCol})");
            }
        }
        static bool IsValid(char[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }
        static int CountCoal(int currentR, int currentC, char[,] matrix, int coalLeft)
        {
            if (IsValid(matrix, currentR, currentC))
            {
                if (matrix[currentR, currentC] == 'c')
                {
                    matrix[currentR, currentC] = '*';
                    coalLeft--;

                    if (coalLeft == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentR}, {currentC})");
                        return 0;
                    }
                }
                else if (matrix[currentR, currentC] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentR}, {currentC})");
                    return 0;
                }
            }

            return coalLeft;
        }
    }
}
