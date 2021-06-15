using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class Cart
    {
        public string CarId { get; set; }
        public string ProId { get; set; }
        public string CusId { get; set; }
        public string Quantity { get; set; }

        public virtual CustomerInfo Cus { get; set; }
        public virtual Product Pro { get; set; }
    }
}
