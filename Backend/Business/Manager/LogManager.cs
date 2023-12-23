using Entity.Context;
using Entity.Models;
using Entity.Shared;
using Business.Interface;
using Dal.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Entity.Models.Log;


namespace Business.Manager
{
	public class LogManager: ILogService
    {
		private ILogDal logDal;
		public LogManager(ILogDal logDal)
		{
			this.logDal = logDal;
		}
		public IQueryable<Log> GetList(Expression<Func<Log, bool>> filter = null)
		=> logDal.GetList(filter);
		public Guid Add(Log log)
		=> logDal.Add(log);
		
		public Guid Delete(Log log) 
			=> logDal.Delete(log);
		
		public Guid Update(Log log)
		=> logDal.Update(log);
		
		public Log Get(string id)
		=> logDal.Get(x=>x.Id==Guid.Parse(id));
		

		public ProcessResult<IQueryable<LogView>> Search(LogSearchCriteria criteria)
		{
			MyDbContext dbContext = new();
			var logs = (from l in dbContext.Logs
								select new LogView
								{
									Id= l.Id,
									UserID= l.UserID,
									UserName= "Admin",
									IP4= l.IP4,
									IP6=l.IP6,
									Url= l.Url,
									Operation=l.Operation,
									CreatedDateTime=l.CreatedDateTime,
									Status=l.Status
								}).OrderBy(x => x.CreatedDateTime).AsQueryable();

			var result=new ProcessResult<IQueryable<LogView>>(logs);
			result.Success = true;
			return result;
		}
	}
}
