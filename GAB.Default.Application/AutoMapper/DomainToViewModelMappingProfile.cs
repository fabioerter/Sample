using AutoMapper;
using $safeprojectname$.Dtos;
using $ext_projectname$.Domain.Entities;

namespace $safeprojectname$.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PersonSample, PersonSampleDto>();
        }
    }
}
