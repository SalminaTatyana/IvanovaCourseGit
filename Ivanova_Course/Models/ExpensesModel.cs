using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core;

namespace Web.Models
{
    public class ExpensesModel
    {
        public List<Expense> Expenses { get; set; }
    }
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
                    .ForMember(request => request.DepartmentName, conf => conf.MapFrom(filter => filter.Employee.Department.Name))
                    .ForMember(request => request.DepartmentEmployeesNumber, conf => conf.MapFrom(filter => filter.Employee.Department.EmployeesNumber))
                    .ForMember(request => request.Sum, conf => conf.MapFrom(filter => filter.Sum))
                    .ForMember(request => request.Date, conf => conf.MapFrom(filter => filter.Date))
            );
        }
        public static IQueryable<Expenses> ExpensesEntities(this IQueryable<Expense> query)
            => query.ProjectTo<Expenses>(MapperConfigurationExpenses);

    }
}
