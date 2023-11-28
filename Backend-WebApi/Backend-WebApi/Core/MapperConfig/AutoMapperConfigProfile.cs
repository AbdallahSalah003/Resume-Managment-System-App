using AutoMapper;
using Backend_WebApi.Core.Dtos.Candidate;
using Backend_WebApi.Core.Dtos.Company;
using Backend_WebApi.Core.Dtos.Job;
using Backend_WebApi.Core.Entities;

namespace Backend_WebApi.Core.MapperConfig
{
    public class AutoMapperConfigProfile : Profile 
    {
        public AutoMapperConfigProfile() 
        {
            //Company
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();
            //Job
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
            //Candidate
            CreateMap<CandidateCreateDto, Candidates>();
            CreateMap<Candidates, CandidateGetDto>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src =>src.Job.Title));
        }
    }
}
