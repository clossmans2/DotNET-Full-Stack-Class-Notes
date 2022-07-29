using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public string Color { get; set; }
        private bool Tail { get; set; }
        protected bool Tail2 { get; set; }

        public Animal() { }

        public Animal(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public abstract string Speak();

        public string View()
        {
            return $"I am a {this.Color} animal";
        }

        public abstract string Move();

        public virtual bool Vaccinated()
        {
            return true;
        }
    }
}
