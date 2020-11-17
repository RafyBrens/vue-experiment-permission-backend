using AutoMapper;
using RequestPermission.Business.Entities.DTO;
using RequestPermission.Business.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestPermission.Business.Entities.Mappers
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<Permission, PermissionView>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Employees.Name))
                .ForMember(x => x.LastName, y => y.MapFrom(s => s.Employees.LastName)).ReverseMap();
        }
    }
}
