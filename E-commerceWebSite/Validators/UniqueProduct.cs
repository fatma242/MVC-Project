using System.ComponentModel.DataAnnotations;
using E_commerceWebSite.Models;
using E_commerceWebSite.Entities;

namespace E_commerceWebSite.Validators
{
    public class UniqueProduct : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string? name = value?.ToString();
            WebSiteContext Db = new WebSiteContext();
            Product product = Db.Products.FirstOrDefault(c => c.Name == name);
            if (product == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name is already Exist!!");
        }
    }
}
