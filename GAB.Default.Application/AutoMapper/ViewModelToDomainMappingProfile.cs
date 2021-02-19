using AutoMapper;
using $safeprojectname$.Dtos;
using $ext_projectname$.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonSampleDto, PersonSample>();
        }
    }
}
