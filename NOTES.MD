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