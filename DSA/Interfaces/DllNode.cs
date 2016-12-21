using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DllNode<T> : BinaryTreeNode<T> where T : IComparable
    {
        public DllNode<T> Prev
        {
            get
            {
                if (base.Neighbors != null)
                    return (DllNode<T>)base.Neighbors[0];
                else
                    return null;
            }
            set
            {
                if (base.Neighbors == null)
                {
                    base.Neighbors = new NodeList<T>(2);
                }
                base.Neighbors[0] = value;
            }
        }
        public DllNode<T> Next
        {
            get
            {
                if (base.Neighbors != null)
                    return (DllNode<T>)base.Neighbors[1];
                else
                    return null;
            }
            set
            {
                if (base.Neighbors == null)
                {
                    base.Neighbors = new NodeList<T>(2);
                }
                base.Neighbors[1] = value;
            }
        }

        public DllNode(T data)
            : base(data)
        {
            this.Prev = null;
            this.Next = null;
        }

    }
}
