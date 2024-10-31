using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork12
{
    internal class OtusDictionary
    {
        private int[] keysHashCode = new int[32];
        private string[] values = new string[32];
        public int Position { get; set; }

        public string this[string word]
        {
            /*get
            {
                int hashCode = CalculationHashCode(word, values.Length);

                if (hashCode > values.Length)
                {
                    throw new ArgumentOutOfRangeException("Значения с таким ключем нет в коллекции");
                }

                if (values[hashCode] == null)
                {
                    throw new EmptyPositionException("Пустая позиция");
                }

                return values[hashCode];
            }*/
            set
            {
                Position = CalculationHashCode(word, values.Length);

                if (value == null)
                {
                    throw new ArgumentNullException("Строка не должна быть пустой");
                }

                if(Position >=  values.Length)
                {
                    throw new IndexOutOfRangeException($"Вы можете добавить в коллекцию значение с индексом от 0 до {keysHashCode.Length}");
                }

                if (keysHashCode[Position] == Position)
                {
                    string[] newValues = new string[values.Length * 2];
                    int[] newKeysHashCode = new int[newValues.Length];

                    for (int i = 0; i < keysHashCode.Length; i++)
                    {
                        
                        if (values[i] == null)
                        {
                            continue;
                        }

                        newKeysHashCode[i] = CalculationHashCode(values[i], newKeysHashCode.Length);
                        newValues[keysHashCode[i]] = values[i];
                    }

                    keysHashCode = newKeysHashCode;
                    values = newValues;

                    throw new PositionTakenException("Позиция занята");
                }

                keysHashCode[Position] = Position;
                values[Position] = value;
            }
        }

        public string this[int key]
        {
            get
            {
                if (values[key] == null)
                {
                    return "Строки с таким значением нет в списке";
                }
                else
                {
                    return values[key];
                }
            }
        }
        

        public void Add(string value)
        {

            if (value == null)
            {
                throw new ArgumentNullException("Строка не должна быть пустой");
            }

            int hashCode = CalculationHashCode(value, keysHashCode.Length);

            if (keysHashCode[hashCode] == hashCode)
            {
                string[] newValues = new string[values.Length * 2];
                int[] newKeysHashCode = new int[newValues.Length];

                for(int i = 0; i < keysHashCode.Length; i++)
                {
                    if(values[i] == null)
                    {
                        continue;
                    }

                    newKeysHashCode[i] = CalculationHashCode(values[i], newKeysHashCode.Length);
                }

                for (int i = 0; i < values.Length; i++)
                {
                    newValues[keysHashCode[i]] = values[i];
                }

                keysHashCode = newKeysHashCode;
                values = newValues;

                throw new PositionTakenException("Позиция занята");
            }

            keysHashCode[hashCode] = hashCode;
            values[hashCode] = value;
        }

        public string Get(int key)
        {
            if (values[key] == null)
            {
                return "Строки с таким значением нет в списке";
            }
            else
            {
                return values[key];
            }
        }

        private int CalculationHashCode(string word, int lengthBuckets)
        {
            if(word == null)
            {
                throw new ArgumentNullException("Невозможно добавить пустую строку");
            }

            return (word.GetHashCode() & 0x7fffffff) % lengthBuckets;
        }
    }
}
