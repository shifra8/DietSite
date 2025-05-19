using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietTypeController : ControllerBase
    {
        private readonly IService<DietDto> _service;

        public DietTypeController(IService<DietDto> _service)
        {
            this._service = _service;
        }

        // GET: api/<DietTypeController>

        [HttpGet]
        public ActionResult<List<DietDto>> Get()
        {
            try
            {
                var diets = _service.GetAll();
                return Ok(diets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //V
        [HttpGet("{id}")]
        public ActionResult<DietDto> Get(int id)
        {
            try
            {
                var diet = _service.GetById(id);
                if (diet == null)
                    return NotFound($"diet with id {id} not found.");

                return Ok(diet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }










        // POST api/<DietTypeController>
        [HttpPost]
        //public DietDto Post([FromForm] DietDto diet)
        //{
        //    return _service.AddItem(diet);
        //}


        public IActionResult Post([FromForm] DietDto diet)
        {

            if (diet == null)
                return BadRequest("Invalid Diet data.");
            //var path =Path.Combine( Environment.CurrentDirectory , "Images//" , diet.fileImage.FileName);
            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    stream.CopyTo(stream);

            //}
            _service.AddItem(diet);
            return Ok("Diet added successfully.");
        }






        // PUT api/<DietTypeController>/5
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromForm] DietDto dietDto)
        {
            if (id != dietDto. DietId)
                return BadRequest("ID mismatch.");

            try
            {
                _service.UpdateItem(id, dietDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        // DELETE api/<DietTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
