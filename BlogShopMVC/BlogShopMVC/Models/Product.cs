using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepBlog.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Press product name")]
        [StringLength(100)]
        public string ProductMake { get; set; }
        public string ProductModel { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual Category category { get; set; }
    }
}