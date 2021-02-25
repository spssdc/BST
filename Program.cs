using System;
using System.Collections.Generic;

namespace BST
{
    class Program
    {
        static void Main()
        {
            // Initialise the BST and set the generic type to string
            BinarySearchTree<string> myBST = new BinarySearchTree<string>();

            Console.WriteLine("Binary Search Tree!\n");
            Console.WriteLine("            Lily\n");
            Console.WriteLine("      Daisy     Sunflower\n");
            Console.WriteLine("Begonia   Hosta        Peony\n");
            Console.WriteLine("                           Rose\n");

            // Test .Insert() method to construct tree
            myBST.Insert("Lily");
            myBST.Insert("Daisy");
            myBST.Insert("Sunflower");
            myBST.Insert("Peony");
            myBST.Insert("Rose");
            myBST.Insert("Hosta");
            myBST.Insert("Begonia");

            // Test Postorder() traversal method
            Console.WriteLine("\nDepth First Search");
            myBST.Postorder();

            // Test BFS
            Console.WriteLine("\nBreadth First Search");
            myBST.BreadthFirst();

            // Test .Contain() method
            Console.WriteLine("\nEnter value to look for: Hebe");
            if (myBST.Contains("Hebe"))
            {
                Console.WriteLine("Found");
            }
            else
            {
                Console.WriteLine("Not Present");
            }
        }
    }
}
