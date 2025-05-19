namespace MyProject.Requests
{
    public class CustomerCreateRequest
    {
        public int Id { get; set; }  
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Role { get; set; }
        public string DietType { get; set; }
        public IFormFile Image { get; set; }
    }
}
