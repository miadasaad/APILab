using APILabThree.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APILabThree.Controllers
{
    public class UsersController : Controller
    {
        private readonly IConfiguration configuration;
        public UsersController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult<TokenDto> StaticLogin(LoginDto credentials)
        {
           if (credentials.UserName != "admin" || credentials.Password != "mayada")
            {
                return BadRequest();
            }

            var claimsList = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier,"56565656"),
               new Claim(ClaimTypes.Role ,"Employee"),
               new Claim("Nationality","Egyptian")
           };
            string keyString =configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var keyInBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyInBytes);
            var expiry = DateTime.Now.AddMinutes(55);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var jwt = new JwtSecurityToken(
                expires : expiry,
               claims :claimsList ,
               signingCredentials :signingCredentials 
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);
            return new TokenDto { Token = tokenString };
        }
    }
}
