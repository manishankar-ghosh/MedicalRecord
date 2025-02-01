using Appointment.Application.DTOs;
using Appointment.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(IMediator _mediator) : ApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AppointmentDTO>), 200)]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAll()
        {
            var query = new GetAllAppointmentsQuery();
            var data = await _mediator.Send(query);
            return Ok(data);
        }
    }
}
