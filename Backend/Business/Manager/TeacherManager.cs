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
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal teacherDal;

        public TeacherManager(ITeacherDal teacherDal)
        {
            this.teacherDal = teacherDal;
        }

        public Teacher Get(string id)
            => this.teacherDal.Get(x => x.Id == Guid.Parse(id));

        public Guid Delete(Teacher entity)
            => this.teacherDal.Delete(entity);

        public Guid Add(Teacher entity)
            => this.teacherDal.Add(entity);

        public Guid Update(Teacher entity)
            => this.teacherDal.Update(entity);

        public IQueryable<Teacher> GetList(Expression<Func<Teacher, bool>> filter = null)
            => this.teacherDal.GetList(filter);

    }
}
