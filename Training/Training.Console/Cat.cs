using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Cat : Animal
    {
        public string EyeColor { get; set; }

        public Cat(string name, string color, string eye) : base(name, color)
        {
            EyeColor = eye;
        }

        public override string Move()
        {
            return "I prowl";
        }

        public override string Speak()
        {
            return "MEOW!!";
        }
    }
}
