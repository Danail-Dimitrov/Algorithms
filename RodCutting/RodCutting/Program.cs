using System;
using System.Linq;

namespace RodCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            Console.WriteLine($"Prices are:{Environment.NewLine}{string.Join("," + Environment.NewLine, prices.Select((x, i) => $"{i} meters => ${x}"))}");

            Console.Write("What would you like to sell?: ");

            int n = int.Parse(Console.ReadLine());

            int[] bestPrices = new int[prices.Length];
            int[][] bestPreviouse = new int[prices.Length][];

            bestPrices[0] = 0;
            bestPreviouse[0] = new int[] { 0, 0 };

            for(int i = 0; i <= 10; i++)
            {
                int max = bestPrices[i];
                bestPreviouse[i] = new int[] { i, 1 };
                for(int j = 1; j < i; j++)
                {
                    int current = prices[j] + prices[i - j];

                    if(current > max)
                    {
                        max = current;
                        bestPreviouse[i] = new int[] { j, i - j };
                    }
                }

                bestPrices[i] = max;
            }

            Console.WriteLine($"You would sell it best for {bestPrices[n]}");
            Console.WriteLine($"You should split in in the following peaces: {string.Join(", ", bestPreviouse[n].Where(x => x > 0).Select(x => $"{x} meters"))}!");
        }
    }
}
