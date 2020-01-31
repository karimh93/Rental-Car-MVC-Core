using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class RolesPermissions
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public virtual Permissions Permission { get; set; }
        public virtual Roles Role { get; set; }
    }
}
