using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class Doctor
    {
        private int _id;
        private int _appointmentCount;
        private string? _name;

        [JsonPropertyName("doctor_id")]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        [JsonPropertyName("name")]
        public string? Name
        {
            get => _name;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Имя пациента не может быть пустой строкой.");
                else _name = value;
            }
        }

        [JsonPropertyName("appointment_count")]
        public int AppointmentCount
        {
            get => _appointmentCount;
            set => _appointmentCount = value;
        }

        [JsonIgnore]
        public List<Patient>? Patients { get; set; } = new List<Patient>();

        /// <summary>
        /// Обрабатывает событие обновления пациента (изменение appointmentCount происходит в Patient
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Содержит дату и время обновления</param>
        public void OnPatientUpdated(object sender, EnhancedEventArgs e) { }

        public event EventHandler<EnhancedEventArgs> Updated;


        public Doctor(int id,
                      string? name,
                      int appointmentCount)
        {
            Id = id;
            Name = name;
            AppointmentCount = appointmentCount;
        }

        public override bool Equals(object? obj)
        {
            return obj is Doctor doctor && Id == doctor.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public string ToJSON()
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            JsonSerializerOptions optionsCopy = new(options);
            return JsonSerializer.Serialize(this, optionsCopy);
        }
    }
}
