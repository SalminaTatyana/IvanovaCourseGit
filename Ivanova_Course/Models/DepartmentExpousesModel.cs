using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class DepartmentExpouses
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? Sum { get; set; }
        public int Value { get; set; }
        public int? EndMouthSum { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
    public static class DepartmentExpousesMapper
    {
        public static MapperConfiguration MapperConfigurationDepartmentExpouses
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<DepartmentExpousesView, DepartmentExpouses>()

                    .ForMember(request => request.DepartmentId, conf => conf.MapFrom(filter => filter.DepartmentId))
                    .ForMember(request => request.DepartmentName, conf => conf.MapFrom(filter => filter.DepartmentName))
                    .ForMember(request => request.Month, conf => conf.MapFrom(filter => filter.Month))
                    .ForMember(request => request.Year, conf => conf.MapFrom(filter => filter.Year))
                    .ForMember(request => request.Sum, conf => conf.MapFrom(filter => filter.Sum))
                    .ForMember(request => request.Value, conf => conf.MapFrom(filter => filter.Value))
                    .ForMember(request => request.EndMouthSum, conf => conf.MapFrom(filter => filter.EndMouthSum))


            );
        }
        public static IQueryable<DepartmentExpouses> DepartmentExpousesEntities(this IQueryable<DepartmentExpousesView> query)
            => query.ProjectTo<DepartmentExpouses>(MapperConfigurationDepartmentExpouses);

    }
}
