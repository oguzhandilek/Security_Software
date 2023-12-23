using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
	public enum Status
	{
		Working = 0,
		OnLeave = 1,
		Hospital = 2,
		NewComer = 3
	}

	public enum LogStatus
	{
		Archieve= 0,
		Active= 1,
		Deleted= 2,
		Dayly= 5,
		Weekly= 6,
		Monthly= 7,
		Yearly= 8
	}

}
