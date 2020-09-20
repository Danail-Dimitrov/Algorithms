using System;
using System.Linq;

namespace Permutation
{
    class Program
    {
        static string[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(' ').ToArray();
            Permute();
        }

        private static void Permute(int index = 0)
        {
            if(index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                Permute(index + 1);
                for(int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int origin, int destination)
        {
            string buffer = elements[origin];
            elements[origin] = elements[destination];
            elements[destination] = buffer;
        }
    }
}
