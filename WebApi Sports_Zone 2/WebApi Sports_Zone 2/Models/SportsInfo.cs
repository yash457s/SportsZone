using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi_Sports_Zone_2.Models
{
    public partial class SportsInfo
    {
        public string SpoId { get; set; }
        public string SpoName { get; set; }
        public string SpoCategory { get; set; }
        public string SpoGears { get; set; }
        public string SpoDescription { get; set; }
    }
}
