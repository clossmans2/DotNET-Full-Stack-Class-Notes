using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Threads
{
    public sealed class MyThreadSafeSingleton
    {
        private static MyThreadSafeSingleton instance = null;
        private static readonly object mutex = new object();

        private MyThreadSafeSingleton() { }

        public static MyThreadSafeSingleton Instance
        {
            get
            {
                //critical section
                //only want one thread at a time entering this
                //this is the same as trying to aquire the lock and if it errors
                //out it releases the lock for you:
                //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement
                lock (mutex)
                {
                    if (instance == null)
                    {
                        instance = new MyThreadSafeSingleton();
                    }
                    return instance;
                }
            }
        }
    }
}
