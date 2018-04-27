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
//				plane.AddDispatcher(new Dispatcher("Andrew"));
//				plane.AddDispatcher(new Dispatcher("John"));
				while (!plane.finished)
				{
					plane.Status();
					ConsoleKeyInfo key = Console.ReadKey();
					plane.Menu(key);
				}
			}
			catch (CrashException e)
			{
				Output.Print(e.Message);
				Output.Print("You've crashed the plane!");
			}
			catch (NotEnoughDispatchersException e)
			{
				Output.Print(e.Message);
				Main(args);
			}
			catch (UnsuitableForFlightsException e)
			{
				Output.Print(e.Message);
				Output.Print("You are unsuitable for flights! Goodbye!");
			}
		}
	}
}
