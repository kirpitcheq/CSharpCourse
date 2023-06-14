using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06_IEnumerable
{
    public class SinglyNode<T> : IEnumerator<T> 
    {
        SinglyNode<T> Next = null!;
        public T? Value { get; private set; } = default(T); // can be null! if Next and Value == null => SinglyNode is empty
        public SinglyNode(T value) {
            Value = value;
        }
        public override string ToString(){
            return Value.ToString();
        }
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
            if(head == null){
                head = this;
                return true;
            }
            head = head.Next;
            if(head == null) 
                return false;
            return true;
        }
        public void Reset() => throw new NotImplementedException();
        public void Dispose() => head = null!;
        //end IEnumerator implementation

        public SinglyNode<T> PushFront(T value) {
            SinglyNode<T> temp = new SinglyNode<T>(value){Next = this};
            return temp;
        }
        public SinglyNode<T> PushBack(T value){
            SinglyNode<T> temp = Next;
            if(temp == null){
                Next = new SinglyNode<T>(value);
                return Next;
            }
            while(temp?.Next != null) temp = temp.Next;
            temp.Next = new SinglyNode<T>(value);
            return temp.Next;
        }
        // public bool PopFront(){
        //     if(Value == null) return false;
        //     if(Next = null)
        //     return true;
        // }
    }


}