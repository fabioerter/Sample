using $ext_projectname$.Domain.Entities;
using $safeprojectname$.Mappings;
using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonSampleMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
