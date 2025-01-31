namespace Patient.Application.DTOs;
public class MedicalRecordDTO
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string Diagnosis { get; set; } = default!;
    public string Treatment { get; set; } = default!;
    public DateTime RecordDate { get; set; }
}
