
using System;
using System.Diagnostics;

namespace Lab_5_OOP
{
    class InsuranceCompany : Enterprise
    {
        // Специфічне поле (тільки для страхової)
        private double productValue;

        public double ProductValue
        {
            get { return productValue; }
            set { productValue = value; }
        }

        // 1. Конструктор без параметрів
        public InsuranceCompany() : base()
        {
            ProductValue = 0;
            Activity = "Страхування";
        }

        // 2. Конструктор з параметрами
        public InsuranceCompany(string name, string location, string activity, double rating, int employees, double productValue)
            : base(name, location, activity, rating, employees)
        {
            ProductValue = productValue;
        }

        // 3. Конструктор копіювання
        public InsuranceCompany(InsuranceCompany other) : base(other)
        {
            ProductValue = other.ProductValue;
        }

        // Перевизначення методу прибутку
        public override double CalculateProfit(double percent, double avgSalary)
        {
            CurrentProfit = (ProductValue * percent / 100.0) - (Employees * avgSalary);
            return CurrentProfit;
        }

        // Перевантажений метод прибутку
        public override double CalculateProfit(double percent, double avgSalary, double extraIncome)
        {
            CurrentProfit = (ProductValue * percent / 100.0) + extraIncome - (Employees * avgSalary);
            return CurrentProfit;
        }

        // Перевизначення методу для працівників
        public override int CalculateEmployees(double salaryFund, double avgYearSalary)
        {
            if (avgYearSalary <= 0)
                return 0;

            Employees = (int)(salaryFund / avgYearSalary);
            return Employees;
        }

        // Перевантажений метод для працівників
        public override int CalculateEmployees(double salaryFund, double avgYearSalary, int extraEmployees)
        {
            if (avgYearSalary <= 0)
                return 0;

            Employees = (int)(salaryFund / avgYearSalary) + extraEmployees;
            return Employees;
        }

        // Вивід інформації
        public override void Display()
        {
            Console.WriteLine("===== Страхова компанія =====");
            base.Display();
            Console.WriteLine($"Вартість продукту: {ProductValue}");
        }

        // ===== БІНАРНІ ОПЕРАТОРИ =====

        public static InsuranceCompany operator +(InsuranceCompany a, InsuranceCompany b)
        {
            InsuranceCompany result = new InsuranceCompany(a);
            result.Employees += (int)((a.CurrentProfit + b.CurrentProfit) / 100000.0);
            return result;
        }

        public static InsuranceCompany operator -(InsuranceCompany a, InsuranceCompany b)
        {
            InsuranceCompany result = new InsuranceCompany(a);
            result.Employees -= (int)((a.CurrentProfit + b.CurrentProfit) / 100000.0);

            if (result.Employees < 0)
                result.Employees = 0;

            return result;
        }

        public static bool operator >(InsuranceCompany a, InsuranceCompany b)
        {
            return a.CurrentProfit > b.CurrentProfit;
        }

        public static bool operator <(InsuranceCompany a, InsuranceCompany b)
        {
            return a.CurrentProfit < b.CurrentProfit;
        }

        public static bool operator ==(InsuranceCompany a, InsuranceCompany b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.CurrentProfit == b.CurrentProfit;
        }

        public static bool operator !=(InsuranceCompany a, InsuranceCompany b)
        {
            return !(a == b);
        }

        // ===== УНАРНІ ОПЕРАТОРИ =====

        public static InsuranceCompany operator ++(InsuranceCompany a)
        {
            a.CurrentProfit += a.CurrentProfit * 0.1;
            return a;
        }

        public static InsuranceCompany operator --(InsuranceCompany a)
        {
            a.CurrentProfit -= a.CurrentProfit * 0.1;
            return a;
        }

        public static InsuranceCompany operator -(InsuranceCompany a)
        {
            InsuranceCompany result = new InsuranceCompany(a);
            result.CurrentProfit = -result.CurrentProfit;
            return result;
        }

        // Обов'язково для == операторів
        public override bool Equals(object obj)
        {
            if (obj is InsuranceCompany other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return CurrentProfit.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + $", Вартість продукту: {ProductValue}";
        }
    }
}