using System;

namespace Lab_6_OOP
{
    class Person
    {
        private string name;
        private int age;
        private string status;
        private bool isRecognized;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    age = 0;
                else
                    age = value;
            }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public bool IsRecognized
        {
            get { return isRecognized; }
            set { isRecognized = value; }
        }

        public Person()
        {
            Name = "Невідомо";
            Age = 0;
            Status = "Нормальний";
            IsRecognized = false;
        }

        public Person(string name, int age, string status)
        {
            Name = name;
            Age = age;
            Status = status;
            IsRecognized = false;
        }

        public void Recognize()
        {
            IsRecognized = true;
            Console.WriteLine("Людину розпізнано: " + Name);
        }

        public void AnalyzeCondition()
        {
            if (Status == "Підозрілий")
                Console.WriteLine("Увага! Людина має підозрілий статус.");
            else
                Console.WriteLine("Стан людини нормальний.");
        }

        public void ShowInfo()
        {
            Console.WriteLine("Ім'я: " + Name);
            Console.WriteLine("Вік: " + Age);
            Console.WriteLine("Стан: " + Status);
            Console.WriteLine("Розпізнано: " + IsRecognized);
        }
    }
}
