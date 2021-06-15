using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_App.Models
{
    public partial class Payment
    {
        public string PaymentId { get; set; }
        public string CusId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual CustomerInfo Cus { get; set; }
    }
}
