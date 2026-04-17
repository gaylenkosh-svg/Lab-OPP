using System;

namespace Lab_5_OOP
{
    class Factory : Enterprise
    {
        public double ProductionVolume { get; set; }

        // 1. без параметрів
        public Factory() : base()
        {
            Activity = "Виробництво";
        }

        // 2. з параметрами
        public Factory(string name, string location, string activity, double rating, int employees, double productionVolume)
            : base(name, location, activity, rating, employees)
        {
            ProductionVolume = productionVolume;
        }

        // 3. копіювання
        public Factory(Factory other) : base(other)
        {
            ProductionVolume = other.ProductionVolume;
        }

        public override double CalculateProfit(double percent, double avgSalary)
        {
            return CurrentProfit = (ProductionVolume * percent / 100.0) - (Employees * avgSalary);
        }

        public override double CalculateProfit(double percent, double avgSalary, double extraIncome)
        {
            return CurrentProfit = (ProductionVolume * percent / 100.0) + extraIncome - (Employees * avgSalary);
        }

        public override int CalculateEmployees(double fund, double salary)
        {
            return salary <= 0 ? 0 : Employees = (int)(fund / salary);
        }

        public override int CalculateEmployees(double fund, double salary, int extra)
        {
            return salary <= 0 ? 0 : Employees = (int)(fund / salary) + extra;
        }

        public override void Display()
        {
            Console.WriteLine("=== Завод ===");
            base.Display();
            Console.WriteLine($"Обсяг виробництва: {ProductionVolume}");
        }

        // Бінарні оператори
        public static Factory operator +(Factory a, Factory b)
        {
            var r = new Factory(a);
            r.Employees += (int)((a.CurrentProfit + b.CurrentProfit) / 100000);
            return r;
        }

        public static Factory operator -(Factory a, Factory b)
        {
            var r = new Factory(a);
            r.Employees = Math.Max(0, r.Employees - (int)((a.CurrentProfit + b.CurrentProfit) / 100000));
            return r;
        }

        public static bool operator >(Factory a, Factory b) => a.CurrentProfit > b.CurrentProfit;
        public static bool operator <(Factory a, Factory b) => a.CurrentProfit < b.CurrentProfit;
        public static bool operator ==(Factory a, Factory b) => a?.CurrentProfit == b?.CurrentProfit;
        public static bool operator !=(Factory a, Factory b) => !(a == b);

        // Унарні оператори
        public static Factory operator ++(Factory a)
        {
            a.CurrentProfit *= 1.1;
            return a;
        }

        public static Factory operator --(Factory a)
        {
            a.CurrentProfit *= 0.9;
            return a;
        }

        public static Factory operator -(Factory a)
        {
            var r = new Factory(a);
            r.CurrentProfit = -r.CurrentProfit;
            return r;
        }

        public override bool Equals(object obj) => obj is Factory f && this == f;
        public override int GetHashCode() => CurrentProfit.GetHashCode();
        public override string ToString() => base.ToString() + $", Обсяг виробництва: {ProductionVolume}";
    }
}