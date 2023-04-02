using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.PermissionServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.bussiness.webApi.Controllers
{
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionServices _PermissionServices;

        public PermissionController(IPermissionServices PermissionServices)
        {
            _PermissionServices = PermissionServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var p = await _PermissionServices.GetAllPermissionAsync();
            return Ok(p);
        }

       [HttpGet("{id}")]
       public async Task<IActionResult> GetMatterByIdAsync(int id)
        {
            var per = await _PermissionServices.GetPermissionByIdAsync(id);

            if (per == null)
            {
                return NotFound();
            }

            return Ok(per);

        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] PermissionImage permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error create");
            }
            else
            {
                return Ok(_PermissionServices.CreatePermissionAsync(permission));
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PermissionImage permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_PermissionServices.UpdatePermissionAsync(permission));
            }
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return _PermissionServices.DeletePermissionAsync(id);
        }
    }
}