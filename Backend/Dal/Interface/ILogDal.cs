using Entity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
using Entity.Models.Log;

namespace Dal.Interface
{
    public interface ILogDal: IEntityRepository<Log>
    {
    }
}
