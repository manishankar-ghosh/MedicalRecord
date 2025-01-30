using AutoMapper;
using PatientApi.Models;

namespace PatientApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<MedicalRecord, MedicalRecordDTO>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<Doctor, DoctorDTO>();

            CreateMap<CreatePatientDTO, Patient>();
            CreateMap<UpdatePatientDTO, Patient>();
            CreateMap<AppointmentRequestDTO, Appointment>();
        }
    }
}
