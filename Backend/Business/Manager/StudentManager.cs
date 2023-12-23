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
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            this.studentDal = studentDal;
        }

        public Student Get(string id)
            => this.studentDal.Get(x => x.Id == Guid.Parse(id));

        public Guid Delete(Student entity)
            => this.studentDal.Delete(entity);

        public Guid Add(Student entity)
            => this.studentDal.Add(entity);

        public Guid Update(Student entity)
            => this.studentDal.Update(entity);

        public IQueryable<Student> GetList(Expression<Func<Student, bool>> filter = null)
            => this.studentDal.GetList(filter);

    }
}
