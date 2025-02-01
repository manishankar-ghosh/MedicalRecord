using Appointment.Application.DTOs;
using Appointment.Application.Queries;
using MediatR;
using RepositoryLibrary;
using Entities = Appointment.Domain.Entities;
using AutoMapper;

namespace Appointment.Application.Handlers
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<AppointmentDTO>>
    {
        private readonly IRepository<Entities.Appointment> _repo;
        private readonly IMapper _mapper;

        public GetAllAppointmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = unitOfWork.Repository<Entities.Appointment>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDTO>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAllAsync();

            return _mapper.Map<IEnumerable<AppointmentDTO>>(data);
        }
    }
}
