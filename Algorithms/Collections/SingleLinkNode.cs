using System;
namespace Algorithms.Collections
{
    class SingleLinkNode<T>
    {
        private T value;
        private SingleLinkNode<T> next;

        public SingleLinkNode()
        {
            value = default(T);
            next = null;
        }

        public SingleLinkNode(T value) 
        {
            this.value = value;
            next = null;
        }

        public SingleLinkNode(T value, SingleLinkNode<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public T Value 
        { 
            get { return value; }
            set { this.value = value; }
        }

        public SingleLinkNode<T> Next
        {
            get { return next; }
            set { this.next = value; }
        }
    }
}
