using System.Text;

namespace ClassLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public int Age { get; set; }

        private int _heartRate;
        private double _temperature;
        private int _oxygenSaturaion;

        private string? _name;
        private string? _gender;
        private string? _diagnosis;

        public List<Doctor>? Doctors { get; set; } = new List<Doctor>();

        /// <summary>
        /// Событие, возникающее при изменении показателей пациента
        /// </summary>
        public event EventHandler<EnhancedEventArgs> Updated;

        public string? Name
        {
            get => _name;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Имя пациента не может быть пустой строкой.");
                else _name = value;
            }
        }

        public int HeartRate
        {
            get => _heartRate;
            set
            {
                _heartRate = value;
                OnFieldChanged("heartRate");
            }
        }

        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnFieldChanged("temperature");
            }
        }

        public int OxygenSaturation
        {
            get => _oxygenSaturaion;
            set
            {
                _oxygenSaturaion = value;
                OnFieldChanged("oxygenSaturation");
            }
        }

        /// <summary>
        /// Вызывает событие при изменении показателей
        /// </summary>
        protected virtual void OnFieldChanged(string fieldName)
        {
            var args = new EnhancedEventArgs(DateTime.Now);
            Updated?.Invoke(this, args);

            switch (fieldName)
            {
                case "heartRate":
                    Console.WriteLine("пизда бачку");
                    if (HeartRate < 60 || HeartRate > 100)
                    {
                        foreach (var doctor in Doctors)
                        {
                            doctor.AppointmentCount++;
                        }
                    }
                    else
                    {
                        foreach (var doctor in Doctors)
                        {
                            doctor.AppointmentCount--;
                        }
                    };
                    break;

                case "temperature":
                    if (Temperature < 36 || Temperature > 38)
                    {
                        foreach (var doctor in Doctors)
                        {
                            doctor.AppointmentCount++;
                        }
                    }
                    else
                    {
                        foreach (var doctor in Doctors)
                        {
                            doctor.AppointmentCount--;
                        }
                    };
                    break;

                case "oxygenSaturation":
                    if (OxygenSaturation < 95 || OxygenSaturation > 100)
                    {
                        foreach (var doctor in Doctors)
                        {
                            doctor.AppointmentCount++;
                        }
                    }
                    else
                    {
                        foreach (var doctor in Doctors)
                        {
                            doctor.AppointmentCount--;
                        }
                    };
                    break;
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
            OxygenSaturation = oxygenSaturation;
            Doctors = doctors;
        }

        public Patient(int id,
                       string? name,
                       int age,
                       string? gender,
                       string? diagnosis,
                       int heartRate,
                       double temperature,
                       int oxygenSaturation)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Diagnosis = diagnosis;
            HeartRate = heartRate;
            Temperature = temperature;
            OxygenSaturation = oxygenSaturation;
        }

        public string ToJSON()
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            sb.AppendLine($"  \"patient_id\": {Id},");
            sb.AppendLine($"  \"name\": \"{Name}\",");
            sb.AppendLine($"  \"age\": {Age},");
            sb.AppendLine($"  \"gender\": \"{Gender}\",");
            sb.AppendLine($"  \"diagnosis\": \"{Diagnosis}\",");
            sb.AppendLine($"  \"heart_rate\": {HeartRate},");
            sb.AppendLine($"  \"temperature\": {Temperature.ToString().Replace(',', '.')},");
            sb.AppendLine($"  \"oxygen_saturation\": {OxygenSaturation},");
            sb.AppendLine($"  \"doctors\": [");

            for (int i = 0; i < Doctors?.Count; i++)
            {
                sb.Append(Doctors[i].ToJSON());
                if (i != Doctors?.Count - 1) sb.AppendLine(",");
            }

            sb.AppendLine("\n  ]");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
