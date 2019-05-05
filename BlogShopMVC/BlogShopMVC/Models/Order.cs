using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepBlog.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Comment{ get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Price { get; set; }

        public ICollection<PositionOfTheOrder> PositionOfTheOrder;

    }
}
public enum OrderStatus
{
    New,
    Done
}