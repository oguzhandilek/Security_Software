using Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interface;
using Entity.Models;
using System.Linq.Expressions;

namespace Business.Manager
{
    public class LessonManager: ILessonService
    {
        private readonly ILessonDal lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            this.lessonDal = lessonDal;
        } 
        
        public Lesson Get(string id)
            => this.lessonDal.Get(x => x.Id == Guid.Parse(id));

        public Guid Delete(Lesson entity)
            => this.lessonDal.Delete(entity);

        public Guid Add(Lesson entity)
            => this.lessonDal.Add(entity);

        public Guid Update(Lesson entity)
            => this.lessonDal.Update(entity);

        public IQueryable<Lesson> GetList(Expression<Func<Lesson, bool>> filter = null)
            => this.lessonDal.GetList(filter);

    }
}
