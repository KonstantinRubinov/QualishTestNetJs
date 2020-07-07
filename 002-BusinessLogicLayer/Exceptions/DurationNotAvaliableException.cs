using System;

namespace QualishTestBLL
{
	public class DurationNotAvaliableException : Exception
	{
		public DurationNotAvaliableException()
		{
		}

		public DurationNotAvaliableException(string message) : base(message)
		{
		}

		public DurationNotAvaliableException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
