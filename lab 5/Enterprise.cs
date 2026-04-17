using System;

namespace Lab_5_OOP
{
    class Enterprise
    {
        // Закриті поля базового класу
        private string name;
        private string location;
        private string activity;
        private double rating;

        // protected - доступні в похідних класах
        protected int employees;
        protected double currentProfit;

        // Властивості для доступу до закритих полів
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public int Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public double CurrentProfit
        {
            get { return currentProfit; }
            protected set { currentProfit = value; }
        }

        // 1. Конструктор без параметрів
        public Enterprise()
        {
            Name = "Невідомо";
            Location = "Невідомо";
            Activity = "Невідомо";
            Rating = 0;
            Employees = 0;
            CurrentProfit = 0;
        }

        // 2. Конструктор з параметрами
        public Enterprise(string name, string location, string activity, double rating, int employees)
        {
            Name = name;
            Location = location;
            Activity = activity;
            Rating = rating;
            Employees = employees;
            CurrentProfit = 0;
        }

        // 3. Конструктор копіювання
        public Enterprise(Enterprise other)
        {
            Name = other.Name;
            Location = other.Location;
            Activity = other.Activity;
            Rating = other.Rating;
            Employees = other.Employees;
            CurrentProfit = other.CurrentProfit;
        }

        // Віртуальний метод виведення інформації
        public virtual void Display()
        {
            Console.WriteLine($"Назва: {Name}");
            Console.WriteLine($"Місце: {Location}");
            Console.WriteLine($"Сфера: {Activity}");
            Console.WriteLine($"Рейтинг: {Rating}");
            Console.WriteLine($"Працівники: {Employees}");
            Console.WriteLine($"Поточний прибуток: {CurrentProfit}");
        }

        // Віртуальний метод для розрахунку прибутку
        public virtual double CalculateProfit(double percent, double avgSalary)
        {
            CurrentProfit = -Employees * avgSalary;
            return CurrentProfit;
        }

        // Перевантажений метод прибутку (з додатковим доходом)
        public virtual double CalculateProfit(double percent, double avgSalary, double extraIncome)
        {
            CurrentProfit = extraIncome - Employees * avgSalary;
            return CurrentProfit;
        }

        // Віртуальний метод для визначення кількості працівників
        public virtual int CalculateEmployees(double salaryFund, double avgYearSalary)
        {
            if (avgYearSalary <= 0)
                return 0;

            Employees = (int)(salaryFund / avgYearSalary);
            return Employees;
        }

        // Перевантажений метод для визначення кількості працівників
        public virtual int CalculateEmployees(double salaryFund, double avgYearSalary, int extraEmployees)
        {
            if (avgYearSalary <= 0)
                return 0;

            Employees = (int)(salaryFund / avgYearSalary) + extraEmployees;
            return Employees;
        }

        // Метод для запису об'єкта у вигляді рядка
        public override string ToString()
        {
            return $"Назва: {Name}, Місце: {Location}, Сфера: {Activity}, Рейтинг: {Rating}, Працівники: {Employees}, Прибуток: {CurrentProfit}";
        }
    }
}