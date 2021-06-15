using System;
using System.Collections.Generic;

namespace SportsZone2.Models
{
    public partial class UserLogin
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        public virtual Users User { get; set; }
    }
}
