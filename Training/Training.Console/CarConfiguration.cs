using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace Training
{
    public static class CarConfiguration
    {
        public static NameValueCollection? Config => 
            ConfigurationManager.GetSection("CarConfig") as NameValueCollection;
        public static int Year => int.Parse(Config["Year"]);
        public static string Model => Config["Model"];
        public static string Color => Config["Color"];
        public static string BodyStyle => Config["BodyStyle"];
        public static string Make => Config["Make"];
    }
}
