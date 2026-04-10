using System;

namespace Lab3oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // 1) Створюємо університет (ввід з консолі)
            Console.WriteLine("Лабораторна робота 3 Гейленко Роман ІПЗ-11");
            Console.WriteLine("=== Ввід даних університету ===");

            Console.Write("Назва університету: ");
            string uniName = Console.ReadLine();

            Console.Write("Адреса університету: ");
            string uniAddress = Console.ReadLine();

            Console.Write("Кількість факультетів: ");
            int facCount = int.Parse(Console.ReadLine());

            Console.Write("Кількість спеціальностей: ");
            int specCount = int.Parse(Console.ReadLine());

            Console.Write("Загальна кількість студентів: ");
            int studCount = int.Parse(Console.ReadLine());

            University uni = new University(uniName, uniAddress, facCount, specCount, studCount);

            // 2) Створюємо факультет (ввід з консолі)
            Console.WriteLine("\n=== Ввід даних факультету ===");

            Console.Write("Назва факультету: ");
            string facName = Console.ReadLine();

            Console.Write("Кількість кафедр: ");
            int dep = int.Parse(Console.ReadLine());

            Console.Write("Кількість спеціальностей факультету: ");
            int facSpecs = int.Parse(Console.ReadLine());

            Console.Write("Кількість студентів факультету: ");
            int facStud = int.Parse(Console.ReadLine());

            Faculty fac = new Faculty(facName, dep, facSpecs, facStud);

            // 3) Виводимо дані
            Console.WriteLine("\n=== Дані (вивід) ===");
            uni.Print();
            fac.Print();

            // 4) Рейтинг університету (Random) + фінансування (Random)
            uni.CalculateRating();
            int funding = uni.CalculateYearFunding();

            // 5) Запис у файли
            uni.SaveToFile();
            uni.SaveFinanceToFile(funding);
            fac.SaveToFile();

            Console.WriteLine("\nФайли збережено: university.txt, university_finance.txt, faculty.txt");

            // 6) Вкладений клас StartupIncubator
            Console.WriteLine("\n=== StartupIncubator (вкладений клас) ===");
            Faculty.StartupIncubator incubator = new Faculty.StartupIncubator();
            incubator.GenerateStartups();
            incubator.PrintMatrix();
            incubator.BestStartup();

            // 7) Static class StartupProject (3 задачі з ЛР2)
            Console.WriteLine("\n=== StartupProject (static class) ===");
            StartupProject.Task1();
            StartupProject.Task2();
            StartupProject.Task3();

            Console.WriteLine("\nГотово. Натисни Enter щоб вийти...");
            Console.ReadLine();
        }
    }
}