using System;

namespace VariationsWithRepetition
{
    class Program
    {
        private static int slots = 2;
        private static string[] arr = { "A", "B", "C" };
        private static string[] reslut = new string[slots];

        static void Main(string[] args)
        {
            Var(0);
        }

        static void Var(int index)
        {
            if(index >= slots)
            {
                Console.WriteLine(string.Join(' ', reslut));
            }
            else
            {
                for(int i = 0; i < arr.Length; i++)
                {
                    reslut[index] = arr[i];
                    Var(index + 1);
                }
            }
        }
    }
}
