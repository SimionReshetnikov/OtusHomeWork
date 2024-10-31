using System.Text;

namespace OtusHomeWork12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int maxIndex = 31;
            int countKollision = 0;
            var dictionary = new OtusDictionary();
            var value = new StringBuilder();
            bool сondition = true;

            while (сondition)
            {
                Console.WriteLine("Введите номер нужной команды из списка:\n" +
                    "1. Добавить значение;\n" +
                    "2. Посмотреть значение по индексу;\n" +
                    "Для выхода нажмите любую другую клавишу.");
                
                string result = Console.ReadLine();
                
                switch(result)
                {
                    case "1":

                        
                        Console.WriteLine("Введите нужное значение.");

                        value.Append(Console.ReadLine());

                        Console.WriteLine("Добавляю значения...");

                        string message = $"Значения успешно добавлены в позицию {dictionary.Position}.";

                        try
                        {
                            dictionary[value.ToString()] = value.ToString();
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (PositionTakenException ex)
                        {
                            countKollision++;
                            maxIndex = maxIndex * 2 + countKollision;
                            Console.WriteLine($"{ex.Message} максимальный индекс увеличен." +
                                $" Доступны индексы для ввода от 0 до {maxIndex}");

                            message = "Значение не добавлено. " +
                                "Попробуйте задать другое значение.";
                        }
                        finally
                        {
                            Console.WriteLine(message);
                        }

                        value.Clear();
                        break;

                    case "2":

                        Console.WriteLine("Введите индекс интересующего значения.");

                        int key = int.Parse(Console.ReadLine());

                        try
                        {
                            Console.WriteLine(dictionary[key]);
                        }
                        catch (EmptyPositionException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            value.Clear();
                        }

                        break;

                    default:

                        Console.WriteLine("Выхожу из программы.");
                        сondition = false;

                        break;
                }
                
            }
        }
    }
}
