using Entity.Models;
using Entity.Shared;
using Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entity.Models.Log;

namespace WebApi.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class LogController : BaseController
	{
		private ILogService _logService;
		public LogController(ILogService logService) { 
			_logService= logService;
		}

		[Route("Search")]
		[HttpPost]
		public ProcessResult<IQueryable<LogView>> Search([FromBody] LogSearchCriteria criteria)
		{
			return _logService.Search(criteria);
		}

		[Route("Delete")]
		[HttpDelete]
		public Guid Delete(string id)
		{
			Log log=new() { Id = Guid.Parse(id)};
			return _logService.Delete(log);
		}
	}
}


