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
            return false;
        }

        public void PrintLevelOrderTranversal()
        {
            
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

        private static bool IsLeaf(BinaryTreeNode<T> current)
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
