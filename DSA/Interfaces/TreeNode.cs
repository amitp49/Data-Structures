using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class TreeNode<T> where T : IComparable
    {
        private T data;
        private NodeList<T> neighbors;
        private DataList addOns;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public NodeList<T> Neighbors
        {
            get { return neighbors; } 
            set{neighbors = value;}
        }

        public DataList AddOns
        {
            get { return addOns; }
            set { addOns = value; }
        }

        public TreeNode(T data)
        {
            this.Data = data;
            this.Neighbors = null;
            this.AddOns = null;
        }

        public TreeNode(T data, NodeList<T> neighbors)
        {
            this.Data = data;
            this.Neighbors = neighbors;
            this.AddOns = null;
        }

        public TreeNode(T data, NodeList<T> neighbors, DataList addOns)
        {
            this.Data = data;
            this.Neighbors = neighbors;
            this.AddOns = addOns;
        }
    }
}
