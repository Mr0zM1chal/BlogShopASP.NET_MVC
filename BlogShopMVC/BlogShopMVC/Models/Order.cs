using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepBlog.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Press first name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Press last name")]
        [StringLength(40)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Press address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Press city")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "Press postcode")]
        [StringLength(6)]
        public string Postcode { get; set; }
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Press category name")]
        [StringLength(100)]
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