using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_App.Models
{
    public partial class Feedback
    {
        public string CusId { get; set; }
        public string ProId { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }

        public virtual CustomerInfo Cus { get; set; }
        public virtual Product Pro { get; set; }
    }
}
