using System;

namespace Lab_5_OOP
{
    class University : Enterprise
    {
        private double researchIncome;
        private double expertiseIncome;
        private int facultiesCount;

        public double ResearchIncome { get; set; }
        public double ExpertiseIncome { get; set; }
        public int FacultiesCount { get; set; }

        // 1. без параметрів
        public University() : base()
        {
            Activity = "Освіта та наука";
        }

        // 2. з параметрами
        public University(string name, string location, string activity, double rating, int employees,
            double researchIncome, double expertiseIncome, int facultiesCount)
            : base(name, location, activity, rating, employees)
        {
            ResearchIncome = researchIncome;
            ExpertiseIncome = expertiseIncome;
            FacultiesCount = facultiesCount;
        }

        // 3. копіювання
        public University(University other) : base(other)
        {
            ResearchIncome = other.ResearchIncome;
            ExpertiseIncome = other.ExpertiseIncome;
            FacultiesCount = other.FacultiesCount;
        }

        public override double CalculateProfit(double percent, double avgSalary)
        {
            double income = ResearchIncome + ExpertiseIncome;
            return CurrentProfit = (income * percent / 100.0) - (Employees * avgSalary);
        }

        public override double CalculateProfit(double percent, double avgSalary, double extraIncome)
        {
            double income = ResearchIncome + ExpertiseIncome + extraIncome;
            return CurrentProfit = (income * percent / 100.0) - (Employees * avgSalary);
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
            Console.WriteLine("=== Університет ===");
            base.Display();
            Console.WriteLine($"Дохід: {ResearchIncome + ExpertiseIncome}");
            Console.WriteLine($"Факультети: {FacultiesCount}");
        }

        // Бінарні оператори
        public static University operator +(University a, University b)
        {
            var r = new University(a);
            r.Employees += (int)((a.CurrentProfit + b.CurrentProfit) / 100000);
            return r;
        }

        public static University operator -(University a, University b)
        {
            var r = new University(a);
            r.Employees = Math.Max(0, r.Employees - (int)((a.CurrentProfit + b.CurrentProfit) / 100000));
            return r;
        }

        public static bool operator >(University a, University b) => a.CurrentProfit > b.CurrentProfit;
        public static bool operator <(University a, University b) => a.CurrentProfit < b.CurrentProfit;
        public static bool operator ==(University a, University b) => a?.CurrentProfit == b?.CurrentProfit;
        public static bool operator !=(University a, University b) => !(a == b);

        // Унарні
        public static University operator ++(University a)
        {
            a.CurrentProfit *= 1.1;
            return a;
        }

        public static University operator --(University a)
        {
            a.CurrentProfit *= 0.9;
            return a;
        }

        public static University operator -(University a)
        {
            var r = new University(a);
            r.CurrentProfit = -r.CurrentProfit;
            return r;
        }

        public override bool Equals(object obj) => obj is University u && this == u;
        public override int GetHashCode() => CurrentProfit.GetHashCode();
    }
}
