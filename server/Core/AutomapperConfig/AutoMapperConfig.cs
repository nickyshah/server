using AutoMapper;
using server.Core.Dtos.Company;
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

            //Candidate

        }
    }
}
