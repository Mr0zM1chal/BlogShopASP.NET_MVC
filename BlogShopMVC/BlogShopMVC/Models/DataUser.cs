using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogShopMVC.Models
{
    public class DataUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string Mobile { get; set; }
        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        public string Email { get; set; }
    }
}