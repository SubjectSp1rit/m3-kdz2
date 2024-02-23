using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    public class Patient
    {
        private int _id;
        private string? _name;
        private int _age;
        private string? _gender;
        private string? _diagnosis;
        private int _heartRate;
        private double _temperature;
        private int _oxygenSaturaion;

        /// <summary>
        /// Событие, возникающее при изменении показателей пациента
        /// </summary>
        public event EventHandler<EnhancedEventArgs> Updated;

        [JsonPropertyName("patient_id")]
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

        [JsonPropertyName("age")]
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        [JsonPropertyName("gender")]
        public string? Gender
        {
            get => _gender;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Пол пациента не может быть пустой строкой.");
                else _gender = value;
            }
        }

        [JsonPropertyName("diagnosis")]
        public string? Diagnosis
        {
            get => _diagnosis;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Диагноз пациента не может быть пустой строкой.");
                else _diagnosis = value;
            }
        }

        [JsonPropertyName("heart_rate")]
        public int HeartRate
        {
            get => _heartRate;
            set
            {
                _heartRate = value;
                OnFieldChanged("heartRate");
            }
        }

        [JsonPropertyName("temperature")]
        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnFieldChanged("temperature");
            }
        }

        [JsonPropertyName("oxygen_saturation")]
        public int OxygenSaturation
        {
            get => _oxygenSaturaion;
            set
            {
                _oxygenSaturaion = value;
                OnFieldChanged("oxygenSaturation");
            }
        }

        [JsonPropertyName("doctors")]

        public List<Doctor>? Doctors { get; set; } = new List<Doctor>();

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
            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            JsonSerializerOptions optionsCopy = new(options);
            return JsonSerializer.Serialize(this, optionsCopy);
        }
    }
}
