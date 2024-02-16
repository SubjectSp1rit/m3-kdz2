using System.Text;

namespace ClassLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public int AppointmentCount { get; set; }

        private string? _name;

        public List<Patient>? Patients { get; set; } = new List<Patient>();

        /// <summary>
        /// Обрабатывает событие обновления пациента (изменение appointmentCount происходит в Patient
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Содержит дату и время обновления</param>
        public void OnPatientUpdated(object sender, EnhancedEventArgs e) { }

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

        public Doctor()
        {
            throw new NotImplementedException("Пустой конструктор не предусмотрен классом Doctor.");
        }

        public Doctor(int id,
                      string? name,
                      int appointmentCount,
                      List<Patient>? patients)
        {
            Id = id;
            Name = name;
            AppointmentCount = appointmentCount;
            Patients = patients;
        }

        public Doctor(int id,
                      string? name,
                      int appointmentCount)
        {
            Id = id;
            Name = name;
            AppointmentCount = appointmentCount;
        }

        public string ToJSON()
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            sb.AppendLine($"  \"doctor_id\": {Id},");
            sb.AppendLine($"  \"name\": {Name},");
            sb.AppendLine($"  \"appointment_count\": {AppointmentCount}");
            sb.Append("}");

            return sb.ToString();
        }
    }
}
