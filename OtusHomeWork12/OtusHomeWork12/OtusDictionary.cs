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

        //public int Key { get; set; }
        //public string? Value { get; set; }

        //индексатор
        
        public string this[int key]
        {
            get
            {
                if (key > values.Length)
                {
                    throw new ArgumentOutOfRangeException("Значения с таким ключем нет в коллекции");
                }

                if (values[key] == null)
                {
                    throw new EmptyPositionException("Пустая позиция");
                }

                return values[CalculationHashCode(key, keysHashCode.Length)];
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Строка не должна быть пустой");
                }

                if(key >=  values.Length)
                {
                    throw new IndexOutOfRangeException($"Вы можете добавить в коллекцию значение с индексом от 0 до {keysHashCode.Length}");
                }

                int hashCode = CalculationHashCode(key, keysHashCode.Length);

                if (keysHashCode[key] == hashCode)
                {
                    string[] newValues = new string[values.Length * 2];
                    int[] newKeysHashCode = new int[newValues.Length];

                    for (int i = 0; i < keysHashCode.Length; i++)
                    {
                        newKeysHashCode[i] = CalculationHashCode(i, newKeysHashCode.Length);
                        newValues[keysHashCode[i]] = values[i];
                    }

                    keysHashCode = newKeysHashCode;
                    values = newValues;

                    throw new PositionTakenException("Позиция занята");
                }

                keysHashCode[key] = hashCode;
                values[hashCode] = value;
            }
        }
        

        public void Add(int key, string value)
        {

            if (value == null)
            {
                throw new ArgumentNullException("Строка не должна быть пустой");
            }

            int hashCode = CalculationHashCode(key, keysHashCode.Length);

            if (keysHashCode[key] == hashCode)
            {
                string[] newValues = new string[values.Length * 2];
                int[] newKeysHashCode = new int[newValues.Length];

                for(int i = 0; i < keysHashCode.Length; i++)
                {
                    newKeysHashCode[i] = CalculationHashCode(i, newKeysHashCode.Length);
                }

                for (int i = 0; i < values.Length; i++)
                {
                    newValues[keysHashCode[i]] = values[i];
                }

                keysHashCode = newKeysHashCode;
                values = newValues;

                throw new PositionTakenException("Позиция занята");
            }

            keysHashCode[key] = hashCode;
            values[hashCode] = value;
        }

        public string Get(int key) => values[CalculationHashCode(key, keysHashCode.Length)];

        private int CalculationHashCode(int key, int lengthBuckets)
        {
            return (key & 0x7fffffff) % lengthBuckets;
        }
    }
}
