namespace OtusHomeWork12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int maxIndex = 31;
            int countKollision = 0;
            var dictionary = new OtusDictionary();

            while (true)
            {
                Console.WriteLine("Введите номер нужной команды из списка:\n" +
                    "1. Добавить значение;\n" +
                    "2. Посмотреть значение по индексу;\n" +
                    "Для выхода нажмите любую другую клавишу.");
                
                string result = Console.ReadLine();
                
                if(result != "1" && result != "2")
                {
                    Console.WriteLine("Выхожу из программы.");
                    break;
                }

                if(result == "1")
                {
                    Console.WriteLine($"Введите индекс от 0 до {maxIndex}.");

                    dictionary.Key = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите нужное значение.");

                    dictionary.Value = Console.ReadLine();

                    Console.WriteLine("Добывляю значения...");

                    string message = "Значения успешно добавлены.";

                    try
                    {
                        dictionary[dictionary.Key] = dictionary.Value;
                        //dictionary.Add(dictionary.Key, dictionary.Value);
                    }
                    catch (PositionTakenException ex)
                    {
                        countKollision++;
                        maxIndex = maxIndex*2 + countKollision;
                        Console.WriteLine($"{ex.Message} максимальный индекс увеличен." +
                            $" Доступны индексы для ввода от 0 до {maxIndex}");

                        message = "Значение не добавлено. " +
                            "Попробуйте указать другой индекс.";
                    }
                    finally
                    {
                        Console.WriteLine(message);
                    }
                }
                else if (result == "2")
                {
                    Console.WriteLine("Введите индекс интересующего значения.");

                    dictionary.Key = int.Parse(Console.ReadLine());

                    try
                    {
                        Console.WriteLine($"По индексу {dictionary.Key} найдено значение {dictionary[dictionary.Key]}");
                        //Console.WriteLine($"По индексу {dictionary.Key} найдено значение {dictionary.Get(dictionary.Key)}");
                    }
                    catch (EmptyPositionException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
