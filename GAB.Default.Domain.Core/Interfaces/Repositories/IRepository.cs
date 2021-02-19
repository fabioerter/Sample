using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

        void Delete(Guid id);
        void Delete(TEntity obj);
        void DeleteAsync(TEntity obj);
        void DeleteRange(ICollection<TEntity> t);

        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);

        TEntity Insert(TEntity obj);
        Task<TEntity> InsertAsync(TEntity obj);
        TEntity Update(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        IEnumerable<TEntity> GetAll();

    }
}
