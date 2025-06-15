using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interfaces;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IService<CustomerDto> _service;
        private readonly IConfiguration _config;

        public SignUpController(IService<CustomerDto> service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpPost]
        public IActionResult Post([FromForm] SignUpDto signUpDto)
        {
            if (signUpDto == null)
                return BadRequest("Invalid sign-up data.");

            if (signUpDto.Role == eRole.USER)
            {
                if (signUpDto.Height == null || signUpDto.Weight == null || signUpDto.Height <= 0 || signUpDto.Weight <= 0)
                    return BadRequest("Users must provide valid height and weight.");
            }
            else
            {
                signUpDto.Height = 0;
                signUpDto.Weight = 0;
            }

            // שמירת תמונה בתיקיה
            string imageDirectory = Path.Combine(Environment.CurrentDirectory, "Images");
            if (!Directory.Exists(imageDirectory))
                Directory.CreateDirectory(imageDirectory);

            string imagePath = Path.Combine(imageDirectory, $"{signUpDto.FullName}.jpg");

            byte[]? imageBytes = null;
            if (signUpDto.FileImage != null)
            {
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    signUpDto.FileImage.CopyTo(stream);
                }

                using (var ms = new MemoryStream())
                {
                    signUpDto.FileImage.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }
            }

            // בניית רשימת מאכלים אהובים/שנואים
            var likedFoodPreferences = signUpDto.LikedProductIds?
                .Select(id => new CustomerFoodPreference
                {
                    ProductId = id,
                    IsLiked = true
                }).ToList();

            var dislikedFoodPreferences = signUpDto.DislikedProductIds?
                .Select(id => new CustomerFoodPreference
                {
                    ProductId = id,
                    IsLiked = false
                }).ToList();

            var allFoodPreferences = new List<CustomerFoodPreference>();
            if (likedFoodPreferences != null)
                allFoodPreferences.AddRange(likedFoodPreferences);
            if (dislikedFoodPreferences != null)
                allFoodPreferences.AddRange(dislikedFoodPreferences);

            // יצירת CustomerDto
            var customer = new CustomerDto
            {
                FullName = signUpDto.FullName,
                Phone = signUpDto.Phone,
                Role = signUpDto.Role,
                Password = signUpDto.Password,
                Email = signUpDto.Email,
                Height = signUpDto.Height,
                Weight = signUpDto.Weight,
                ImagePath = imageBytes,
                FileImage = signUpDto.FileImage
            };

            _service.AddItem(customer);

            return Ok("Customer added successfully.");
        }
    }
}
