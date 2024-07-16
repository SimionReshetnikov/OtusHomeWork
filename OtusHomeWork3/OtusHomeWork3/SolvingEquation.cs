using System;
using System.Runtime.CompilerServices;

namespace OtusHomeWork3
{
    internal class SolvingEquation : QuadraticEquation
    {
        public string CalculationOfSolutionToTheEquation()
        {
            double discriminant = Math.Pow(ParameterB, 2) - 4 * ParameterA * ParameterC;

            if(discriminant < 0)
            {
                throw new NegativeDiscriminantException("No real values found.");
            }
            else if(discriminant > 0)
            {
                double x1 = (-ParameterB + Math.Sqrt(discriminant)) / 2 * ParameterA;
                double x2 = (-ParameterB - Math.Sqrt(discriminant)) / 2 * ParameterA;

                return $"x1 = {x1}, x2 = {x2}";
            }

            else
            {
                return $"x = {(-ParameterB + Math.Sqrt(discriminant)) / 2 * ParameterA}";
            }
        }
    }
}
