using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietTypeController : ControllerBase
    {
        private readonly IService<DietDto> _service;
        private readonly IFileUploadService _fileUploadService;

        public DietTypeController(IFileUploadService fileUploadService, IService<DietDto> _service)
        {
            _fileUploadService = fileUploadService;
            this._service = _service;
        }

       
        // GET: api/<DietTypeController>
        [HttpGet]
        public List<DietDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<DietTypeController>/5
        [HttpGet("{id}")]
        public DietDto Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<DietTypeController>
        [HttpPost]
        public DietDto Post([FromForm] DietDto diet)
        {
            return _service.AddItem(diet);
        }

        // PUT api/<DietTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DietTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
