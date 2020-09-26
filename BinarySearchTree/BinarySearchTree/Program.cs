using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(17);
            binarySearchTree.Insert(9);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(25);
            binarySearchTree.Insert(11);
            binarySearchTree.Insert(31);
            binarySearchTree.Insert(20);

            binarySearchTree.Remove(3);

            binarySearchTree.InOrder();
        }
    }
}
