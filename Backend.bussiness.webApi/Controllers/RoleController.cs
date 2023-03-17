using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.Services.RoleServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.business.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly ManagementPresenceDbContext presenceManagementDbContext;
        private RoleService RoleServices;

        public RoleController(ManagementPresenceDbContext? dbContext, RoleService roleServices)
        {
            presenceManagementDbContext = dbContext;
            RoleServices = roleServices;
        }



        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return RoleServices.GetAllRoles();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return RoleServices.GetRoleById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(RoleServices.AddRole(role));
            }

        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role Xrole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(RoleServices.RoleUpdate(Xrole));
            }
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return RoleServices.RoleDelete(id);
        }
    }
}
