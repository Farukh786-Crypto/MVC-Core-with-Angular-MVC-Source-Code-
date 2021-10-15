using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PatientEntity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private string GenerateJSONWebToken(string username)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Shiv@123333Shiv@12333"));
            var credentials = new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Issuer","Shiv"),
                new Claim("Admin","true"),
                new Claim(JwtRegisteredClaimNames.UniqueName,username)
            };

            var token = new JwtSecurityToken("Shiv","Shiv",
                claims,
                expires:DateTime.Now.AddSeconds(240),
                signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
        [HttpGet]
        public string Get()
        {
            // Validations ..
            return GenerateJSONWebToken("Shiv");
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
             if(user.userName=="Shiv")
            {
                var token = GenerateJSONWebToken(user.userName);
                var security = new Security() { token= token };
                return Ok(security);
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized,"Not authorized");
            }
        }
    }
}
