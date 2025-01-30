using PatientApi.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = default!; // Scheduled, Completed, Cancelled

    // Navigation Properties
    public Patient Patient { get; set; } = default!;
    public Doctor Doctor { get; set; } = default!;
}