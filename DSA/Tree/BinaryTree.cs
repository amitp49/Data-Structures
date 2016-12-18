using Stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTree<T> where T : IComparable
    {
        BinaryTreeNode<T> root;

        public BinaryTreeNode<T> Root 
        {
            get { return root; }
            set { root = value; } 
        }

        public BinaryTree()
        {

        }

        public BinaryTree(BinaryTreeNode<T> root)
        {
            this.Root = root;
        }

        public bool Contains(T data)
        {
            return ContainsInternalUtil(this.Root,data);
        }

        private bool ContainsInternalUtil(BinaryTreeNode<T> binaryTreeNode, T data)
        {
            if (binaryTreeNode == null)
                return false;

            if (binaryTreeNode.Data.CompareTo(data) == 0)
                return true;

            return (ContainsInternalUtil(binaryTreeNode.Left, data) == true) ||
                (ContainsInternalUtil(binaryTreeNode.Right, data) == true);
        }

        public void DeleteTree()
        {
            DeleteNode(this.Root);
            return;
        }

        private void DeleteNode(BinaryTreeNode<T> binaryTreeNode)
        {
            if (binaryTreeNode == null)
                return;

            DeleteNode(binaryTreeNode.Left);
            DeleteNode(binaryTreeNode.Right);

            binaryTreeNode = null;
        }

        public int GetSizeOfTree()
        {
            return GetSizeOfNode(this.Root);
        }

        public int GetSizeOfNode(BinaryTreeNode<T> currentRoot)
        {
            if (currentRoot == null)
                return 0;

            return ( 1 +
                (currentRoot.Left != null ? GetSizeOfNode(currentRoot.Left) : 0) +
                (currentRoot.Right != null ? GetSizeOfNode(currentRoot.Right) : 0)
                );
        }

        public int MaxDepth()
        {
            return MaxDepthInternalRecursiveUtil(this.Root);
        }

        private int MaxDepthInternalRecursiveUtil(BinaryTreeNode<T> binaryTreeNode)
        {
            if (binaryTreeNode == null)
                return 0;

            int leftTreeDepth = MaxDepthInternalRecursiveUtil(binaryTreeNode.Left);
            int rightTreeDepth = MaxDepthInternalRecursiveUtil(binaryTreeNode.Right);

            return 1+ Math.Max(leftTreeDepth, rightTreeDepth);
        }

        public bool AreIdentical(BinaryTree<T> other)
        {
            return AreIdenticalInternalRecursiveUtil(this.Root,other.Root);
        }

        private bool AreIdenticalInternalRecursiveUtil(BinaryTreeNode<T> binaryTreeNode1, BinaryTreeNode<T> binaryTreeNode2)
        {
            if(binaryTreeNode1==null && binaryTreeNode2==null)
            {
                return true;
            }
            else if(binaryTreeNode1==null || binaryTreeNode2==null)
            {
                return false;
            }
            else
            {
                return ( binaryTreeNode1.Data.CompareTo(binaryTreeNode2.Data) == 0  && 
                    AreIdenticalInternalRecursiveUtil(binaryTreeNode1.Left, binaryTreeNode2.Left) &&
                    AreIdenticalInternalRecursiveUtil(binaryTreeNode1.Right,binaryTreeNode2.Right)
                    );
            }
        }

        public void PrintLevelOrderTranversal()
        {
            List<BinaryTreeNode<T>> listOfNodes = new List<BinaryTreeNode<T>>();
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this.Root);

            while (queue.Count>0)
            {
                BinaryTreeNode<T> current = queue.Dequeue();
                listOfNodes.Add(current);

                if(current.Left!=null)
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            //Print all
            foreach (var item in listOfNodes)
            {
                Console.Write(item.Data + ", ");
            }
            Console.WriteLine();
        }

        public void PreorderTraversalRecursive()
        {
            PreorderTraversalInternalUtil(this.Root);
            Console.WriteLine();

        }

        private void PreorderTraversalInternalUtil(BinaryTreeNode<T> current)
        {
            if(current!=null)
            {
                Console.Write(current.Data + ", ");
                PreorderTraversalInternalUtil(current.Left);
                PreorderTraversalInternalUtil(current.Right);
            }
        }

        public void PostorderTraversalRecursive()
        {
            PostorderTraversalInternalUtil(this.Root);
            Console.WriteLine();
        }

        private void PostorderTraversalInternalUtil(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                PostorderTraversalInternalUtil(current.Left);
                PostorderTraversalInternalUtil(current.Right);
                Console.Write(current.Data + ", ");
            }
        }

        public void InorderTraversalRecursive()
        {
            InorderTraversalInternalUtil(this.Root);
            Console.WriteLine();

        }

        private void InorderTraversalInternalUtil(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                InorderTraversalInternalUtil(current.Left);
                Console.Write(current.Data + ", ");
                InorderTraversalInternalUtil(current.Right);
            }
        }

        public void PostOrderTraversalIterative()
        {
            Stack<BinaryTreeNode<T>> myStack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> prev = null;

            List<BinaryTreeNode<T>> listOfNodes = new List<BinaryTreeNode<T>>();

            myStack.Push(this.Root);

            while (myStack.Count > 0)
            {
                BinaryTreeNode<T> current = myStack.Peek();

                if (IsLeaf(current) || 
                    current.Right == prev || 
                    (current.Right==null && current.Left==prev))
                {
                    //leaf or upward  - Process it
                    myStack.Pop();
                    listOfNodes.Add(current);
                }
                else
                {
                    //Sibling or downwards flow
                    if (current.Right != null)
                    {
                        myStack.Push(current.Right);
                    }
                    if (current.Left != null)
                    {
                        myStack.Push(current.Left);
                    }
                }

                prev = current;
            }

            //Print list
            foreach (var item in listOfNodes)
            {
                Console.Write(item.Data + ", ");
            }
            Console.WriteLine();
        }

        public void PreOrderTraversalIterative()
        {
            Stack<BinaryTreeNode<T>> myStack = new Stack<BinaryTreeNode<T>>();

            List<BinaryTreeNode<T>> listOfNodes = new List<BinaryTreeNode<T>>();

            myStack.Push(this.Root);

            while (myStack.Count > 0)
            {
                BinaryTreeNode<T> current = myStack.Peek();
                listOfNodes.Add(current);
                myStack.Pop();

                if (current.Right != null)
                {
                    myStack.Push(current.Right);
                }
                if (current.Left != null)
                {
                    myStack.Push(current.Left);
                }
            }

            //Print list
            foreach (var item in listOfNodes)
            {
                Console.Write(item.Data + ", ");
            }
            Console.WriteLine();
        }

        private bool IsLeaf(BinaryTreeNode<T> current)
        {
            return (current.Right == null && current.Left == null);
        }

        public void InorderTraversalIterative()
        {
            Stack<BinaryTreeNode<T>> myStack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = this.Root;

            List<BinaryTreeNode<T>> listOfNodes = new List<BinaryTreeNode<T>>();

            //Go to left most node which needs to be processed first
            while (current!=null)
            {
                myStack.Push(current);
                current = current.Left;
            }

            while (myStack.Count > 0)
            {
                //Process and discard as it would be left most
                BinaryTreeNode<T> currentStackItem = myStack.Peek();
                listOfNodes.Add(currentStackItem);
                myStack.Pop();

                if (currentStackItem.Right != null)
                {
                    BinaryTreeNode<T> rightSideLeftNodes = currentStackItem.Right;
                    while (rightSideLeftNodes != null)
                    {
                        myStack.Push(rightSideLeftNodes);
                        rightSideLeftNodes = rightSideLeftNodes.Left;
                    }
                }
            }

            //Print list
            foreach (var item in listOfNodes)
            {
                Console.Write(item.Data + ", ");
            }
            Console.WriteLine();
        }
    }
}
