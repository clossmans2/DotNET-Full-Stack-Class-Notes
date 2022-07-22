using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using Training.Factories;
using Training.Threads;


namespace Training
{
    public class Program
    {

        private readonly string _loggerName = "Training.Program";

        public int Id { get; set; }

        public string MY_GLOBAL_CONFIG_VALUE = "Database=MyDb;";

        public string MyName { get; set; }


        public static async Task Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            //Day3 day3 = new Day3();

            //day3.ListExample();
            //GetConfigurationValue();
            //GetConfigurationSectionValues();
            //Car car = new Car()
            //{
            //    Year = CarConfiguration.Year,
            //    Color = CarConfiguration.Color,
            //    Make = CarConfiguration.Make,
            //    BodyStyle = CarConfiguration.BodyStyle,
            //    Model = CarConfiguration.Model
            //};
            //Console.WriteLine($"{car.Year} {car.Make} {car.Model} {car.Color} {car.BodyStyle}");
            //var fileOps = new FileOperations();
            //fileOps.ReadFile();
            //fileOps.WriteFile();
            //var csv = fileOps.ReadCSV();

            //Console.WriteLine("Would you like to see the CSV Data? [y/n]");
            //var userInput = Console.ReadLine();

            //if (userInput.Equals("y"))
            //{
            //    Console.WriteLine("Contents of the CSV");
            //    Console.WriteLine("-------------------");
            //    foreach (var line in csv)
            //    {
            //        Console.WriteLine(line.ToString());
            //    }
            //} else
            //{
            //    Console.WriteLine("Press any key to terminate the program");
            //}

            //XBoxFactory xBoxFactory = new XBoxFactory(true, true, "Microsoft");
            //var xrem = xBoxFactory.GetRemote();

            //PSFactory psFactory = new PSFactory(true, true, "Sony");
            //var psrem = psFactory.GetRemote();


            await BreakfastAsync.MakeBreakfast();
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

        public static void GetConfigurationSectionValues()
        {
            var appSettings = ConfigurationManager
                .GetSection("ApplicationSettings") as NameValueCollection;

            if (appSettings.Count == 0)
            {
                Console.WriteLine("There aren't any application settings defined.");
            }
            else
            {
                foreach (var key in appSettings.AllKeys)
                {
                    Console.WriteLine($"{key} = {appSettings[key]}");
                }
            }
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