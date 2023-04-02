Car car = new();
car.Speed = 100;
car.Move();
(car as IMovable).Stop();
((IMovable)car).Stop();

IMovable movable = new Car();
movable.Speed = 100;
movable.Move();
movable.Stop();

IMovable[] movables = new IMovable[] 
{ 
    new Car(),
    new Person()
};

foreach(var item in movables)
    item.Move();


ClassAB obj = new ClassAB();
obj.PrintA();
obj.PrintB();
obj.Print();

IA objA = new ClassAB();
objA.PrintA();
//objA.PrintB();
objA.Print();

IB objB = new ClassAB();
//objB.PrintA();
objB.PrintB();
objB.Print();



interface IMovable
{
    const int Count = 100;
    static int MaxSpeed;

    int Speed { set; get; }
    void Move();

    void Stop()
    {
        Console.WriteLine("Stop");
    }

    event Action<string> SpeedEvent;
}

class Car : IMovable
{
    public string Brand { set; get; }
    public int Speed { get; set; }

    public event Action<string> SpeedEvent;

    public void Move()
    {
        Console.WriteLine("Move Car!");
        SpeedEvent?.Invoke("Move Car!");
    }
}

class Person : IMovable
{
    public string Name { set; get; }
    public int Speed { get; set; }

    public event Action<string> SpeedEvent;

    public void Move()
    {
        Console.WriteLine("Move Person!");
    }

    void IMovable.Move()
    {
        Console.WriteLine("Move IMovable Person!");
    }
}

interface IA
{
    void PrintA();
    void Print();
}

interface IB
{
    void PrintB();
    void Print();
}

class ClassAB : IA, IB
{
    public void Print()
    {
        Console.WriteLine("Q");
    }
    void IB.Print()
    {
        Console.WriteLine("QB");
    }

    void IA.Print()
    {
        Console.WriteLine("QA");
    }

    public void PrintA()
    {
        Console.WriteLine("A");
    }

    public void PrintB()
    {
        Console.WriteLine("B");
    }
}