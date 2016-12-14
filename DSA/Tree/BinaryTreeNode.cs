using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTreeNode<T> : TreeNode<T>
    {
        public BinaryTreeNode<T> Left 
        { 
            get
            {
                if (base.Neighbors != null)
                    return (BinaryTreeNode<T>)base.Neighbors[0];
                else
                    return null;
            }
            private set
            {
                if(base.Neighbors==null)
                    base.Neighbors = new List<TreeNode<T>>(2);
                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors != null)
                    return (BinaryTreeNode<T>)base.Neighbors[1];
                else
                    return null;
            }
            private set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new List<TreeNode<T>>(2);
                base.Neighbors[1] = value;
            }
        }

        public BinaryTreeNode(T data) : base(data)
        {

        }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
            : base(data)
        {
            this.Neighbors = new List<TreeNode<T>>(2);
            this.Neighbors[0] = left;
            this.Neighbors[1] = right;
        }
    }
}
