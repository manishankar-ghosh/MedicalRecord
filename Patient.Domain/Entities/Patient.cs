﻿using System.ComponentModel.DataAnnotations;

namespace Patient.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DOB { get; set; }
        public string Gender { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;

        // Navigation Property
        //public ICollection<MedicalRecord> MedicalRecords { get; set; } = default!;
    }
}
