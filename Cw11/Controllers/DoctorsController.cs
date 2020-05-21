using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Cw11.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDbClinic _context;

        public DoctorsController(IDbClinic context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.GetDoctorsList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(_context.GetDoctor(id));
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            return Ok(_context.AddDoctor(doctor));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctors(int id, Doctor doctor)
        {
            return Ok(_context.UpdateDoctor(id, doctor));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctors(int id)
        {
            return Ok(_context.DeleteDoctor(id));
        }


    }
}