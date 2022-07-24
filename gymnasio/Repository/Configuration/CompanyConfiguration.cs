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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
                new Company
                {
                    Id = 1000,
                    Name = "IT_solutions",
                    Address = "pedregal 483, Medellin",
                    Country = "Colombia"
                },
                new Company
                {
                    Id = 2000,
                    Name = "Gycso IT solutions",
                    Address = "Hopelchen 483, Ciudad de México",
                    Country = "México"
                }

            );
        }
    }
}
