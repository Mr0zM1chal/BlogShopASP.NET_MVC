using BlogShopMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepBlog.Models
{
    public class Order
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }

        public virtual ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Press first name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Press last name")]
        [StringLength(40)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Press address")]
        [StringLength(100)]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Press city")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "Press postcode")]
        [StringLength(6)]
        public string Postcode { get; set; }
        [Required(ErrorMessage = "Press mobile number")]
        [StringLength(20)]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Press corectly mobile format")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Press email")]
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