using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientDbContext;
using PatientEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  /*  [Authorize]
    [EnableCors("MyCorsPolicy")]*/
    public class PatientApiController : ControllerBase
    {
        PatientDb db = null;
        public PatientApiController(PatientDb _db)
        {
            this.db = _db;
        }
        // GET: api/<PatientApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PatientApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Patient obj)
        {
            db.patients.Add(obj);
            db.SaveChanges();// save to database just like update-datbase command
            return Ok(obj);

           // return StatusCode(StatusCodes.Status500InternalServerError);
        }

        // PUT api/<PatientApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
