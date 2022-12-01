using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core;

namespace Web.Models
{
    public class LimitsModel
    {
        public List<Limits> Limits;
        public List<Department> Departments;
    }
    public class Limits
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public int DepartmentEmployeesCount { get; set; }

    }
    public static class LimitsMapper
    {


        public static MapperConfiguration MapperConfigurationLimits
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<Limit, Limits>()
                    .ForMember(request => request.DepartmentId, conf => conf.MapFrom(filter => filter.DepartmentId))
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.Value, conf => conf.MapFrom(filter => filter.Value))
                    .ForMember(request => request.Date, conf => conf.MapFrom(filter => filter.Date))

            );
        }
        public static IQueryable<Limits> LimitsEntities(this IQueryable<Limit> query)
            => query.ProjectTo<Limits>(MapperConfigurationLimits);
        public static MapperConfiguration MapperConfigurationLimitsView
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<LimitsView, Limits>()
                    .ForMember(request => request.DepartmentName, conf => conf.MapFrom(filter => filter.DepartmentName))
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.Value, conf => conf.MapFrom(filter => filter.Value))
                    .ForMember(request => request.Date, conf => conf.MapFrom(filter => filter.Date))
                    .ForMember(request => request.DepartmentEmployeesCount, conf => conf.MapFrom(filter => filter.DepartmentEmployeesCount))

            );
        }
        public static IQueryable<Limits> LimitsViewEntities(this IQueryable<LimitsView> query)
            => query.ProjectTo<Limits>(MapperConfigurationLimitsView);
    }
}
