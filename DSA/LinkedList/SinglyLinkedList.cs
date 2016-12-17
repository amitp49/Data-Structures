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

        public void PushToHead(SllNode<T> newNode)
        {
            //Append whole list behind new node
            newNode.Next = Head;

            //Make new node as head of the list
            Head = newNode;
        }

        public void AlternateSplitOfNodes(out SinglyLinkedList<T> firstList, out SinglyLinkedList<T> secondList)
        {
            SllNode<T> current = this.Head;
            SllNode<T> nextNode = null;
            firstList = new SinglyLinkedList<T>();
            secondList = new SinglyLinkedList<T>();

            while (current!=null)
            {
                nextNode = current.Next;
                firstList.PushToHead(current);
                current = nextNode;
                if(current!=null)
                {
                    nextNode = current.Next;
                    secondList.PushToHead(current);
                    current = nextNode;
                }
            }

            firstList.ReverseList();
            secondList.ReverseList();
        }

        public void DeleteAlternateNodes()
        {
            DeleteNodesAtDistance(2);
        }

        public void DeleteNodesAtDistance(int distance)
        {
            SllNode<T> current = Head;
            SllNode<T> prev = null;

            while (current!=null)
            {
                //Skip distance nodes
                for (int i = 1; i < distance; i++)
                {
                    prev = current;
                    current = current.Next;
                }

                if (current != null && prev != null)
                {
                    prev.Next = current.Next;
                    current = prev.Next;
                }
            }
        }

        public void DeleteAlternateNodesRecursive()
        {
            DeleteNodesAtDistanceRecursive(2);
        }

        public void DeleteNodesAtDistanceRecursive(int distance)
        {
            SllNode<T> current = Head;
            DeleteNodesAtDistanceRecursiveInternalUtil(current,distance);
        }

        private void DeleteNodesAtDistanceRecursiveInternalUtil(SllNode<T> currentHead, int distance)
        {
            if (currentHead == null)
                return;

            SllNode<T> prev = null;
            //Skip distance nodes
            for (int i = 1; i < distance; i++)
            {
                prev = currentHead;
                if (currentHead == null)
                    return;
                currentHead = currentHead.Next;
            }

            if (currentHead != null && prev != null)
            {
                prev.Next = currentHead.Next;
                currentHead = currentHead.Next;
            }
            DeleteNodesAtDistanceRecursiveInternalUtil(currentHead,distance);
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
        public SinglyLinkedList<T> SortedIntersectionRecursive(SinglyLinkedList<T> otherList)
        {
            SllNode<T> mergedListHead = SortedIntersectionRecursiveInternalUtil(this.Head,otherList.Head);
            return new SinglyLinkedList<T>(mergedListHead);
        }
        private SllNode<T> SortedIntersectionRecursiveInternalUtil(SllNode<T> thisHead, SllNode<T> otherHead)
        {
            if ((thisHead == null && otherHead != null) || (thisHead != null && otherHead == null))
                return null;

            SllNode<T> result = null;
            if(thisHead.Data.CompareTo(otherHead.Data) == 0)
            {
                result = new SllNode<T>(thisHead.Data);
                result.Next = SortedIntersectionRecursiveInternalUtil(thisHead.Next,otherHead.Next);
            }
            else if (thisHead.Data.CompareTo(otherHead.Data) < 0)
            {
                return SortedIntersectionRecursiveInternalUtil(thisHead.Next,otherHead);
            }
            else
            {
                return SortedIntersectionRecursiveInternalUtil(thisHead, otherHead.Next);
            }
            return result;
        }

        public SinglyLinkedList<T> SortedIntersectionIterative(SinglyLinkedList<T> otherList)
        {
            SllNode<T> thisCurrent = this.Head;
            SllNode<T> otherCurrent = otherList.Head;

            SllNode<T> result = null;
            SllNode<T> resultHead = null;

            while (thisCurrent != null && otherCurrent != null)
            {
                if(thisCurrent.Data.CompareTo(otherCurrent.Data) == 0)
                {
                    if(result==null)
                    {
                        resultHead = new SllNode<T>(thisCurrent.Data);
                        result = resultHead;
                    }
                    else
                    {
                        result.Next = new SllNode<T>(thisCurrent.Data);
                        result = result.Next;
                    }
                    thisCurrent = thisCurrent.Next;
                    otherCurrent = otherCurrent.Next;
                }
                else if(thisCurrent.Data.CompareTo(otherCurrent.Data) < 0)
                {
                    thisCurrent = thisCurrent.Next;
                }
                else
                {
                    otherCurrent = otherCurrent.Next;
                }
            }
            return new SinglyLinkedList<T>(resultHead);
        }

        public bool areIdenticalRecursive(SinglyLinkedList<T> otherList)
        {
            SllNode<T> currentOfThisList = this.Head;
            SllNode<T> currentOfOtherList = otherList.Head;
            return areIdenticalRecursive(currentOfThisList, currentOfOtherList);
        }

        public bool areIdenticalRecursive(SllNode<T> currentOfThisList, SllNode<T> currentOfOtherList)
        {
            if (currentOfThisList == null && currentOfOtherList == null)
                return true;
            if (currentOfThisList.Data.CompareTo(currentOfOtherList.Data) != 0)
                return false;
            return areIdenticalRecursive(currentOfThisList.Next, currentOfOtherList.Next);
        }

        public bool areIdentical(SinglyLinkedList<T> otherList)
        {
            SllNode<T> currentOfThisList = this.Head;
            SllNode<T> currentOfOtherList = otherList.Head;

            while(currentOfThisList!=null && currentOfOtherList!=null)
            {
                if (currentOfThisList.Data.CompareTo(currentOfOtherList.Data) != 0)
                    return false;
                currentOfThisList = currentOfThisList.Next;
                currentOfOtherList = currentOfOtherList.Next;
            }
            return (currentOfThisList == null && currentOfOtherList == null);
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

        public SllNode<T> DeleteHeadNode()
        {
            return DeleteNode(this.Head);
        }

        public SllNode<T> DeleteNode(SllNode<T> node)
        {
            if(this.Head==node)
            {
                SllNode<T> nextNode = this.Head.Next;
                this.Head.Next = null;
                this.Head = nextNode;
            }
            else
            {
                SllNode<T> current = this.Head;
                while (current.Next != node)
                {
                    current = current.Next;
                }
                current.Next = node.Next;
            }
            
            return node;
        }

        public void DeleteNodeTricky(SllNode<T> node)
        {
            if(node.Next!=null)
            {
                //Trick works only if its not last node
                SllNode<T> nextNode = node.Next;
                if (nextNode != null)
                {
                    node.Data = nextNode.Data;
                    node.Next = nextNode.Next;
                    nextNode.Next = null;//Garbage collector will delete it
                }
            }
            else if(node == this.Head)
            {
                this.Head = null;
            }
            else
            {
                SllNode<T> current = this.Head;
                while (current.Next != node)
                {
                    current = current.Next;
                }
                current.Next = node.Next; //always null
            }
            
        }

        public SllNode<T> GetMiddleNode()
        {
            SllNode<T> prevToMiddleNode = null;
            return this.GetMiddleNode(out prevToMiddleNode);
        }

        public SllNode<T> GetMiddleNode(out SllNode<T> prevToMiddleNode)
        {
            return GetMiddleNode(this.Head, out prevToMiddleNode);
        }

        private SllNode<T> GetMiddleNode(SllNode<T> startOfList,out SllNode<T> prevToMiddleNode)
        {
            SllNode<T> fastPointer = startOfList;
            SllNode<T> slowPointer = startOfList;
            prevToMiddleNode = null;

            while (fastPointer != null && fastPointer.Next != null && fastPointer.Next.Next != null)
            {
                fastPointer = fastPointer.Next.Next;
                prevToMiddleNode = slowPointer;
                slowPointer = slowPointer.Next;
            }

            return slowPointer;
        }

        public void ReverseListWithGroupSizeRecursive(int size)
        {
            this.Head = ReverseListWithGroupSizeRecursiveInternalUtil(this.Head,size);
        }
        private SllNode<T> ReverseListWithGroupSizeRecursiveInternalUtil(SllNode<T> currentHead, int size)
        {
            if (currentHead == null)
                return null;

            SllNode<T> current = currentHead, prev = null, next = null;
            SllNode<T> newHead = null;
            SllNode<T> passedHead = currentHead;

            for (int i = 0; current!=null && i < size; i++)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            newHead = prev;
            passedHead.Next = ReverseListWithGroupSizeRecursiveInternalUtil(current, size);
            return newHead;
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

        public void MergeSort()
        {
            this.Head = MergeSortInternalUtil(this.Head);
        }

        private SllNode<T> MergeSortInternalUtil(SllNode<T> currentHead)
        {
            //If no node or only one node then it is already sorted, no more recursion
            if (currentHead == null || currentHead.Next == null)
                return currentHead;

            SllNode<T> firstHalf = null;
            SllNode<T> secondHalf = null;

            SplitListIntoTwoHalf(currentHead, ref firstHalf, ref secondHalf);

            SllNode<T> firstHalfNewHead = MergeSortInternalUtil(firstHalf);
            SllNode<T> secondHalfNewHead = MergeSortInternalUtil(secondHalf);

            SllNode<T> newHead = MergeSortedHalfs(firstHalfNewHead, secondHalfNewHead);

            return newHead;
        }

        private void SplitListIntoTwoHalf(SllNode<T> currentHead, ref SllNode<T> firstHalf, ref SllNode<T> secondHalf)
        {
            SllNode<T> prevToMiddleNode = null;
            SllNode<T> middleNode = this.GetMiddleNode(currentHead,out prevToMiddleNode);

            prevToMiddleNode = middleNode;
            middleNode = middleNode.Next;

            prevToMiddleNode.Next = null;

            firstHalf = currentHead;
            secondHalf = middleNode;
        }

        private SllNode<T> MergeSortedHalfs(SllNode<T> firstHalf, SllNode<T> secondHalf)
        {
            if (firstHalf == null)
                return secondHalf;
            if (secondHalf == null)
                return firstHalf;

            SllNode<T> combinedList = null;

            if(firstHalf.Data.CompareTo(secondHalf.Data) <= 0)
            {
                combinedList = firstHalf;
                combinedList.Next = MergeSortedHalfs(firstHalf.Next, secondHalf);
            }
            else
            {
                combinedList = secondHalf;
                combinedList.Next = MergeSortedHalfs(firstHalf, secondHalf.Next);
            }
            return combinedList;
        }


        public void SortByDataMovement()
        {
            SllNode<T> outer = Head;
            
            while(outer!=null)
            {
                SllNode<T> inner = outer;
                while(inner!=null)
                {
                    if(outer.Data.CompareTo(inner.Data) > 0)
                    {
                        //We are swaping data itself and not nodes
                        SwapData(outer, inner);
                    }
                    inner = inner.Next;
                }
                outer = outer.Next;
            }
        }

        public void SortByNodeMovement()
        {
            SllNode<T> outer = Head;
            SllNode<T> prevToOuter = null;
            SllNode<T> prevToInner = null;


            while (outer != null)
            {
                SllNode<T> inner = outer;
                while (inner != null)
                {
                    if (outer.Data.CompareTo(inner.Data) > 0)
                    {
                        SwapNode(ref outer,ref  inner, prevToOuter, prevToInner);
                    }
                    prevToInner = inner;
                    inner = inner.Next;
                }
                prevToOuter = outer;
                outer = outer.Next;
            }
        }

        private void SwapNode(ref SllNode<T> node1, ref SllNode<T> node2, SllNode<T> prevToNode1, SllNode<T> prevToNode2)
        {
            SllNode<T> nextToNode1 = node1.Next;
            SllNode<T> nextToNode2 = node2.Next;

            //If node1 or node2 is head
            if (node1 == Head)
                Head = node2;
            else if (node2 == Head)
                Head = node1;

            //If node1 or node2 is null
            if(node1 == null && node2 == null)
            {
                return;
            }
            else if (node1 == null)
            {
                node1 = node2;
                node2 = null;
            }
            else if (node2 == null)
            {
                node2 = node1;
                node1 = null;
            }

            //adjecent
            if(node1.Next == node2)
            {
                if (prevToNode1 != null)
                    prevToNode1.Next = node2;
                node2.Next = node1;
                node1.Next = nextToNode2;
            }
            else if (node2.Next == node1)
            {
                if (prevToNode2 != null)
                    prevToNode2.Next = node1;
                node1.Next = node2;
                node2.Next = nextToNode1;
            }
            else
            {
                //Break node1 from its position and put it between prevToNode2 and nextToNode2, and vice versa
                if (prevToNode2 != null)
                    prevToNode2.Next = node1;
                node1.Next = nextToNode2;

                if (prevToNode1 != null)
                    prevToNode1.Next = node2;
                node2.Next = nextToNode1;
            }
           
            //Put reference back, so that outer loops can work
            SllNode<T> temp = node1;
            node1 = node2;
            node2 = temp;
        }

        private void SwapData(SllNode<T> outer, SllNode<T> inner)
        {
            T tempData = outer.Data;
            outer.Data = inner.Data;
            inner.Data = tempData;
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
