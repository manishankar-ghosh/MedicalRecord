using System.ComponentModel.DataAnnotations;

namespace Patient.Domain.Entities;
public class Doctor
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Specialization { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;

    // Navigation Property
    public ICollection<Appointment> Appointments { get; set; } = default!;
}