using AutoMapper;
using Entities = Patient.Domain.Entities;
using Patient.Application.DTOs;

namespace PatientApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Patient, PatientDTO>();
            CreateMap<Entities.MedicalRecord, MedicalRecordDTO>();
            CreateMap<Entities.Appointment, AppointmentDTO>();
            CreateMap<Entities.Doctor, DoctorDTO>();

            CreateMap<CreatePatientDTO, Entities.Patient>();
            CreateMap<UpdatePatientDTO, Entities.Patient>();
            CreateMap<AppointmentRequestDTO, Entities.Appointment>();
        }
    }
}
