using Entity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly Entity.Context.MyDbContext _context;

        public AccountsController()
        {
            _context = new Entity.Context.MyDbContext();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel user)
        {

            Student student = _context.Students.SingleOrDefault(s => s.Firstname == user.Username && s.Password == user.Password);
            if (student == null)
            {
                return BadRequest("No User");
            }
            else
            {
        

            Claim[] claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, student.Firstname),
                    new Claim(ClaimTypes.Email, student.Email),
                    new Claim(ClaimTypes.MobilePhone, student.Phone),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ne Mutlu Türküm Diyene - Mustafa Kemal Atatürk"));
                var cryptoCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                        issuer: "jsga.edu.tr",
                        audience: "client.jsga.edu.tr",
                        claims: claims,
                        signingCredentials: cryptoCredential,
                        notBefore:DateTime.Now,
                        expires: DateTime.Now.AddMinutes(20)
                    );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }


        }
    }
}
