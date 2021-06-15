using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            Cart = new HashSet<Cart>();
            OrdersDetails = new HashSet<OrdersDetails>();
            Payment = new HashSet<Payment>();
        }

        public string CusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual Users Cus { get; set; }
        public virtual Feedback Feedback { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
