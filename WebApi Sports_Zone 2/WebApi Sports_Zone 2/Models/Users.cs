using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi_Sports_Zone_2.Models
{
    public partial class Users
    {
        public Users()
        {
            UserAddresses = new HashSet<UserAddresses>();
            UserMobileNumbers = new HashSet<UserMobileNumbers>();
        }

        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual CustomerInfo CustomerInfo { get; set; }
        public virtual ICollection<UserAddresses> UserAddresses { get; set; }
        public virtual ICollection<UserMobileNumbers> UserMobileNumbers { get; set; }
    }
}
