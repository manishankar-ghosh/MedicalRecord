using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RepositoryLibrary;

namespace Appointment.Application.Queries
{
    public class GetAllAppointmentsQuery : IRequest<IEnumerable<Appointment.Application.DTOs.AppointmentDTO>>
    {


    }
}
