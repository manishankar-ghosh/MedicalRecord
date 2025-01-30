using PatientApi.Models;
using System.ComponentModel.DataAnnotations;

public class Appointment
{
    [Key]
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = default!; // Scheduled, Completed, Cancelled

    // Navigation Properties
    public Patient Patient { get; set; } = default!;
    public Doctor Doctor { get; set; } = default!;
}