using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Airplane_pilot_simulator
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Plane plane = new Plane();
				Dispatcher vasya = new Dispatcher("vasya");
				plane.AddDispatcher(vasya);
				plane.AddDispatcher(new Dispatcher("RuSiK"));
				while (true)
				{
					plane.Status();
					ConsoleKeyInfo key = Console.ReadKey();
					plane.Menu(key);

				}
			}
			catch (CrashException e)
			{
				Output.Print(e.Message);
			}
			catch (NotEnoughDispatchersException e)
			{
				Output.Print(e.Message);
			}
			catch (UnsuitableForFlightsException e)
			{
				Output.Print(e.Message);
			}
		}
	}
}
