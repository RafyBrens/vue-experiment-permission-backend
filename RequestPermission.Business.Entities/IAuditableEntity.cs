﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RequestPermission.Contracts.Contract
{
    public interface IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
