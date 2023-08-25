using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.Struct
{
    public class LinkedList<T>
    {
        private int count;
        public Node<T> Head { get; private set; }
        public Node<T> Last { get; private set; }

        public LinkedList()
        {
            count = 0;
            Head = null;
            Last = null;
        }
        public int Lenght() => count;
        
        /// <summary>
        /// Add Node To List
        /// </summary>        
        /// <returns>void</returns>
        public void Add(T value)
        {            
            var Node = new Node<T>(value, count);

            if (Head == null && Last == null)
            {
                Head = Node;
                Last = Node;
                Node.prev = Node;
                Node.next = Node;
            }
            else
            if (Head.Id == Last.Id)
            {
                Head.next = Node;
                Head.prev = Node;
                Last = Node;
                Node.prev = Head;
                Node.next = Head;
            }
            else
            {
                Node.next = Head;
                Node.prev = this[count - 1];
                this[count - 1].next = Node;
                Head.prev = Node;
            }
            count++;
        }

        
        public Node<T> this[int index]
        {
            get 
            {
                if (index <= count && index >= 0)
                {
                    return GetNode(Head);
                }
                else
                    return null;

                Node<T> GetNode(Node<T> obj)
                {
                    if (obj.Id == index)
                        return obj;
                    else
                    {
                      var obj1 = GetNode(obj.next);
                        return obj1;
                    }

                    
                }
            }
        }

        public void MoveLeft()
        {
            MoveIndex(-1);
        }        

        public void MoveRight()
        {
            MoveIndex(1);
        }

        private void MoveIndex(int value)
        {
            RecursionMove(Head, count);

            void RecursionMove(Node<T> obj, int Lenght)
            {
                UnityEngine.Debug.Log(Lenght);
                if (Lenght == 0)
                    return;

                int NewIndex = (value + obj.Id);

                if (NewIndex >= 0 && NewIndex != count)
                    obj.Id = NewIndex;

                if (NewIndex == count)
                    obj.Id = 0;

                if (NewIndex < 0)
                    obj.Id = count - 1;

                RecursionMove(obj.next, Lenght - 1);
            }
        }



        public class Node<K>
        {
            public int Id;
            public Node<K> next;
            public Node<K> prev;
            public K value { get; private set; }

            public Node(K value, int id)
            {
                Id = id;
                this.value = value;
                next = null;
                prev = null;
            }
        }
    }

    
}
