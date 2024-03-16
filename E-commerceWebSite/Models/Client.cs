using System.ComponentModel.DataAnnotations;
using E_commerceWebSite.Validators;



namespace E_commerceWebSite.Models
{
    public class Client 
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(45, ErrorMessage = "Name must be at most 45 characters")]
        [UniqeName(ErrorMessage = "Name is already Exist!!")]
        public string Name { get; set; }
        [MinLength(15, ErrorMessage = "E-mail must be at least 15 charactes")]
        [MaxLength(45, ErrorMessage = "Name must be at most 45 characters")]
        public string Email { get; set; }
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [MaxLength(16, ErrorMessage = "Name must be at most 16 characters")]
        public string Password { get; set; }
        [MinLength(11, ErrorMessage = "PhoneNumber is Invaild!!")]
        [MaxLength(11)]
        public string? PhoneNumber { get; set; }
        [RegularExpression("[a-zA-Z]{5,30}",ErrorMessage ="Address must Contain Characters only between 5 & 30")]
        public string ?Addrees { get; set; }
       
        public static explicit operator User(Client c) 
        {
            return new User
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Password = c.Password,
                Type = "Client"
            };
        }
    }
}
