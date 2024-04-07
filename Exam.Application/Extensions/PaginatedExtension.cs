using Exam.Application.RequestParameters;
using Exam.Application.ResponseModels.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Extensions;
public static class PaginatedExtension
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, Pagination pagination) where TDestination : class
    => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pagination.PageNumber, pagination.PageSize);

    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IEnumerable<TDestination> list, Pagination pagination) where TDestination : class
    => PaginatedList<TDestination>.CreateAsync(list, pagination.PageNumber, pagination.PageSize);

}
