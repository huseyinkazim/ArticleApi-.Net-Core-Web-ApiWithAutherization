using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.DtoLayer.Dto;
using Core.EntityLayer.Context;
using Core.EntityLayer.Models;
using Core.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IUserService _userService;
        private readonly LogManager _logManager;

        private const string controllername = "Token";
        private string username => User.Claims.FirstOrDefault()?.Value.ToUpper();

        public TokenController(IUserService userService, ILoggerService loggerService)
        {
            this._userService = userService;
            this._logManager = new LogManager(loggerService);

        }

        [HttpPost]
        public IActionResult GetToken([FromBody]LoginDto login)
        {
            var methodname = "GetToken";
            try
            {
                if (login == null)
                    return BadRequest("");
                var user = _userService.FindByName(login.Username);

                if (user != null && _userService.CheckPassword(user, login.Password))
                {
                    var Token = CreateToken(login.Username);
                    _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);

                    return Ok(new { Token = Token.Item1, Expiration = Token.Item2.ToString() });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username, login.GetParameters());

                return BadRequest("Beklenmedik bir hata oluştu");
            }

        }
        private (string, DateTime) CreateToken(string username)
        {
            var list = new List<Claim> { new Claim(JwtRegisteredClaimNames.Sub, username), new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) };
            var token = new JwtSecurityToken(
                   issuer: Startup.tokenValidationParameters.ValidIssuer,
                   audience: Startup.tokenValidationParameters.ValidAudience,
                   claims: list,
                   expires: DateTime.Now.AddMinutes(30),
                   signingCredentials: new SigningCredentials(Startup.signingKey, SecurityAlgorithms.HmacSha256)
               );
            return (new JwtSecurityTokenHandler().WriteToken(token), DateTime.Now.AddMinutes(30));
        }
    }
}