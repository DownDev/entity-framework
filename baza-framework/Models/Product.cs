using System.ComponentModel.DataAnnotations;

namespace baza_framework.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string UnitName { get; set; }
        public int UnitScale { get; set; }
        public long InStock { get; set; }
        public double Price { get; set; }
        public double DiscontinuedPrice { get; set; }

        public ProductCategory Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

