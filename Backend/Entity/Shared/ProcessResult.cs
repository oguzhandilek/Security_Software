using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Shared
{
	public class ProcessResult<T>
	{
		public T Data { get; set; }
		public bool Success {get; set;}
		public int RecordsCount { get; set;}
		public string? Message { get; set;}
		public int? Id { get; set;}
		public ProcessResult()
		{
			this.Data = default(T);
			this.Success = false;
			this.RecordsCount = 0;
			this.Message = string.Empty;
		}
		public ProcessResult(int id)
		{
			this.Success = true;
			this.RecordsCount = 1;
			this.Message = string.Empty;
			this.Id = id;
		}

		public ProcessResult(T resultData)
		{
			this.Data = resultData;
		}
		public ProcessResult(Exception Ex)
		{
			this.Success = false;
			this.Message= Ex.Message;
		}
	}
}
