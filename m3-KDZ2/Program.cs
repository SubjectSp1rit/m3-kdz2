using static ClassLibrary.InputData;
using static ClassLibrary.Doctor;
using static ClassLibrary.Patient;
using ClassLibrary;

class Program
{
    public static void Main()
    {
        do
        {
            /*string? filePath = GetFilePath();*/
            string? filePath = "D:/Other/15V.json";

            Doctor doctor1 = new Doctor(4, "Adrian Leon", 0);
            Doctor doctor2 = new Doctor(4, "Adrian Leon", 0);
            Doctor doctor3 = new Doctor(4, "Adrian Leon", 0);
            List<Doctor> doctorsArray = new List<Doctor> { doctor1, doctor2, doctor3 };
            Patient patient = new Patient(1, "Stephanie Powell", 38, "Other", "Current", 78, 37.9, 96, doctorsArray);
            patient.Updated += doctor1.OnPatientUpdated;
            Console.WriteLine(patient.ToJSON());
            var patients = new List<Patient> { patient };

            var autoSaver = new AutoSaver(patients, filePath.Insert(filePath.LastIndexOf(".json"), "_tmp"));
            Console.WriteLine(doctor1.AppointmentCount);
            patient.Temperature = 0;
            Console.WriteLine(doctor1.AppointmentCount);
            patient.Temperature = 200;
            Console.WriteLine(doctor1.AppointmentCount);

            Console.WriteLine("Для завершения работы нажмите ESC; иначе любую другую клавишу.");
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}