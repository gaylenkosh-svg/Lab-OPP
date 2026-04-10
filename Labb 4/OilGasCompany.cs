using System;

namespace Lab_4_OOP
{
    class OilGasCompany : Enterprise
    {
        public int Employees { get; set; }
        public double ProductionVolume { get; set; } // Обсяг виробництва 

        public OilGasCompany() : base()  // Конструктор базового класf
        {
            Employees = 0;
            ProductionVolume = 0;
        }

        public OilGasCompany(string name, string location, string activity, double rating,
                             int employees, double productionVolume)
            : base(name, location, activity, rating)  // Конструктор з параметрами, який викликає конструктор базового класу
        {
            Employees = employees;
            ProductionVolume = productionVolume; // Ініціалізація обсягу виробництва
        }

        public double CalculateProfit(double percent, double avgSalary) // Метод для розрахунку прибутку, який враховує відсоток прибутку та середню зарплату
        {
            double salaryFund = Employees * avgSalary;
            double profit = (ProductionVolume * percent / 100.0) - salaryFund;
            return profit;
        }

        public override void Display() //викликає метод з базового класу
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
