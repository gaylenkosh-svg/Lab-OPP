using System;

namespace Lab3oop
{
    static class StartupProject
    {
        // Завдання 1 — генерація масиву та сортування
        public static void Task1()
        {
            int[] arr = new int[10];
            Random rnd = new Random();

            Console.WriteLine("\nМасив:");

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-50, 50);
                Console.Write(arr[i] + " ");
            }

            // сортування
            Array.Sort(arr);

            Console.WriteLine("\nВідсортований масив:");

            foreach (int x in arr)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }

        // Завдання 2 — знайти max серед від'ємних
        public static void Task2()
        {
            int[] arr = { -10, -3, -25, 5, 8, -2 };

            int max = int.MinValue;

            foreach (int x in arr)
            {
                if (x < 0 && x > max)
                {
                    max = x;
                }
            }

            Console.WriteLine("\nМаксимальне серед від'ємних: " + max);
        }

        // Завдання 3 — робота зі строкою
        public static void Task3()
        {
            Console.WriteLine("\nВведіть строку з дужками:");
            string s = Console.ReadLine();

            int balance = 0;
            bool correct = true;

            foreach (char c in s)
            {
                if (c == '(')
                    balance++;

                if (c == ')')
                    balance--;

                if (balance < 0)   // якщо закриваюча дужка зустрічається раніше, ніж відкрита
                { 
                    correct = false;
                    break;
                }
            }

            if (correct && balance == 0)
            {
                Console.WriteLine("Дужки розставлені правильно");
            }
            else
            {
                Console.WriteLine("Помилка у розстановці дужок");
            }
        }
    }
}
