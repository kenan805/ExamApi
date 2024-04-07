using AutoMapper;
using Exam.Application.Mapping.Converter;
using Exam.Application.ResponseModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Mapping.Common;
public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
                .ConvertUsing(typeof(PaginatedListTypeConverter<,>));
    }
}
