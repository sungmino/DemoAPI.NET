using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }
    }

    public class ProductDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}