using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Name = "Freddy",
                    Age = 28,
                    CompanyId = 1000,
                    Id = new Random().Next(),
                    Position = ".Net developer"
                },
                new Employee
                {
                    Age = 35,
                    CompanyId = 2000,
                    Id = new Random().Next(),
                    Name = "Juan Sebastian",
                    Position = "Poject Manager"
                },
                new Employee
                {
                    Age = 30,
                    CompanyId = 2000,
                    Id = new Random().Next(),
                    Name = "Fabio Quintero",
                    Position = "Tech lead"
                }

                );
        }
    }
}
