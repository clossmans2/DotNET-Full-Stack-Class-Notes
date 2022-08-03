using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Training.Factories;
using Training.Threads;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Training
{
    public class Program
    {

        private readonly string _loggerName = "Training.Program";

        public int Id { get; set; }

        public string MY_GLOBAL_CONFIG_VALUE = "Database=MyDb;";

        public static readonly string ConnString = "Data Source=0353L-GZW7KL3;Initial Catalog=SkillStormMotors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //public static readonly string ConnString2 = "Server=0353L-GZW7KL3;Database=SkillStormMotors;Trusted_Connection=True;";

        public string MyName { get; set; }

        public static async Task Main(string[] args)
        {
            SSMotorsTableAdapters.VehicleTableAdapter vehicleTableAdapter =
                new SSMotorsTableAdapters.VehicleTableAdapter();
            SSMotors.VehicleDataTable vehicles;
            vehicles = vehicleTableAdapter.GetData();
            
            

            foreach (SSMotors.VehicleRow car in vehicles)
            {
                Console.WriteLine($"Vehicle:: {car.Id} {car.ModelYear} {car.Make} {car.Model} - {car.Mileage} Miles, Asking ${car.MSRP}\r\n");
            }


            // ADO.NET Introduction
            await using var conn = new SqlConnection(ConnString);
            SqlTransaction tx = conn.BeginTransaction("MyTransaction"); // <====== WHAT IS THAT BEING CALLED ON?
            
            //string selectQuery = "SELECT * FROM [Vehicle] FOR JSON PATH";

            //SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn);

            //DataSet vehicleDataSet = new DataSet();
            //adapter.Fill(vehicleDataSet, "Vehicle");

            //List<Vehicle> inventory = new List<Vehicle>();

            //foreach (DataRow row in vehicleDataSet.Tables["Vehicle"].Rows)
            //{
            //string trim;
            //string vinnumber;

            //// Check for dbnull on trimlevel
            //if (row.IsNull(7))
            //{
            //    trim = "N/A";
            //}
            //else
            //{
            //    trim = (string)row["TrimLevel"];
            //}

            //if (row.IsNull(9))
            //{
            //    vinnumber = "N/A";
            //}
            //else
            //{
            //    vinnumber = (string)row["VIN"];
            //}

            //    var vehicle = new Vehicle {
            //        Id = (int)row["Id"],
            //        Body = (string)row["Body"],
            //        Model = (string)row["Model"],
            //        Color = (string)row["Color"],

            //        Mileage = (int)row["Mileage"],
            //        Make = (string)row["Make"],
            //        MSRP = (int)row["MSRP"],
            //        ModelYear = (int)row["ModelYear"],
            //        TrimLevel = row.IsNull(7) ? "N/A" : (string)row["TrimLevel"],
            //        VIN = row.IsNull(9) ? "N/A" : (string)row["VIN"]
            //    };
            //    inventory.Add(vehicle);
            //}

            //foreach (var car in inventory)
            //{
            //    Console.WriteLine(car.ToString());
            //}

            //SqlCommand command = new SqlCommand(selectQuery, conn);

            //try
            //{
            //    await conn.OpenAsync();
            //    SqlDataReader reader = await command.ExecuteReaderAsync();
            //    while (reader.Read())
            //    {
            //        //Console.WriteLine($"{reader[0]}");
            //        //Console.WriteLine($"\t{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}\t{reader[4]}\t{reader[5]}\t{reader[6]}\t{reader[7]}\t{reader[8]}\t{reader[9]}");
            //    }
            //    await reader.CloseAsync();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.ReadLine();        

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

            //ProducerConsumerExample();
        }

        public static IConfigurationBuilder CreateDefaultBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            

            return builder;
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

            //Threads do not like methods that return values, and must
            //use methods that don't have parameters for methods that don't
            //invovle parameters
            //in order to involve parameters have a class that contains the state info
            Dog dog = new Dog("Sparky", "Yellow", true);
            Thread thread4 = new Thread(dog.ThreadTest);
            tasks.Add(thread4);
            Thread thread5 = new Thread(new ThreadStart(dog.ThreadTest));
            tasks.Add(thread5);

            // demonstration of how a lambda works
            // and that you can put the entire thread method
            // inside of one
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

        //issues with this could be things such as a producer or consumer thread waiting and
        //not having any producers alive to produce and therefore deadlock
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
                //random values between 0 and 
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
            var connString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            Console.WriteLine($"{connString}");
        }

        public static void GetConfigurationSectionValues()
        {
            var appSettings = System.Configuration.ConfigurationManager
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