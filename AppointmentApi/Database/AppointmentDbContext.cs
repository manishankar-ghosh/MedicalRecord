using Microsoft.EntityFrameworkCore;

namespace AppointmentApi.Database
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
