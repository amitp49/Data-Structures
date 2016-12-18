using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BTRunner : IRunner
    {
        public void Run()
        {
            BinaryTree<int> btree = new BinaryTree<int>();
            btree.Root = new BinaryTreeNode<int>(1);
            btree.Root.Left = new BinaryTreeNode<int>(2);
            btree.Root.Right = new BinaryTreeNode<int>(3);

            btree.Root.Left.Left = new BinaryTreeNode<int>(4);
            btree.Root.Right.Right = new BinaryTreeNode<int>(5);

            btree.Root.Left.Left.Right = new BinaryTreeNode<int>(6);
            btree.Root.Right.Right.Right = new BinaryTreeNode<int>(7);

            btree.Root.Right.Right.Right.Right = new BinaryTreeNode<int>(8);


            BinaryTree<int> btreeOther = new BinaryTree<int>();
            btreeOther.Root = new BinaryTreeNode<int>(1);
            btreeOther.Root.Left = new BinaryTreeNode<int>(2);
            btreeOther.Root.Right = new BinaryTreeNode<int>(3);

            btreeOther.Root.Left.Left = new BinaryTreeNode<int>(4);
            btreeOther.Root.Right.Right = new BinaryTreeNode<int>(5);

            btreeOther.Root.Left.Left.Right = new BinaryTreeNode<int>(6);
            btreeOther.Root.Right.Right.Right = new BinaryTreeNode<int>(7);

            btreeOther.Root.Right.Right.Right.Right = new BinaryTreeNode<int>(8);


            btree.PostorderTraversalRecursive();
            btree.PreorderTraversalRecursive();
            btree.InorderTraversalRecursive();

            btree.PostOrderTraversalIterative();
            btree.PreOrderTraversalIterative();
            btree.InorderTraversalIterative();

            btree.PrintLevelOrderTranversal();
            Console.WriteLine("Size of tree:" + btree.GetSizeOfTree());

            Console.WriteLine("Are identical: " + btree.AreIdentical(btreeOther));

            Console.WriteLine("Max depth of tree: " + btree.MaxDepth());

            Console.WriteLine("Tree contains 5: " + btree.Contains(5));
            Console.WriteLine("Tree contains 10: " + btree.Contains(10));

            btree.MirrorTree();

            btree.PrintLevelOrderTranversal();

            Console.ReadLine();
        }
    }
}
