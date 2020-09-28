using System;

namespace Combinations
{
    class Program
    {
        private static int slots = 2;
        private static string[] arr = { "A", "B", "C" };
        private static string[] reslut = new string[slots];

        static void Main(string[] args)
        {
            Comb(0, 0);
        }
        
        static void Comb(int index, int setIndex)
        {
            if(index >= slots)
            {
                Console.WriteLine(string.Join(' ', reslut));
            }
            else
            {
                for(int i = setIndex; i < arr.Length; i++)
                {
                    reslut[index] = arr[i];
                    Comb(index + 1, i + 1);
                }      
            }           
        }
    }
}
