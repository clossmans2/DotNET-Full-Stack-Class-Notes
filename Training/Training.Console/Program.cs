﻿using System;
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

        public static void BankAccountExample()
        {
            BankAccount b1 = new BankAccount(100);
            BankAccount b2 = new BankAccount(100);
            BankAccount b3 = new BankAccount(100);
            Person p1 = new Person("Dan Pickles", b1);
            Person p2 = new Person("John Doe", b2);
            Person p3 = new Person("Seth Rogen", b3);
            Person p4 = new Person("Tammy Pickles", b1);
            Random rand = new Random();
            List<Thread> tasks = new List<Thread>();
            // new Thread(new ThreadStart(Method))
            Thread thread1 = new Thread(() => ManageAccount(p1, rand));
            tasks.Add(thread1);
            Thread thread2 = new Thread(() => ManageAccount(p2, rand));
            tasks.Add(thread2);
            Thread thread3 = new Thread(() => ManageAccount(p3, rand));
            tasks.Add(thread3);

            //Thread thread4 = new Thread()

        }

        private static void ManageAccount(Person p, Random rando)
        {
            for (int i = 0; i < 3; i++)
            {
                double val = rando.NextDouble() * (50.50 - 20.50) + 20.50;
                p.Add(val);
                Thread.Sleep(3000);
                val = rando.NextDouble() * (50.50 - 20.50) + 20.50;
                p.Withdraw(val);
            }
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