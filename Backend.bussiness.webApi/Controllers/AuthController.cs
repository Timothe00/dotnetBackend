using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.Logic.Services.AuthServices;
using Backend.business.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.bussiness.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthServices authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Login([FromBody] Login userLogin)
        {
            var user = _authService.Authenticate(userLogin);
            if (user != null)
            {
                var tokens = _authService.Token(user);
                return Ok(tokens);
            }
            return NotFound("user not found");
        }
    }
}