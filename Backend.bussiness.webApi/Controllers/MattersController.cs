using Backend.business.DataAccess.Data;
using Backend.business.DataAccess.Models;
using Backend.business.Logic.ModelsImage;
using Backend.business.Logic.Services.MatersServices;
using Backend.business.Logic.Services.MattersServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Backend.business.webApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class MattersController : ControllerBase
    {


        private readonly IMattersServices _matterService;

        public MattersController(IMattersServices matterService)
        {
            _matterService = matterService;
        }


        // GET: api/<UsersController>
        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            var m = await _matterService.GetMattersAsync();
            return Ok(m);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
       public async Task<IActionResult> GetMatterByIdAsync(int id)
        {
            var mat = await _matterService.GetMatterIdAsync(id);

            if (mat == null)
            {
                return NotFound();
            }

            return Ok(mat);

        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] MattersImage matter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error create");
            }
            else
            {
                return Ok(_matterService.CreateMatterAsync(matter));
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MattersImage matter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_matterService.UpdateMatterAsync(matter));
            }
        }



        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
            return _matterService.DeleteMatterAsync(id);
        }
    }
}
