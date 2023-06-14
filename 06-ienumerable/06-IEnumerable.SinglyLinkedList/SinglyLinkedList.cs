using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace _06_IEnumerable
{
    public class SinglyLinkedList<T> : IEnumerable<T> 
    {
        SinglyNode<T>? first = null;
        SinglyNode<T>? last = null;
        IEnumerator IEnumerable.GetEnumerator() => first!;
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => first!;


        public void PushBack(T value){
            if(first == null){
                first = new SinglyNode<T>(value);
                last = first;
            }
            else{
                last = last.PushBack(value);
            }
        }
        public void PushFront(T value){
            if(first == null){
                first = new SinglyNode<T>(value);
            }
            else{
                first = first.PushFront(value);
            }
        }

    }
}

