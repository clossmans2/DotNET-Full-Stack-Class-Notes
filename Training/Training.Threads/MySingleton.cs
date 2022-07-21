namespace Training.Threads
{
    public sealed class MySingleton
    {
        private static MySingleton instance = null;

        private MySingleton() { }
        
        public static MySingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MySingleton();
                }
                return instance;
            }
        }
    }
}