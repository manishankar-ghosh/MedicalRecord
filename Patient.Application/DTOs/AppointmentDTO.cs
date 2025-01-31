namespace Patient.Application.DTOs;
public class AppointmentDTO
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; } = default!;
    public string Status { get; set; } = default!; // Scheduled, Completed, Cancelled
}
