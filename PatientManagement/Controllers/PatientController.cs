using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatientDbContext;
using PatientEntity;
using PatientManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientManagement.Controllers
{
    [Authorize]
    [EnableCors("MyCorsPolicy")]
    public class PatientController : Controller
    {
        PatientDb db = null;
        public PatientController(PatientDb _db)
        {
            this.db = _db;
        }
        public IActionResult Add()// invoke UI
        {
            return View("AddPatient");
        }
        public IActionResult SubmitPatient(Patient obj) //  Submit
        {
            db.patients.Add(obj);
            db.SaveChanges();// save to database just like update-datbase command
            return Json(obj);
        }
        public IActionResult Update()
        {
            Patient p = db.patients.ToList<Patient>()[0];
            p.name = "Shivam";
            db.SaveChanges();
            return View();
        }
    }
}
