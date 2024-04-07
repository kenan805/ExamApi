using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entites.Common;
public interface IEntity<T>
{
    public T Id { get; set; }
}