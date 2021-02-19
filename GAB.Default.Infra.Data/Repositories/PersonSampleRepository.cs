using $ext_projectname$.Domain.Core.Interfaces.Repositories;
using $ext_projectname$.Domain.Entities;
using $safeprojectname$.Context;

namespace $safeprojectname$.Repositories
{
    public class PersonSampleRepository : Repository<PersonSample>, IPersonSampleRepository
    {

        public PersonSampleRepository(IUnitOfWork context) : base (context)
        {
        }
    }
}
