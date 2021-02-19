using $safeprojectname$.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces
{
    public interface IPersonSampleAppService : IDisposable
    {
        PersonSampleDto Insert(PersonSampleDto personSampleDto);
        PersonSampleDto Update(Guid id, PersonSampleDto obj);
        void Delete(Guid id);
        IEnumerable<PersonSampleDto> GetAll();
        PersonSampleDto GetById(Guid Id);
    }
}
