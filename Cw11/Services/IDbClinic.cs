using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Services
{
    public interface IDbClinic
    {
        public IEnumerable<Doctor> GetDoctorsList();
        public IEnumerable<Doctor> GetDoctor(int id);
        public string AddDoctor(Doctor doctor);
        public string UpdateDoctor(int id, Doctor doctor);
        public string DeleteDoctor(int id);

    }
}
