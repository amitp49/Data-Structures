using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList<T>
    {
         private DllNode<T> head;
        //the head of doubly linked list
        public DllNode<T> Head { 
            get {return head;}
            private set {head = value;}
        }

        public DoublyLinkedList()
        {
            this.Head = null;
        }

        public DoublyLinkedList(DllNode<T> someHeadOfOtherList)
        {
            this.Head = someHeadOfOtherList;
        }
    }
}
