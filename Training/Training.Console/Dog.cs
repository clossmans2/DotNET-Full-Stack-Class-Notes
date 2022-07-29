using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Dog : Animal, IComparable<Dog>
    {
        public bool Collar { get; set; }

        public DogSize Size { get; set; }

        public Dog(string name, string color, bool collar) : base(name, color)
        {
            this.Collar = collar;
            this.Tail2 = true;
        }

        public Dog(string name, string color, bool collar, DogSize size) : base(name, color)
        {
            this.Collar = collar;
            this.Tail2 = true;
            this.Size = size;
        }

        public override string Speak()
        {
            return "BARK WOOF!";
        }

        public override string Move()
        {
            return "I run.";
        }

        public void ThreadTest()
        {
            Console.WriteLine($"I worked in a thread. Name: {this.Name}, Color: {this.Color}, Collar: {this.Collar}");
        }

        public override string ToString()
        {
            return $"[Dog: {Name}, {Color}, {Collar}]";
        }

        public int CompareTo(Dog obj)
        {
            return String.Compare(this.Name, obj.Name);
        }
    }

    public enum DogSize
    {
        Small,
        Medium,
        Large
    }
}
