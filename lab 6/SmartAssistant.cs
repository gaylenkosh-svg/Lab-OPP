using System;

namespace Lab_6_OOP
{
    class SmartAssistant : SmartGlasses
    {
        private string assistantName;
        private bool isActive;

        public string AssistantName
        {
            get { return assistantName; }
            set { assistantName = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public SmartAssistant()
        {
            AssistantName = "Smart Voice";
            IsActive = true;
        }

        public SmartAssistant(string assistantName)
        {
            AssistantName = assistantName;
            IsActive = true;
        }

        public void VoiceCommand(string command)
        {
            if (!IsActive)
            {
                Console.WriteLine("Голосовий помічник вимкнений.");
                return;
            }

            Console.WriteLine("Команда: " + command);

            if (command == "повідомлення")
            {
                ShowMessage("Нове повідомлення зі смартфона");
            }
            else if (command == "людина")
            {
                RecognizePerson();
            }
            else if (command == "ar")
            {
                UseAR();
            }
            else if (command == "зарядити")
            {
                ChargeBattery();
            }
            else
            {
                Console.WriteLine("Команда не розпізнана.");
            }
        }

        public void TurnAssistantOff()
        {
            IsActive = false;
            Console.WriteLine("Голосовий помічник вимкнений.");
        }

        public void TurnAssistantOn()
        {
            IsActive = true;
            Console.WriteLine("Голосовий помічник увімкнений.");
        }
    }
}
