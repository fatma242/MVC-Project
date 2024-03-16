using E_commerceWebSite.Models;
using E_commerceWebSite.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_commerceWebSite.Validators
{
    public class UniqeNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string? name = value?.ToString();
            WebSiteContext Db = new WebSiteContext();
            Client client = Db.Clients.FirstOrDefault(c => c.Name == name);
            if (client == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name is already Exist!!");
        }
    }
}
