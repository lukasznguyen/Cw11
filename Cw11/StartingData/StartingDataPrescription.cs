using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.StartingData
{
    public class StartingDataPrescription : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            var data = new List<Prescription>();

            data.Add(new Prescription()
            { 
                    Date = Convert.ToDateTime("2020-02-03"), 
                    DueDate = Convert.ToDateTime("2020-02-09"), 
                    IdDoctor = 1, 
                    IdPatient = 1, 
                    IdPrescription = 1
            });

            data.Add(new Prescription()
            {
                Date = Convert.ToDateTime("2020-01-04"),
                DueDate = Convert.ToDateTime("2020-01-24"),
                IdDoctor = 2,
                IdPatient = 2,
                IdPrescription = 2
            });

            data.Add(new Prescription()
            {
                Date = Convert.ToDateTime("2020-04-12"),
                DueDate = Convert.ToDateTime("2020-05-09"),
                IdDoctor = 3,
                IdPatient = 3,
                IdPrescription = 3
            });

            builder.HasData(data);
        }
    }
}
