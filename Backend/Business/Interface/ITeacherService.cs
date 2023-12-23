using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ITeacherService
    {
        Teacher Get(string id);
        IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> filter = null);
        Guid Add(Teacher entity);
        Guid Update(Teacher entity);
        Guid Delete(Teacher entity);
    }
}
