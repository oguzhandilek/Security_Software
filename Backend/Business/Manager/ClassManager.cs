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
    public class ClassManager : IClassService
    {
        private readonly IClassDal classDal;

        public ClassManager(IClassDal classDal)
        {
            this.classDal = classDal;
        }

        public Class Get(string id)
            => this.classDal.Get(x => x.Id == Guid.Parse(id));

        public Guid Delete(Class entity)
            => this.classDal.Delete(entity);

        public Guid Add(Class entity)
            => this.classDal.Add(entity);

        public Guid Update(Class entity)
            => this.classDal.Update(entity);

        public IQueryable<Class> GetList(Expression<Func<Class, bool>> filter = null)
            => this.classDal.GetList(filter);

    }
}
