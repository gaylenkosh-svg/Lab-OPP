using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Lab_4_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Гейленко Роман Іп-11 вар 5");

            InsuranceCompany insurance = new InsuranceCompany(
                "ARX", "Київ", "Страхування", 8.7, 120, 500000);

            OilGasCompany oilGas = new OilGasCompany(
                "УкрНафта", "Полтава", "Нафтогазова промисловість", 9.1, 300, 1200000);

            Factory factory = new Factory(
                "Інтерпайп", "Дніпро", "Виробництво", 8.9, 450, 2000000);

            InterfaceCompany interfaceCompany = new InterfaceCompany(
                "ТАС", "Львів", "Страхування", 8.3, 90, 400000);

            AbstractCompany abstractCompany = new AbstractCompany(
                "Кернел", "Одеса", "Промисловість", 9.0, 250, 1500000);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("========== МЕНЮ ==========");
                Console.WriteLine("1 - Успадкування");
                Console.WriteLine("2 - Інтерфейс");
                Console.WriteLine("3 - Абстрактний клас");
                Console.WriteLine("4 - Колекції");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                Console.Write("Введіть % прибутку: ");
                double percent;
                while (!double.TryParse(Console.ReadLine(), out percent))
                {
                    Console.Write("Введіть число нормально: ");
                }

                Console.Write("Введіть середню зарплату: ");
                double salary;
                while (!double.TryParse(Console.ReadLine(), out salary))
                {
                    Console.Write("Введіть число нормально: ");
                }

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowInheritance(insurance, oilGas, factory, percent, salary);
                        break;

                    case "2":
                        ShowInterface(interfaceCompany, percent, salary);
                        break;

                    case "3":
                        ShowAbstract(abstractCompany, percent, salary);
                        break;

                    case "4":
                        ShowCollections(insurance, oilGas, factory, percent, salary);
                        break;

                    default:
                        Console.WriteLine("Неправильний вибір.");
                        break;
                }
            }
        }

        static void ShowInheritance(InsuranceCompany insurance, OilGasCompany oilGas, Factory factory,
                                    double percent, double salary)
        {
            Console.WriteLine("===== УСПАДКУВАННЯ =====");

            Console.WriteLine("\n--- Страхова ---");
            insurance.Display();
            double p1 = insurance.CalculateProfit(percent, salary);
            Console.WriteLine("Прибуток: " + p1);
            SaveToFile("insurance_profit.txt", p1);

            Console.WriteLine("\n--- Нафтогаз ---");
            oilGas.Display();
            double p2 = oilGas.CalculateProfit(percent, salary);
            Console.WriteLine("Прибуток: " + p2);
            SaveToFile("oilgas_profit.txt", p2);

            Console.WriteLine("\n--- Завод ---");
            factory.Display();
            double p3 = factory.CalculateProfit(percent, salary);
            Console.WriteLine("Прибуток: " + p3);
            SaveToFile("factory_profit.txt", p3);
        }

        static void ShowInterface(InterfaceCompany company, double percent, double salary)
        {
            Console.WriteLine("===== ІНТЕРФЕЙС =====");
            company.Display();
            double profit = company.CalculateProfit(percent, salary);
            Console.WriteLine("Прибуток: " + profit);
            SaveToFile("interface_profit.txt", profit);
        }

        static void ShowAbstract(AbstractCompany company, double percent, double salary)
        {
            Console.WriteLine("===== АБСТРАКТНИЙ КЛАС =====");
            company.Display();
            double profit = company.CalculateProfit(percent, salary);
            Console.WriteLine("Прибуток: " + profit);
            SaveToFile("abstract_profit.txt", profit);
        }

        static void ShowCollections(InsuranceCompany insurance, OilGasCompany oilGas, Factory factory,
                                    double percent, double salary)
        {
            Console.WriteLine("===== КОЛЕКЦІЇ =====");

            Enterprise[] enterprises = { insurance, oilGas, factory };

            Console.WriteLine("\n--- Початковий масив ---");
            foreach (Enterprise e in enterprises)
            {
                e.Display();
                ShowProfit(e, percent, salary);
                Console.WriteLine();
            }

            Console.WriteLine("--- Сортування через IComparable (за кількістю працівників) ---");
            List<Enterprise> byComparable = new List<Enterprise>(enterprises);
            byComparable.Sort();
            foreach (Enterprise e in byComparable)
            {
                e.Display();
                ShowProfit(e, percent, salary);
                Console.WriteLine();
            }

            Console.WriteLine("--- Сортування через IComparer (за рейтингом) ---");
            List<Enterprise> byRating = new List<Enterprise>(enterprises);
            byRating.Sort(new EnterpriseByRatingComparer());
            foreach (Enterprise e in byRating)
            {
                e.Display();
                ShowProfit(e, percent, salary);
                Console.WriteLine();
            }

            Console.WriteLine("--- Сортування через IComparer (за працівниками) ---");
            List<Enterprise> byEmployees = new List<Enterprise>(enterprises);
            byEmployees.Sort(new EnterpriseByEmployeesComparer());
            foreach (Enterprise e in byEmployees)
            {
                e.Display();
                ShowProfit(e, percent, salary);
                Console.WriteLine();
            }

            Console.WriteLine("--- IEnumerable ---");
            EnterpriseCollection collection = new EnterpriseCollection();
            collection.Add(insurance);
            collection.Add(oilGas);
            collection.Add(factory);

            foreach (Enterprise e in collection)
            {
                e.Display();
                ShowProfit(e, percent, salary);
                Console.WriteLine();
            }
        }

        static void ShowProfit(Enterprise enterprise, double percent, double salary)
        {
            double profit = 0;

            if (enterprise is InsuranceCompany i)
                profit = i.CalculateProfit(percent, salary);
            else if (enterprise is OilGasCompany o)
                profit = o.CalculateProfit(percent, salary);
            else if (enterprise is Factory f)
                profit = f.CalculateProfit(percent, salary);

            Console.WriteLine("Прибуток: " + profit);
            SaveToFile("collections_profit.txt", profit);
        }

        static void SaveToFile(string fileName, double value)
        {
            File.AppendAllText(fileName, "Розраховане значення: " + value + Environment.NewLine);

            Console.WriteLine("Дані збережено у файл: " + fileName);
        }
    }
}