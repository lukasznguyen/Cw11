using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Services
{
    public class DbService : IDbClinic
    {
        private readonly CodeFirstContext _context;

        public DbService(CodeFirstContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetDoctorsList()
        {
            return _context.Doctor.ToList();
        }

        public IEnumerable<Doctor> GetDoctor(int id)
        {
            var res = _context.Doctor.Where(doctor => doctor.IdDoctor == id).ToList();
            return res;
        }

        public string AddDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            _context.SaveChangesAsync();
            return "Added complete";
        }

        public string UpdateDoctor(int id, Doctor doctor)
        {
            doctor.IdDoctor = id;
            _context.Attach(doctor);
            _context.Entry(doctor).Property("FirstName").IsModified = true;
            _context.Entry(doctor).Property("LastName").IsModified = true;
            _context.Entry(doctor).Property("Email").IsModified = true;
            _context.SaveChangesAsync();
            return "Update success";
        }

        public string DeleteDoctor(int id)
        {
            var d = new Doctor() { IdDoctor = id };
            _context.Attach(d);
            _context.Remove(d);
            _context.SaveChangesAsync();

            return "Delete success";
        }
    }
}
