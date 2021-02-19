using $ext_projectname$.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace $safeprojectname$.Mappings
{
    public class PersonSampleMap : IEntityTypeConfiguration<PersonSample>
    {
        public void Configure(EntityTypeBuilder<PersonSample> builder)
        {
            builder.ToTable("PersonSamples");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FullName).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(p => p.DateBirth).IsRequired();
        }
    }
}
