using System;
using System.Diagnostics;


namespace OtusHomeWork2
{
    public interface ICollections
    {
        public Stopwatch stopwatch { get; set; }
        public Random random { get; }
        public TimeSpan tWorks { get; set; }

        public void AddValuesInCollection();

        public void FindingAnItemInACollection();

        public void DivisionElementsInto777();

    }
}
