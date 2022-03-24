int[,,] mas = { 
{ { 1, 2 },{ 3, 4 } },
{ { 4, 5 }, { 6, 7 } },
{ { 7, 8 }, { 9, 10 } },
{ { 10, 11 }, { 12, 13 } }
};

int rank = mas.Rank;

printMatrix();
// #1
void printMatrix()  // не осилил, много измерений, но интересно :D
{
    string result = String.Empty;

    for (int i = 0; i < rank; i++)
    {   // первое измерение
        int upperBound = mas.GetUpperBound(i);
    }

}

// #2
class MyString
{
    public string Value { get; set; } = String.Empty;

    public MyString(string value)
    {
        Value = value; 
    }

    public MyString(string value1, string value2)
    {
        Value = value1 + value2;
    }

    public string reverse(string value)
    {
        char[] charArray = value.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

// #3
static class Extensions
{
    public static string getSomeData(this DateTime date)
    {
        var day = date.Day;
        var month = date.Month;
        var year = date.Year + 5501;

        return $"День {day} месяца {month} года {year} от сотворения мира";
    }
}

// #4 
class MyStack
{
    int[] Stack;

    public MyStack(int length)
    {
        Stack = new int[length];
    }

    public int pop()
    {
        var newLength = Stack.Length - 1;
        var temp = Stack;
        Array.Resize(ref temp, newLength);
        Stack = temp;
        return Stack[newLength - 1];
    }

    public void push(int value)
    {
        var newLength = Stack.Length + 1;
        Array.Resize(ref Stack, newLength);
        Stack[newLength - 1] = value;
    }
}

// #5

class Child : Person
{
    Person parent;
    public Child(string name, int age, Person parent) : base(name, age)
    {
        this.parent = parent;
    }

    public override void getInfo()
    {
        Console.WriteLine("name: {0}, age: {0}, parent name: {0}", name, age, parent.name);
    }
}

class Employee : Person
{
    string occupation;
    public Employee(string name, int age, string occupation) : base(name, age)
    {
        this.occupation = occupation;
    }

    public override void getInfo()
    {
        Console.WriteLine("name: {0}, age: {0}, occupation: {0}", name, age, occupation);
    }
}
class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public virtual void getInfo()
    {
        Console.WriteLine("name: {0}, age: {0}", name, age);
    }
}

// #6
//Используя обобщения разработайте интерфейс для сохрания/чтения объекта
//произвольного типа в/из источник данных. Разработайте несколько классов
//реализующих интерфейс разработанный ранее. В качестве источника данных
//используйе коллекции.

class PersonSource : IReadWrite<Person>
{
    List<Person> Source;

    public void addSource(List<Person> collection)
    {
        Source = collection;
    }
    public void readFromSource()
    {
        foreach (var item in Source)
        {
            Console.WriteLine("name: {0}, age: {1}", item.name, item.age);
        }
    }

    public void saveToSource(Person item)
    {
        Source.Add(item);
    }
}

class StringSource : IReadWrite<string>
{
    List<string> Source { get; set; }

    public void addSource(List<string> collection)
    {
        Source = collection;
    }

    public void readFromSource()
    {
        foreach (var item in Source)
        {
            Console.WriteLine(item);
        }
    }

    public void saveToSource(string item)
    {
        Source.Add(item);
    }
}
interface IReadWrite<T>
{
    public void addSource(List<T> collection);
    public void saveToSource(T item);
    public void readFromSource();
}