# Notes / links

* Course description
https://informator.se/utbildning/c-avancerad/

* C# versions and feautures
https://dotnetcrunch.in/csharp-version-history-features/


## .NET history

CLR - Common Language Runtime motsvarar JVM i java, tolkar IL i runtime
.NET Framework = CLR + Class Library + Compilator
.NET Framework -> Windows only, 4.7.2
.NET Core -> cross platform linux, mac, windows, 
.NET 5 => .NET Core + .NET Framework

.NET Standard - class libraries portable across platforms
https://docs.microsoft.com/en-us/dotnet/standard/net-standard

1.1, 1.2, 1.4, 2.0, 2.1

C#  -> compile -> MSIL (Intermediate Language) -> execute on CLR
Java-> compile -> Byte code -> execute JVM

JIT - Just In Time compilation => CLR


# method references
Javascript anonyma funktioners

const square = function(a) {return a * a;};

function apply(f, a)
{
    return f(a)
}

callbacks i java använder interface

button.addEventListener(new ActionListener(){
    public void actionPerformed(){
        //todo: implement
    }
});

class MyActionListener implements ActionListener{ ... }

button.addEventListener(new MyActionListener())

delegate defined: A delegate is a named type definition for a method signature.

Generic delegates
Action -> void, no return
  Action, Action<T>,Action<T1,T2>
Func -> returns something
Func<R>, Func<T,R>, Func<T1,T2,R>




## Anonymous classes

var names = await ctx.Customers.Select(c => new {c.Id, c.Name}).ToListAsync();

class IdAndName {Name, Id}


 ## Extension methods
 Extend a class without touching it or subclassing
 Extend = add methods, add properties
 extension methods can access public members (or internal)
 defined as static methods on a static class

 ## Design patterns
 Patterns where objects colloborate to achieve some goal
 Gang of Four Gamma et al
 Christopher Alexander - arkitekt

 https://github.com/codebleeder/HeadfirstDesignPattern
 
 Patterns of enterpris application architecture
 https://www.martinfowler.com/eaaCatalog/

 https://www.amazon.com/Working-Effectively-Legacy-Michael-Feathers/dp/0131177052

Categories of patterns: (not a complete list!)
 * Creational
   - Singleton
   - Factory Method
   - Abstract factory
   - Prototype - Clone()
   - Builder 
  * Structural
   - Composite 
 * Behavioral
   - Proxy
   - Facade
   - Adapter
   - Decorator
   - Strategy


##   SOLID - Martin Fowler
   Single responsibility - single reason to change - Cohesion
      Bounded Context (DDD)
      Lines of code per method (7 rader), Cyclomatic complexity
      number of methods/members (2-3 dependencies) (7)
      antal argument per metod (2-3)
   Open/closed principle modification vs extension
   Liskov substituion principle
   Interface segregation (2-3 members)
   Dependency Inversion Principle (DIP)

   Coupling / Cohesion

   OrderManager(ILog logger, IInventoryManager)

   im.AdjustLevel(productId, quantity);

   OrderManager

     event Action<Order> OrderPlaced = delegate{};

     void PlaceOrder()
        OrderPlaced.Invoke(this)

    DI wiring

    string CalculateChecksum(Widget w)
    {
        widget.getCeck
        //todo: push ToBytes into Widget
        var bytes = ToBytes(w);
        _checksumCalculation.Calculate(w.ToBytes())
    }

    private string Md5(Widget)

    Calculator(IChecksumCalculation csc)

    IChecksumStrategy

    Md5Calculation : BaseCalculation
    Sha1Calculation

### Decorator example
Proxy but with contraint on composing chain by passing base type to constructor
    abstract Stream
    MemoryStream
    NetworkStream
    FileStream

    BufferedStream
    ZipCompressionStream
    ArcCompressionStream
    SymmetricEncryptionStream
    AsymmetricEncryptionStream 

    client - stream.Write(data)

    //compose decorator chains using constructors
    
    GetStream() {
        var s = new FileStream(fileName);
        if (useEncryption) s = new SymmetricEncryptionStream(s);
        if (useCompression) s = new ZipCompressionStream(s);
        if (useDoubleCompression) s = new ArcCompressionStream(s);
    }

### Abstract factory
    
    //ADO.NET System.Data
    //IDbDataReader, IDbConnection, IDbCommand

    //System.Data.SqlClient
    //System.Data.MySql

    //var connection = ...
    ///    IDbCommand command = connection.CreateCommand();
    ///    

    //class MyDatabaseProvider : IDbProvider
    //{
    //    public IDbCommand CreateCommand { }
    //    public IDbConnection CreateConnection() { }
    //}

## Reflection

Code can examine itself, read it's own metadata
Metadata included in assembly, as opposed to C or C++
 - Names of types, name and type of members, method signatures, attributes
Assembly - output of compiler, IL - intermediate language

Reflector tool
ILDASM - Intermediate Language disassembler ships with .NET
dotPeek from Jetbrains
Object Browser window in VS2019

Types for reflection:

System.Assembly - static factory methods
instance methods: GetTypes(), GetClasses(), GetInterfaces()


Type class: typeof(T), Type.From(string name), Object.GetType()
instance methods: GetMembers(), GetMethods(), GetProperties(), GetConstructors()

MethodInfo class describes a method arguments and types, return type, static/modifiers


Shape s = new Circle();
var type = s.GetType();
Assert.IsTrue(type == typeof(Circle));

type.IsInterface, IsAbstract, IsPublic

Above is examples of reading, we can also execute code using reflection!

MethodInfo.Invoke() (static methods, instance methods, property getters and setters)
Constructor.Invoke()

Reflection can access private fields and methods!

Attributes - defining: Inherit System.Attribute, Attribute suffix is optional

[]
class TestMethodAttribute : System.Attribute

@Component
class MyTestClass {
    [TestMethod]
    public void MyMethod([FromBody][Required] int number)
}

Built in useful attributes
[CallerMemberName]
[Obsolete]
[Serializable]

Log : ILog
{
    public void Write(string message, [CallerMemberName] string caller = null)
}

Inside Widget.DoStuff()
  _log.Write("hello world");


###  Threads

```csharp
Thread t = new Thread(ThreadDelegate);
Thread.Sleep(0);
t.Start(); 

t.Join(); //block until t completes
```
Data synchronization. Immutable,
thread safe collections ConcurrentDictionary, ConcurrentQueue

Actor model -> Akka.Net, Proto.Actor Erlang
Actor model handles synchronization by not sharing data, only
passes immutable messages.

First rule of distributed programming -> "Don't"
First rule of multithreading, also "Don't"

### Tasks vs Threads...
Threads are heavy weight and managed by the OS / runtime.
cCeating, destroying, switching threads is expensive.
Tasks are lightweight, there can be millions.

Java: ExecutorFramework.submit(Task)

```csharp
Task<List<Quote>> t = Task.Start(() => worker.GetQuotes())

Task t1 = Task.Delay(ts);
//avoid the following, use async / await instead
t.IsCompleted
t.Result //blocking call, will wait for result, can cause deadlocks
t.ContinueWith(t => {...} )
```

### await / async
```csharp
private async Task<List<Quote>> GetQuotes(string ticker)
{
   var quotes = await dbContext.Quotes.Where(q => q.Ticker == ticker).ToListAsync();
   //do something with quotes
   return quotes;
}
```
async keyword makes compiler rewrite method as a state machine
A thread visits the state machine when there is work to do.

* Don't use async keyword unless there is at least one await
* don't use async/await if there is a single await as the last statement, instead just return the task!

* A lambda can me marked async to allow awaiting within.

* A void method can be marked async, but if it crashes the exception will be lost. Common practice in event handlers, such as Button.Click

## Events

use event keyword to define events.
event <delegateType> <eventName>
```csharp
event Action<OrderPlaced> OrderPlaced;

//fire event

OrderPlaced.Invoke(new OrderPlaced(order));

//subscribe
var orderManager = new OrderManager();
orderManager.OrderPlaced += (orderPlaced) => {
    //handle event here
}

//or reference a method
orderManager.OrderPlaced += HandleOrderPlaced;

void HandleOrderPlaced(OrderPlaced orderPlaced) {...}
```

### Even less coupling
Above, the subscriber needs a reference to the publisher and thus has a dependency.
With the mediator pattern, consumers and producers only depend on the event types themselves and the mediator.

### Mediator using dotnet style events
In this example the events are domain specific and predefined. Sometimes this is a good thing.

```csharp
static class Events
{
    public static event Action<OrderPlaced> OrderPlaced;
    //todo: other events

    static internal FireOrderPlaced(OrderPlaced orderPlaced)
    {
        OrderPlaced.Invoke(orderPlaced);
    }
}
```

### Mediator take 2, pub/sub
See MessageBus.cs in ClassLibary1


### Advanced LINQ
LINQ was introduced with .NET 3.5 together with var, anonymous 
classes, extension methods, and more, all supporting the LINQ features.

LINQ to objects is implemented as extension methods to IEnumerable and operate on framework collections or anything that implements IEnumerable.

EF LINQ operators are implemented on DbSet, translates operator chain to SQL and maps back to entities.

Linq2Sql - first ORM, before EF DbContext -> DbSet<T>

See IQueryable and AsQueryable(), convert any IEnumerable

deferred execution -> terminal operators trigger execution

Sources: collection class, IEnumerable, EF DbSet<T>
Intermediate operators: Select, Where, GroupBy, Join, etc
Terminal operators: ToList, First, Single, SingleOrDefault, FirstOrDefault, Max, Min, Sum, Average, ToDictionary(), 

How does EF translate this:

```csharp
   ctx.Customers.Where(c => c.Name == "Robert")
      .Select(c => c.Id).ToList();
```
into this?

```sql
SELECT Id FROM Customers WHERE Name = "Robert"
```
Answer: Linq operators take Expression<Func<T,..>> and analyze the expression tree, see MyExtensions.MyWhere

101 Linq Samples
https://linqsamples.com/linq-to-objects/restriction/Where-numbers-lambda
