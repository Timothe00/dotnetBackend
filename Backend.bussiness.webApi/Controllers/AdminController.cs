using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.DataAccess.Data;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;

namespace Backend.bussiness.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly presenceManagementDbContext presenceManagementDbContext;
        private AdminService AdminServices;

        public AdminController(presenceManagementDbContext dbContext, AdminService adminServices)
        {
            presenceManagementDbContext = dbContext;
            AdminServices = adminServices;
        }




        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var admin = await AdminServices.GetAdminsAsync();
            return Ok(admin);
        }




        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminByIdAsync(int id)
        {
            var admin = await AdminServices.GetAdminIdAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);

        }



        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] AdminImage admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(AdminServices.CreateAdminAsync(admin));
            }

        }



        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdminImage admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(AdminServices.UpdateAdminAsync(admin, id));
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return AdminServices.DeleteAdminAsync(id);
        }
    }
}