using Entity.Models;
using Business.Interface;
using Microsoft.Extensions.Primitives;
using Entity.Models.Log;

namespace WebApi.Helpers
{
	public class LoggerHelper
	{
		private IHttpContextAccessor _httpContextAccessor;
		private Log log;
		private DateTimeHelper _dateTimeHelper;
		private ILogService _logService;

		public LoggerHelper(ILogService logService ,IHttpContextAccessor httpContextAccessor)
		{
			_logService= logService;
			_httpContextAccessor = httpContextAccessor;
			_dateTimeHelper = new();
			log = new Log();
		}
		public void CreateLog(string url, string operation, int userId = -1)
		{
			log.UserID = userId;
			log.IP4 = _httpContextAccessor.HttpContext.Request.Host.Value;
			log.IP6 = "";
			log.Url = url;
			log.Operation= operation;
			log.CreatedDateTime = _dateTimeHelper.GetCurrentDateTime();
			log.Status = (int)LogStatus.Active;
			_logService.Add(log);
		}
		private string GetValue(string key)
		{
			if (_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(key, out StringValues headerValues) && headerValues.Any())
			{
				return headerValues.First();
			}
			return string.Empty;
		}
	}
}
