using System;
using System.IO;

namespace Lab3oop
{
    public partial class University
    {
        private string name;
        private string address;
        private int facultyCount;
        private int specialityCount;
        private int studentsCount;
        private double rating;

        public University()
        {
            name = "";
            address = "";
            facultyCount = 0;
            specialityCount = 0;
            studentsCount = 0;
            rating = 0;
        }

        public University(string name, string address, int facultyCount, int specialityCount, int studentsCount)
        {
            this.name = name;
            this.address = address;
            this.facultyCount = facultyCount;
            this.specialityCount = specialityCount;
            this.studentsCount = studentsCount;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int FacultyCount
        {
            get { return facultyCount; }
            set { facultyCount = value; }
        }

        public int SpecialityCount
        {
            get { return specialityCount; }
            set { specialityCount = value; }
        }

        public int StudentsCount
        {
            get { return studentsCount; }
            set { studentsCount = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public void Print()
        {
            Console.WriteLine("Університет: " + name);
            Console.WriteLine("Адреса: " + address);
            Console.WriteLine("Кількість факультетів: " + facultyCount);
            Console.WriteLine("Кількість спеціальностей: " + specialityCount);
            Console.WriteLine("Кількість студентів: " + studentsCount);
            Console.WriteLine("Рейтинг університету: " + rating);
        }

        public void SaveToFile()
        {
            StreamWriter sw = new StreamWriter("university.txt");

            sw.WriteLine("Університет: " + name);
            sw.WriteLine("Адреса: " + address);
            sw.WriteLine("Кількість факультетів: " + facultyCount);
            sw.WriteLine("Кількість спеціальностей: " + specialityCount);
            sw.WriteLine("Кількість студентів: " + studentsCount);
            sw.WriteLine("Рейтинг університету: " + rating);

            sw.Close();
        }
    }
}
