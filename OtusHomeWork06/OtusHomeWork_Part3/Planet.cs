namespace OtusHomeWork_Part3
{
    internal class Planet
    {
        public string Name { get; init; }
        public int SerialNumber { get; init; }
        public int EquatorialLength { get; init; }
        public object? PreviousPlanet { get; init; }

        public Planet(string name, int serialNumber, int equatorialLength, object? previousPlanet)
        {
            Name = name;
            SerialNumber = serialNumber;
            EquatorialLength = equatorialLength;
            PreviousPlanet = previousPlanet;
        }
    }
}
