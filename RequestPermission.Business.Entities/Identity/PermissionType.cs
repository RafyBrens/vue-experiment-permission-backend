using RequestPermission.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestPermission.Business.Entities.Identity
{
    public  class PermissionType : EntityBase, IAuditableEntity
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }

    }
}
