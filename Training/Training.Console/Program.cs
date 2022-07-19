using System;
using System.Collections.Generic;
using System.Text;

namespace Training {
    public class Program {

        private readonly string _loggerName = "Training.Program";

        public int Id { get; set; }

        public string MY_GLOBAL_CONFIG_VALUE = "Database=MyDb;";

        public string MyName { get; set; }


        public static void Main(string[] args) {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, World!");
        }

        public void MainTwo(string[] args)
        {
            Console.WriteLine("Hi, Earth!");
        }
    }

    // Static Keyword examples
    public static class App
    {
        public static void Run()
        {
            var argList = new string[] { };

            Program.Main(argList);

            var myProgram = new Program();
            myProgram.MainTwo(argList);

            StringBuilder str = new StringBuilder();

            // String manipulation
            foreach (var value in argList)
            {
                str.Append(value);
                Console.WriteLine($"{value}");
                Console.WriteLine(string.Format("{0,3:}", value));
            }

            Console.WriteLine(str.ToString());
        }

        
    }
}