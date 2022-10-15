using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class SkillsConfiguration : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.HasData
            (
            new Skills
            {
                Id = new Guid ("3d490a70-94ce-4d15-9494-5244280c2c23"),
                CharacterId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Stealing = 1,
                OrganizedCrime = 1,

            },
            new Skills
            {
                Id= new Guid("3d490a70-94ce-4d25-9494-5244280c2c23"),
                CharacterId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Stealing = 1,
                OrganizedCrime = 1,
                
            }
            );

        }
    }
}
