using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            RolesPermissions = new HashSet<RolesPermissions>();
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RolesPermissions> RolesPermissions { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
