using Dal.Interface;
using Entity.DataAccess;
using Entity.Models;
using Entity.Models.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DIRepository
{
    public class LogDal: EntityRepositoryBase<Log, Entity.Context.MyDbContext>, ILogDal
    {
    }
}
