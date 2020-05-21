using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.StartingData
{
    public class StartingDataPrescriptionMedicament : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            var data = new List<PrescriptionMedicament>();

            data.Add(new PrescriptionMedicament { Details = "Przed posilkiem", Dose = 3, IdMedicament = 1, IdPrescription = 1 });
            data.Add(new PrescriptionMedicament { Details = "Popijac duza iloscia wody", Dose = 5, IdMedicament = 2, IdPrescription = 2 });
            data.Add(new PrescriptionMedicament { Details = "Po posilku", Dose = 10, IdMedicament = 3, IdPrescription = 3 });

            builder.HasData(data);
        }
    }
}
