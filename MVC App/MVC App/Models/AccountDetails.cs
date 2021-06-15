using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVC_App.Models
{
    public partial class AccountDetails
    {
        public string AccName { get; set; }
        public string AccPassword { get; set; }
        public string AccPhone { get; set; }
        public string AccAddress { get; set; }
        public string AccEmail { get; set; }
    }
}
