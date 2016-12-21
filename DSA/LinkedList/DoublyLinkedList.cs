using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList<T> where T : IComparable
    {
        private DllNode<T> head;
        //the head of doubly linked list
        public DllNode<T> Head { 
            get {return head;}
            private set {head = value;}
        }

        public DllNode<T> Tail { get; set; }
        public DoublyLinkedList()
        {
            this.Head = null;
            this.Tail = null;
        }

        public DoublyLinkedList(DllNode<T> someHeadOfOtherList,DllNode<T> tailOfOtherList)
        {
            this.Head = someHeadOfOtherList;
            this.Tail = tailOfOtherList;
        }

        public void PushToHead(T data)
        {
            //Allocate new node
            DllNode<T> newNode = new DllNode<T>(data);
            this.PushToHead(newNode);
        }

        public void PushToHead(DllNode<T> newNode)
        {
            //Append whole list behind new node
            newNode.Next = Head;

            if (this.Tail == null)
            {
                this.Tail = newNode;
            }

            if (Head != null)
            {
                Head.Prev = newNode;
            }

            //Make new node as head of the list
            Head = newNode;
        }

        public void Print()
        {
            DllNode<T> current = Head;
            while (current != null)
            {
                Console.Write(current.Data);
                Console.Write("->");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public DllNode<T> DeleteHeadNode()
        {
            return DeleteNode(this.Head);
        }

        public DllNode<T> DeleteNode(DllNode<T> node)
        {

            DllNode<T> prevNode = node.Prev;
            DllNode<T> nextNode = node.Next;

            if (prevNode==null) //node to be deleted is head
            {
                this.Head = null;
            }
            else
            {
                prevNode.Next = nextNode;
            }

            if(nextNode!=null) // node to be deleted is not last node
            {
                nextNode.Prev = prevNode;
            }
            else //if(nextNode==null) //node to be deleted is last node
            {
                this.Tail = null;
            }
            return node;
        }
    }
}
