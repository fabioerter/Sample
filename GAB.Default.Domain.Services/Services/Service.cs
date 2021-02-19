using FluentValidation;
using $ext_projectname$.Domain.Core.Interfaces.Repositories;
using $ext_projectname$.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Services
{

    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public Service(IUnitOfWork context, IRepository<TEntity> repository)
        {
            Repository = repository;
            Context = context;
        }

        protected IRepository<TEntity> Repository { get; }

        protected AbstractValidator<TEntity> Validator { get; set; }

        protected IUnitOfWork Context { get; set; }

        public virtual void Delete(TEntity obj)
        {
            if (Context.ValidateEntity)
                Validator.Validate(obj, options =>
                {
                    options.ThrowOnFailures();
                    options.IncludeRuleSets("Delete");
                });

            Repository.Delete(obj);
        }

        public void Dispose()
        {
            Repository.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        public virtual TEntity Insert(TEntity obj)
        {
            if (Context.ValidateEntity)
                Validator.Validate(obj, options =>
                {
                    options.ThrowOnFailures();
                    options.IncludeRuleSets("Insert");
                });

            return Repository.Insert(obj);
        }

        public virtual TEntity Update(TEntity obj)
        {
            if (Context.ValidateEntity)
                Validator.Validate(obj, options =>
                {
                    options.ThrowOnFailures();
                    options.IncludeRuleSets("Update");
                });
            
            return Repository.Update(obj);
        }
    }

}
