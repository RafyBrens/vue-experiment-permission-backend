using RequestPermission.Business.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestPermission.Contracts.Contract
{
    public interface IPermissionRepository
    {
        public Task<Guid> Insert(PermissionRequest permissionRequest);
        public Task Update(PermissionRequest permissionRequest);
        public Task DeleteById(Guid Id);
        public Task<PermissionView> GetById(Guid Id);
        public Task<IEnumerable<PermissionView>> GetAll();

    }
}
