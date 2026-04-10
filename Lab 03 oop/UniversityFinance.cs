using System;
using System.IO;

namespace Lab3oop
{
    public partial class University
    {
        // 6) Розрахунок рейтингу університету за версією Osvita.ua
    
        public void CalculateRating()
        {
            Random rnd = new Random();

            int scopus = rnd.Next(0, 201);
            int top200 = rnd.Next(0, 201);
            int znoContract = rnd.Next(0, 201);

            int total = scopus + top200 + znoContract;
            rating = total; // записуємо у поле класу

            Console.WriteLine("\n--- Розрахунок рейтингу (Osvita.ua) ---");
            Console.WriteLine($"SCOPUS = {scopus}");
            Console.WriteLine($"ТОП200 Україна = {top200}");
            Console.WriteLine($"ЗНО на контракт = {znoContract}");
            Console.WriteLine($"Загальний бал = {total}");
        }
        public int CalculateYearFunding()
        {
            Random rnd = new Random();
            int costPerStudent = rnd.Next(2000, 6001);
            int funding = studentsCount * costPerStudent;

            Console.WriteLine("\n--- Річне фінансування ---");
            Console.WriteLine($"К-сть студентів = {studentsCount}");
            Console.WriteLine($"Вартість 1 студента/рік = {costPerStudent}$");
            Console.WriteLine($"Річне фінансування = {funding}$");

            return funding;
        }

        // Додатково: збережемо в файл і рейтинг, і фінансування
        public void SaveFinanceToFile(int funding)
        {
            StreamWriter sw = new StreamWriter("university_finance.txt");
            sw.WriteLine("=== Фінансова інформація університету ===");
            sw.WriteLine("Університет: " + name);
            sw.WriteLine("Рейтинг (загальний бал): " + rating);
            sw.WriteLine("К-сть студентів: " + studentsCount);
            sw.WriteLine("Річне фінансування: " + funding + "$");
            sw.Close();
        }
    }
}