using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.StartingData
{
    public class StartingDataMedicament : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            var data = new List<Medicament>();
            data.Add(new Medicament(){Description = "na sen", IdMedicament = 1, Name = "Dobry Sen Forte", Type = "tabletki"});
            data.Add(new Medicament() { Description = "na bol glowy", IdMedicament = 2, Name = "Ibuprom", Type = "syrop" });
            data.Add(new Medicament() { Description = "na bol brzucha", IdMedicament = 3, Name = "Witaminium C", Type = "czopki" });

            builder.HasData(data);
        }
    }
}
