using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class AugmentedBtNode<T> : BinaryTreeNode<T> where T : IComparable
    {
        public int LeftSubTreeCount
        {
            get
            {
                if (base.AddOns != null)
                    return base.AddOns[0];
                else
                    return default(int);
            }
            set
            {
                if (base.AddOns == null)
                {
                    base.AddOns = new DataList(2);
                }
                base.AddOns[0] = value;
            }
        }

        public int RightSubTreeCount
        {
            get
            {
                if (base.AddOns != null)
                    return base.AddOns[1];
                else
                    return default(int);
            }
            set
            {
                if (base.AddOns == null)
                {
                    base.AddOns = new DataList(2);
                }
                base.AddOns[1] = value;
            }
        }

        public AugmentedBtNode(T data) : base(data)
        {

        }
        public AugmentedBtNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
            : base(data,left,right)
        {
        }

        public AugmentedBtNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right, int leftSubTreeCount, int rightSubTreeCount)
            : base(data, left, right)
        {
            this.AddOns = new DataList(2);

            this.AddOns[0] = leftSubTreeCount;
            this.AddOns[1] = rightSubTreeCount;
        }
    }
}
