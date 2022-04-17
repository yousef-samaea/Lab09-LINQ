using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../data.json";
            string jsonData = File.ReadAllText(path);
            Console.WriteLine(jsonData);
        }

        public class Root
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
            public Properties properties { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

        public class Properties
        {
            public string zip { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string address { get; set; }
            public string borough { get; set; }
            public string neighborhood { get; set; }
            public string county { get; set; }
        }





    }
}
