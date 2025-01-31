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
            var data = await _repo.GetAllAsync();

            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePatientDTO createRequest)
        {
            if (createRequest == null)
            {
                return BadRequest();
            }

            var entity = _mapper.Map<Patient>(createRequest);

            _repo.Add(entity);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(this.GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> Update(int id, UpdatePatientDTO updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(updateRequest.Id != id) 
            { 
                return BadRequest();
            }

            var entity = _mapper.Map<Patient>(updateRequest);
            _repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return Ok(entity);
        }
    }
}
