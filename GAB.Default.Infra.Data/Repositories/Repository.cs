using $ext_projectname$.Domain.Base;
using $ext_projectname$.Domain.Core.Interfaces.Repositories;
using $safeprojectname$.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public IDbConnection Connection { get; set; }
        protected IUnitOfWork Uow { get; set; }

        public Repository(IUnitOfWork uow)
        {
            Uow = uow;
            Connection = uow.Connection;
        }

        public virtual void Delete(Guid id)
        {
            var obj = Activator.CreateInstance<TEntity>();
            obj.Id = id;
            Uow.Context.Set<TEntity>().Remove(obj);
            Uow.Context.SaveChanges();
        }
        public virtual void Delete(TEntity obj)
        {
            Uow.Context.Set<TEntity>().Remove(obj);
            Uow.Context.SaveChanges();
        }
        public virtual async void DeleteAsync(TEntity obj)
        {
            Uow.Context.Set<TEntity>().Remove(obj);
            await Uow.Context.SaveChangesAsync();

        }
        public virtual void DeleteRange(ICollection<TEntity> t)
        {
            Uow.Context.Set<TEntity>().RemoveRange(t);
            Uow.Context.SaveChanges();
        }

        public virtual TEntity GetById(Guid id)
        {
            return Uow.Context.Set<TEntity>().FirstOrDefault(o => o.Id == id);
        }
        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Uow.Context.Set<TEntity>().FirstOrDefaultAsync(o => o.Id == id);
        }

        public virtual TEntity Insert(TEntity obj)
        {
            Uow.Context.Set<TEntity>().Add(obj);
            Uow.Context.SaveChanges();
            return obj;
        }
        public virtual async Task<TEntity> InsertAsync(TEntity obj)
        {
            Uow.Context.Set<TEntity>().Add(obj);
            await Uow.Context.SaveChangesAsync();
            return obj;
        }

        public virtual TEntity Update(TEntity obj)
        {
            Uow.Context.Set<TEntity>().Update(obj);
            Uow.Context.SaveChanges();
            return obj;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            Uow.Context.Set<TEntity>().Update(obj);
            await Uow.Context.SaveChangesAsync();
            return obj;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Uow.Context.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
