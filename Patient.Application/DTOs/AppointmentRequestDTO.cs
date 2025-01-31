namespace Patient.Application.DTOs;
public class AppointmentRequestDTO
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
}
