using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw11.StartingData
{
    public class StartingDataDoctor : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            var data = new List<Doctor>();
            data.Add(new Doctor() {Email = "email1@pjwstk.edu.pl", FirstName = "Jan", LastName = "Jankowski", IdDoctor = 1});
            data.Add(new Doctor() { Email = "email2@pjwstk.edu.pl", FirstName = "Adam", LastName = "Adamowski", IdDoctor = 2 });
            data.Add(new Doctor() { Email = "email3@pjwstk.edu.pl", FirstName = "Karol", LastName = "Karolowskiki", IdDoctor = 3 });

            builder.HasData(data);
        }
    }
}
