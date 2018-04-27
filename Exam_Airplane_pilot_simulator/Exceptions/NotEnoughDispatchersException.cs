using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Airplane_pilot_simulator
{
	public class NotEnoughDispatchersException : Exception
	{
		public NotEnoughDispatchersException() : this("At least 2 dispatchers must control the plane") { }
		public NotEnoughDispatchersException(string message) : base(message) { }
		public NotEnoughDispatchersException(string message, Exception inner) : base(message, inner) { }
	}
}
