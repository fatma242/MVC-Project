using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using E_commerceWebSite.Validators;

namespace E_commerceWebSite.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MinLength(4, ErrorMessage = "Name must be at least 4 characters")]
        [MaxLength(25, ErrorMessage = "Name must be at most 25 characters")]
        [UniqueProduct(ErrorMessage = "Product Name is Exist!!")]
        public string Name { get; set; }
        [Range(0, 100, ErrorMessage = "Qunatity must between 0 & 100")]
        public int Quantity { get; set; }
        [Range(0, 100000, ErrorMessage = "Price must between 0 & 100000")]
        public double Price { get; set; }
        [RegularExpression(@"\w*\.(png|jpg)", ErrorMessage = "Image extensions should be png or jpg only")]
        public string Image { get; set; }
        [ForeignKey("Seller")]
        public int SellerID { get; set; }
        public virtual Seller? Seller { get; set; }
    }
}
