using System;

namespace Lab_4_OOP
{
    class InsuranceCompany : Enterprise  // Похідний клас для страхової компанії
    {
        public int Employees { get; set; } // Кількість працівників
        public double ProductValue { get; set; }    // Вартість страхового продукту

        public InsuranceCompany() : base() //   Конструктор за замовчуванням
        {
            Employees = 0;
            ProductValue = 0;  //вартість продукту
        }

        public InsuranceCompany(string name, string location, string activity, double rating,int employees, double productValue)
            : base(name, location, activity, rating) // Конструктор з параметрами, який викликає конструктор базового класу
        {
            Employees = employees;
            ProductValue = productValue;
        }

        public double CalculateProfit(double percent, double avgSalary)   // Метод для розрахунку прибутку, який враховує відсоток прибутку та середню зарплату
        {
            double salaryFund = Employees * avgSalary;
            double profit = (ProductValue * percent / 100.0) - salaryFund;
            return profit;
        }

        public override void Display() // перевизначаємо метод з базового класу
        {
            base.Display();
            Console.WriteLine("Кількість працівників: " + Employees);
            Console.WriteLine("Вартість продукту: " + ProductValue);
        }

        public override int GetEmployees()  // перевизначаємо метод
        {
            return Employees;
        }
    }
}