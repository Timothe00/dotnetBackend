using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;






namespace Backend.bussiness.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _iadminServices;

        public AdminController(IAdminServices iadminServices)
        {
            _iadminServices = iadminServices;
        }




        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var admin = await _iadminServices.GetAdminsAsync();
            return Ok(admin);
        }




        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminByIdAsync(int id)
        {
            var admin = await _iadminServices.GetAdminIdAsync(id);

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
                return Ok(_iadminServices.CreateAdminAsync(admin));
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
                return Ok(_iadminServices.UpdateAdminAsync(admin, id));
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return _iadminServices.DeleteAdminAsync(id);
        }
    }
}