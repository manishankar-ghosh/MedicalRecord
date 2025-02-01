using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Appointment.Domain.Entities;

namespace Appointment.Infrastructure.Database
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base (options)
        {
            
        }

        public virtual DbSet<Entities.Appointment> Appointments { get; set; }
    }
}
