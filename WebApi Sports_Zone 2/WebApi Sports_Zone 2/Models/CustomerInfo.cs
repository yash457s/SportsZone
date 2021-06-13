using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi_Sports_Zone_2.Models
{
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            Cart = new HashSet<Cart>();
            Invoice = new HashSet<Invoice>();
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
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
