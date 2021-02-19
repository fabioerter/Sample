using $ext_projectname$.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data;
using System.Data.Common;

namespace $safeprojectname$.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public Guid Id { get; set; }
        public bool ValidateEntity { get; set; }
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public DbContext Context { get; set; }

        public UnitOfWork(IDbConnection connection, DbContext context)
        {
            Context = context;
            ValidateEntity = true;
            Context.Database.OpenConnection();
            Connection = Context.Database.GetDbConnection();
        }

        public void BeginTransaction()
        {
            var transactionContext = Context.Database.BeginTransaction();
            Transaction = (transactionContext as IInfrastructure<DbTransaction>).Instance;
        }

        public void Commit(bool dispose = true)
        {
            Transaction.Commit();

            if (dispose)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                Connection?.Dispose();
                Connection = null;
            }

            if (Transaction != null)
            {
                Transaction?.Dispose();
                Transaction = null;
            }

            if (Context != null)
            {
                Context?.Dispose();
                Context = null;
            }
        }

        public void Open()
        {
            Connection.Open();
        }

        public void Rollback(bool dispose = true)
        {
            Transaction.Rollback();
            if (dispose)
            {
                Dispose();
            }
        }
    }
}
