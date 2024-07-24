using System;
using System.Threading;
using System.Collections.Generic;

namespace OtusHomeWork05
{
    public class Quadcopter : IFlyingRobot, IChargeable
    {
        private readonly List<string> _components = ["rotor1", "rotor2", "rotor3", "rotor4"];
        public void Charge()
        {
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");
        }

        public List<string> GetComponents()
        {
            return _components;
        }

        public string GetInfo()
        {
            return "Available quadcopter features: \n" +
                "1. - GetComponents\n" +
                "2. - Change\n" +
                "3. - GetRobotType" +
                "\n";
        }

        public string GetRobotType()
        {
            return "I am a flying robot.";
        }
    }
}
