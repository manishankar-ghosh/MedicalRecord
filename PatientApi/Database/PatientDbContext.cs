using Microsoft.EntityFrameworkCore;
using PatientApi.Models;

namespace PatientApi.Database
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options): base(options) 
        {
            
        }

        public virtual DbSet<Patient> Patients { get; set; }
    }
}
