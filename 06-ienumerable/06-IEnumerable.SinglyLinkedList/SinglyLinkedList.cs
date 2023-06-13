using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_IEnumerable
{
    public class SinglyLinkedList<T> : IEnumerable<T> where T : class
    {
        SinglyNode<T>? first = new SinglyNode<T>();
        SinglyNode<T>? last = new SinglyNode<T>();
        IEnumerator IEnumerable.GetEnumerator() => first!;
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => first!;
    }
}

