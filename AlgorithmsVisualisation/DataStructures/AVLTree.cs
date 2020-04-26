using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class AVLTree<T> : ICollection<T> 
        where T : IComparable<T> 
    {
        public AVLTree()
        {
            root = null;
            Count = 0;
        }
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private Node root;

        #region NodeImplementation
        private class Node
        {
            public T Value { get; set; }
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int balance { get; set; }

            public Node(T value)
            {
                Parent = Left = Right = null;
                Value = value;
                balance = 0;
            }
            public Node(Node parent, T value)
            {
                Parent = parent;
                Left = Right = null;
                Value = value;
                balance = 0;
            }
            public bool HasChildren() => Right != null || Left != null;

        }
        #endregion
    }
}
