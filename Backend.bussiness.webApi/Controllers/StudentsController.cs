using Backend.business.DataAccess.Data;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.StudentServices;
using Backend.business.Logic.Services.UsersServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.business.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly presenceManagementDbContext presenceManagementDbContext;
        private StudentService StudentServices;

        public StudentsController(presenceManagementDbContext dbContext, StudentService studentServices)
        {
            presenceManagementDbContext = dbContext;
            StudentServices = studentServices;
        }




        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var std = await StudentServices.GetStudentsAsync();
            return Ok(std);
        }




        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentsByIdAsync(int id)
        {
            var std = await StudentServices.GetStudentIdAsync(id);

            if (std == null)
            {
                return NotFound();
            }

            return Ok(std);

        }



        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentsImage student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(StudentServices.CreateStudentAsync(student));
            }

        }



        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentsImage student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(StudentServices.UpdateStudentAsync(student, id));
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return StudentServices.DeleteStudentAsync(id);
        }
    }
}
