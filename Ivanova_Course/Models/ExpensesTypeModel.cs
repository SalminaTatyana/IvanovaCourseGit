using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core;

namespace Web.Models
{
    public class ExpensesTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public static class ExpensesTypesMapper
    {


        public static MapperConfiguration MapperConfigurationExpenseType
        {
            get => new MapperConfiguration(cfg =>
                    cfg.CreateMap<ExpenseType, ExpensesTypes>()
                   
                    .ForMember(request => request.Id, conf => conf.MapFrom(filter => filter.Id))
                    .ForMember(request => request.Name, conf => conf.MapFrom(filter => filter.Name))
                    .ForMember(request => request.Description, conf => conf.MapFrom(filter => filter.Description))


            );
        }
        public static IQueryable<ExpensesTypes> ExpensesTypesEntities(this IQueryable<ExpenseType> query)
            => query.ProjectTo<ExpensesTypes>(MapperConfigurationExpenseType);

    }
}
