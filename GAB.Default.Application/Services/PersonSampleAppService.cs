using AutoMapper;
using $safeprojectname$.Base;
using $safeprojectname$.Dtos;
using $safeprojectname$.Interfaces;
using $ext_projectname$.Domain.Core.Interfaces.Repositories;
using $ext_projectname$.Domain.Core.Interfaces.Services;
using $ext_projectname$.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Services
{
    public class PersonSampleAppService : AppService, IPersonSampleAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonSampleService _servicePersonSample;
        private readonly IPersonSampleRepository _personSampleRepository;
        public PersonSampleAppService(IUnitOfWork uoW, IMapper mapper, IPersonSampleService servicePersonSample,
            IPersonSampleRepository personSampleRepository) : base(uoW, mapper)
        {
            _mapper = mapper;
            _servicePersonSample = servicePersonSample;
            _personSampleRepository = personSampleRepository;
        }

        public PersonSampleDto Insert(PersonSampleDto obj)
        {

            try
            {
                UoW.BeginTransaction();
                var PersonSample = _servicePersonSample.Insert(Mapper.Map<PersonSample>(obj));
                UoW.Commit();

                return Mapper.Map<PersonSampleDto>(PersonSample);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public PersonSampleDto Update(Guid id, PersonSampleDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                var PersonSample = Mapper.Map<PersonSample>(obj);
                PersonSample.Id = id;
                PersonSample = _servicePersonSample.Update(PersonSample);

                UoW.Commit();
                return Mapper.Map<PersonSampleDto>(PersonSample);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                UoW.BeginTransaction();
                var obj = _servicePersonSample.GetById(id);
                _servicePersonSample.Delete(Mapper.Map<PersonSample>(obj));

                UoW.Commit();
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public IEnumerable<PersonSampleDto> GetAll()
        {
            return _mapper.Map<IEnumerable<PersonSampleDto>>(_servicePersonSample.GetAll());
        }

        public PersonSampleDto GetById(Guid Id)
        {
            return _mapper.Map<PersonSampleDto>(_servicePersonSample.GetById(Id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
