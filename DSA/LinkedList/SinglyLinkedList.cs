﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SinglyLinkedList<T>
    {
        SllNode<T> head; //the head of singly linked list

        public void PushToHead(T data)
        {
            //Allocate new node
            SllNode<T> newNode = new SllNode<T>(data);

            //Append whole list behind new node
            newNode.Next = head;

            //Make new node as head of the list
            head = newNode;
        }

        public SllNode<T> GetNthNodeFromEnd(int index)
        {
            SllNode<T> currentAhead = head;
            SllNode<T> currentBehind = head;

            //Skip index nodes from beginning
            for (int i = 0; i < index; i++)
            {
                currentAhead = currentAhead.Next;
            }

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
            SllNode<T> current = head;
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

        public void Print()
        {
            SllNode<T> current = head;
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