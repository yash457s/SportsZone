using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_App.Models
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
