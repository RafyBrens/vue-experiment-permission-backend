using Microsoft.AspNetCore.Mvc;
using RequestPermission.Business.Entities.DTO;
using RequestPermission.Contracts.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestPermission.Api.Controllers
{
    [Route("permission")]
    [ApiController]
    public class PermissionController: ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionController(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        [HttpPost]
        public async Task<object> SavePermission([FromBody] PermissionRequest entity)
        {
            return new { Id = await _permissionRepository.Insert(entity) };
        }

        [HttpPatch]
        public async Task UpdateEntity([FromBody] PermissionRequest entity)
        {
            await _permissionRepository.Update(entity);
        }

        [HttpDelete("{id}")]
        public async Task DeletePermission(Guid id)
        {
            await _permissionRepository.DeleteById(id);
        }


        [HttpGet]
        public async Task<object> GetPermission(Guid id)
        {
            return new { Id = await _permissionRepository.GetById(id) };
        }

        [HttpGet("all")]
        public async Task<IEnumerable<PermissionView>> GetAll()
        {
            return await this._permissionRepository.GetAll();
        }

    }
}
