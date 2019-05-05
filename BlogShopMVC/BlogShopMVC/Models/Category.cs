using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepBlog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Press category name")]
        [StringLength(100)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string IconFileName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}