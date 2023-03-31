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
    {
        private readonly presenceManagementDbContext _presenceManagementDbContext;
        //private readonly IConfiguration _configuration;
        private AuthService _authService;
        public AuthController(presenceManagementDbContext presenceManagementDbContext, AuthService authService)
        {
           // _authService = authService;
            // _configuration = configuration;
            _presenceManagementDbContext= presenceManagementDbContext;
            _authService =  authService;
        }

        [HttpPost]
        public ActionResult Login([FromBody] Login userLogin)
        {
            var user = _authService.Authenticate(userLogin);
            if (user != null)
            {
                //var tokens = _authService.Token(user);
                return Ok(user);
            }
            return NotFound("user not found");
        }
    }
}