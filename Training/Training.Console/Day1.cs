using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Day1
    {
        public void DataTypesDemo()
        {
            // Value Types
            float floatExample = 0.0f;
            int dayOfTheWeek = 0;
            bool thisIsFalse = true;
            double myDouble = 1.1;
            long myLongNumber = 1010101029499809802;
            sbyte mySigned8BitInt = 14;
            byte myUnsigned8BitInt = 1;
            short mySigned16BitInt = 32766;
            ushort myUnsigned16BitInt = 65534;
            uint myUnsigned32BitInt = 4294967294;
            ulong myUnsigned64BitInt = 18446744073709551614;
            nint myPlatformDependent32or64BitSignedIntCompAtRuntime = 42;
            nuint myPlatformDependent32or64BitUnsignedIntCompAtRuntime = 42;
            char myCharVal = '\u0000';


            // Reference Types
            object myObj = new object();
            string weekDay = "Monday";
            string myStringNum = @"111111111fppsaeimf;ke11";
            dynamic myDynamicVar = 1;


            //Collection Types
            List<string> myClass = new List<string>();
            string[] myClass2 = new string[] { };

            // Boxing
            int myVal = 15;
            object myValObj = myVal;

            // Unboxing
            myVal = (int)myValObj;

            int myLongNumberAsAnInt = (int)myLongNumber;
            int myOutputVar;
            bool myStringStoredNumParseAttempt = int.TryParse(myStringNum, out myOutputVar);

            if (myStringStoredNumParseAttempt)
            {
                System.Console.WriteLine($"{myOutputVar}");
            }
            else
            {
                System.Console.WriteLine("The value was not a string and could not be parsed");
            }
        }
    }


    public sealed class ConfigDefaults
    {
        public ConfigDefaults()
        {

        }
    }


    public class MyBaseClass
    {
        public virtual void DoWork() { }
    }

    public class MyLastRandomClass : MyBaseClass
    {
        public sealed override void DoWork() { }
    }


    public class EncapsulationExample
    {
        //public: The type or member can be accessed by any other code in the same assembly or another assembly that references it.The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
        //private: The type or member can be accessed only by code in the same class or struct.
        //protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
        //internal: The type or member can be accessed by any code in the same assembly, but not from another assembly.In other words, internal types or members can be accessed from code that is part of the same compilation.
        //protected internal: The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
        //private protected: The type or member can be accessed by types derived from the class that are declared within its containing assembly.
    }


    public class InheritanceParentClass
    {
        public int Id { get; set; }
        public string LastName { get; set; }
    }

    public interface InheritanceParentClass2
    {
        public int Id2 { get; set; }
        public string LastName2 { get; set; }
    }

    public interface InheritanceParentClass3
    {
        public int Id3 { get; set; }
        public string LastName3 { get; set; }
    }

    public class InheritanceChildExample : InheritanceParentClass { 
        public InheritanceChildExample()
        {
            
        }
    }

    public class InheritanceTest
    {
        public void Run()
        {
            InheritanceChildExample myChild = new InheritanceChildExample();
            myChild.Id = 1;
            myChild.LastName = "Smith";
        }
    }
    
    public class PolymorphismExample
    {
        public string Name { get; set; }

        public void SayHello(string val)
        {
            Console.WriteLine("Hello " + val);
        }

        public void SayHello(string firstName, string lastName)
        {
            Console.WriteLine("Hello " + firstName + " " + lastName);
        }

        public PolymorphismExample()
        {
            Name = "Seth";
        }

        public PolymorphismExample(string name)
        {
            this.Name = name;
            SayHello(Name);
        }

        public PolymorphismExample(string fName, string lName)
        {
            Name = fName + " " + lName;
            SayHello(fName, lName);
        }
    }

    public abstract class AbstractionExample
    {
        public abstract void Run();

        public abstract string SaySomething();
    }

    public class AbstractionExample2 : AbstractionExample
    {
        public override void Run()
        {
            Console.WriteLine("I am running");
        }

        public override string SaySomething()
        {
            return "I am saying something";
        }
    }


    public class Animal
    {
    }

    public class Cat : Animal
    {
    }

    public class Dog : Animal
    {
        
    }

    public class CovarianceExample { 
        
        public IEnumerable<Animal> ListAnimals()
        {
            // Can return anything as long as it implements the IEnumerable interface and the Animal Base class.
            //return new List<Dog>();
            //return new List<Cat>();
            //return new HashSet<Dog>();
            return new LinkedList<Animal>();
        }

    }
}



    
