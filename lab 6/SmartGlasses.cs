using System;

namespace Lab_6_OOP
{
    class SmartGlasses
    {
        private Camera camera;
        private Display display;
        private Battery battery;
        private Sensor sensor;

        private Person[] people;

        // Делегат і події
        public delegate void GlassesHandler(string message);
        public event GlassesHandler LowBattery;
        public event GlassesHandler PersonDetected;

        public SmartGlasses()
        {
            camera = new Camera();
            display = new Display();
            battery = new Battery();
            sensor = new Sensor();

            people = new Person[3];
            people[0] = new Person("Іван", 25, "Нормальний");
            people[1] = new Person("Олег", 40, "Підозрілий");
            people[2] = new Person("Анна", 30, "Нормальний");
        }

        public void TurnOn()
        {
            Console.WriteLine("Окуляри увімкнені");
        }

        public void ShowMessage(string text)
        {
            try
            {
                if (battery.Level <= 0)
                    throw new SmartGlassesException("Батарея розряджена!");

                display.Show(text);
                battery.Use(5);

                CheckBattery();
            }
            catch (SmartGlassesException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        public void RecognizePerson()
        {
            try
            {
                if (battery.Level <= 0)
                    throw new SmartGlassesException("Немає заряду для розпізнавання!");

                camera.Capture();
                sensor.Detect();

                Random rnd = new Random();
                int index = rnd.Next(people.Length);

                Console.WriteLine("Розпізнано:");
                people[index].Recognize();
                people[index].AnalyzeCondition();

                PersonDetected?.Invoke("Особа знайдена!");

                battery.Use(10);
                CheckBattery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        public void UseAR()
        {
            try
            {
                if (battery.Level <= 10)
                    throw new SmartGlassesException("Недостатньо заряду для AR!");

                display.Show("Доповнена реальність активна");
                battery.Use(15);

                CheckBattery();
            }
            catch (SmartGlassesException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        public void CheckBattery()
        {
            if (battery.Level <= 20)
            {
                LowBattery?.Invoke("УВАГА! Низький заряд батареї!");
            }
        }

        public void ChargeBattery()
        {
            battery.Charge();
        }

        public void ShowAllPeople()
        {
            Console.WriteLine("\nСписок людей:");

            for (int i = 0; i < people.Length; i++)
            {
                people[i].ShowInfo();
                Console.WriteLine();
            }
        }
    }
}
