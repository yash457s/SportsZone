using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class Users
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public string UserMobile { get; set; }

        public virtual CustomerInfo CustomerInfo { get; set; }
        public virtual UserLogin UserLogin { get; set; }
    }
}
