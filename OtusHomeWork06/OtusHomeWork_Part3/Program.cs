using System;

namespace OtusHomeWork_Part3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string message = "You ask too often.";
            var planetCatalog = new PlanetaryCatalog();
            string[] planetsName = ["Earth", "Limonia", "Mars"];

            foreach(var planet in planetsName)
            {
                if (planet == "Limonia")
                {
                    Console.WriteLine(planetCatalog.GetPlanet(planet,
                namePlanet => planetCatalog.Counter == 3 ? message : "Unable to locate the planet.").Item3);
                }
                else
                {
                    Console.WriteLine(planetCatalog.GetPlanet(planet,
                namePlanet => planetCatalog.Counter == 3 ? message : "null").Item3);
                }
            }

            Console.WriteLine("\nAdditional task");
            foreach (var planet in planetsName)
            {
                Console.WriteLine(planetCatalog.GetPlanet(planet,
                namePlanet => planet == "Limonia" ? "It's a forbidden planet." : "null").Item3);
            }
        }
    }
}
