
namespace OtusHomeWork_Part3
{
    internal class PlanetaryCatalog
    {
        private List<Planet> planets = new List<Planet>(3);

        public int Counter { get; set; }

        public PlanetaryCatalog()
        {
            planets.Add(new Planet("Venus", 2, 38025, null));
            planets.Add(new Planet("Earth", 3, 40075, planets[0]));
            planets.Add(new Planet("Mars", 4, 21344, planets[1]));
        }

        public (int, int, string?) GetPlanet(string namePlanet, Func<string, string?> planetValidator)
        {
            Counter++;
            
            switch (namePlanet)
            {
                case "Venus":
                    return (planets[0].SerialNumber, planets[0].EquatorialLength, planetValidator(namePlanet));
                case "Earth":
                    return (planets[1].SerialNumber, planets[1].EquatorialLength, planetValidator(namePlanet));
                case "Mars":
                    return (planets[2].SerialNumber, planets[2].EquatorialLength, planetValidator(namePlanet));
                default:
                    return (0, 0, planetValidator(namePlanet));
            }
        }
    }
}
