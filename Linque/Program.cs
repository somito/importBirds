using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linque
{
    class Program
    {
        static void Main(string[] args)
        {
            var birds = BirdRepository.LoadBirds();
            /*foreach (var bird in birds)
            {
                Console.WriteLine(birds.Count());
            }*/

            Console.WriteLine(birds.Select(b => b.Sightings.Count()).Average());
        }
    }
}
