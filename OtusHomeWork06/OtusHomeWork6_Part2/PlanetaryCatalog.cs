using System.Collections.Generic;

namespace OtusHomeWork6_Part2
{
    internal class PlanetaryCatalog
    {
        private List<Planet> planets = new List<Planet>(3);
        private int counter = 0;

        public PlanetaryCatalog()
        {
            planets.Add(new Planet("Venus", 2, 38025, null));
            planets.Add(new Planet("Earth", 3, 40075, planets[0]));
            planets.Add(new Planet("Mars", 4, 21344, planets[1]));
        }

        public (int, int, string?) GetPlanet(string namePlanet)
        {
            counter++;
            if (counter == 3)
            {
                return (0, 0, "You ask too often.");
            }
            switch (namePlanet)
            {
                case "Venus":
                    return (planets[0].SerialNumber, planets[0].EquatorialLength, "null");
                case "Earth":
                    return (planets[1].SerialNumber, planets[1].EquatorialLength, "null");
                case "Mars":
                    return (planets[2].SerialNumber, planets[2].EquatorialLength, "null");
                default:
                    return (0, 0, "Unable to locate the planet.");
            }
        }
    }
}
