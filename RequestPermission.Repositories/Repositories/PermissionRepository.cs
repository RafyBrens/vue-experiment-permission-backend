using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequestPermission.Business.Entities.DTO;
using RequestPermission.Business.Entities.Identity;
using RequestPermission.Contracts.Contract;
using RequestPermission.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestPermission.Repositores.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly RequestPermissionContext _context;
        private readonly IMapper _mapper;

        public PermissionRepository(RequestPermissionContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task DeleteById(Guid Id)
        {
            var data = await _context.Permissions.Where(x => x.Id == Id).FirstOrDefaultAsync();
            _context.Permissions.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PermissionView>> GetAll()
        {
            var permissions = await _context.Permissions.Include(x => x.Employees).Include(x => x.PermissionTypes).ToListAsync();
            var data = _mapper.Map<List<PermissionView>>(permissions);
            return data;
        }

        public async Task<PermissionView> GetById(Guid Id)
        {
            var permissions = await _context.Permissions.Include(x => x.Employees).Include(x => x.PermissionTypes).Where(x => x.Id == Id).FirstOrDefaultAsync();
            var data = _mapper.Map<PermissionView>(permissions);
            return data;
        }

        public async Task<Guid> Insert(PermissionRequest permissionRequest)
        {
            var data = await  _context.Employees.AddAsync(new Employee { Name = permissionRequest.Employee.Name, LastName = permissionRequest.Employee.LastName });  
            var dataResponse = await _context.PermissionTypes.AddAsync(new PermissionType { Description = permissionRequest.PermissionType.Description });
            var re =  await _context.Permissions.AddAsync(new Permission { RequestDate = permissionRequest.RequestDate, EmployeeId = data.Entity.Id ,PermissionTypeId = dataResponse.Entity.Id });
            await _context.SaveChangesAsync();
            return re.Entity.Id;
        }

        public async Task Update(PermissionRequest permissionRequest)
        {
            var permissions = await _context.Permissions.Where(x => x.Id == permissionRequest.Id).Include(x => x.PermissionTypes).Include(x => x.Employees).FirstOrDefaultAsync();
            permissions.RequestDate = permissionRequest.RequestDate;
            permissions.Employees.Name = permissionRequest.Employee.Name;
            permissions.Employees.LastName = permissionRequest.Employee.LastName;
            permissions.PermissionTypes.Description = permissionRequest.PermissionType.Description;
            _context.Permissions.Update(permissions);
            await _context.SaveChangesAsync();
        }
    }
}
