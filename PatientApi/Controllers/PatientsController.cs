using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientApi.Models;
using RepositoryLibrary;

namespace PatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Patient> _repo;
        private readonly IMapper _mapper;
        public PatientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.Repository<Patient>();
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllAsync() 
        {
            var patients = await _repo.GetAllAsync();

            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientDTO patientDTO)
        {
            if (patientDTO == null)
            {
                return BadRequest();
            }

            //var patient = _mapper.Map<Patient>(patientDTO);

            Patient patient = new Patient
            {
                Address = patientDTO.Address,
                ContactNumber = patientDTO.ContactNumber,
                DOB = patientDTO.DOB,
                Email = patientDTO.Email,
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                Gender = patientDTO.Gender
            };

            _repo.Add(patient);
            await _unitOfWork.SaveChangesAsync();

            return Ok(patient);
        }
    }
}
