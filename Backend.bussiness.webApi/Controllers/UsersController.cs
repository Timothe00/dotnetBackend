using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.UsersServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Backend.business.webApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly presenceManagementDbContext presenceManagementDbContext;
        private UsersService UsersServices;

        public UsersController(presenceManagementDbContext dbContext, UsersService usersService)
        {
            presenceManagementDbContext = dbContext;
            UsersServices = usersService;
        }


        // GET: api/<UsersController>
        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            var users = await UsersServices.GetAllUsersAsync();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
       public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await UsersServices.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] ImagePost user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(UsersServices.CreateUserAsync(user));
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ImagePost Xuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(UsersServices.UpdateUserAsync(Xuser));
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return UsersServices.DeleteUserAsync(id);
        }
    }
}
