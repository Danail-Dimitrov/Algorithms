using System;
using System.Collections.Generic;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = "ABCBDAB";
            string second = "BDCABA";

            int[,] lcs = new int[first.Length + 1, second.Length + 1];

            for(int row = 1; row <= first.Length; row++)
            {
                for(int col = 1; col <= second.Length; col++)
                {
                    int up = lcs[row - 1, col];
                    int left = lcs[row, col - 1];

                    int result = Math.Max(up, left);

                    if(first[row - 1] == second[col - 1])
                    {
                        result = Math.Max(1 + lcs[row - 1, col - 1], result);
                    }

                    lcs[row, col] = result;
                }
            }

            for(int i = 0; i < lcs.GetLength(0); i++)
            {
                for(int j = 0; j < lcs.GetLength(1); j++)
                {
                    Console.Write(lcs[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(lcs[first.Length, second.Length]);

            int currentRow = first.Length;
            int currentCol = second.Length;

            Stack<char> resultStack = new Stack<char>();
            while(currentRow > 0 && currentCol > 0)
            {
                if(first[currentRow - 1] == second[currentCol - 1])
                {
                    resultStack.Push(first[currentRow - 1]);
                    currentRow--;
                    currentCol--;
                }
                else if(lcs[currentRow - 1, currentCol] == lcs[currentRow, currentCol])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }
            }

            Console.WriteLine(string.Join(' ', resultStack));
        }
    }
}
