using System;
using System.Runtime.Serialization;

namespace ShawInterviewExercise.Common.Data
{
	public class InvalidKeyException : Exception
	{
		public InvalidKeyException()
		{
			return;
		}

		public InvalidKeyException(string message)
			: base(message)
		{
			return;
		}

		public InvalidKeyException(string message, Exception inner)
			: base(message, inner)
		{
			return;
		}

		protected InvalidKeyException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			return;
		}
	}
}
