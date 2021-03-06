﻿using Interfaces;
using LinkedList;
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

			btree.PreorderTraversalRecursive();
			btree.PreOrderTraversalIterative();
			btree.PreOrderTraversalIterativeCompilerMimic();

			btree.PostorderTraversalRecursive();
			btree.PostOrderTraversalIterative();
			btree.PostOrderTraversalIterativeCompilerMimic();
			
            btree.InorderTraversalRecursive();
            btree.InorderTraversalIterative();
			btree.InOrderTraversalIterativeCompilerMimic();
			
            btree.PrintLevelOrderTranversal();
            Console.WriteLine("Size of tree:" + btree.GetSizeOfTree());

            Console.WriteLine("Are identical: " + btree.AreIdentical(btreeOther));

            Console.WriteLine("Max depth of tree: " + btree.MaxDepth());

            Console.WriteLine("Tree contains 5: " + btree.Contains(5));
            Console.WriteLine("Tree contains 10: " + btree.Contains(10));

            //btree.MirrorTree();
            //btree.PrintLevelOrderTranversal();

            btree.PrintRootToLeafPaths();

            Console.WriteLine("LCA for binary tree: " + btree.FindLowestCommonAncestor(7, 6).Data);
            Console.WriteLine("Largest BST subtree size: " + btree.LargestBstSubtree());

            Console.WriteLine("----------------BST----------------");

            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(50);
            binarySearchTree.Insert(30);
            binarySearchTree.Insert(20);
            binarySearchTree.Insert(40);
            binarySearchTree.Insert(70);
            binarySearchTree.Insert(60);
            binarySearchTree.Insert(80);

            int temp = binarySearchTree.Root.Left.Data;
            binarySearchTree.Root.Left.Data = binarySearchTree.Root.Right.Data;
            binarySearchTree.Root.Right.Data = temp;

            binarySearchTree.InorderTraversalRecursive();
            binarySearchTree.CorrectBst();
            binarySearchTree.InorderTraversalRecursive();


            binarySearchTree.InorderTraversalRecursive();
            Console.WriteLine("BST contain 60 : "+ binarySearchTree.Contains(60));
            Console.WriteLine("BST contain 66 : " + binarySearchTree.Contains(66));
            Console.WriteLine("MinValue in BST: " + binarySearchTree.MinValue());

            Console.WriteLine("Is BST: " + binarySearchTree.IsBst());
            Console.WriteLine("InOrderSuccessor of root(50): " + binarySearchTree.InOrderSuccessor(binarySearchTree.Root).Data);
            Console.WriteLine("5th node: " + binarySearchTree.KthSmallestNode(5).Data);
            Console.WriteLine("Largest BST subtree size: " + binarySearchTree.LargestBstSubtree());
            Console.WriteLine("Ceil for 50:" + binarySearchTree.Ceil(50));
            Console.WriteLine("CeilIterative for 51:" + binarySearchTree.CeilIterative(51));
            Console.WriteLine("FloorIterative for 49:" + binarySearchTree.FloorIterative(49));
            
            SinglyLinkedList<int> sortedLinkedList = new SinglyLinkedList<int>();
            sortedLinkedList.PushToHead(70);
            sortedLinkedList.PushToHead(60);
            sortedLinkedList.PushToHead(50);
            sortedLinkedList.PushToHead(40);
            sortedLinkedList.PushToHead(30);
            sortedLinkedList.PushToHead(20);
            sortedLinkedList.PushToHead(10);
            BinarySearchTree<int> bstFromSll = BinarySearchTree<int>.GetBstFromSortedList(sortedLinkedList);
            bstFromSll.InorderTraversalRecursive();

            BinarySearchTree<int>.PrintCommonNodes(binarySearchTree, bstFromSll);

            binarySearchTree.AddGreaterNodeSum();
            binarySearchTree.InorderTraversalRecursive();


            int[] sortedArray = new int[7] {1,2,3,4,5,6,7};
            BinarySearchTree<int> bstFromArray = BinarySearchTree<int>.GetBstFromSortedArray(sortedArray);
            bstFromArray.InorderTraversalRecursive();

            binarySearchTree.GetInorderTraversal();

            BinarySearchTree<int> mergeBst = BinarySearchTree<int>.GetMergeTree(bstFromSll,bstFromArray);
            mergeBst.InorderTraversalRecursive();

            int[] preOrderOfSomeTreeWithOnlyONeChildAtEachNode = new int[] { 20, 10, 11, 13, 12 };
            Console.WriteLine("preOrderOfSomeTreeWithOnlyONeChildAtEachNode:" + 
                BinarySearchTree<int>.IsPreOrderWithOnlyOneChildSatisfyBstProperty(preOrderOfSomeTreeWithOnlyONeChildAtEachNode));

            int[] preOrderOfTree = new int[] { 8,10,12,15,16,20,25 };
            BinarySearchTree<int> bstFromPreOrder = BinarySearchTree<int>.ConstructBstFromPreOrder(preOrderOfTree);
            bstFromPreOrder.InorderTraversalRecursive();

            //bstFromPreOrder.BstToDll();
            //dll.Print();

            BinarySearchTree<int>.FindPairWithSumAs(bstFromPreOrder.Root, 33);

            bstFromPreOrder.RemoveOutsideRangeNodes(10,26);
            bstFromPreOrder.InorderTraversalRecursive();

            AugmentedBst<int> augmentedBst = new AugmentedBst<int>();
            augmentedBst.Insert(50);
            augmentedBst.Insert(30);
            augmentedBst.Insert(20);
            augmentedBst.Insert(40);
            augmentedBst.Insert(70);
            augmentedBst.Insert(60);
            augmentedBst.Insert(80);

            augmentedBst.InorderTraversalRecursive();
            Console.WriteLine("5th element: " + augmentedBst.KthSmallestNodeInOrderOfHeightTime(5).Data);


            Console.ReadLine();
        }

    }
}
