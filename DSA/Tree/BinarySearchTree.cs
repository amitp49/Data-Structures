﻿using Interfaces;
using LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
    {
        public BinarySearchTree()
        {

        }

        public BinarySearchTree(BinaryTreeNode<T> root): base(root)
        {

        }

        public static BinarySearchTree<T> GetBstFromSortedArray(T[] sortedArray)
        {
            int n = sortedArray.Length;
            BinaryTreeNode<T> root = BinarySearchTree<T>.GetBstFromSortedArrayInternalUtil(sortedArray, 0, n-1);
            return new BinarySearchTree<T>(root);
        }

        private static BinaryTreeNode<T> GetBstFromSortedArrayInternalUtil(T[] sortedArray, int start, int end)
        {
            if (start > end)
                return null;

            int mid = start + (end - start) / 2;
            BinaryTreeNode<T> root = new BinaryTreeNode<T>(sortedArray[mid]);

            root.Left = GetBstFromSortedArrayInternalUtil(sortedArray, start, mid - 1);
            root.Right = GetBstFromSortedArrayInternalUtil(sortedArray, mid+1, end);

            return root;
        }

        public static BinarySearchTree<T> GetBstFromSortedList(SinglyLinkedList<T> sortedList)
        {
            int n = sortedList.GetCount();
            SllNode<T> head = sortedList.Head;
            BinaryTreeNode<T> root = BinarySearchTree<T>.GetBstFromSortedListInternalUtil(ref head, n);
            return new BinarySearchTree<T>(root);
        }

        private static BinaryTreeNode<T> GetBstFromSortedListInternalUtil(ref SllNode<T> currentSllNode, int n)
        {
            if (n <= 0)
                return null;

            //Convert n/2 nodes to left side tree
            BinaryTreeNode<T> leftRoot = GetBstFromSortedListInternalUtil(ref currentSllNode, n / 2);

            //Make current node as root - ASSUME recursion would have incremented pointer in list
            BinaryTreeNode<T> root = new BinaryTreeNode<T>(currentSllNode.Data);
            root.Left = leftRoot;

            //Critical - move ahead in sortedlist
            currentSllNode = currentSllNode.Next;

             //Convert n/2 nodes to left side tree
            BinaryTreeNode<T> rightRoot = GetBstFromSortedListInternalUtil(ref currentSllNode, n - n / 2 - 1);
            root.Right = rightRoot;

            return root;
        }

        public BinaryTreeNode<T> Insert(T newData)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(newData);
            return this.Insert(newNode);
        }

        public BinaryTreeNode<T> Insert(BinaryTreeNode<T> newNode)
        {
            this.Root = this.InsertInternalUtil(this.Root, newNode); //Citical .. root can change
            return newNode;
        }

        private BinaryTreeNode<T> InsertInternalUtil(BinaryTreeNode<T> currentRoot, BinaryTreeNode<T> newNode)
        {
            if(currentRoot == null)
            {
                currentRoot = newNode;
            }
            else if(currentRoot.Data.CompareTo(newNode.Data) > 0) //go to left
            {
                currentRoot.Left = InsertInternalUtil(currentRoot.Left, newNode);
            }
            else if (currentRoot.Data.CompareTo(newNode.Data) < 0) //go to right
            {
                currentRoot.Right = InsertInternalUtil(currentRoot.Right, newNode);
            }

            return currentRoot;
        }

        public bool IsBst()
        {
            //Use reflection to get min and max value
            return IsBstInternalUtil(this.Root, 
                (T) typeof(T).GetField("MinValue").GetValue(null),
                (T) typeof(T).GetField("MaxValue").GetValue(null));
        }

        private bool IsBstInternalUtil(BinaryTreeNode<T> currentRoot, T minValueAllowd, T maxValueAllowed)
        {
            if (currentRoot == null)
                return true;

            return (currentRoot.Data.CompareTo(minValueAllowd) > 0 &&
                currentRoot.Data.CompareTo(maxValueAllowed) < 0 &&
                IsBstInternalUtil(currentRoot.Left, minValueAllowd, currentRoot.Data) &&
                IsBstInternalUtil(currentRoot.Right,currentRoot.Data,maxValueAllowed)
                );
        }

        public DoublyLinkedList<T> BstToDll()
        {
            DllNode<T> head = null;
            DllNode<T> tail = null;

            return BstToDllInternalUtil(this.Root);
        }

        private DoublyLinkedList<T> BstToDllInternalUtil(BinaryTreeNode<T> currentRoot)
        {
            if (currentRoot == null)
                return null;

            //TODO: Need to complete this.
            //DllNode<T> convertedNode = (DllNode<T>) currentRoot;
            //DoublyLinkedList<T> dll = new DoublyLinkedList<T>();

            return null;
        }

        public override bool Contains(T data)
        {
            return ContainsInternalUtil(this.Root,data);
        }

        private bool ContainsInternalUtil(BinaryTreeNode<T> currentRoot, T data)
        {
            if (currentRoot == null)
                return false;

            if (currentRoot.Data.CompareTo(data) == 0)
                return true;
            else if (currentRoot.Data.CompareTo(data) > 0)
                return ContainsInternalUtil(currentRoot.Left,data);
            else if (currentRoot.Data.CompareTo(data) < 0)
                return ContainsInternalUtil(currentRoot.Right, data);

            return false;
        }

        public BinaryTreeNode<T> InOrderSuccessor(BinaryTreeNode<T> node)
        {
            //Case-1: If node has right child
            BinaryTreeNode<T> rightChild = node.Right;
            if (rightChild != null)
            {
                return MinValue(rightChild);
            }

            //Case-2: if it doesn't have right child, and we doesn't have parent pointer to up the ladder from node
            BinaryTreeNode<T> successor = null;
            BinaryTreeNode<T> current = this.Root;

            while (current!=null && current!=node)
            {
                if(current.Data.CompareTo(node.Data) > 0) // we will take left route
                {
                    successor = current; //Maintain left turns
                    current = current.Left;
                }
                else // we will take right roor
                {
                    current = current.Right;
                }
            }

            return successor;
        }

        public BinaryTreeNode<T> KthSmallestNode(int k)
        {
            int count = 0; //To maintain processed count
            return KthSmallestNodeInternalUtil(this.Root, k, ref count);
        }

        private BinaryTreeNode<T> KthSmallestNodeInternalUtil(BinaryTreeNode<T> currentRoot, int k, ref int count)
        {
            if (currentRoot == null)
                return null;

            BinaryTreeNode<T> leftSideSearchResult = KthSmallestNodeInternalUtil(currentRoot.Left, k, ref count);
            if (leftSideSearchResult != null)
                return leftSideSearchResult;

            count++;
            //Inorder processing
            if (count == k)
                return currentRoot;

            return KthSmallestNodeInternalUtil(currentRoot.Right, k, ref count);
        }

        public T MinValue()
        {
            BinaryTreeNode<T> current = this.Root;
            return MinValue(current).Data;
            
        }

        private BinaryTreeNode<T> MinValue(BinaryTreeNode<T> current)
        {
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        public BinarySearchTree<T> GetMergeTree( BinarySearchTree<T> other)
        {
            return GetMergeTree(this,other);
        }
        public static BinarySearchTree<T> GetMergeTree(BinarySearchTree<T> first, BinarySearchTree<T> second)
        {
            T[] firstInorder = first.GetInorderTraversal();
            T[] secondInorder = second.GetInorderTraversal();

            T[] mergedArr = MergeSortedArray(firstInorder, secondInorder);

            return GetBstFromSortedArray(mergedArr);
        }

        private static T[] MergeSortedArray(T[] firstInorder, T[] secondInorder)
        {
            
            int n=firstInorder.Length,m=secondInorder.Length;
            int i = 0, j = 0, k = 0;

            T[] mergeArray = new T[n + m];

            while (i<n && j<m)
            {
                if(firstInorder[i].CompareTo(secondInorder[j]) <= 0)
                {
                    mergeArray[k] = firstInorder[i];
                    i++;
                }
                else if (firstInorder[i].CompareTo(secondInorder[j]) > 0)
                {
                    mergeArray[k] = secondInorder[j];
                    j++;
                }
                k++;
            }

            while (i<n)
            {
                 mergeArray[k] = firstInorder[i];
                 i++;
                 k++;
            }

            while (j < m)
            {
                mergeArray[k] = firstInorder[j];
                j++;
                k++;
            }
            return mergeArray;
        }

        public static bool IsPreOrderWithOnlyOneChildSatisfyBstProperty(T[] preOrder)
        {
            T min = (T) typeof(T).GetField("MinValue").GetValue(null);
            T max = (T) typeof(T).GetField("MaxValue").GetValue(null);

            if (preOrder.Length <= 2)
                return true;

            for (int i = 0; i < preOrder.Length - 2; i++)
            {
                if(preOrder[i].CompareTo(max) < 0 && preOrder[i].CompareTo(min)>0)
                {
                    if( preOrder[i].CompareTo(preOrder[i+1]) > 0) //we found new max limit
                    {
                        max = preOrder[i];
                    } else if (preOrder[i].CompareTo(preOrder[i + 1]) < 0) //we found new max limit
                    {
                        min = preOrder[i];
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Will work only for int
        /// </summary>
        public void AddGreaterNodeSum()
        {
            int sum = 0;
            AddGreaterNodeSumInternalUtil(this.Root,ref sum); 
        }

        private void AddGreaterNodeSumInternalUtil(BinaryTreeNode<T> current, ref int sum)
        {
            if (current == null)
                return;
            //Do reverse inorder , right - node - left
            AddGreaterNodeSumInternalUtil(current.Right, ref sum);
            sum += (int)(object)current.Data;
            current.Data = (T)(object)sum;
            AddGreaterNodeSumInternalUtil(current.Left, ref sum);
        }

        public T CeilIterative(T data)
        {
            BinaryTreeNode<T> current = this.Root;
            BinaryTreeNode<T> ceilingNode = null;

            while (current!=null)
            {
                if(current.Data.CompareTo(data)==0)
                {
                    return current.Data;
                }
                else if (current.Data.CompareTo(data) < 0)
                {
                    current = current.Right;
                } 
                else if(current.Data.CompareTo(data) > 0)
                {
                    ceilingNode = current; //while taking left turn, store
                    current = current.Left;
                }
            }
            if (ceilingNode != null)
                return ceilingNode.Data;

            return default(T);
        }

        public T FloorIterative(T data)
        {
            BinaryTreeNode<T> current = this.Root;
            BinaryTreeNode<T> floorNode = null;

            while (current != null)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    return current.Data;
                }
                else if (current.Data.CompareTo(data) < 0)
                {
                    floorNode = current; //while taking right turn, store
                    current = current.Right;
                }
                else if (current.Data.CompareTo(data) > 0)
                {
                    current = current.Left;
                }
            }
            if (floorNode != null)
                return floorNode.Data;

            return default(T);
        }

        public T Ceil(T data)
        {
             BinaryTreeNode<T> ceilingNode =  CeilInternalUtil(this.Root, data);
             if (ceilingNode != null)
                 return ceilingNode.Data;

             return default(T);
        }

        private BinaryTreeNode<T> CeilInternalUtil(BinaryTreeNode<T> currentRoot, T data)
        {
            if (currentRoot == null)
                return null;

            if(currentRoot.Data.CompareTo(data)==0)
            {
                return currentRoot;
            }

            if (currentRoot.Data.CompareTo(data) < 0)
                return CeilInternalUtil(currentRoot.Right, data); //go to right first as we want ceil, and root cann't be ceiling if root is less

            BinaryTreeNode<T> ceilingNode = CeilInternalUtil(currentRoot.Left, data);
            if(ceilingNode!=null)
            {
                return ceilingNode;
            }
            else
            {
                //return root as we couldn't find ceiling in left side
                return currentRoot;
            }
        }

        public void CorrectBst()
        {
            BinaryTreeNode<T> prevToCurrent = null;
            BinaryTreeNode<T> prevToFirstPointInViolation = null;
            BinaryTreeNode<T> firstPointInViolation = null;
            BinaryTreeNode<T> secondPointInViolation = null;

            CorrectBstInorderInternalUtil(this.Root, ref prevToCurrent,ref prevToFirstPointInViolation,ref firstPointInViolation,ref secondPointInViolation);

            //fix tree based on violations
            if(firstPointInViolation!=null && secondPointInViolation!=null) //misplaced nodes are not adjecent
            {
                SwapData(prevToFirstPointInViolation, secondPointInViolation);
            }
            else if(firstPointInViolation!=null && prevToFirstPointInViolation!=null && secondPointInViolation==null) //misplaced nodes are adjecent
            {
                SwapData(prevToFirstPointInViolation, firstPointInViolation);
            }
        }

        private void SwapData(BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
        {
            T temp = node1.Data;
            node1.Data = node2.Data;
            node2.Data = temp;
        }

        private void CorrectBstInorderInternalUtil(BinaryTreeNode<T> currentRoot, ref BinaryTreeNode<T> prevToCurrent, ref BinaryTreeNode<T> prevToFirstPointInViolation, ref BinaryTreeNode<T> firstPointInViolation, ref BinaryTreeNode<T> secondPointInViolation)
        {
            if (currentRoot == null)
                return;

            //Recurse on left
            CorrectBstInorderInternalUtil(currentRoot.Left, ref prevToCurrent, ref prevToFirstPointInViolation, ref firstPointInViolation, ref secondPointInViolation);

            //Process
            if(prevToCurrent!=null && prevToCurrent.Data.CompareTo(currentRoot.Data) > 0 ) //violation of bst sorted inorder
            {
                if (firstPointInViolation==null)
                {
                    prevToFirstPointInViolation = prevToCurrent;
                    firstPointInViolation = currentRoot;
                }
                else if (secondPointInViolation==null)
                {
                    secondPointInViolation = currentRoot;
                }
                else
                {
                    //more than two violation. can't fix
                }
            }
            prevToCurrent = currentRoot;

            //Recurse on right
            CorrectBstInorderInternalUtil(currentRoot.Right, ref prevToCurrent, ref prevToFirstPointInViolation, ref firstPointInViolation, ref secondPointInViolation);
        }

        public override BinaryTreeNode<T> FindLowestCommonAncestor(T data1, T data2)
        {
            return FindLowestCommonAncestorInternalUtil(this.Root, data1, data2);
        }

        private BinaryTreeNode<T> FindLowestCommonAncestorInternalUtil(BinaryTreeNode<T> currentRoot, T data1, T data2)
        {
            if (currentRoot == null)
                return null;

            if(currentRoot.Data.CompareTo(data1) > 0 && currentRoot.Data.CompareTo(data2) > 0)
            {
                return FindLowestCommonAncestorInternalUtil(currentRoot.Left, data1, data2);
            }

            if (currentRoot.Data.CompareTo(data1) < 0 && currentRoot.Data.CompareTo(data2) < 0)
            {
                return FindLowestCommonAncestorInternalUtil(currentRoot.Right, data1, data2);
            }

            return currentRoot;
        }

        public static BinarySearchTree<T> ConstructBstFromPreOrder(T[] preOrderOfTree)
        {
            int currentIndex = 0;
            T min = (T) typeof(T).GetField("MinValue").GetValue(null);
            T max = (T) typeof(T).GetField("MaxValue").GetValue(null);
            BinaryTreeNode<T> root = ConstructBstFromPreOrderInternalUtil(preOrderOfTree,ref currentIndex,min,max);
            return new BinarySearchTree<T>(root);
        }

        private static BinaryTreeNode<T> ConstructBstFromPreOrderInternalUtil(T[] preOrderOfTree, ref int currentIndex, T minValueAllowed, T maxValueAllowed)
        {
            if (currentIndex >= preOrderOfTree.Length)
                return null;

            BinaryTreeNode<T> newNode = null;
            T currentKey = preOrderOfTree[currentIndex];
            if ((currentKey.CompareTo(minValueAllowed) > 0) &&
                (currentKey.CompareTo(maxValueAllowed) < 0))
            {
                newNode = new BinaryTreeNode<T>(currentKey);
                currentIndex++;
                newNode.Left = ConstructBstFromPreOrderInternalUtil(preOrderOfTree, ref currentIndex, minValueAllowed, currentKey);
                newNode.Right = ConstructBstFromPreOrderInternalUtil(preOrderOfTree, ref currentIndex, currentKey, maxValueAllowed);
            }
            return newNode;
        }
    }
}
