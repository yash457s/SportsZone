using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class Categories
    {
        public string CatId { get; set; }
        public string CatName { get; set; }
        public string ProId { get; set; }
        public string CatDescription { get; set; }

        public virtual Product Pro { get; set; }
    }
}
