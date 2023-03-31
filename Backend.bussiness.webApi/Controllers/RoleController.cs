using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.AdminServices;
using Backend.business.Logic.Services.RoleServices;
using Backend.business.Logic.Services.UsersServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.business.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleServices _iroleServices;

        public RoleController(IRoleServices iroleServices)
        {
            _iroleServices = iroleServices;
        }



        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var role = await _iroleServices.GetAllRolesAsync();
            return Ok(role);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _iroleServices.GetRoleByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] RolesImage role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_iroleServices.CreateRoleAsync(role));
            }

        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RolesImage Xrole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_iroleServices.UpdateRoleAsync(Xrole));
            }
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid id.");
            }
            else
            {
                var role = await _iroleServices.DeleteRoleAsync(id);
                return Ok(role);

            }

        }

    }
}
