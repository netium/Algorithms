using System;
namespace Algorithms.Collections
{
    public class LinkedQueue<T>
    {
        private SingleLinkNode<T> head;
        private SingleLinkNode<T> tail;
        private int size = 0;

        public LinkedQueue()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public void Enqueue(T item)
        {
            var node = new SingleLinkNode<T>(item);
            if (tail == null)
            {
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                tail = tail.Next;
            }
            size++;
        }

        public T Dequeue()
        {
            if (head == null)
                throw new OverflowException();

            T item = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            size--;

            return item;
        }
    }
}
