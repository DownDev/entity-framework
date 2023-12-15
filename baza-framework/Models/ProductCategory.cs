using System.ComponentModel.DataAnnotations;

namespace baza_framework.Models
{
    public class ProductCategory
    {
        [Key]
        public long CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
