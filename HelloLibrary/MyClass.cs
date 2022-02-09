namespace HelloLibrary;

public class MyClass
{
    public static void DoSomethingWithAList()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        Console.WriteLine ("Average of my list: " + list.Average());
    }
}
