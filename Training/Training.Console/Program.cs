using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Training
{
    public class Program
    {

        private readonly string _loggerName = "Training.Program";

        public int Id { get; set; }

        public string MY_GLOBAL_CONFIG_VALUE = "Database=MyDb;";

        public string MyName { get; set; }


        public static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            //Day3 day3 = new Day3();

            //day3.ListExample();
            GetConfigurationValue();
        }

        public void MainTwo(string[] args)
        {
            System.Console.WriteLine("Hi, Earth!");
        }

        public static void GetConfigurationValue()
        {
            var connString = ConfigurationManager.AppSettings["ConnectionString"];
            Console.WriteLine($"{connString}");
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
                System.Console.WriteLine($"{value}");
                System.Console.WriteLine(string.Format("{0,3:}", value));
            }

            System.Console.WriteLine(str.ToString());
        }


    }
}