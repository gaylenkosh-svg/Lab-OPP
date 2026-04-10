using System;

namespace Lab_4_OOP
{
    class Factory : Enterprise
    {
        public int Employees { get; set; }
        public double ProductionVolume { get; set; }   

        public Factory() : base()
        {
            Employees = 0;
            ProductionVolume = 0;
        }

        public Factory(string name, string location, string activity, double rating,
                       int employees, double productionVolume)
            : base(name, location, activity, rating)
        {
            Employees = employees;
            ProductionVolume = productionVolume;
        }

        public double CalculateProfit(double percent, double avgSalary) // Метод для розрахунку прибутку, який враховує відсоток прибутку та середню зарплату
        {
            double salaryFund = Employees * avgSalary;
            double profit = (ProductionVolume * percent / 100.0) - salaryFund; 
            return profit;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Кількість працівників: " + Employees);
            Console.WriteLine("Обсяг виробництва: " + ProductionVolume);
        }

        public override int GetEmployees() // перевизначаємо метод для отримання кількості працівників
        {
            return Employees;
        }
    }
}