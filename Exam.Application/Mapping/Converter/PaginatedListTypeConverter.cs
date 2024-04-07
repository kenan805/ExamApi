using AutoMapper;
using Exam.Application.ResponseModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Mapping.Converter;
public class PaginatedListTypeConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDestination>>
{
    public PaginatedList<TDestination> Convert(PaginatedList<TSource> source, PaginatedList<TDestination> destination, ResolutionContext context)
    {
        var items = context.Mapper.Map<List<TSource>, List<TDestination>>(source.Items.ToList());
        var paginatedList = new PaginatedList<TDestination>(items, source.TotalCount, source.PageNumber, source.PageSize);

        return paginatedList;
    }
}
