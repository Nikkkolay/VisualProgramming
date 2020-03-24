using System;

namespace Lab4
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T t)
        {
            Data = t;
        }

        public Node()
        {
        }
    }
}