using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class NodeList<T> : Collection<TreeNode<T>> where T: IComparable
    {
        public NodeList() : base()
        {

        }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
                base.Items.Add(default(TreeNode<T>));
            }
        }
    }
}
