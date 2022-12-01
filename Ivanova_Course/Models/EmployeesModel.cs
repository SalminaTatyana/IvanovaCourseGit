using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core;

namespace Web.Models
{
    public class EmployeesModel
    {
        public List<Employees> Employees { get; set; }
        public List<Department> Departments { get; set; }
    }
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentEmployeesCount { get; set; }
    }
    public static class EmployeesMapper
    {


        public static MapperConfiguration MapperConfigurationEmployees
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<Employee, Employees>()
                    .ForMember(request => request.DepartmentId, conf => conf.MapFrom(filter => filter.DepartmentId))
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.FirstName, conf => conf.MapFrom(filter => filter.FirstName))
                    .ForMember(request => request.LastName, conf => conf.MapFrom(filter => filter.LastName))
                    .ForMember(request => request.Patronymic, conf => conf.MapFrom(filter => filter.Patronymic))

            );
        }
        public static IQueryable<Employees> EmployeesEntities(this IQueryable<Employee> query)
            => query.ProjectTo<Employees>(MapperConfigurationEmployees);
        public static MapperConfiguration MapperConfigurationEmployeesView
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<EmployeesView, Employees>()
                    .ForMember(request => request.DepartmentName, conf => conf.MapFrom(filter => filter.DepartmentName))
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.FirstName, conf => conf.MapFrom(filter => filter.FirstName))
                    .ForMember(request => request.LastName, conf => conf.MapFrom(filter => filter.LastName))
                    .ForMember(request => request.Patronymic, conf => conf.MapFrom(filter => filter.Patronymic))
                    .ForMember(request => request.DepartmentEmployeesCount, conf => conf.MapFrom(filter => filter.DepartmentEmployeesCount))

            );
        }
        public static IQueryable<Employees> EmployeesViewEntities(this IQueryable<EmployeesView> query)
            => query.ProjectTo<Employees>(MapperConfigurationEmployeesView);
    }
}
