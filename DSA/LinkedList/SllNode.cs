using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SllNode<T>
    {
        public T Data { get; set; }
        public SllNode<T> Next { get; set; }

        public SllNode(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}
