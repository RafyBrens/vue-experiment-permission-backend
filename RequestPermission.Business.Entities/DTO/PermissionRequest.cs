using System;
using System.Collections.Generic;
using System.Text;

namespace RequestPermission.Business.Entities.DTO
{
    public class PermissionRequest
    {
        public Guid Id { get; set; }
        public EmployeeRequest Employee { get; set; }
        public PermissionTypeRequest PermissionType { get; set; }
        public DateTime RequestDate { get; set; }

        public class EmployeeRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
        }
        public class PermissionTypeRequest
        {
            public string Description { get; set; }

        }
    }
      


}


