using System;
namespace Algorithms.Collections
{
    public class LinkedStack<T>
    {
        private SingleLinkNode<T> top;
        private int size;

        public LinkedStack()
        {
            top = null;
            size = 0;
        }

        public void Push(T item)
        {
            top = new SingleLinkNode<T>(item, top);
            size++;
        }

        public T Pop()
        {
            if (top == null)
                throw new OverflowException();

            var item = top.Value;
            top = top.Next;
            size--;

            return item;
        }

        public int Size {
            get { return size; }
        }
    }
}
