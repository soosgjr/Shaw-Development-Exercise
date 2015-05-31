using System;
using System.Runtime.Serialization;

namespace ShawInterviewExercise.Common.Data
{
	public class DuplicateKeyException : Exception
	{
		public DuplicateKeyException()
		{
			return;
		}

		public DuplicateKeyException(string message)
			: base(message)
		{
			return;
		}

		public DuplicateKeyException(string message, Exception inner)
			: base(message, inner)
		{
			return;
		}

		protected DuplicateKeyException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			return;
		}
	}
}
