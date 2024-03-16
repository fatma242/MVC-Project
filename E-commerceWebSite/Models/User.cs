using System.ComponentModel.DataAnnotations;
using E_commerceWebSite.Validators;

namespace E_commerceWebSite.Models
{
    public class User
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
        public string Type { get; set; }
        public List<Product>? cart { get; set; }

    }
}
