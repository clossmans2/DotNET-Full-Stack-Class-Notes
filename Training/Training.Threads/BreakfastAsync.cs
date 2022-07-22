using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads
{
    public static class BreakfastAsync
    {
        public static async Task MakeBreakfast()
        {
            // Synchronous run
            //Coffee cup = PourCoffee();
            //Console.WriteLine("Coffee is ready");

            //Eggs eggs = FryEggs();
            //Console.WriteLine("Eggs are ready");

            //Bacon bacon = FryBacon();
            //Console.WriteLine("Bacon is ready");

            //Toast toast = ToastBread();
            //Console.WriteLine("Toast is ready");

            //Juice oj = PourJuice();
            //Console.WriteLine("Juice is ready");

            // Phase 2
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            Eggs eggs = await FryEggsAsync(2);
            Console.WriteLine("Eggs are ready");

            Bacon bacon = await FryBaconAsync(4);
            Console.WriteLine("Bacon is ready");

            Toast toast = ToastBread();
            Console.WriteLine("Toast is ready");

            Juice oj = PourJuice();
            Console.WriteLine("Juice is ready");

        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee.");
            return new Coffee();
        }

        private static Juice PourJuice()
        {
            Console.WriteLine("Pouring the juice.");
            return new Juice();
        }

        private static Eggs FryEggs()
        {
            Console.WriteLine("Frying the eggs");
            return new Eggs();
        }

        private static async Task<Eggs> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the frying pan...");
            await Task.Delay(3000);
            Console.WriteLine($"Cracking {howMany} eggs ...");
            Console.WriteLine("Cooking the eggs...");
            await Task.Delay(3000);
            Console.WriteLine("Putting the cooked eggs on a plate...");
            return new Eggs();
        }

        private static async Task<Bacon> FryBaconAsync(int numSlices)
        {
            Console.WriteLine("Warming the frying pan...");
            Console.WriteLine("Cooking the first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < numSlices; slice++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Putting the bacon on a plate...");
            return new Bacon();
        }

        private static Toast ToastBread()
        {
            Console.WriteLine("Putting bread into the toaster");
            return new Toast();
        }

        private static void ApplyJelly(Toast toast)
        {
            Console.WriteLine("Putting jelly on the toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
        }

        private static Bacon FryBacon()
        {
            Console.WriteLine("Frying up the bacon");
            return new Bacon();
        }

        private class Coffee { }
        private class Bacon { }

        private class Eggs { }

        private class Toast { }

        private class Juice { }
    }
}
