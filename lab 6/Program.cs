using System;
using System.Text;

namespace Lab_6_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Гейленко Роман ІП-11 вар 5");
            SmartAssistant glasses = new SmartAssistant("Окуляри-помічник");

            glasses.LowBattery += ShowEvent;
            glasses.PersonDetected += ShowEvent;

            while (true)
            {
                Console.WriteLine("\n========== МЕНЮ ==========");
                Console.WriteLine("1 - Увімкнути окуляри");
                Console.WriteLine("2 - Показати повідомлення");
                Console.WriteLine("3 - Розпізнати людину");
                Console.WriteLine("4 - Увімкнути доповнену реальність");
                Console.WriteLine("5 - Показати список людей");
                Console.WriteLine("6 - Голосова команда");
                Console.WriteLine("7 - Зарядити батарею");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            glasses.TurnOn();
                            break;

                        case "2":
                            Console.Write("Введіть повідомлення: ");
                            string message = Console.ReadLine();
                            glasses.ShowMessage(message);
                            break;

                        case "3":
                            glasses.RecognizePerson();
                            break;

                        case "4":
                            glasses.UseAR();
                            break;

                        case "5":
                            glasses.ShowAllPeople();
                            break;

                        case "6":
                            Console.WriteLine("Команди: повідомлення, людина, ar, зарядити");
                            Console.Write("Введіть команду: ");
                            string command = Console.ReadLine();
                            glasses.VoiceCommand(command);
                            break;

                        case "7":
                            glasses.ChargeBattery();
                            break;

                        case "0":
                            return;

                        default:
                            throw new SmartGlassesException("Неправильний пункт меню!");
                    }
                }
                catch (SmartGlassesException ex)
                {
                    Console.WriteLine("Помилка програми: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Невідома помилка: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Операцію завершено.");
                }
            }
        }

        static void ShowEvent(string message)
        {
            Console.WriteLine("ПОДІЯ: " + message);
        }
    }
}