using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Airplane_pilot_simulator
{
	public delegate bool DispDelegate(int speed, int altitude);
	class Plane
	{
		List<Dispatcher> dispatchers;
		DispDelegate InfoDel;
		int speed;
		int speed_record = 0;
		public bool finished = false;
		public int Speed
		{
			get { return speed; }
			private set
			{
				if (value >= 0)
				{
					finished = InfoDel(speed = value, altitude);
					if (finished && speed_record < 1000) finished = false;
					speed_record = Math.Max(value, speed_record);
				}
			}
		}
		int altitude;
		int altitude_record = 0;
		public int Altitude
		{
			get { return altitude; }
			private set
			{
				if (value >= 0)
				{
					finished = InfoDel(speed, altitude = value);
					if (finished && speed_record < 1000) finished = false;
					altitude_record = Math.Max(value, altitude_record);
				}
			}
		}
		int points;
		int removed_points = 0; // очки удаленных диспетчеров
		public int PenaltyPoints
		{
			get { return points; }
			private set
			{
				if (value > 1000)
					throw new UnsuitableForFlightsException();
				points = value;
			}
		}
		public Plane()
		{
			dispatchers = new List<Dispatcher>();
		}
		public void AddDispatcher(Dispatcher dispatcher)
		{
			dispatchers.Add(dispatcher);
			InfoDel += dispatcher.PlaneTracking;
		}
		public void Status()
		{
			if(finished)
			{
				Output.Print();
				Output.Print("Congratulations! You've finished!");
				Output.Print($"Record Altitude: {altitude_record}\tRecord Speed: {speed_record}\tPenalty points: {PenaltyPoints}");
				Output.Print();
			}
			Output.Print();
			Output.Print($"Dispatchers: {dispatchers.Count}\t Altitude: {Altitude}\tSpeed: {Speed}\tPenalty points: {PenaltyPoints}");
			Output.Print();
			Output.Print("1. Add dispatcher");
			if (dispatchers.Count > 0)
				Output.Print("2. Remove dispatcher");
			Output.Print();
			Output.Print("Controls: ← → ↑ ↓ (+Shift)\n");
		}
		public void Menu(ConsoleKeyInfo key)
		{
			switch (key.Key)
			{
				case ConsoleKey.D1:
					Output.Print("Input name of new dispatcher: ");
					AddDispatcher(new Dispatcher(Console.ReadLine()));
					break;
				case ConsoleKey.D2:
					if (dispatchers.Count > 0)
					{
						Output.Print("Input number of dispatcher to remove: ");
						int num = Convert.ToInt32(Console.ReadLine()) - 1;
						removed_points += dispatchers[num].PenaltyPoints;
						dispatchers.RemoveAt(num);
					}
					break;
				default:
					Fly(key);
					break;
			}
		}

		public void Fly(ConsoleKeyInfo key)
		{
			if (dispatchers.Count < 2)
				throw new NotEnoughDispatchersException();

			bool shift = false;
			if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
				shift = true;

			switch(key.Key)
			{
				case ConsoleKey.RightArrow:
					Speed += shift ? 150 : 50;
					break;
				case ConsoleKey.LeftArrow:
					Speed -= shift ? 150 : 50;
					break;
				case ConsoleKey.UpArrow:
					Altitude += shift ? 500 : 250;
					break;
				case ConsoleKey.DownArrow:
					Altitude -= shift ? 500 : 250;
					break;
			}
			PenaltyPoints = removed_points;
			foreach (Dispatcher item in dispatchers)
			{
				PenaltyPoints += item.PenaltyPoints;
			}
		}
	}
}
