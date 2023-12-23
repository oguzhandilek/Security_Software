using Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
	public class BaseController : ControllerBase
	{
		public LoggerHelper loggerHelper;
		IHttpContextAccessor httpContextAccessor;

		public BaseController()
		{
			httpContextAccessor= new HttpContextAccessor();
			ILogService logService = httpContextAccessor.HttpContext.RequestServices.GetService<ILogService>();
			loggerHelper = new LoggerHelper(logService, httpContextAccessor);
		}
	}
}
