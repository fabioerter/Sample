using FluentValidation;
using $ext_projectname$.Domain.Core.Interfaces.Repositories;
using $ext_projectname$.Domain.Core.Interfaces.Services;
using $ext_projectname$.Domain.Entities;
using $ext_projectname$.Domain.Services.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.Services
{
    public class PersonSampleService : Service<PersonSample>, IPersonSampleService
    {
        public PersonSampleService(IUnitOfWork context, IPersonSampleRepository personSampleRepository) : base(context, personSampleRepository)
        {
            Validator = new PersonSampleValidator();
        }

        public override PersonSample Insert(PersonSample obj)
        {
            if (Context.ValidateEntity)
                Validator.Validate(obj, options =>
                {
                    options.ThrowOnFailures();
                    options.IncludeRuleSets("Insert");
                });

            if ((DateTime.Now.Year - obj.DateBirth.Year) < 18)
                throw new ValidationException("Registration is not allowed to the under 18 years");

            return Repository.Insert(obj);
        }
    }
}
