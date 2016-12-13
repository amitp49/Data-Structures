using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SinglyLinkedList<T> where T : IComparable
    {
        //the head of singly linked list
        public SllNode<T> Head { get; private set; }

        public void PushToHead(T data)
        {
            //Allocate new node
            SllNode<T> newNode = new SllNode<T>(data);

            //Append whole list behind new node
            newNode.Next = Head;

            //Make new node as head of the list
            Head = newNode;
        }

        public SllNode<T> GetNthNodeFromEnd(int index)
        {
            SllNode<T> currentAhead = Head;
            SllNode<T> currentBehind = Head;
            int i=0;
            //Skip index nodes from beginning
            for (i = 0; currentAhead!=null && i < index; i++)
            {
                currentAhead = currentAhead.Next;
            }

            if (i < index)
                return null;

            //when ahead one reaches end of list, behind one whould be index behind from end
            while (currentAhead!=null)
            {
                currentAhead = currentAhead.Next;
                currentBehind = currentBehind.Next;
            }

            return currentBehind; // not found, index > length of sll
        }

        public SllNode<T> GetNthNodeFromStart(int index)
        {
            SllNode<T> current = Head;
            int count = 0;
            while (current!=null && current.Next != null)
            {
                count++;
                if (count == index)
                    return current;

                current = current.Next;
            }
            return null; // not found, index > length of sll
        }

        public void DeleteNode(SllNode<T> node)
        {
            //Trick works only if its not last node
            SllNode<T> nextNode = node.Next;
            if(nextNode!=null)
            {
                node.Data = nextNode.Data;
                node.Next = nextNode.Next;
                nextNode.Next = null;//Garbage collector will delete it
            }
        }

        public SllNode<T> MiddleNode()
        {
            SllNode<T> fastPointer = Head;
            SllNode<T> slowPointer = Head;

            while (fastPointer!=null && fastPointer.Next!=null)
            {
                fastPointer = fastPointer.Next.Next;
                slowPointer = slowPointer.Next;
            }

            return slowPointer;
        }

        public void ReverseList()
        {
            SllNode<T> current = Head, prev = null, next = null;

            while (current!=null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }

        public void ReverseRecursive()
        {
            if (Head != null)
            {
                SllNode<T> oldHead = Head;
                ReverseRecursiveInternalUtil(Head);
                oldHead.Next = null; //Critical to make new last node's next as null
            }
        }

        private void ReverseRecursiveInternalUtil(SllNode<T> currentNode)
        {
            SllNode<T> nextNode = currentNode.Next;
            if (nextNode != null)
            {
                ReverseRecursiveInternalUtil(currentNode.Next);
                nextNode.Next = currentNode;
            }
            else
            {
                Head = currentNode;
            }
        }

        public bool IsLoopPresentByUsingExtraSpace()
        {
            Dictionary<SllNode<T>, bool> hashTable = new Dictionary<SllNode<T>, bool>();
            SllNode<T> currentNode = Head;
            while (currentNode!=null)
            {
                if(hashTable.ContainsKey(currentNode))
                {
                    return true;//Loop detected
                }

                hashTable.Add(currentNode, true);
                currentNode = currentNode.Next;
            }
            return false;
        }

        public bool IsLoopPresent()
        {
            SllNode<T> fastPointer = Head;
            SllNode<T> slowPointer = Head;

            while (fastPointer != null && fastPointer.Next != null)
            {
                fastPointer = fastPointer.Next.Next;
                slowPointer = slowPointer.Next;
                if(fastPointer==slowPointer)
                {
                    return true;
                }
            }

            return false;
        }

        public int countOccurances(T data)
        {
            int count = 0;
            SllNode<T> current = Head;
            while(current!=null)
            {
                if (current.Data.CompareTo(data)==0)
                    count++;

                current = current.Next;
            }
            return count;
        }

        public void DeleteList()
        {
            Head = null;
        }

        public void Print()
        {
            SllNode<T> current = Head;
            while(current!=null)
            {
                Console.Write(current.Data);
                Console.Write("->");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
