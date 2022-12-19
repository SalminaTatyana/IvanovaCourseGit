using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core;

namespace Web.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentEmployeesNumber { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
    }
    public static class ExpensesMapper
    {


        public static MapperConfiguration MapperConfigurationExpenses
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<Expense, Expenses>()
                    .ForMember(request => request.TypeId, conf => conf.MapFrom(filter => filter.TypeId))
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.TypeName, conf => conf.MapFrom(filter => filter.Type.Name))
                    .ForMember(request => request.Date, conf => conf.MapFrom(filter => filter.Date))
                    .ForMember(request => request.EmployeeId, conf => conf.MapFrom(filter => filter.EmployeeId))
                    .ForMember(request => request.FirstName, conf => conf.MapFrom(filter => filter.Employee.FirstName))
                    .ForMember(request => request.LastName, conf => conf.MapFrom(filter => filter.Employee.LastName))
                    .ForMember(request => request.Patronymic, conf => conf.MapFrom(filter => filter.Employee.Patronymic))
                    .ForMember(request => request.DepartmentId, conf => conf.MapFrom(filter => filter.Employee.Department.Id))
                    .ForMember(request => request.DepartmentName, conf => conf.MapFrom(filter => filter.Employee.Department.Name))
                    .ForMember(request => request.DepartmentEmployeesNumber, conf => conf.MapFrom(filter => filter.Employee.Department.EmployeesNumber))
                    .ForMember(request => request.Sum, conf => conf.MapFrom(filter => filter.Sum))
                    .ForMember(request => request.Date, conf => conf.MapFrom(filter => filter.Date))
            );
        }
        public static IQueryable<Expenses> ExpensesEntities(this IQueryable<Expense> query)
            => query.ProjectTo<Expenses>(MapperConfigurationExpenses);

    }
    public static class ExpensesViewMapper
    {


        public static MapperConfiguration MapperConfigurationExpenses
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<ExpensesView, Expenses>()
                    .ForMember(request => request.TypeId, conf => conf.MapFrom(filter => filter.TypeId))
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.TypeName, conf => conf.MapFrom(filter => filter.TypeName))
                    .ForMember(request => request.Date, conf => conf.MapFrom(filter => filter.Date))
                    .ForMember(request => request.EmployeeId, conf => conf.MapFrom(filter => filter.EmployeeId))
                    .ForMember(request => request.FirstName, conf => conf.MapFrom(filter => filter.FirstName))
                    .ForMember(request => request.LastName, conf => conf.MapFrom(filter => filter.LastName))
                    .ForMember(request => request.Patronymic, conf => conf.MapFrom(filter => filter.Patronymic))
                    .ForMember(request => request.DepartmentId, conf => conf.MapFrom(filter => filter.DepartmentId))
                    .ForMember(request => request.DepartmentName, conf => conf.MapFrom(filter => filter.DepartmentName))
                    .ForMember(request => request.DepartmentEmployeesNumber, conf => conf.MapFrom(filter => filter.DepartmentEmployeesNumber))
                    .ForMember(request => request.Sum, conf => conf.MapFrom(filter => filter.Sum))
                    .ForMember(request => request.Date, conf => conf.MapFrom(filter => filter.Date))
            );
        }
        public static IQueryable<Expenses> ExpensesViewEntities(this IQueryable<ExpensesView> query)
            => query.ProjectTo<Expenses>(MapperConfigurationExpenses);

    }
}
