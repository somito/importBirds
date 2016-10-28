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
            var importedBirds = BirdRepository.LoadImportedBirds();
            /*foreach (var bird in birds)
            {
                Console.WriteLine(birds.Count());
            }

            Console.WriteLine(birds.Select(b => b.Sightings.Count()).Average());
            var listOfSightings = birds.SelectMany(b => b.Sightings);
            var listOfCountries = listOfSightings.Select(s => s.Place.Country).Distinct();
            var query = birds.SelectMany(b => b.Sightings).GroupBy(gs => gs.Place.Country).Select(s => new { Country = s.Key, Sightings = s.Count() });
            var statuses = birds.Select(b => b.ConservationStatus).Distinct();
            statuses = statuses.Where(s => s != "LeastConcern" && s != "NearThreatened");
            var endangeredSightings = birds.Join(
                statuses,
                b => b.ConservationStatus,
                s => s,
                (b, s) => new { Status = s, Sightings = b.Sightings }).GroupBy(b => b.Status).Select(b => new { Status = b.Key, Sightings = b.Sum(s => s.Sightings.Count())});
                */

            var newBirds = importedBirds.GroupJoin(birds,
                  ib => ib.CommonName,
                  b => b.CommonName,
                  (ib, b) => new { ImportedBird = ib, Birds = b }).SelectMany(gb => gb.Birds.DefaultIfEmpty(), (gb, b) => new { ImportedBird = gb.ImportedBird, Bird = b });

            var newBirdsFinal = newBirds.Where(nb => nb.Bird == null).Select(nb => nb.ImportedBird).ToList();

            birds.AddRange(newBirdsFinal);
             
            foreach (var element in newBirdsFinal)
            {
                Console.WriteLine(element);
            }

           

        }
    }
}
