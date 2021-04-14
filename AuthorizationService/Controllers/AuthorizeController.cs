using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Provider;
using AuthorizationService.Models;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthorizeController));
        private readonly IJwtAuthenticationManager ap;
        public AuthorizeController(IJwtAuthenticationManager ap)
        {
            this.ap = ap;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            _log4net.Info("Login Request");
            if (login == null)
            {
                _log4net.Info("Bad Login Request");
                return BadRequest();
            }
            try
            {
                IActionResult response = Unauthorized();
                User user = ap.Validate(login);

                if (user != null)
                {
                    _log4net.Info("Login Success! Token Generated");
                    var tokenString = ap.GenarateToken(user.Email);
                    response = Ok(new {token=tokenString,memId=user.MemberId });
                }
                return response;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception Occured " + e.Message);
                return StatusCode(500);
            }

        }

    }
}
