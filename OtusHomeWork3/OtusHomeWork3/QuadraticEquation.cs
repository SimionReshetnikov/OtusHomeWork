using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace OtusHomeWork3
{
    internal class QuadraticEquation
    {
        public int ParameterA { get; set; }
        public int ParameterB { get; set; }
        public int ParameterC { get; set; }

        public Dictionary<int, string> EquationValuesInString { get; set; }

        public QuadraticEquation()
        {
            EquationValuesInString = new Dictionary<int, string>()
            {
                { 0, "a" },
                { 1, "b" },
                { 2, "c" }
            };
        }

        public string PrintParameterA(string parameterValue)
        {
            EquationValuesInString[0] = parameterValue;
            ParameterA = AddParameter(parameterValue);
            return parameterValue;
        }

        public string PrintParameterB(string parameterValue)
        {
            EquationValuesInString[1] = parameterValue;
            ParameterB = AddParameter(parameterValue);
            return parameterValue;
        }

        public string PrintParameterC(string parameterValue)
        {
            EquationValuesInString[2] = parameterValue;
            ParameterC = AddParameter(parameterValue);
            return parameterValue;
        }
        private int AddParameter(string parameterValue)
        {
            return Convert.ToInt32(parameterValue);
        }

        

        public override string ToString()
        {
            if(ParameterA != 0 && ParameterB != 0 && ParameterC != 0)
            {
                return $"{ParameterA}*x^2 + {ParameterB}*x + {ParameterC} = 0";
            }
            else if(ParameterA != 0 && ParameterB != 0)
            {
                return $"{ParameterA}*x^2 + {ParameterB}*x + c = 0";
            }
            else if (ParameterA != 0)
            {
                return $"{ParameterA}*x^2 + b*x + c = 0";
            }
            else
            {
                return $"a*x^2 + b*x + c = 0";
            }
        }
    }
}
