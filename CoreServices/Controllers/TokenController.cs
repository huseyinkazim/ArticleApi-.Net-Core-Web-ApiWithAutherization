using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.DataLayer.Context;
using Core.DataLayer.Dto;
using Core.DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoreServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private AppDbContext _appDbContext;
        private UserManager<ApplicationUser> _userManager;
        public TokenController(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            this._appDbContext = appDbContext;
            this._userManager = userManager;
        }

        [HttpPost]
        public IActionResult GetToken([FromBody]LoginDto login)
        {

            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
                return BadRequest("Please fill areas");

            if (login.Username == "digiturk" && login.Password == "digiturk")
            {
                var Token = CreateToken();
                return Ok(new { Token = Token });
            }
            else
            {
                return Unauthorized();
            }

        }
        private string CreateToken()
        {
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                   issuer: Startup.tokenValidationParameters.ValidIssuer,
                   audience: Startup.tokenValidationParameters.ValidAudience,
                   claims: new List<Claim>(),
                   expires: DateTime.Now.AddMinutes(30),
                   signingCredentials: new SigningCredentials(Startup.signingKey, SecurityAlgorithms.HmacSha256)
               ));
        }
    }
}