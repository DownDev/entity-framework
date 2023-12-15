using System.ComponentModel.DataAnnotations;

namespace baza_framework.Models
{
    public class OrderDetail
    {
        [Key]
        public long OrderDetailID { get; set; }

        public double Price { get; set; }
        public double Quantity { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }
    }
}
