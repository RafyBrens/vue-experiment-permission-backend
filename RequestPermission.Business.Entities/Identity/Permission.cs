using RequestPermission.Contracts.Contract;
using System;

namespace RequestPermission.Business.Entities.Identity
{
    public class Permission : EntityBase, IAuditableEntity
    {
        public DateTime RequestDate { get; set; }
        public Employee Employees { get; set; }
        public Guid EmployeeId { get; set; }
        public PermissionType PermissionTypes { get; set; }
        public Guid PermissionTypeId { get; set; }     
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
