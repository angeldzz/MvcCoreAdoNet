namespace MvcCoreAdoNet.Models
{
    public class Doctor
    {
        public int IdHospital { get; set; }
        public int DoctorId { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public int Salario { get; set; }
    }
}
