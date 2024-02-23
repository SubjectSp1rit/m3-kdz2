using System.Text.Json;

namespace ClassLibrary
{
    public class JsonParser
    {
        /// <summary>
        /// Парсит JSON-файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Список объектов Patient без повторно созданных Doctor</returns>
        public static List<Patient> ReadJson(string filePath)
        {
            // TODO: добавить проверку на существование файла
            // TODO: проверка на Null
            // TODO: Некорректный формат JSON
            string jsonString = File.ReadAllText(filePath);

            // Настройка десериализации для корректной работы
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var patients = JsonSerializer.Deserialize<List<Patient>>(jsonString);

            // Словаь для отслеживания уникальных докторов по их ID
            var uniqueDoctors = new Dictionary<int, Doctor>();

            foreach (var patient in patients)
            {
                // Временный список для хранения докторов текущего пациента
                var patientDoctors = new List<Doctor>();
                foreach (var doctor in patient.Doctors)
                {
                    // Проверяем, существует ли доктор с таким ID в словаре сущ. докторов
                    if (!uniqueDoctors.ContainsKey(doctor.Id))
                    {
                        // Если нет, добавляем его в словарь и в список докторов пациента
                        uniqueDoctors.Add(doctor.Id, doctor);
                        patientDoctors.Add(doctor);
                    }
                    else
                    {
                        // Если существует, то добавляем в список докторов пациента
                        patientDoctors.Add(uniqueDoctors[doctor.Id]);
                    }
                }
                // Добавляем докторов в список докторов пациента
                patient.Doctors = patientDoctors;
            }

            return patients;
        }

        public static void WriteJson() { }
    }
}
