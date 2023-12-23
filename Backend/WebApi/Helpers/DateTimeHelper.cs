using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
	public class DateTimeHelper
	{
		public DateTime GetCurrentDateTime()
			=> DateTime.UtcNow ;
	}
}
