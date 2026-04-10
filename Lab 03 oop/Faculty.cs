using System;
using System.IO;

namespace Lab3oop
{
    public class Faculty
    {
        private string facultyName;
        private int departments;
        private int specialities;
        private int students;

        public Faculty()
        {
            facultyName = "";
            departments = 0;
            specialities = 0;
            students = 0;
        }

        public Faculty(string facultyName, int departments, int specialities, int students)
        {
            this.facultyName = facultyName;
            this.departments = departments;
            this.specialities = specialities;
            this.students = students;
        }

        public string FacultyName
        {
            get { return facultyName; }
            set { facultyName = value; }
        }

        public int Departments
        {
            get { return departments; }
            set { departments = value; }
        }

        public int Specialities
        {
            get { return specialities; }
            set { specialities = value; }
        }

        public int Students
        {
            get { return students; }
            set { students = value; }
        }

        public void Print()
        {
            Console.WriteLine("\n--- Факультет ---");
            Console.WriteLine("Назва факультету: " + facultyName);
            Console.WriteLine("Кількість кафедр: " + departments);
            Console.WriteLine("Кількість спеціальностей: " + specialities);
            Console.WriteLine("Кількість студентів: " + students);
        }

        public void SaveToFile()
        {
            StreamWriter sw = new StreamWriter("faculty.txt");

            sw.WriteLine("Факультет: " + facultyName);
            sw.WriteLine("Кількість кафедр: " + departments);
            sw.WriteLine("Кількість спеціальностей: " + specialities);
            sw.WriteLine("Кількість студентів: " + students);

            sw.Close();
        }

        // Вкладений клас
        public class StartupIncubator
        {
            private int[,] startupMatrix = new int[5, 10];

            public void GenerateStartups()
            {
                Random rnd = new Random();

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        startupMatrix[i, j] = rnd.Next(0, 101);
                    }
                }
            }

            public void PrintMatrix()
            {
                Console.WriteLine("\nМатриця оцінок стартапів:");

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(startupMatrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            public void BestStartup()
            {
                int max = startupMatrix[0, 0];

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (startupMatrix[i, j] > max)
                        {
                            max = startupMatrix[i, j];
                        }
                    }
                }

                Console.WriteLine("\nНайкраща оцінка стартапу: " + max);
            }
        }
    }
}
