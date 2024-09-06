using Microsoft.VisualBasic;

namespace TestTemplate
{

    class Program
    {


        static List<string> names = new List<string> { "Andrew", "Sarah", "Mark", "Anders", "Edward", "Barry", "Simon", "Bob", "Hannah" };
        static void Main(string[] args)
        {

            //palindrone 
            Console.WriteLine("Palindrones: \n");
            var results = from n in names
                          let forward = n
                          let reverse = new string(forward.ToCharArray().Reverse().ToArray())
                          where forward.Equals(reverse, StringComparison.OrdinalIgnoreCase)
                          select n;

            Console.WriteLine(string.Join("\n", results));


            Console.WriteLine("Group by first letter: \n");

            var results_group = from n in names 
                                group n by n[0] into groups
                                select groups;
            
            foreach(var r in results_group)
                Console.WriteLine(string.Join("\n", r));


        }
    }
}