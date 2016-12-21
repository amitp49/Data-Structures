using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DllNode<T> : BinaryTreeNode<T> where T: IComparable
    {
        public DllNode<T> Prev
        {
            get
            {
                return (DllNode < T >) this.Left;
            }
            set
            {
                this.Left = value;
            }
        }
        public DllNode<T> Next
        {
            get
            {
                return (DllNode<T>)this.Right;
            }
            set
            {
                this.Right = value;
            }
        }

        public DllNode(T data) : base(data)
        {
            this.Prev = null;
            this.Next = null;
        }

    }
}
