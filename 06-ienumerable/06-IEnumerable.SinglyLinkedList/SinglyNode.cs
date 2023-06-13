using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_IEnumerable
{
    public class SinglyNode<T> : IEnumerator<T> where T : class
    {
        SinglyNode<T> Next = null!;
        private T? Value; // can be null! if Next and Value == null => SinglyNode is empty
        
        //IEnumerator inmplementation
        
        object System.Collections.IEnumerator.Current{
            get{
                if(head == null) return (object)Value;
                return (object)head.Value;
            } 
        }
        T IEnumerator<T>.Current{
            get{
                if(head == null) return Value;
                return head.Value;
            } 
        }
        SinglyNode<T> head = null!;
        public bool MoveNext() {
            if(Next == null) return false;
            head = Next;
            return true;
        }
        public void Reset() => throw new NotImplementedException();
        public void Dispose() => throw new NotImplementedException();
        //end IEnumerator implementation

        public void PushFront(T value) {
            SinglyNode<T> temp = new SinglyNode<T>{Value = value, Next = this};
        }
        public void PushBack(T value){
            SinglyNode<T> temp = Next;
            while(temp.Next != null) temp = temp.Next;
            temp.Next = new SinglyNode<T> { Value = value };
        }
        // public bool PopFront(){
        //     if(Value == null) return false;
        //     return true;
        // }
    }


}