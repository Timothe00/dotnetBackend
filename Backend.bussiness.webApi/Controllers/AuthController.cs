using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.Logic.Services.AuthServices;
using Backend.business.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Backend.business.DataAccess.Data;

namespace Backend.bussiness.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {        private readonly IAuthentificationServices _configuration;
        private AuthService _authService;
        public AuthController (IAuthentificationServices configuration)
        {
             _configuration = configuration;    
        }

        [HttpPost]
        public ActionResult Login([FromBody] Login userLogin)
        {
            var user = _configuration.Authenticate(userLogin);
            if (user != null)
            {
                //var tokens = _authService.Token(user);
                return Ok(user);
            }
            return NotFound("user not found");
        }
    }
}