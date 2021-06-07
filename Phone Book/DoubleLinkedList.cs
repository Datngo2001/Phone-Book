using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book
{
    public class DoubleNode
    {
        public object Value { get; set; }
        public DoubleNode Next  { get; set; }
        public DoubleNode Prev { get; set; }
    }
    public class DoubleLinkedList
    {
        public int size { get; set; }
        public DoubleNode head { get; set; }
        public DoubleNode tail { get; set; }

        DoubleNode CreateDoublyLL(int nodeValue)
        {
            head = new DoubleNode();
            DoubleNode node = new DoubleNode();
            node.Value = nodeValue;
            node.Next = null;
            node.Prev = null;
            head = node;
            tail = node;
            size = 1;
            return head;
        }
        public void InsertInDoublyLL(int nodeValue, int location)
        {

            //create blank node   
            var node = new DoubleNode();
            node.Value = nodeValue;
            if (head == null)
            {
                Console.WriteLine("LinkedList doesnot exists");
                return;
            }
            else if (location == 0)
            {

                node.Next = head;
                node.Prev = null;
                head.Prev = node;
                head = node;

            }
            else if (location >= size)
            { // last position  

                node.Next = null;
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            else
            {
                DoubleNode tempNode = head;
                int index = 0;
                while (index < location - 1)
                {
                    tempNode = tempNode.Next;
                    index++;
                }//end of while loop  
                node.Next = tempNode.Next;
                node.Prev = tempNode;
                tempNode.Next = node;
                node.Next.Prev = node;
            }
            size++;
        }
        public void TraverseDDL()
        {
            if (head == null)
            {
                Console.WriteLine("LinkedList does not exists");
                return;
            }
            else
            {
                DoubleNode tempNode = head;
                for (int i = 0; i < size; i++)
                {
                    Console.Write(tempNode.Value);
                    Console.Write("-->");
                    tempNode = tempNode.Next;
                }
            }
            Console.WriteLine("\n");
        }
        public void ReverseTraverseDDL()
        {
            if (head == null)
            {
                Console.WriteLine("Linked list doesnot exists");
                return;
            }
            else
            {
                DoubleNode tempNode = tail;
                for (int i = 0; i < size; i++)
                {
                    Console.Write(tempNode.Value);
                    Console.Write("<---");
                    tempNode = tempNode.Prev;
                }

            }
            Console.WriteLine("\n");
        }
        public bool SearchNodeInDDL(object nodeValue)
        {
            if (head == null)
            {
                Console.WriteLine("LinkedList does not exists");
                return false;
            }
            else
            {
                DoubleNode tempNode = head;
                for (int i = 0; i < size; i++)
                {
                    if (tempNode.Value == nodeValue)
                    {
                        Console.WriteLine("node  exists in the Linked list:" + nodeValue);
                        return true;
                    }
                    tempNode = tempNode.Next;
                }
                return false;
            }
        }
        // Deletes a node having a given value  
        public void deletionOfNode(int location)
        {
            if (head == null)
            {
                Console.WriteLine("The linked list does not exist!!");// Linked List does not exists  
                return;
            }
            else if (location == 0)
            { // we want to delete first element  
                if (size == 1)
                { // if this is the only node in this list  
                    head = tail = null;
                    size = size - 1;
                    return;
                }
                else
                {
                    head = head.Next;
                    head.Prev = null;
                    size = size - 1;
                }
            }
            else if (location >= size)
            { // If location is not in range or equal, then delete last node  
                DoubleNode tempNode = tail.Prev; // temp node points to 2nd last node  
                if (tempNode == head)
                { // if this is the only element in the list  
                    tail = head = null;
                    size = size - 1;
                    return;
                }
                tempNode.Next = null;
                tail = tempNode;
                size = size - 1;
            }
            else
            { // if any inside node is to be deleted  
                DoubleNode tempNode = head;
                for (int i = 0; i < location - 1; i++)
                {
                    tempNode = tempNode.Next; // we need to traverse till we find the location  
                }
                tempNode.Next = tempNode.Next.Next; // delete the required node  
                tempNode.Next.Prev = tempNode;
                size = size - 1;
            } // end of else  

        }// end of method  
    }
}
