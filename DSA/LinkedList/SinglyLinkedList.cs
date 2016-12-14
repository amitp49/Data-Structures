using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SinglyLinkedList<T> where T : IComparable
    {
        private SllNode<T> head;
        //the head of singly linked list
        public SllNode<T> Head { 
            get {return head;}
            private set {head = value;}
        }

        public SinglyLinkedList()
        {
            this.Head = null;
        }

        public SinglyLinkedList(SllNode<T> someHeadOfOtherList)
        {
            this.Head = someHeadOfOtherList;
        }

        public void PushToHead(T data)
        {
            //Allocate new node
            SllNode<T> newNode = new SllNode<T>(data);

            //Append whole list behind new node
            newNode.Next = Head;

            //Make new node as head of the list
            Head = newNode;
        }

        public int GetCount()
        {
            SllNode<T> current = Head;
            int count = 0;
            while(current!=null)
            {
                count++;
                current = current.Next;
            }
            return count;
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

        public SllNode<T> GetMiddleNode()
        {
            SllNode<T> prevToMiddleNode = null;
            return this.GetMiddleNode(out prevToMiddleNode);
        }

        public SllNode<T> GetMiddleNode(out SllNode<T> prevToMiddleNode)
        {
            SllNode<T> fastPointer = Head;
            SllNode<T> slowPointer = Head;
            prevToMiddleNode = null;

            while (fastPointer != null && fastPointer.Next != null && fastPointer.Next.Next != null)
            {
                fastPointer = fastPointer.Next.Next;
                prevToMiddleNode = slowPointer;
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

        public bool IsPalindromeRecursive()
        {
            SllNode<T> currentReverse = Head;
            SllNode<T> currentForward = Head;
            //Critical - passing by reference will work as data member/double pointer
            return IsPalindromeRecursiveInternalUtil(currentReverse,ref currentForward);
        }

        private bool IsPalindromeRecursiveInternalUtil(SllNode<T> currentReverse, ref SllNode<T> currentForward)
        {
            bool remainingListIsPalindrome = true;
            //Go ahead till you reach end of list for one pointer
            if (currentReverse.Next != null)
            {
                remainingListIsPalindrome = IsPalindromeRecursiveInternalUtil(currentReverse.Next,ref currentForward);
            }

            //Now when coming back from recursion, will check for data equality
            if(currentForward.Data.CompareTo(currentReverse.Data)==0)
            {
                currentForward = currentForward.Next;
                return remainingListIsPalindrome;
            }
            return false;
        }
        
        public bool IsPalindromeWithoutExtraSpace()
        {
            SllNode<T> prevToMiddleNode = null;
            SllNode<T> middleNode = this.GetMiddleNode(out prevToMiddleNode);
            SllNode<T> backUpMiddleNode = middleNode;

            //Get the starting of list after middle node
            SllNode<T> nextToMiddleNode = middleNode.Next;

            //Get the odd or even count
            int length = GetCount();

            //Critical to ignore middle node if its odd count
            if (length % 2 != 0)
            {
                middleNode = prevToMiddleNode;
            }

            // Break list from middle
            middleNode.Next = null;

            //Make new second half from next to middle
            SinglyLinkedList<T> newSecondHalfList = new SinglyLinkedList<T>(nextToMiddleNode);

            //Reverse second half
            newSecondHalfList.ReverseList();

            //Compare original first half and reversed second half
            bool isSame = this.IsSameDataList(newSecondHalfList);

            //Reverse second half again to make original list
            newSecondHalfList.ReverseList();

            if (length % 2 != 0)
            {
                middleNode.Next = backUpMiddleNode;
                middleNode = middleNode.Next;
            }

            //Join both list again
            middleNode.Next = newSecondHalfList.Head;

            return isSame;
        }

        public bool IsPalindromeWithStack()
        {
            Stack<SllNode<T>> stack = new Stack<SllNode<T>>();
            SllNode<T> currentNode = Head;
            while(currentNode!=null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.Next;
            }

            //Now check by poping each node from stack and compare with current iteration
            SllNode<T> otherIterationNode = Head;
            while (otherIterationNode!=null)
            {
                SllNode<T> stackNode = stack.Pop();
                if(stackNode.Data.CompareTo(otherIterationNode.Data)!=0)
                {
                    return false;
                }
                otherIterationNode = otherIterationNode.Next;
            }

            return true;
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

        public bool IsSameDataList(SinglyLinkedList<T> otherList)
        {
            SllNode<T> currentForThisList = this.Head;
            SllNode<T> currentForOtherList = otherList.Head;

            while(currentForThisList!=null && currentForOtherList!=null)
            {
                if(currentForThisList.Data.CompareTo(currentForOtherList.Data)==0)
                {
                    currentForThisList = currentForThisList.Next;
                    currentForOtherList = currentForOtherList.Next;
                }
                else
                {
                    return false;
                }
            }

            if (currentForThisList == null && currentForOtherList == null)
                return true;

            return false;
        }
    }
}
