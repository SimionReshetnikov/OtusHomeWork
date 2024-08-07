namespace OtusHomeWork6_Part2
{
    internal class Planet
    {
        public string Name { get; init; }
        public int SerialNumber { get; init; }
        public int EquatorialLength { get; init; }
        public Planet? PreviousPlanet { get; init; }

        public Planet(string name, int serialNumber, int equatorialLength, Planet? previousPlanet)
        {
            Name = name;
            SerialNumber = serialNumber;
            EquatorialLength = equatorialLength;
            PreviousPlanet = previousPlanet;
        }
    }
}
