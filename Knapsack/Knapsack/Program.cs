using System;

namespace Knapsack
{
    class Program
    {
        // returns max of two integers 
        static int Max(int num1, int num2)
        {
            return (num1 > num2) ? num1 : num2;
        }

        // returns max values in knapsack
        static int Knapsack(int W, int[] weight, int[] value, int n)
        {
            int i, w;
            int[,] TotalValue = new int[n + 1, W + 1];

            // bottom up approach        
            for(i = 0; i <= n; i++)
            {
                for(w = 0; w <= W; w++)
                {
                    if(i == 0 || w == 0)
                        TotalValue[i, w] = 0;
                    else if(weight[i - 1] <= w)
                        TotalValue[i, w] = Math.Max(value[i - 1]
                               + TotalValue[i - 1, w - weight[i - 1]], TotalValue[i - 1, w]);
                    else
                        TotalValue[i, w] = TotalValue[i - 1, w];
                }
            }

            return TotalValue[n, W];
        }

        // entry point
        static void Main()
        {
            int[] Values = new int[] { 50, 80, 110, 230 };
            int[] Weights = new int[] { 10, 20, 30, 40 };
            int limit = 60;
            int n = Weights.Length;

            Console.WriteLine("Total value: {0}", Knapsack(limit, Weights, Values, n));
            Console.ReadKey();
        }
    }
}
