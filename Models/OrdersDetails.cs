using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class OrdersDetails
    {
        public string OrderId { get; set; }
        public string CusId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }

        public virtual CustomerInfo Cus { get; set; }
    }
}
