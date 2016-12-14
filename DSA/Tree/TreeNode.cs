using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TreeNode<T>
    {
        private T data;
        private IList<TreeNode<T>> neighbors;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        
        public IList<TreeNode<T>> Neighbors {
            get { return neighbors; } 
            set{neighbors = value;}
        }
        public TreeNode(T data)
        {
            this.data = data;
        }

        public TreeNode(T data, IList<TreeNode<T>> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }
    }
}
