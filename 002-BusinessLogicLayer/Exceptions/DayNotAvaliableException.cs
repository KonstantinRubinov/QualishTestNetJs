using System;

namespace QualishTestBLL
{
	public class DayNotAvaliableException : Exception
	{
		public DayNotAvaliableException()
		{
		}

		public DayNotAvaliableException(string message) : base(message)
		{
		}

		public DayNotAvaliableException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
