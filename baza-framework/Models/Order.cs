using System.ComponentModel.DataAnnotations;

namespace baza_framework.Models
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }

        [Key]
        public long OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
        public DateTime? ShipDate { get; set; }
        public double Discount { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
