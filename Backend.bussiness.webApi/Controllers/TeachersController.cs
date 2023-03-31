
using Backend.business.DataAccess.Data;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.TeachersServices;
using Microsoft.AspNetCore.Mvc;

namespace Backend.bussiness.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersServices _iteachersServices;

        public TeachersController(ITeachersServices iteachersServices)
        {
            _iteachersServices = iteachersServices;
        }




        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var teach = await _iteachersServices.GetTeachersAsync();
            return Ok(teach);
        }




        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int id)
        {
            var teach = await _iteachersServices.GetTeacherIdAsync(id);

            if (teach == null)
            {
                return NotFound();
            }

            return Ok(teach);

        }



        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] TeacherImage teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_iteachersServices.CreateTeacherAsync(teacher));
            }

        }



        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TeacherImage teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_iteachersServices.UpdateTeacherAsync(teacher, id));
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return _iteachersServices.DeleteTeacherAsync(id);
        }
    }
    
}