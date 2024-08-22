namespace OtusHomeWork08
{
    internal class Employee
    {
        public string Name { get; init; }
        public int Salary { get; set; }

        public Employee(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} - {Salary}";
        }
    }
}
