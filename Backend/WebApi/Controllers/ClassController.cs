using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Interface;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : BaseController
    {
        private IClassService classService;
        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public string Add(Class entity)
        {
            loggerHelper.CreateLog("Class/Add", $"Classname: {entity.ClassName}");
            return classService.Add(entity).ToString();
        }

        [HttpPut]
        [Route("Update")]
        public string Update(Class entity) => classService.Update(entity).ToString();

        [HttpDelete]
        [Route("Delete")]
        public string Delete(string id) 
            => classService.Delete(new Entity.Models.Class() { Id = Guid.Parse(id)}).ToString();

        [HttpGet]
        [Route("Get")]
        public Class Get(string id)
                => classService.Get(id);

        [HttpGet]
        [Route("GetList")]
        [Authorize]
        public IQueryable<Class> GetList()
        => classService.GetList();
    }
}

