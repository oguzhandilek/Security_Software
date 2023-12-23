using Entity.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IClassService
    {
        Class Get(string id);
        IQueryable<Class> GetList(Expression<Func<Class, bool>> filter = null);
        Guid Add(Class entity);
        Guid Update(Class entity);
        Guid Delete(Class entity);
    }
}
