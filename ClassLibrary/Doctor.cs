namespace ClassLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public int AppointmentCount { get; set; }

        private string? _name;

        public List<Patient>? Patients { get; set; }

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

        public void ToJson()
        {
            ;
        }
    }
}
