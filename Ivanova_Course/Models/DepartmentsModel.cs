using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core;

namespace Web.Models
{
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeesNumber { get; set; }
    }
    public static class DepartmentsMapper
    {


        public static MapperConfiguration MapperConfigurationDepartments
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<Department, Departments>()
                    .ForMember(request => request.Name, conf => conf.MapFrom(filter => filter.Name))
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.EmployeesNumber, conf => conf.MapFrom(filter => filter.EmployeesNumber))

            );
        }
        public static IQueryable<Departments> DepartmentsEntities(this IQueryable<Department> query)
            => query.ProjectTo<Departments>(MapperConfigurationDepartments);

    }
}
