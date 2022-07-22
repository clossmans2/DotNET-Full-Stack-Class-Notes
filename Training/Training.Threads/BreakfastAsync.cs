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
            /////////////////////////////////////
            // Phase 2
            //Coffee cup = PourCoffee();
            //Console.WriteLine("Coffee is ready");

            //Eggs eggs = await FryEggsAsync(2);
            //Console.WriteLine("Eggs are ready");

            //Bacon bacon = await FryBaconAsync(4);
            //Console.WriteLine("Bacon is ready");

            //Toast toast = ToastBread();
            //Console.WriteLine("Toast is ready");

            //Juice oj = PourJuice();
            //Console.WriteLine("Juice is ready");
            //////////////////////////////////////

            Coffee cup = PourCoffee();
            Console.WriteLine("Coffe is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("The eggs are ready");
                } else if (finishedTask == baconTask)
                {
                    Console.WriteLine("The bacon is ready");
                } else if (finishedTask == toastTask)
                {
                    Console.WriteLine("The toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourJuice();
            Console.WriteLine("Juice is ready");

            Console.WriteLine("Breakfast is complete.  Come eat!");
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
            await Task.Delay(1000);
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
            await Task.Delay(4000);
            for (int slice = 0; slice < numSlices; slice++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking the second side of bacon...");
            await Task.Delay(4000);
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

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread into the toaster");
            }
            Console.WriteLine("Starting toasting...");

            //Console.WriteLine("Fire! The toaster is on fire! The toast is ruined.");
            //throw new InvalidOperationException("The toaster is on fire");

            await Task.Delay(6000);
            Console.WriteLine("Removing toast from the toaster.");
            
            return new Toast();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            Toast toast = new Toast();

            try
            {
                toast = await ToastBreadAsync(number);
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught the fire");
                Console.WriteLine($"{e.GetType().Name}:\n {e.Message}");
            }

            ApplyButter(toast);
            ApplyJelly(toast);

            return toast;
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
