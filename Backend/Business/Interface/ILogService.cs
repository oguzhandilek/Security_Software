using Entity.Models;
using Entity.Models.Log;
using Entity.Shared;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ILogService
    {
        Log Get(string id);
        IQueryable<Log> GetList(Expression<Func<Log, bool>> filter = null);
        Guid Add(Log entity);
        Guid Update(Log entity);
        Guid Delete(Log entity);
        ProcessResult<IQueryable<LogView>> Search(LogSearchCriteria criteria);
    }
}
