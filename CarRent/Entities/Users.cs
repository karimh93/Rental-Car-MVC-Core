using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
    }
}
