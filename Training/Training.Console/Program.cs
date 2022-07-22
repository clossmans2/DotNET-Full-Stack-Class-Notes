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


            //await BreakfastAsync.MakeBreakfast();

            //BankAccountExample();

            ProducerConsumerExample();
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

            Dog dog = new Dog("Sparky", "Yellow", true);
            Thread thread4 = new Thread(dog.ThreadTest);
            tasks.Add(thread4);
            Thread thread5 = new Thread(new ThreadStart(dog.ThreadTest));
            tasks.Add(thread5);

            Thread thread6 = new Thread(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    double val = rand.NextDouble() * (50.50 - 20.50) + 20.50;
                    p4.Add(val);
                    Thread.Sleep(3000);
                    val = rand.NextDouble() * (50.50 - 20.50) + 20.50;
                    p4.Withdraw(val);
                }
            });
            tasks.Add(thread6);

            foreach (Thread task in tasks)
            {
                task.Start();
            }

            foreach (Thread task in tasks)
            {
                task.Join();
            }

            Console.WriteLine("All threads finished!");

            Thread newThread = new Thread(() => { Thread.Sleep(1200000); });
            newThread.Start();
            newThread.Interrupt(); // Interrupts the thread when blocked/terminates it
            Console.WriteLine("Thread interrupted");
            newThread.Join();

        }

        public static void ProducerConsumerExample()
        {
            Random rand = new Random();
            ProducerConsumer pcExample = new ProducerConsumer();

            Thread producer1 = new Thread(() =>
            {
                int val = rand.Next(20, 51);

                for (int i = 0; i < 5; i++)
                {
                    pcExample.AddProduce(val);
                    Thread.Sleep(1000);
                }
            });

            Thread producer2 = new Thread(() => {
                int val = rand.Next(20, 51);

                for (int i = 0; i < 5; i++)
                {
                    pcExample.AddProduce(val);
                    Thread.Sleep(1000);
                }
            });

            Thread consumer1 = new Thread(() => {
                int val = rand.Next(10, 21);

                for (int i = 0; i < 5; i++)
                {
                    pcExample.ConsumeProduce(val);
                    Thread.Sleep(1000);
                }
            });

            Thread consumer2 = new Thread(() => {
                int val = rand.Next(10, 21);

                for (int i = 0; i < 5; i++)
                {
                    pcExample.ConsumeProduce(val);
                    Thread.Sleep(1000);
                }
            });

            producer1.Start();
            producer2.Start();
            consumer1.Start();
            consumer2.Start();

            producer1.Join();
            producer2.Join();
            consumer1.Join();
            consumer2.Join();
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