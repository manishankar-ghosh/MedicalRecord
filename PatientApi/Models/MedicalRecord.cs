using PatientApi.Models;
using System.ComponentModel.DataAnnotations;

public class MedicalRecord
{
    [Key]
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string Diagnosis { get; set; } = default!;
    public string Treatment { get; set; } = default!;
    public DateTime RecordDate { get; set; }

    // Navigation Property
    public Patient Patient { get; set; } = default!;
}