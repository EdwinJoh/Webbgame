using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Configuration
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Characters>
    {
        public void Configure(EntityTypeBuilder<Characters> builder)
        {
            builder.HasData
            (
            new Characters
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Thief",
                Profession="Good at stealing stuff",
               
            },
            new Characters
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "Maffia",
                Profession = "Good at organized crime",

            }
            );
        }

    }
}
