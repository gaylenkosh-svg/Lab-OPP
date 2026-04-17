using System;

namespace Lab_5_OOP
{
    class EnterpriseArray
    {
        private Enterprise[] data;

        public EnterpriseArray(int size)
        {
            data = new Enterprise[size];
        }

        // Індексатор
        public Enterprise this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        public void DisplayAll()
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"\n--- {i} ---");
                data[i]?.Display();
            }
        }
    }
}
