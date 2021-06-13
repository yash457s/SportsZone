using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi_Sports_Zone_2.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            Categories = new HashSet<Categories>();
            Feedback = new HashSet<Feedback>();
            Invoice = new HashSet<Invoice>();
        }

        public string ProId { get; set; }
        public string ProName { get; set; }
        public string ProDescription { get; set; }
        public decimal? ProPrice { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
