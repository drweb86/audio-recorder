using System;
using System.Runtime.Serialization;

namespace HDE.Platform.Logging
{
	[Serializable]
	public sealed class LogException: Exception
	{
		public LogException()
		{ 
		
		}

		private LogException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{ 
		
		}


		public LogException(string message)
			: base(message)
		{

		}

		public LogException(string message, Exception innerException)
			: base(message, innerException)
		{ 
		
		}
	}
}
