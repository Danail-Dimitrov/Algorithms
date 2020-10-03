using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace LongestIncreasingSubSequense
{
    class Program
    {
        private static int[] seq = { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
        private static int[] len = new int[seq.Length];
        private static int[] prev = new int[seq.Length];

        static void Main(string[] args)
        {
            for(int i = 0; i < seq.Length; i++)
            {
                prev[i] = -1;
                len[i] = 1;

                for(int j = 0; j < i; j++)
                {
                    if(seq[j] < seq[i])
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', seq));
            Console.WriteLine(string.Join(' ', len));
            Console.WriteLine(string.Join(' ', prev));

            int maxValue = len.Max();
            int maxValueIndex = len.ToList().IndexOf(maxValue);
            Console.WriteLine(seq[maxValueIndex]);
            int index = prev[maxValueIndex];
            while(index != -1)
            {
                Console.WriteLine(seq[index]);
                index = prev[index];
            }
        }
    }
}
