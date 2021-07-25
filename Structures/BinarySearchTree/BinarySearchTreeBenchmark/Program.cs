using System;
using Structures.BinarySearchTree.BinarySearchTree;

namespace BinarySearchTreeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();

            bst.Add(3, "three");
            bst.Add(4, "four");
            bst.Add(5, "five");
            bst.Add(2, "two");
            bst.Add(8, "eight");
            bst.Add(6, "six");
            bst.Add(7, "seven");

            bst.DisplayAll();

        }
    }
}
