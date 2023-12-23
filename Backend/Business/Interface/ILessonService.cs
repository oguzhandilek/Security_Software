using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ILessonService
    {
        Lesson Get(string id);
        IQueryable<Lesson> GetList(Expression<Func<Lesson, bool>> filter = null);
        Guid Add(Lesson entity);
        Guid Update(Lesson entity);
        Guid Delete(Lesson entity);
    }
}
