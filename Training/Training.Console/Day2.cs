using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Training
{
    public class Day2
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Seth";

        public List<string> WorkDays { get; set; }

        public List<int> WinningLottoNumbers { get; set; }

        // Default Constructor
        public Day2()
        {
            int[] intArray = new int[] { };
            string[] strArray = new string[3];

            strArray.Append("hello");

            int[] oddNumbers = new int[] { 1, 3, 5, 7, 9, 10, 11, 12 };

            oddNumbers = oddNumbers.Where(x => (x % 2) != 0).ToArray();

            var num = oddNumbers.FirstOrDefault(x => x > 0, 3);

            var lastItem = strArray.Last(s => s.Contains("hello"));

            Array.IndexOf(strArray, "hello");

            int[,,,] multiIntArray = new int[,,,] { { { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } } } };
            // LINQ
            // Language INtegrated Query

            // SELECT * FROM dbtable WHERE dbtable.Id > 15

            //for (int i = 0; i < oddNumbers.Length; i++)
            //{
            //    if ((oddNumbers[i] %2) == 0)
            //    {

            //    }
            //}
            if (WorkDays == null)
            {
                WorkDays = new List<string>();
            }
            WorkDays.AddRange(new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" });

            if (WinningLottoNumbers == null)
            {
                WinningLottoNumbers = new List<int>();
            }
            WinningLottoNumbers.Add(12);
            WinningLottoNumbers.Add(7);
            WinningLottoNumbers.Add(27);
            WinningLottoNumbers.Add(14);
        }

        // Overloaded Constructor
        public Day2(int id, string name) 
        {
            Id = id;
            Name = name;

            if (WorkDays == null)
            {
                WorkDays = new List<string>();
            }

            if (WinningLottoNumbers == null)
            {
                WinningLottoNumbers = new List<int>();
            }
            WorkDays.Add("Monday");
            WorkDays.Add("Tuesday");
            WinningLottoNumbers.Add(12);
            WinningLottoNumbers.Add(7);
            WinningLottoNumbers.Add(27);
            WinningLottoNumbers.Add(14);
            
            Log(WorkDays);
            Log(Id);
            Log(Name);
            Log(WinningLottoNumbers);
                
        }

        // Base Method
        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        // Overload to handle ints
        private void Log(int num)
        {
            //Console.WriteLine(num.ToString());
            var numString = num.ToString();
            Log(numString);
        }


        // Overload for lists of string
        private void Log(IEnumerable<string> list)
        {
            foreach(var item in list)
            {
                //Console.WriteLine(item.ToString());
                Log(item);
            }
        }

        // Overload for lists of int
        private void Log(IEnumerable<int> list)
        {
            foreach (var item in list)
            {
                //Console.WriteLine(item.ToString());
                Log(item.ToString());
            }
        }
    }

    // Inheritance example base class
    public class Dwelling 
    {
        public int Walls { get; set; }

        public bool Roof { get; set; } = false;

        public string Address { get; set; } = "123 Test Street";

        // Default Constructor
        public Dwelling()
        {
            Walls = 4;
        }

        // Overloaded Constructor
        public Dwelling(string address, int walls, bool roof = true)
        {
            Address = address;
            Walls = walls;
            Roof = roof;
        }

        // Base Virtual Method that allows overriding in child class
        // Virtual allows for the child class to override the method
        // Makes it possible to define a base level implementation of a method
        public virtual void GetAddress()
        {
            Console.WriteLine(Address);
        }
    }

    // Child class inheriting
    public class Townhouse : Dwelling
    {
        public string Name { get; set; }

        // More overloading the constructor
        // Call to base allows us to pass args to the parent (super) constructor
        public Townhouse(string name, int walls, string address) : base(address, walls)
        {
            Name = name;
        }

        public Townhouse(string name) : base()
        {
            Name = name;
        }

        // Overriding the base method
        // Override keyword is required
        // Can have the base method run by calling base.MethodName()
        public override void GetAddress()
        {
            base.GetAddress();
            Console.WriteLine($"Place Name: {Name}");
        }
    }

    // Inheritance using an Abstract class
    public abstract class Shape
    {
        // All shapes have a GetArea method
        // Each implementation will be different based on the shape
        public abstract int GetArea();
    }

    // Inherited the abstract base class
    public class Square : Shape
    {
        public int SideLength { get; set; }

        // Square's version of GetArea
        // Side x Side = Area of Square
        // If SquareSides was a method instead of a prop, we'd have to include ()
        // public override int GetArea() => SquareSides();
        public override int GetArea() => SquareSides;
        

        // Arrow notation for a read only property (only has a getter but no setter)
        // Could make this a method by adding parentheses
        //public int SquareSides() => SideLength * SideLength;
        public int SquareSides => SideLength * SideLength;

        public int SquareSides2
        {
            get
            {
                return SideLength * SideLength;
            }
        }

        //public override int GetArea()
        //{
        //    return SideLength * SideLength;
        //}

        // Square = All sides are equal
        // To create we'd ask that only one side be defined
        public Square(int side)
        {
            SideLength = side;
        }
    }

    // Circle inheriting the abtract base class
    public class Circle : Shape
    {
        public double Radius { get; set; }

        // Cant change the return type
        public override int GetArea()
        {
            // We have to round the double to the nearest int value before casting
            return (int)Math.Round(Math.PI * (Radius * Radius));
        }

        public Circle(double rad)
        {
            Radius = rad;
        }
    }

    public class LoopExample
    {
        public int[] OddNumbers = new int[] { 1, 3, 5, 7, 9, 10, 11, 12, 42 };

        public void WhileLoops()
        {

            int[] oddNumbers = new int[] { 1, 3, 5, 7, 9, 10, 11, 12 };


            for (int i = 0; i < oddNumbers.Length; i++)
            {
                while (i <= 5)
                {
                    Console.WriteLine("Still Running");
                    i++;
                }
            }
            
        }

        public void ForLoops()
        {
            //int i;
            

            for (int i = 0; i < OddNumbers.Length; i++)
            {
                Console.WriteLine($"{OddNumbers[i]}");
            }
        }

        public void ForEachLoops()
        {
            foreach (var item in OddNumbers)
            {
                Console.WriteLine(item);
                if (item == 42)
                {
                    throw new DidNotComputeException("This value did not compute");
                }
            }
        }

        public void DoWhileLoops()
        {
            var i = 0;
            do
            {
                Console.WriteLine(string.Format("Still Running - {0}", i));
                Console.WriteLine($"Still Running - {i} ");
                //i = i + 1;
                i++;
            } while (i <= 10);
        }

        public void IfStatements(int onOrOff)
        {
            if (onOrOff == 1)
            {
                // Turn on some configuration setting
            }
            else if(onOrOff == 0)
            {
                // Maybe throw an error, nah just turn it off
            }
            else
            {
                // Turn off some config setting
            }
        }

        public string SwitchStatements(int logLevel)
        {
            // This is a switch expression
            // Basically short hand for the full switch statement
            //string logLevelOutput = logLevel switch
            //{
            //    0 => "Info",
            //    1 => "Warning",
            //    2 => "Error",
            //    3 => "Trace",
            //    4 => "Debug",
                    // Default Case uses _
            //    _ => "Info",
            //};

            string logLevelOutput = "";
            switch (logLevel)
            {
                case 0:
                    logLevelOutput = "Info";
                    break;

                case 1:
                    logLevelOutput = "Warning";
                    break;


                case 2:
                    logLevelOutput = "Error";
                    break;

                case 3:
                    logLevelOutput = "Trace";
                    break;

                case 4:
                    logLevelOutput = "Debug";
                    break;

                default:
                    logLevelOutput = "Info";
                    break;
            }

            return logLevelOutput;

        }
    }

    public class TryCatchFinallyExample
    {
        public int TestValue { get; set; }


        public TryCatchFinallyExample(string testval)
        {
            try
            {
                if (testval.Equals("Seth")) 
                {
                    Console.WriteLine("Some text");
                    throw new DidNotComputeException("This didn't work", new DidNotComputeANumberException());
                }

            }
            // Exceptions don't have to be caught
            // Multiple catch statements go from most specific to least specific
            // with the errors they catch
            catch(ArgumentNullException argex)
            {
                Console.WriteLine(argex.Message);
            }
            catch (DidNotComputeException argex)
            {
                Console.WriteLine(argex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            // Finally runs after everything else has finished
            // Won't run if we didn't catch an exception that crashed the application
            // Best used for closing db connections or stopping long running services
            // Used by an application
            finally
            {
                Console.WriteLine("Happens after everything");
            }
        }

    }

    // To Answer the Question Why does my custom exception need to be serialized,
    // Here's a good StackOverflow answer for you...
    // Because your exceptions may need to be marshalled
    // between different AppDomains and if they aren't
    // (properly) serializable you will lose precious debugging information.
    // Unlike other classes, you won't have control over
    // whether your exception will be marshalled -- it will.
    // When I mean "you won't have control" I mean that classes
    // you create generally have a finite space of existence
    // and the existence is well known. If it's a return value
    // and someone tries to call it in a different AppDomain
    // (or on a different machine) they will get a fault and
    // can just say "Don't use it that way."
    // The caller knows they have to convert it into a type that
    // can be serialized (by wrapping the method call). However
    // since exceptions are bubbled up to the very top if not caught
    // they can transcend AppDomain boundaries you didn't even know you had.
    // Your custom application exception 20 levels deep in a different AppDomain
    // might be the exception reported at Main() and nothing along the way
    // is going to convert it into a serializable exception for you.
    // Your exceptions may be passed across Web Services as well,
    // in this case the exception needs to be serializable/deserializable
    // so it can be turned into XML and transmitted by the Web Service

    [Serializable]
    public class DidNotComputeException : Exception
    {
        public DidNotComputeException() : base() { }

        
        public DidNotComputeException(string message) : base(message) { }

        // Pass along inner exceptions to the base class
        public DidNotComputeException(string message, Exception inner) : base(message, inner) { }

        // For serialization to remote systems
        // Without this constructor, deserialization will fail
        protected DidNotComputeException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }

    // More specific error to talk about the errro bubbling up
    // And how a less specific catch exception would catch this more specific exception
    public class DidNotComputeANumberException : DidNotComputeException
    {
        public DidNotComputeANumberException() : base()
        {

        }

    }

    // Nested types example
    // Anything outside this OutsideClass (e.g. Day2, Dwelling, DidNotComputeException)
    // Cannot access InnerClass unless it wa public
    // Methods and props in OutsideClass can interact with an instance of the InnerClass
    // But obviously can't touch any private methods inside InnerClass
    public class OutsideClass
    {
        public int Id { get; set; }
        private string _name;

        public OutsideClass()
        {
            _name = "Container";
        }

        // InnerClass CAN access its container
        // To do this, it has to have a field or property that will hold
        // a reference to the container class and the container has to be
        // passed as an argument to the constructor of the nested class
        //
        // From MS Docs https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/nested-types
        // A nested type has access to all of the members that are accessible
        // to its containing type. It can access private and protected members
        // of the containing type, including any inherited protected members.
        // If we made this InnerClass public, we would instantiate it like this:
        // OutsideClass.InnerClass innerClass = new OutsideClass.InnerClass();
        private class InnerClass 
        {
            // Field that holds the reference
            // Could be a property
            // public OutsideClass Parent { get; set; }
            private OutsideClass _parent;

            // Default Constructor
            public InnerClass()
            {
                _parent = new OutsideClass();
            }

            // Constructor that takes the container instance and assigns it
            // to the instance variable
            public InnerClass(OutsideClass parent)
            {
                this._parent = parent;
                // Once the class has access to the container
                // It can run methods from its parent class
                _parent.Run();
                
            }
            
        }

        // Do not do this
        // It would basically create an infinite loop of 
        // New class instances because of passing in the
        // Container reference
        public void Run()
        {
            var iClass = new InnerClass(this);
        }
    }
}
