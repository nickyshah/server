using AutoMapper;
using server.Core.Dtos.Candidate;
using server.Core.Dtos.Company;
using server.Core.Dtos.Job;
using server.Core.Entities;

namespace server.Core.AutomapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //Company
            CreateMap<CompanyCreateDto, Company>().ReverseMap();
            CreateMap<CompanyGetDto, Company>().ReverseMap();

            //Job
            CreateMap<JobCreateDto, Job>().ReverseMap();
            CreateMap<JobGetDto, Job>().ReverseMap();
            CreateMap<Job, JobGetDto>()
                .ForMember(destination => destination.CompanyName, option => option.MapFrom(src => src.Company.Name));

            //Candidate
            CreateMap<CandidateCreateDto, Candidate>().ReverseMap();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(destination => destination.JobTitle, option => option.MapFrom(src => src.Job.Title));
        }
    }
}
