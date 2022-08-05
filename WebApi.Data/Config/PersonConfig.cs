using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Model;

namespace WebApi.Data.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            //entity.ToTable("Person");
            //entity.Property(x => x.FirstName).IsRequired().HasColumnType("nvarchar(500)");
            //entity.Property(x => x.LastName).IsRequired().HasColumnType("nvarchar(500)");
            //entity.Property(x => x.Email).HasColumnType("nvarchar(500)");
            //entity.Property(x => x.Description).HasColumnType("nvarchar(500)");
            //entity.Property(x => x.Phone).HasColumnType("varchar(25)");
            //entity.Property(x => x.CreatedBy).HasColumnType("nvarchar(500)");
            //entity.Property(x => x.CreatedAt).IsRequired().HasColumnType("datetime2");
            //entity.Property(x => x.DateOfBirth).IsRequired().HasColumnType("date");
            //entity.Property(x => x.StaffId).IsRequired().HasColumnType("varchar(25)");
            //entity.HasIndex(x => x.StaffId);
            //entity.HasIndex(x => x.FirstName);
        }
    }
}
