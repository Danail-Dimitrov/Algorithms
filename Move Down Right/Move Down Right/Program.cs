using System;
using System.Collections.Generic;

namespace Move_Down_Right
{
    class Program
    {
        private static int[,] matrix =
        {
            { 2, 6, 1, 8, 9, 4, 2 },
            { 1, 8, 0, 3, 5, 6, 7 },
            { 3, 4, 8, 7, 2, 1, 8 },
            { 0, 9, 2, 8, 1, 7, 9 },
            { 2, 7, 1, 9, 7, 8, 2 },
            { 4, 5, 6, 1, 2, 5, 6 },
            { 9, 3, 5, 2, 8, 1, 9 },
            { 2, 3, 4, 1, 7, 2, 8 }
        };
        private static int[,] transfered = new int[matrix.GetLength(0), matrix.GetLength(1)];
        private static List<int> path = new List<int>();

        static void Main(string[] args)
        {
            for(int row = 0; row < transfered.GetLength(0); row++)
            {
                for(int col = 0; col < transfered.GetLength(1); col++)
                {
                    int currentMax = 0;
                    if(row - 1 >= 0 && transfered[row - 1, col] > currentMax)
                    {
                        currentMax = transfered[row - 1, col];
                    }
                    if(col - 1 >= 0 && transfered[row, col - 1] > currentMax)
                    {
                        currentMax = transfered[row, col - 1];
                    }

                    transfered[row, col] = matrix[row, col] + currentMax;
                }
            }

            for(int i = 0; i < transfered.GetLength(0); i++)
            {
                for(int j = 0; j < transfered.GetLength(1); j++)
                {
                    Console.Write(transfered[i, j] + " ");
                }
                Console.WriteLine();
            }

            FindPath(transfered.GetLength(0) - 1, transfered.GetLength(1) - 1);
        }

        private static void FindPath(int currentRow, int currentCol)
        {
            if(currentRow == 0 && currentCol == 0)
            {
                //Console.WriteLine(Environment.NewLine + transfered[currentRow, currentCol]);
                Console.WriteLine(string.Join(" ", path));
            }
            else
            {
                int currentMax = 0;
                int nextRow = 0;
                int nextCol = 0;
                if(currentRow - 1 >= 0 && transfered[currentRow - 1, currentCol] > currentMax)
                {
                    currentMax = transfered[currentRow - 1, currentCol];
                    nextRow = currentRow - 1;
                    nextCol = currentCol;
                }
                if(currentCol - 1 >= 0 && transfered[currentRow, currentCol - 1] > currentMax)
                {
                    currentMax = transfered[currentRow, currentCol - 1];
                    nextRow = currentRow;
                    nextCol = currentCol - 1;
                }
                path.Add(currentMax);

                FindPath(nextRow, nextCol);
            }
        }
    }
}
