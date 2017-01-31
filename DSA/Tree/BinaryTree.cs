using Interfaces;
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

        public virtual bool Contains(T data)
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

        public int LargestBstSubtree()
        {
            int size = 0;
            //Use reflection to get min and max value
            LargestBstSubtreeInternalUtil(this.Root,
                (T)typeof(T).GetField("MinValue").GetValue(null),
                (T)typeof(T).GetField("MaxValue").GetValue(null),
                ref size);
            return size;
        }

        private bool LargestBstSubtreeInternalUtil(BinaryTreeNode<T> currentRoot, T minValueAllowd, T maxValueAllowed, ref int maxBstSubtreeSize)
        {
            if (currentRoot == null)
                return true;

            int leftTreeSize = 0;
            bool isLeftTreeBst = LargestBstSubtreeInternalUtil(currentRoot.Left, minValueAllowd, currentRoot.Data, ref leftTreeSize);

            int rightTreeSize = 0;
            bool isRightTreeBst = LargestBstSubtreeInternalUtil(currentRoot.Right, currentRoot.Data, maxValueAllowed, ref rightTreeSize);

            bool currentNodeSatisfyBstCondition = (currentRoot.Data.CompareTo(minValueAllowd) > 0 &&
                currentRoot.Data.CompareTo(maxValueAllowed) < 0);

            if (isLeftTreeBst == true && maxBstSubtreeSize < leftTreeSize)
            {
                maxBstSubtreeSize = leftTreeSize;
            }
            if (isRightTreeBst == true && maxBstSubtreeSize < rightTreeSize)
            {
                maxBstSubtreeSize = rightTreeSize;
            }
            if (currentNodeSatisfyBstCondition == true)
            {
                maxBstSubtreeSize = leftTreeSize + rightTreeSize + 1;
            }
            return (currentNodeSatisfyBstCondition == true && isLeftTreeBst == true && isRightTreeBst == true);
        }

        public virtual BinaryTreeNode<T> FindLowestCommonAncestor(T data1, T data2)
        {
            return FindLowestCommonAncestorInternalUtil(this.Root,data1,data2);
        }

        private BinaryTreeNode<T> FindLowestCommonAncestorInternalUtil(BinaryTreeNode<T> currentRoot, T data1, T data2)
        {
            if (currentRoot == null)
                return null;

            if (currentRoot.Data.CompareTo(data1) == 0 || currentRoot.Data.CompareTo(data2) == 0)
                return currentRoot;

            BinaryTreeNode<T> nodeFoundOnLeft = FindLowestCommonAncestorInternalUtil(currentRoot.Left,data1,data2);
            BinaryTreeNode<T> nodeFoundOnRight = FindLowestCommonAncestorInternalUtil(currentRoot.Right,data1,data2);

            if (nodeFoundOnLeft != null && nodeFoundOnRight != null)
                return currentRoot;

            if (nodeFoundOnLeft != null)
                return nodeFoundOnLeft;

            if (nodeFoundOnRight != null)
                return nodeFoundOnRight;

            return null;
        }

        public void PrintRootToLeafPaths()
        {
            T[] arr = new T[this.MaxDepth()]; // to get max length of path
            PrintRootToLeafPathsInternalUtil(this.Root,arr, 0);
        }

        private void PrintRootToLeafPathsInternalUtil(BinaryTreeNode<T> currentRoot,T[] arr, int currentDepth)
        {
            if (currentRoot == null)
                return;

            arr[currentDepth] = currentRoot.Data;

            if(IsLeaf(currentRoot))
            {
                //Print path accumlated till now
                PrintPath(arr, currentDepth);
            }
            else
            {
                PrintRootToLeafPathsInternalUtil(currentRoot.Left, arr, currentDepth + 1);
                PrintRootToLeafPathsInternalUtil(currentRoot.Right, arr, currentDepth + 1);
            }
        }

        private void PrintPath(T[] arr, int length)
        {
            for (int i = 0; i <= length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }

        public void MirrorTree()
        {
            MirrorTreeInternalUtil(this.Root);
            return;
        }

        private void MirrorTreeInternalUtil(BinaryTreeNode<T> binaryTreeNode)
        {
            if (binaryTreeNode == null)
                return;

            MirrorTreeInternalUtil(binaryTreeNode.Left);
            MirrorTreeInternalUtil(binaryTreeNode.Right);

            //Process node
            BinaryTreeNode<T> temp = binaryTreeNode.Left;
            binaryTreeNode.Left = binaryTreeNode.Right;
            binaryTreeNode.Right = temp;
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

        public T[] GetInorderTraversal()
        {
            int index = 0;
            int treeSize = this.GetSizeOfTree();
            T[] arr = new T[treeSize];
            InorderTraversalInternalUtil(this.Root, arr, ref index);
            return arr;
        }

        public void InorderTraversalRecursive()
        {
            int index = 0;
            int treeSize = this.GetSizeOfTree();
            T[] arr = new T[treeSize];
            InorderTraversalInternalUtil(this.Root,arr,ref index);
            for (int i = 0; i < treeSize; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }

        private void InorderTraversalInternalUtil(BinaryTreeNode<T> current, T[] arr,ref int index)
        {
            if (current != null)
            {
                InorderTraversalInternalUtil(current.Left, arr, ref index);
                arr[index] = current.Data;
                index++;
                InorderTraversalInternalUtil(current.Right, arr, ref index);
            }
        }

		private class PostOrderStackData
		{
			public BinaryTreeNode<T> node;
			public int recursionId;
			public PostOrderStackData(BinaryTreeNode<T> node, int recursionId)
			{
				this.node = node;
				this.recursionId = recursionId;
			}
		}

		public void PostOrderTraversalIterativeCompilerMimic()
		{
			Stack<PostOrderStackData> myStack = new Stack<PostOrderStackData>();
			var current = this.Root;
			bool flagRec1 = false;
			bool flagRec2 = false;
			
			Console.WriteLine("Compiler mimic post order...");
			while (true)
			{
				if (current == null)
				{
					if (myStack.Count <= 0)
					{
						break;
					}
					else
					{
						var item = myStack.Pop();
						current = item.node;

						if(item.recursionId==1)
							flagRec1 = true;
						else
							flagRec2 = true;
					}
				}
				else
				{
					if (flagRec1 == false && flagRec2==false)
					{
						myStack.Push(new PostOrderStackData(current,1));
						current = current.Left;
					}
					else
					{
						flagRec1 = false;
						if (flagRec2 == false)//CRITICAL FLAG2
						{
							myStack.Push(new PostOrderStackData(current, 2));
							current = current.Right;
						}
						else
						{
							flagRec2 = false;
							Console.Write("{0}, ", current.Data);
							current = null; //CRITICAL
						}
					}
				}
			}
			Console.WriteLine("");
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

		public void PreOrderTraversalIterativeCompilerMimic()
		{
			Stack<BinaryTreeNode<T>> myStack = new Stack<BinaryTreeNode<T>>();
			var current = this.Root;
			bool flagRec = false;
			Console.WriteLine("Compiler mimic pre order...");
			while (true)
			{
				if (current == null)
				{
					if (myStack.Count <= 0)
					{
						break;
					}
					else
					{
						var item = myStack.Pop();
						current = item;
						flagRec = true;
					}
				}
				else
				{
					if (flagRec == false)
					{
						Console.Write("{0}, ", current.Data);
						myStack.Push(current);
						current = current.Left;
					}
					else
					{
						flagRec = false;
						current = current.Right;
					}
				}
			}
			Console.WriteLine("");
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

		public void InOrderTraversalIterativeCompilerMimic()
		{
			Stack<BinaryTreeNode<T>> myStack = new Stack<BinaryTreeNode<T>>();
			var current = this.Root;
			bool flagRec = false;
			Console.WriteLine("Compiler mimic in order...");
			while (true)
			{
				if (current == null)
				{
					if (myStack.Count <= 0)
					{
						break;
					}
					else
					{
						var item = myStack.Pop();
						current = item;
						flagRec = true;
					}
				}
				else
				{
					if (flagRec == false)
					{
						myStack.Push(current);
						current = current.Left;
					}
					else
					{
						flagRec = false;
						Console.Write("{0}, ", current.Data);
						current = current.Right;
					}
				}
			}
			Console.WriteLine("");
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
