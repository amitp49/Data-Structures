using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
    {
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

        public T MinValue()
        {
            BinaryTreeNode<T> current = this.Root;

            while (current.Left!=null)
            {
                current = current.Left;
            }

            return current.Data;
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
    }
}
