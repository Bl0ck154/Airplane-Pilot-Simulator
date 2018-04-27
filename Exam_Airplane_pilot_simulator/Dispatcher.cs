using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Airplane_pilot_simulator
{
	class Dispatcher
	{
		public string Name { get; }
		int WeatherVal; // «корректировку для погодных условий».
		static Random rand = new Random();
		int points;
		const int MaxSpeed = 1000;
		int distance = 0;
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
		public Dispatcher(string name)
		{
			Name = name;
			WeatherVal = rand.Next(-200, 200);
		}
		public bool PlaneTracking(int curSpeed, int altitude)
		{
			if (curSpeed == 0 && altitude == 0 && distance > 100)
				return true;

			if (curSpeed == 0 && altitude > 0) // недопустимо, чтобы самолет в любой момент времени имел нулевую высоту и нулевую скорость
				throw new CrashException();

			if (curSpeed < 50)
				return false;

			distance += curSpeed;

			if(curSpeed > MaxSpeed)
			{
				PenaltyPoints += 100;
				Output.Print($"\t{Name} : The maximum speed is exceeded! A fine of 100 points!");
			}

			int rec_altitude = RecommendAltitude(curSpeed);
			int difference = Math.Max(rec_altitude - altitude, altitude - rec_altitude);
		//	Output.Print($"{difference}"); // debug

			if (difference >= 300 && difference <= 600)
				PenaltyPoints += 25;
			else if (difference >= 600 && difference <= 1000)
				PenaltyPoints += 50;
			else if (difference > 1000)
				throw new CrashException("Difference between current and recommended altitude was too high");

			return false;
		}
		int RecommendAltitude(int curSpeed)
		{
			int answer = 7 * curSpeed - WeatherVal;
			Output.Print($"\t{Name} : Recommended flight altitude: {answer}");
			return answer;
		}
	}
}
