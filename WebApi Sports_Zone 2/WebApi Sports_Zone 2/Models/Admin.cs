using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi_Sports_Zone_2.Models
{
    public partial class Admin
    {
        public string AdmId { get; set; }
        public string AdmName { get; set; }
        public string AdmEmail { get; set; }
        public string AdmPassword { get; set; }
    }
}
