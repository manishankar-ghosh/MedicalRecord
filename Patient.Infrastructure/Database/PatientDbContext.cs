using Microsoft.EntityFrameworkCore;
using Entities = Patient.Domain.Entities;

namespace Patient.Infrastructure.Database
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options): base(options) 
        {
            
        }

        public virtual DbSet<Entities.Patient> Patients { get; set; }
    }
}
