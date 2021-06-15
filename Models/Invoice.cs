using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class Invoice
    {
        public string InvId { get; set; }
        public string CusId { get; set; }
        public DateTime? Date { get; set; }
        public string ProId { get; set; }
        public int? Quantity { get; set; }

        public virtual CustomerInfo Cus { get; set; }
        public virtual Product Pro { get; set; }
    }
}
