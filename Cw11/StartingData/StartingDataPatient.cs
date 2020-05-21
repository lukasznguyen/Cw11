using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.StartingData
{
    public class StartingDataPatient : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            var data = new List<Patient>();

            data.Add(new Patient() { BirthDate = Convert.ToDateTime("1990-03-05"), FirstName = "Jon", LastName = "Kowal", IdPatient = 1 }); 
            data.Add(new Patient() { BirthDate = Convert.ToDateTime("1994-09-08"), FirstName = "Alicja", LastName = "Czarow", IdPatient = 2 }); 
            data.Add(new Patient() { BirthDate = Convert.ToDateTime("1980-02-10"), FirstName = "Joker", LastName = "Batman", IdPatient = 3 }); ;

            builder.HasData(data);
        }
    }
}
