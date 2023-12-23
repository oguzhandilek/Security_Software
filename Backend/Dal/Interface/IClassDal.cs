using Entity.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;

namespace Dal.Interface
{
    public interface IClassDal: IEntityRepository<Class>
    {
    }
}
