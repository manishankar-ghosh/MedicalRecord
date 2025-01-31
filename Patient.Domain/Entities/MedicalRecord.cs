using Patient.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Patient.Domain.Entities;
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