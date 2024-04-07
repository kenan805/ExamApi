using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.ResponseModels.Results;
public interface IResponseResult
{
    public int StatusCode { get; }
    public string[] Message { get; }
}