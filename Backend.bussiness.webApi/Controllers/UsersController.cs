using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.Services.UsersServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Backend.business.webApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ManagementPresenceDbContext presenceManagementDbContext;
        private UsersService UsersServices;

        public UsersController(ManagementPresenceDbContext? dbContext, UsersService usersService)
        {
            presenceManagementDbContext = dbContext;
            UsersServices = usersService;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return UsersServices.GetAllUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return UsersServices.GetUsersById(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(UsersServices.AddUser(user));
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users Xuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(UsersServices.UserUpdate(Xuser));
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return UsersServices.UserDelete(id);
        }
    }
}
