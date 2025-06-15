//using Common.Dto;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Service.Interfaces;
//using System;
//using System.Collections.Generic;
//using Repository.Entities;
//using Common.Dto.Common.Dto;

//namespace MyProject.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IService<FoodPreferencesDto> _service;
//        private readonly IFoodPreferenceService _foodPreferenceService;

//        public ProductController(IService<FoodPreferencesDto> service, IFoodPreferenceService foodPreferenceService)
//        {
//            _service = service;
//            _foodPreferenceService = foodPreferenceService;
//        }

//        [HttpGet]
//        [Authorize(Roles = "ADMIN, WORKER")]
//        public ActionResult<List<FoodPreferencesDto>> Get()
//        {
//            try
//            {
//                return Ok(_service.GetAll());
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpGet("{id}")]
//        [Authorize]
//        public ActionResult<FoodPreferencesDto> Get(int id)
//        {
//            try
//            {
//                var product = _service.GetById(id);
//                if (product == null)
//                    return NotFound($"Product with ID {id} not found");

//                return Ok(product);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpPost]
//        [Authorize(Roles = "ADMIN")]
//        public ActionResult<FoodPreferencesDto> Post([FromForm] FoodPreferencesDto product)
//        {
//            try
//            {
//                var created = _service.AddItem(product);
//                return CreatedAtAction(nameof(Get), new { id = created.CustomerId }, created);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpPut("{id}")]
//        [Authorize(Roles = "ADMIN")]
//        public IActionResult Put(int id, [FromForm] FoodPreferencesDto product)
//        {
//            if (id != product.CustomerId)
//                return BadRequest("ID mismatch");

//            try
//            {
//                _service.UpdateItem(id, product);
//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        [HttpDelete("{id}")]
//        [Authorize(Roles = "ADMIN")]
//        public IActionResult Delete(int id)
//        {
//            try
//            {
//                _service.DeleteItem(id);
//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }

//        // פונקציה לקבלת רשימת מאכלים אהובים ושנואים
//        [HttpPost("preferences")]
//        [Authorize]
//        public IActionResult SubmitPreferences([FromForm] FoodPreferencesDto dto)
//        {
//            try
//            {
//                int userId = int.Parse(User.FindFirst("id").Value); // שלוף מזהה משתמש מתוך הטוקן
//                _foodPreferenceService.SaveUserPreferences(dto, userId);
//                return Ok("Preferences saved");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }
//    }
//}



using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;




namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<ProductDto> _service;

        public ProductController(IService<ProductDto> service)
        {
            _service = service;
        }

        [HttpGet]
       // [Authorize(Roles = "ADMIN,WORKER")]
        public ActionResult<List<ProductDto>> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ProductDto> Get(int id)
        {
            try
            {
                var product = _service.GetById(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found");

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ActionResult<ProductDto> Post([FromForm] ProductDto product)
        {
            try
            {
                var created = _service.AddItem(product);
                return CreatedAtAction(nameof(Get), new { id = created.ProductId }, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Put(int id, [FromForm] ProductDto product)
        {
            if (id != product.ProductId)
                return BadRequest("ID mismatch");

            try
            {
                _service.UpdateItem(id, product);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteItem(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

