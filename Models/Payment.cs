using System;
using System.Collections.Generic;

namespace SportsZone2.Models
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
