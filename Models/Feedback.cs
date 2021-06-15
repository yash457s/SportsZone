using System;
using System.Collections.Generic;

namespace SportsZone2.Models
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
