using System.Text.Json;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class AutoSaver
    {
        private DateTime? _lastUpdate;
        private List<Patient> _patients;
        private string _filePath;

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Путь не может быть пустой строкой.");
                else _filePath = value;
            }
        }

        public AutoSaver(List<Patient> patients, string filePath)
        {
            _patients = patients;
            FilePath = filePath;
            foreach (var patient in patients)
            {
                patient.Updated += Patient_Updated;
            }
        }

        private void Patient_Updated(object sender, EnhancedEventArgs e)
        {
            if (_lastUpdate.HasValue && (e.UpdateTime - _lastUpdate.Value).TotalSeconds <= 15)
            {
                SavePatients(FilePath);
            }
            _lastUpdate = e.UpdateTime;
        }

        private void SavePatients(string filePath)
        {
            var json = JsonSerializer.Serialize(_patients, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllTextAsync(filePath, json);
            Console.WriteLine($"{DateTime.Now}:: Пациенты сохранены в файл {filePath} ");
        }
    }
}