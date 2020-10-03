using System;
using System.Collections.Generic;

namespace SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 5, 1, 4, 2 };

            Dictionary<int, int> posibleSums = new Dictionary<int, int>();
            posibleSums.Add(0, 0);

            for(int i = 0; i < numbers.Length; i++)
            {
                HashSet<int> newSums = new HashSet<int>();

                foreach(var oldSum in posibleSums.Keys)
                {
                    newSums.Add(oldSum + numbers[i]);
                }

                foreach(var newSum in newSums)
                {
                    if(!posibleSums.ContainsKey(newSum))
                    {
                        posibleSums.Add(newSum, numbers[i]);
                    }
                }
            }

            int n = int.Parse(Console.ReadLine());
            int remaining = n;
            List<int> nums = new List<int>();

            while(remaining > 0)
            {
                nums.Add(posibleSums[remaining]);
                remaining -= posibleSums[remaining];
            }
            nums.Reverse();

            Console.WriteLine($"{n}: {string.Join(", ", nums)}");
        }
    }
}
