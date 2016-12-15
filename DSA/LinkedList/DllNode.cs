using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DllNode<T>
    {
        public T Data { get; set; }
        public DllNode<T> Prev { get; set; }

        public DllNode<T> Next { get; set; }

        public DllNode(T data)
        {
            this.Data = data;
            this.Prev = null;
            this.Next = null;
        }
    }
}
