using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Microsoft.Azure.Amqp.Framing;
using Newtonsoft.Json;

namespace LINQ
{
    class Program
    {
        //public static List<Person> Source { get; private set; }

        public static void Main(string[] args)
        {
            string path = @"../../../data.json";
            string jsonData = File.ReadAllText(path);
                //Console.WriteLine(jsonData);
            dataRoot data = JsonConvert.DeserializeObject<dataRoot>(jsonData);

            Console.WriteLine("All neighborhoods");
            Console.WriteLine("-----------------------------------------");
            allNeighborhood(data);
            Console.WriteLine("-----------------------------------------");


            Console.WriteLine("All neighborhoods with nams");
            Console.WriteLine("-----------------------------------------");
            allNeighborhoodWithNames(data);
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("All neighborhoods with nams with no Duplicates ");
            Console.WriteLine("-----------------------------------------");
            allNeighborhoodNoDuplicates(data);
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("single query.");
            Console.WriteLine("-----------------------------------------");
            singleQuery(data);
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Rewrite using Use LINQ Query.");
            Console.WriteLine("-----------------------------------------");
            rewriteSingleQuery(data);
            Console.WriteLine("-----------------------------------------");



        }

        public static void allNeighborhood(dataRoot data)
        {
            var all = from Feature in data.features
                     select Feature.properties.neighborhood;
            int countar = 1;
            foreach (var x in all)
            {
                Console.WriteLine($"{countar}. {x}"); 
                countar++;
            }
        }

        public static void allNeighborhoodWithNames(dataRoot data)
        {
            var all = from Feature in data.features
                      where Feature.properties.neighborhood != ""
                      select Feature.properties.neighborhood;
            int countar = 1;
            foreach (var x in all)
            {
                Console.WriteLine($"{countar}. {x}");
                countar++;
            }
        }

        public static void allNeighborhoodNoDuplicates(dataRoot data)
        {
            var all = from Feature in data.features
                      where Feature.properties.neighborhood != ""
                      select Feature.properties.neighborhood;
            var y =all.Distinct();
            int countar = 1;
            foreach (var x in y)
            {
                Console.WriteLine($"{countar}. {x}");
                countar++;
            }
        }

        public static void singleQuery(dataRoot data)
        {
            var all = from Feature in data.features where Feature.properties.neighborhood != "" select Feature.properties.neighborhood;
            var y = all.Distinct();
            int countar = 1;
            foreach (var x in y)
            {
                Console.WriteLine($"{countar}. {x}");
                countar++;
            }
        }

        public static void rewriteSingleQuery(dataRoot data)
        {
            //var all = from Feature in data.features where Feature.properties.neighborhood != "" select Feature.properties.neighborhood;
            //var y = all.Distinct();
            var allN = data.features.Select(x => x.properties.neighborhood).Where(y => y != "").Distinct();
            int countar = 1;
            foreach (var x in allN)
            {
                Console.WriteLine($"{countar}. {x}");
                countar++;
            }
        }





        public class dataRoot
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
