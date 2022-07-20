using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Day3
    {
        public readonly Logger<Day3> Logger;
        public List<Day2> Items { get; set; }
        public List<string> CarMakes { get; set; } = new List<string>();
        public Day3()
        {
            Items = new List<Day2>();
            int myNum = 0;
            Logger = new Logger<Day3>();
            WontChangeVariable(ref myNum);
            Console.WriteLine(myNum);
        }

        // Objects are pass by ref
        public void ChangeDay2(Day2 item)
        {
            item.Id = 15;
        }

        // can change with a ref parameter
        public void WontChangeVariable(ref int i)
        //public void WontChangeVariable(int i)
        {
            i = 75;
        }

        public void ListExample()
        {
            Logger.Log("Adding Vehicle Makes");
            CarMakes.Add("Honda");
            CarMakes.Add("Lexus");
            CarMakes.Add("Toyota");
            CarMakes.Add("Acura");
            CarMakes.Add("General Motors");
            CarMakes.Add("Chrysler");
            CarMakes.Add("Subaru");
            CarMakes.Add("Ford");
            CarMakes.Add("Kia");
            CarMakes.Add("Tesla");
            CarMakes.Add("Ferrari");
            CarMakes.Add("Fiat");
            CarMakes.Add("Range Rover");
            CarMakes.Add("BMW");
            CarMakes.Add("Jeep");
            CarMakes.Add("McLaren");

            foreach (var make in CarMakes)
            {
                Console.WriteLine($"{make} : ");
            }

            var mySet = new HashSet<string>();
            var myQ = new Queue<string>();
            var myDict = new Dictionary<string, Car>();
            var myCivic = new HondaCivic();
            myDict.Add("MyCivic", myCivic);
            myDict["myCivic2"] = myCivic;

            var carList = new CarList<Car>();
            carList.Automobiles.Add(1, myCivic);
            var motoList = new CarList<Motorcycle>();

            Car[] newCarList = new Car[] {
                new Car() { Make = "Honda", Model="Civic", BodyStyle="Sedan", Color="Black", Year=2014},
                new Car() { Make = "Lexus", Year=2008 },
                new Car() { Make = "Toyota", Year=2023 },
                new Car() { Make = "Acura", Year=1980 },
                new Car() { Make = "General Motors", Year=2018 },
                new Car() { Make = "Chrysler", Year=1975 },
                new Car() { Make = "Subaru", Year=2005 },
                new Car() { Make = "Ford", Year=1501 },
                new Car() { Make = "Kia", Year=2010 },
                new Car() { Make = "Tesla", Year=2017 },
                new Car() { Make = "Ferrari", Year=2013 },
                new Car() { Make = "Fiat", Year=2020 },
                new Car() { Make = "Range Rover", Year=2020 },
                new Car() { Make = "BMW", Year=2021 },
                new Car() { Make = "Jeep", Year=2019 },
                new Car() { Make = "McLaren", Year=2005 }
            };

            Array.Sort(newCarList, Car.SortYearDescending());
            foreach (var car in newCarList)
            {
                Console.WriteLine($"{car.Year} -- {car.Make}");
            }
        }
    }

    public class Car : IComparable
    {
        private class CarYearSortAscendingHelper : IComparer
        {
            int IComparer.Compare(object? x, object? y)
            {
                Car car1 = x as Car;
                Car car2 = y as Car;

                if (car1.Year > car2.Year)
                {
                    return 1;
                }
                else if (car1.Year < car2.Year)
                {
                    return -1;
                }
                else
                    return 0;

            }
        }

        private class CarYearSortDescendingHelper : IComparer
        {
            // [  2005, 2010, 2015, 2020, 2000 ]
            int IComparer.Compare(object? x, object? y)
            {
                Car car1 = x as Car; // (Car)x
                Car car2 = y as Car;

                if (car1.Year < car2.Year)
                {
                    return 1;
                }
                else if (car1.Year > car2.Year)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }

        // Default sort order
        int IComparable.CompareTo(object? obj)
        {
            Car car = obj as Car;
            return string.Compare(this.Make, car.Make);
        }

        public static IComparer SortYearAscending()
        {
            return (IComparer)new CarYearSortAscendingHelper();
        }

        public static IComparer SortYearDescending()
        {
            return (IComparer)new CarYearSortDescendingHelper();
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string BodyStyle { get; set; }

        public int CompareTo(object? obj)
        {
            return Year.CompareTo(obj);
        }
    }

    public class CarList<T>
    {
        public Dictionary<int, T> Automobiles { get; set; }

        public CarList()
        {
            Automobiles = new Dictionary<int, T>();
        }

        public void GetAutoModel(int index)
        {
            T car = Automobiles[index];
        }

    }

    public class Logger<T>
    {
        Type t = typeof(T);
        public Type GetLoggingClass()
        {
            return t;
        }

        public void Log(string msg)
        {
            Console.WriteLine($"{t.FullName}:: {msg}");
        }

    }
        // Value type equivalent of a class
    public struct StructExample
    {
        public int XLocation { get; set; }
        public int YLocation { get; set; }

        public StructExample()
        {
            YLocation = 0;
            XLocation = 0;
        }

        public string GetLocation()
        {
            return $"{XLocation}, {YLocation}";
        }
    }
        
    public class HondaCivic : Car
    {
        public HondaCivic() : base()
        {
            Make = "Honda";
            Model = "Civic";
            Year = 2022;
            Color = "White";
            BodyStyle = "Coupe";
        }
    }

    public class Motorcycle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }

    public class MyLinkedList<T>
    {
        private class Node
        {
            public Node Next { get; set; }
            public T Data { get; set; }

            public Node(T t)
            {
                Next = null;
                Data = t;
            }

            private Node head;

            public Node()
            {
                head = null;
            }

            public void AddHead(T t)
            {
                Node n = new Node(t);
                n.Next = head;
                head = n;
            }

            public void Print()
            {
                Node current = head;

                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }

            public T Get(int i)
            {
                int count = 0;
                Node current = head;
                while (count < i)
                {
                    current = current.Next;
                    count++;
                }

                return current.Data;
            }
        }
    }
}