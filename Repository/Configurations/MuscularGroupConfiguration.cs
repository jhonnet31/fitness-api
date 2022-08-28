using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class MuscularGroupConfiguration : IEntityTypeConfiguration<MuscularGroup>
    {
        public void Configure(EntityTypeBuilder<MuscularGroup> builder)
        {
            builder.HasData
                (
                    new MuscularGroup {Id=1, Name="Shoulders"} 
                
                );
        }
    }
}
