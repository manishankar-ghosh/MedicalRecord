namespace Patient.Application.DTOs;
public class DoctorDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Specialization { get; set; } = default!;
    public string ContactNumber { get; set; } = default!;
}
