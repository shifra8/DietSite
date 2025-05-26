using Azure.Core;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interfaces;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController: ControllerBase
    {
        private readonly IService<CustomerDto> _service;
        private readonly IConfiguration _config;

        public SignUpController(IService<CustomerDto> service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpPost]
        public IActionResult Post([FromForm] CustomerDto customer)
        {
            if (customer == null)
                return BadRequest("Invalid customer data.");
            if (customer.Role == eRole.USER)
            {
                if (customer.Height == null || customer.Weight == null || customer.Height <= 0 || customer.Weight <= 0)
                    return BadRequest("Users must provide valid height and weight.");
            }
            else
            {
                customer.Height = 0;
                customer.Weight = 0;
            }


            if (customer == null)
                return BadRequest("Invalid customer data.");
            var path = Path.Combine(Environment.CurrentDirectory, "Images//", customer.fileImage.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                customer.fileImage.OpenReadStream().CopyTo(stream);
            }

            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //זה של המורה
            //    stream.CopyTo(stream);

            //}
            _service.AddItem(customer);
            return Ok("Customer added successfully.");
        }
    }
}
