using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Common.Dto;
using Service.Interfaces;
using System;
using Common.Dto.Common.Dto;

namespace MyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodPreferenceController : ControllerBase
    {
        private readonly IFoodPreferenceService _foodPreferenceService;
        //private readonly IService<FoodPreferencesDto> _service;


        public FoodPreferenceController(IFoodPreferenceService foodPreferenceService)
        {
            _foodPreferenceService = foodPreferenceService;
        }

        //[HttpPost]
        //[Authorize]
        //public IActionResult SavePreferences([FromForm] FoodPreferencesDto dto)
        //{
        //    try
        //    {
        //        int userId = int.Parse(User.FindFirst("id").Value);
        //        _foodPreferenceService.SaveUserPreferences(dto, userId);
        //        return Ok("Preferences saved");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}


        [HttpPost]
        [Authorize]
        public IActionResult SavePreferences([FromForm] FoodPreferencesDto dto)
        {
            try
            {
                int userId = int.Parse(User.FindFirst("id").Value);
                _foodPreferenceService.SaveUserPreferences(dto, userId);
                return Ok("Preferences saved");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet]
        [Authorize]
        public IActionResult GetPreferences()
        {
            try
            {
                int userId = int.Parse(User.FindFirst("id").Value);
                var result = _foodPreferenceService.GetUserPreferences(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
