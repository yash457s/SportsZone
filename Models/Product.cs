using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            Categories = new HashSet<Categories>();
            Feedback = new HashSet<Feedback>();
        }

        public string ProId { get; set; }
        public string ProName { get; set; }
        public string ProDescription { get; set; }
        public decimal? ProPrice { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }
    }
}
