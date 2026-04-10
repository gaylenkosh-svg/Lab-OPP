using System;

namespace Lab_4_OOP
{
    interface IEnterprise
    {
        string Name { get; set; }
        string Location { get; set; }
        string Activity { get; set; }
        double Rating { get; set; }

        void Display();
        double CalculateProfit(double percent, double avgSalary);
    }

    abstract class AbstractEnterprise
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Activity { get; set; }
        public double Rating { get; set; }
        public int Employees { get; set; }

        public AbstractEnterprise(string name, string location, string activity, double rating, int employees)
        {
            Name = name;
            Location = location;
            Activity = activity;
            Rating = rating;
            Employees = employees;
        }

        public virtual void Display()
        {
            Console.WriteLine("Назва: " + Name);
            Console.WriteLine("Місце: " + Location);
            Console.WriteLine("Сфера: " + Activity);
            Console.WriteLine("Рейтинг: " + Rating);
            Console.WriteLine("Працівники: " + Employees);
        }

        public abstract double CalculateProfit(double percent, double avgSalary);
    }

    class InterfaceCompany : IEnterprise
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Activity { get; set; }
        public double Rating { get; set; }

        public int Employees { get; set; }
        public double Value { get; set; }

        public InterfaceCompany(string name, string location, string activity, double rating,
                                int employees, double value)
        {
            Name = name;
            Location = location;
            Activity = activity;
            Rating = rating;
            Employees = employees;
            Value = value;
        }

        public void Display()
        {
            Console.WriteLine("Назва: " + Name);
            Console.WriteLine("Місце: " + Location);
            Console.WriteLine("Сфера: " + Activity);
            Console.WriteLine("Рейтинг: " + Rating);
            Console.WriteLine("Працівники: " + Employees);
            Console.WriteLine("Обсяг/вартість: " + Value);
        }

        public double CalculateProfit(double percent, double avgSalary)
        {
            double salaryFund = Employees * avgSalary;
            return (Value * percent / 100) - salaryFund;
        }
    }

    class AbstractCompany : AbstractEnterprise
    {
        public double Value { get; set; }

        public AbstractCompany(string name, string location, string activity, double rating,
                               int employees, double value)
            : base(name, location, activity, rating, employees)
        {
            Value = value;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Обсяг/вартість: " + Value);
        }

        public override double CalculateProfit(double percent, double avgSalary)
        {
            double salaryFund = Employees * avgSalary;
            return (Value * percent / 100) - salaryFund;
        }
    }
}
