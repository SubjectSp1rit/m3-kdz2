using System.Text;

namespace ClassLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int HeartRate { get; set; }
        public double Temperature { get; set; }
        public int OxygenSaturaion { get; set; }

        private string? _name;
        private string? _gender;
        private string? _diagnosis;

        public List<Doctor>? Doctors { get; set; }

        public string? Name
        {
            get => _name;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Имя пациента не может быть пустой строкой.");
                else _name = value;
            }
        }

        public string? Gender
        {
            get => _gender;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Пол пациента не может быть пустой строкой.");
                else _gender = value;
            }
        }

        public string? Diagnosis
        {
            get => _diagnosis;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Диагноз пациента не может быть пустой строкой.");
                else _diagnosis = value;
            }
        }

        public Patient()
        {
            throw new NotImplementedException("Пустой конструктор не предусмотрен классом Patient.");
        }

        public Patient(int id, 
                       string? name, 
                       int age, 
                       string? gender, 
                       string? diagnosis, 
                       int heartRate, 
                       double temperature, 
                       int oxygenSaturation,
                       List<Doctor> doctors)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Diagnosis = diagnosis;
            HeartRate = heartRate;
            Temperature = temperature;
            OxygenSaturaion = oxygenSaturation;
            Doctors = doctors;
        }

        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");
            sb.AppendLine("  {");
            sb.AppendLine($"    \"patient_id\": {Id},");
            sb.AppendLine($"    \"name\": \"{Name}\",");
            sb.AppendLine($"    \"age\": {Age},");
            sb.AppendLine($"    \"gender\": \"{Gender}\",");
            sb.AppendLine($"    \"diagnosis\": \"{Diagnosis}\",");
            sb.AppendLine($"    \"heart_rate\": {HeartRate},");
            sb.AppendLine($"    \"temperature\": {Temperature},");
            sb.AppendLine($"    \"oxygen_saturation\": {OxygenSaturaion},");
            sb.AppendLine($"    \"doctors\": [");
            for (int i = 0; i < Doctors?.Count; i++)
            {
                sb.AppendLine("      {");
                sb.AppendLine($"        \"doctor_id\": {Doctors[i].Id}");
                sb.AppendLine($"        \"name\": \"{Doctors[i].Name}\"");
                sb.AppendLine($"        \"appointment_count\": {Doctors[i].AppointmentCount}");
                if (i != Doctors?.Count - 1)
                {
                    sb.AppendLine("      },");
                }
                else
                {
                    sb.AppendLine("      }");
                }
            }
            sb.AppendLine("    ]");
            sb.AppendLine("  }");
            sb.AppendLine("]");
            return sb.ToString();
        }
    }
}
