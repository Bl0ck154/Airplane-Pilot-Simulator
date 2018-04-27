using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Airplane_pilot_simulator
{
	[Serializable]
	public class CrashException : Exception
	{
		public CrashException() { }
		public CrashException(string message) : base(message) { }
		public CrashException(string message, Exception inner) : base(message, inner) { }
		protected CrashException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
