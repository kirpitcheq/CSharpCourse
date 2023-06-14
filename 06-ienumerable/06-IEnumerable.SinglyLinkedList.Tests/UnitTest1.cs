namespace _06_IEnumerable.SinglyLinkedList.Tests;

using _06_IEnumerable;
public class UnitTest1
{
    [Fact]
    public void TestEnumerator()
    {
        SinglyLinkedList<int> sllint = new();
        sllint.PushBack(1);        
        sllint.PushBack(2);        
        int i = 0;
        foreach(var node in sllint){
            Console.WriteLine(node.ToString());
            i++;
            if(i>3) break;
        }
        Assert.True(i==2);
    }
}