using System;
using System.Text;

namespace Lab_5_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            InsuranceCompany insurance1 = new InsuranceCompany(
                "ARX", "Київ", "Страхування", 8.7, 120, 500000);

            InsuranceCompany insurance2 = new InsuranceCompany(
                "ТАС", "Львів", "Страхування", 8.3, 90, 400000);

            OilGasCompany oilGas = new OilGasCompany(
                "УкрНафта", "Полтава", "Нафтогазова промисловість", 9.1, 300, 1200000);

            Factory factory = new Factory(
                "Інтерпайп", "Дніпро", "Виробництво", 8.9, 450, 2000000);

            University university = new University(
                "КНУ", "Київ", "Освіта та наука", 9.5, 700, 900000, 500000, 12);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("========== МЕНЮ ==========");
                Console.WriteLine("1 - Показати всі підприємства");
                Console.WriteLine("2 - Розрахувати прибуток");
                Console.WriteLine("3 - Розрахувати кількість працівників");
                Console.WriteLine("4 - Бінарні оператори");
                Console.WriteLine("5 - Унарні оператори");
                Console.WriteLine("6 - Індексатор");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                    break;

                switch (choice)
                {
                    case "1":
                        ShowAll(insurance1, insurance2, oilGas, factory, university);
                        break;

                    case "2":
                        CalculateProfits(insurance1, insurance2, oilGas, factory, university);
                        break;

                    case "3":
                        CalculateWorkers(insurance1, oilGas, factory, university);
                        break;

                    case "4":
                        ShowBinaryOperators(insurance1, insurance2);
                        break;

                    case "5":
                        ShowUnaryOperators(insurance1);
                        break;

                    case "6":
                        ShowIndexer(insurance1, oilGas, factory, university);
                        break;

                    default:
                        Console.WriteLine("Неправильний вибір.");
                        break;
                }
            }
        }

        static void ShowAll(InsuranceCompany insurance1, InsuranceCompany insurance2,
                            OilGasCompany oilGas, Factory factory, University university)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double avgSalary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n===== ВСІ ОБ’ЄКТИ =====\n");

            insurance1.CalculateProfit(percent, avgSalary);
            insurance1.Display();
            Console.WriteLine();

            insurance2.CalculateProfit(percent, avgSalary);
            insurance2.Display();
            Console.WriteLine();

            oilGas.CalculateProfit(percent, avgSalary);
            oilGas.Display();
            Console.WriteLine();

            factory.CalculateProfit(percent, avgSalary);
            factory.Display();
            Console.WriteLine();

            university.CalculateProfit(percent, avgSalary);
            university.Display();
            Console.WriteLine();
        }

        static void CalculateProfits(InsuranceCompany insurance1, InsuranceCompany insurance2,
                                     OilGasCompany oilGas, Factory factory, University university)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double avgSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть додатковий дохід: ");
            double extraIncome = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n===== ПРИБУТОК =====\n");

            Console.WriteLine("Страхова 1: " + insurance1.CalculateProfit(percent, avgSalary));
            Console.WriteLine("Страхова 2: " + insurance2.CalculateProfit(percent, avgSalary, extraIncome));
            Console.WriteLine("Нафтогазова: " + oilGas.CalculateProfit(percent, avgSalary));
            Console.WriteLine("Завод: " + factory.CalculateProfit(percent, avgSalary, extraIncome));
            Console.WriteLine("Університет: " + university.CalculateProfit(percent, avgSalary, extraIncome));
        }

        static void CalculateWorkers(InsuranceCompany insurance1, OilGasCompany oilGas,
                                     Factory factory, University university)
        {
            Console.Write("Введіть фонд заробітної плати: ");
            double salaryFund = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню річну зарплату: ");
            double avgYearSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть додаткову кількість працівників: ");
            int extraEmployees = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n===== КІЛЬКІСТЬ ПРАЦІВНИКІВ =====\n");

            Console.WriteLine("Страхова: " + insurance1.CalculateEmployees(salaryFund, avgYearSalary));
            Console.WriteLine("Нафтогазова: " + oilGas.CalculateEmployees(salaryFund, avgYearSalary, extraEmployees));
            Console.WriteLine("Завод: " + factory.CalculateEmployees(salaryFund, avgYearSalary));
            Console.WriteLine("Університет: " + university.CalculateEmployees(salaryFund, avgYearSalary, extraEmployees));
        }

        static void ShowBinaryOperators(InsuranceCompany insurance1, InsuranceCompany insurance2)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double avgSalary = Convert.ToDouble(Console.ReadLine());

            insurance1.CalculateProfit(percent, avgSalary);
            insurance2.CalculateProfit(percent, avgSalary);

            Console.WriteLine("\n===== БІНАРНІ ОПЕРАТОРИ =====\n");

            InsuranceCompany resultPlus = insurance1 + insurance2;
            Console.WriteLine("Результат insurance1 + insurance2:");
            resultPlus.Display();

            Console.WriteLine();
            Console.WriteLine("insurance1 > insurance2 : " + (insurance1 > insurance2));
            Console.WriteLine("insurance1 < insurance2 : " + (insurance1 < insurance2));
            Console.WriteLine("insurance1 == insurance2 : " + (insurance1 == insurance2));
            Console.WriteLine("insurance1 != insurance2 : " + (insurance1 != insurance2));
        }

        static void ShowUnaryOperators(InsuranceCompany insurance1)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double avgSalary = Convert.ToDouble(Console.ReadLine());

            insurance1.CalculateProfit(percent, avgSalary);

            Console.WriteLine("\n===== УНАРНІ ОПЕРАТОРИ =====\n");

            Console.WriteLine("Початковий об’єкт:");
            insurance1.Display();

            ++insurance1;
            Console.WriteLine("\nПісля ++");
            insurance1.Display();

            --insurance1;
            Console.WriteLine("\nПісля --");
            insurance1.Display();

            InsuranceCompany negativeProfit = -insurance1;
            Console.WriteLine("\nПісля зміни знаку прибутку:");
            negativeProfit.Display();
        }

        static void ShowIndexer(InsuranceCompany insurance1, OilGasCompany oilGas,
                                Factory factory, University university)
        {
            Console.Write("Введіть % прибутку: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть середню зарплату: ");
            double avgSalary = Convert.ToDouble(Console.ReadLine());

            insurance1.CalculateProfit(percent, avgSalary);
            oilGas.CalculateProfit(percent, avgSalary);
            factory.CalculateProfit(percent, avgSalary);
            university.CalculateProfit(percent, avgSalary);

            Console.WriteLine("\n===== ІНДЕКСАТОР =====\n");

            EnterpriseArray arr = new EnterpriseArray(4);

            arr[0] = insurance1;
            arr[1] = oilGas;
            arr[2] = factory;
            arr[3] = university;

            arr.DisplayAll();

            Console.WriteLine("\nЕлемент за індексом 2:");
            arr[2].Display();
        }
    }
}