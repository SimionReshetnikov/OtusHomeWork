using System;

namespace OtusHomeWork6_Part1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //EquatorialLength - Порядковый номер от Солнца
            var venus = new
            {
                Name = "Venus",
                SerialNumber = 2, 
                EquatorialLength = 38025,
                PreviousPlanet = (object?)null
            };

            var earth = new
            {
                Name = "Earth",
                SerialNumber = 3,
                EquatorialLength = 40075,
                PreviousPlanet = venus
            };

            var mars = new
            {
                Name = "Mars",
                SerialNumber = 4,
                EquatorialLength = 21344,
                PreviousPlanet = earth
            };

            var newVenus = new
            {
                Name = "Venus",
                SerialNumber = 2,
                EquatorialLength = 38025,
                PreviousPlanet = mars
            };

            Console.WriteLine("All the planets described:");
            Console.Write($"Planet 1: {venus}\t");
            Console.WriteLine($"Planet venus1 equals venus1: {venus.Equals(newVenus)}\n");
            Console.Write($"Planet 2: {earth}\t");
            Console.WriteLine($"Planet earth equals venus1: {earth.Equals(newVenus)}\n");
            Console.Write($"Planet 3: {mars}\t");
            Console.WriteLine($"Planet mars equals venus1: {mars.Equals(newVenus)} \n");
            Console.Write($"Planet 4: {newVenus}\t");
            Console.WriteLine($"Planet venus2 equals venus1: {newVenus.Equals(newVenus)}");
        }
    }
}
