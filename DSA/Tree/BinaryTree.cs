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
    }
}
