using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entites.Common.Auditing;
public interface IAuditedEntity : IHasCreationTime, IHasModificationTime, IHasDeletionTime
{

}