using System;

namespace Lab_6_OOP
{
    // Камера
    class Camera
    {
        private bool isWorking;

        public bool IsWorking
        {
            get { return isWorking; }
            set { isWorking = value; }
        }

        public Camera()
        {
            IsWorking = true;
        }

        public void Capture()
        {
            if (!IsWorking)
                Console.WriteLine("Камера не працює!");
            else
                Console.WriteLine("Камера: захоплення зображення...");
        }
    }

    // Дисплей
    class Display
    {
        private int brightness;

        public int Brightness
        {
            get { return brightness; }
            set
            {
                if (value < 0) brightness = 0;
                else if (value > 100) brightness = 100;
                else brightness = value;
            }
        }

        public Display()
        {
            Brightness = 50;
        }

        public void Show(string text)
        {
            Console.WriteLine($"Дисплей (яскравість {Brightness}%): {text}");
        }
    }

    // Батарея
    class Battery
    {
        private int level;

        public int Level
        {
            get { return level; }
            set
            {
                if (value < 0) level = 0;
                else if (value > 100) level = 100;
                else level = value;
            }
        }

        public Battery()
        {
            Level = 100;
        }

        public void Use(int amount)
        {
            Level -= amount;
            if (Level < 0) Level = 0;

            Console.WriteLine("Рівень батареї: " + Level + "%");
        }

        public void Charge()
        {
            Level = 100;
            Console.WriteLine("Батарея заряджена до 100%");
        }
    }

    // Сенсор
    class Sensor
    {
        public void Detect()
        {
            Console.WriteLine("Сенсор: визначення положення об'єктів...");
        }
    }
}
