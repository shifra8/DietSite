using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;

namespace MyProject.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyTrackingController : ControllerBase
    {
        private readonly IService<WeeklyTrackingDto> _service;
        private readonly IFileUploadService _fileUploadService;

        public WeeklyTrackingController(IService<WeeklyTrackingDto> service, IFileUploadService fileUploadService)
        {
            _service = service;
            _fileUploadService = fileUploadService;
        }


        // שליפת כל מעקבים-V
        [HttpGet]
        public ActionResult<List<WeeklyTrackingDto>> Get()
        {
            try
            {
                var Weeklytrackings = _service.GetAll();
                return Ok(Weeklytrackings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // שליפת Weeklytracking לפי מזהה (string id)

        [HttpGet("{id}")]
        public ActionResult<WeeklyTrackingDto> Get(int id)
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



        // עדכון מעקב קיים
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromForm] WeeklyTrackingDto weeklyTrackingDto)
        {
            if (id != weeklyTrackingDto.Id)
                return BadRequest("ID mismatch.");

            try
            {
                _service.UpdateItem(id, weeklyTrackingDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // מחיקת מעקב
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteItem(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]

        public IActionResult Post([FromForm] WeeklyTrackingDto weeklyTracking)
        {

            if (weeklyTracking == null)
                return BadRequest("Invalid weeklyTracking data.");
            _service.AddItem(weeklyTracking);
            return Ok("weeklyTracking added successfully.");
        }

    }
}



