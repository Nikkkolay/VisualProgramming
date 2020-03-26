using System;

namespace Lab4
{
    public class GenericsDescSortedList<T> where T : IComparable<T>
    {
        public int Count { get; private set; }

        private Node<T> _firstNode;
        private Node<T> _lastNode;

        public T this[int index] => Get(index);

        public void Add(T data)
        {
            var newNode = new Node<T>(data)
            {
                Next = null,
                Previous = null
            };

            if (_firstNode == null)
            {
                _firstNode = newNode;
                _lastNode = newNode;

                Count = 1;

                return;
            }

            var node = _firstNode;
            //node.Data >= data
            for (; node.Data.CompareTo(data) >= 0 && node != _lastNode; node = node.Next) ;
            if(node.Data.CompareTo(data) >= 0)//node.Data >= data
            {
                var tempNode = node.Next;
                node.Next = newNode;
                newNode.Previous = node;
                newNode.Next = tempNode;

                if(newNode.Next != null)
                {
                    newNode.Next.Previous = newNode;
                }

                if(_lastNode == node)
                {
                    _lastNode = newNode;
                }
            }
            else//node.Data < data
            {
                var tempNode = node.Previous;
                node.Previous = newNode;
                newNode.Next = node;
                newNode.Previous = tempNode;

                if(newNode.Previous != null)
                {
                    newNode.Previous.Next = newNode;
                }

                if (_firstNode == node)
                {
                    _firstNode = newNode;
                }
            }

            Count++;
        }

        public T Get(int index)
        {
            Node<T> node = null;

            if (index <= Count / 2)
            {
                node = _firstNode;

                for (var i = 0; i < index; i++)
                {
                    node = node.Next;
                }
            }
            else
            {
                node = _lastNode;

                for (var i = 0; i < Count - 1 - index; i++)
                {
                    node = node.Previous;
                }
            }

            return node.Data;
        }

        public T Max() => _firstNode.Data;
        public T Min() => _lastNode.Data;
    }
}