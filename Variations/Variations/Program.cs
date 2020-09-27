using System;

namespace Variations
{
    class Program
    {
        private static int slots = 3;
        private static string[] elements = { "A", "B", "C", "D" };
        private static string[] vars = new string[slots];
        private static bool[] used = new bool[elements.Length];

        static void Main(string[] args)
        {
            Gen();
        }

        static void Gen(int index = 0)        
        {
            if(index >= slots)
            {
                Console.WriteLine(string.Join(' ', vars));
            }
            else
            {
                for(int i = 0; i < elements.Length; i++)
                {
                    if(!used[i])
                    {
                        used[i] = true;
                        vars[index] = elements[i];
                        Gen(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
