using _06_IEnumerable;
// See https://aka.ms/new-console-template for more information

SinglyLinkedList<int> sll = new SinglyLinkedList<int>();
sll.PushBack(1);
sll.PushBack(3);
sll.PushBack(5);
foreach(var i in sll){
    Console.WriteLine(i.ToString());
}
