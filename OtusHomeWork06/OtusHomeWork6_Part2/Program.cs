using System;

namespace OtusHomeWork6_Part2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var planetaryCatalog = new PlanetaryCatalog();
            PrintMessage(planetaryCatalog.GetPlanet("Earth"));
            PrintMessage(planetaryCatalog.GetPlanet("Limonia"));
            PrintMessage(planetaryCatalog.GetPlanet("Mars"));
        }

        private static void PrintMessage((int, int, string?) planetaryCatalog)
        {
            if(planetaryCatalog.Item1 == 0 &&  planetaryCatalog.Item2 == 0)
            {
                Console.WriteLine(planetaryCatalog.Item3);
            }
            else
            {
                Console.WriteLine(planetaryCatalog);
            }
        }
    }
}
