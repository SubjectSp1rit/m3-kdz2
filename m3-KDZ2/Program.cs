using static ClassLibrary.InputData;
using static ClassLibrary.Doctor;
using static ClassLibrary.Patient;
using static ClassLibrary.OutputData;
using static ClassLibrary.JsonParser;
using ClassLibrary;
using System.Text.Json;

class Program
{
    public static void Main()
    {
        do
        {
            bool finish = false;
            string? filePath = default;
            int mainMenuIndex = MainMenu();
            switch (mainMenuIndex)
            {
                case 1:
                    /*filePath = GetFilePath();*/
                    filePath = "D:/Other/15V.json";
                    break;
                case 2: 
                    finish = true;
                    break;
            }
            if (finish) break;

            List<Patient> patients = ReadJson(filePath);
            foreach (var item in patients)
            {
                Console.WriteLine($"id: {item.Id}");
                Console.WriteLine($"name: {item.Name}");
                Console.WriteLine($"age: {item.Age}");
                Console.WriteLine($"gender {item.Gender}");
                Console.WriteLine($"diagnosis: {item.Diagnosis}");
                Console.WriteLine($"heart_rate: {item.HeartRate}");
                Console.WriteLine($"temperature: {item.Temperature}");
                Console.WriteLine($"oxygen_saturation: {item.OxygenSaturation}");
                foreach (var elem in item.Doctors)
                {
                    Console.WriteLine();
                    Console.WriteLine($"id: {elem.Id}");
                    Console.WriteLine($"name: {elem.Name}");
                    Console.WriteLine($"appointment_count: {elem.AppointmentCount}");
                }
            }


            /*int filterMenuIndex = FilterMenu();*/


            Console.WriteLine("Для завершения работы нажмите ESC; иначе любую другую клавишу.");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}