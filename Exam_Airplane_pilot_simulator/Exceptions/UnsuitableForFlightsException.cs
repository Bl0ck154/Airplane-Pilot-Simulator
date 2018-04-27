using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Airplane_pilot_simulator
{
	[Serializable]
	public class UnsuitableForFlightsException : Exception
	{
		public UnsuitableForFlightsException() { }
		public UnsuitableForFlightsException(string message) : base(message) { }
		public UnsuitableForFlightsException(string message, Exception inner) : base(message, inner) { }
		protected UnsuitableForFlightsException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
