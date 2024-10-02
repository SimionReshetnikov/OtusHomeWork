using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomeWork12
{
    internal class OtusDictionary
    {
        private string[] values = new string[32];

        public int Key { get; set; }
        public string? Value { get; set; }

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

                return values[key];
            }
            set
            {
                if (values[key] != null)
                {
                    string[] newValues = new string[values.Length * 2];

                    for (int i = 0; i < values.Length; i++)
                    {
                        newValues[i] = values[i];
                    }

                    values = newValues;

                    throw new PositionTakenException("Позиция занята");
                }

                values[key] = value;
            }
        }


        //Методы Add и Get
        /*public void Add(int key, string value)
        {
            if (values[key] != null)
            {
                string[] newValues = new string[value.Length * 2];

                for (int i = 0; i < values.Length; i++)
                {
                    newValues[i] = values[i];
                }

                values = newValues;

                throw new PositionTakenException("Позиция занята");
            }

            values[key] = value;
        }

        public string Get(int key)
        {
            if(key > values.Length)
            {
                throw new ArgumentOutOfRangeException("Значения с таким ключем нет в коллекции");
            }

            if(values[key] == null)
            {
                throw new EmptyPositionException("Пустая позиция");
            }

            return values[key];
        }*/

    }
}
