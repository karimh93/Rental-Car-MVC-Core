using System;
using System.Collections.Generic;

namespace CarRent.Entities
{
    public partial class Permissions
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
