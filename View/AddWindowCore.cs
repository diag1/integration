  using System;
using System.Globalization;
//using System.Text.RegularExpressions;
namespace calendar
{
	public partial class AddWindowView
	{
		public long GetTime(){
			return this.time;
		}
		public long GetDistance(){
			Console.Write ("dist "+distance);
			return this.distance;
		}
			
		public long GetStart(){
			Console.Write ("hora "+start.Hour);
			return ToEpochTime(this.start);
		}

		public void getSessionData ()
		{
			string start1 = this.en4.Text;
			var distanceEntry = this.en2.Text;
			var timeEntry = this.en3.Text;

			string[] times = start1.Split (':');

			var startMin = Convert.ToDouble(times[1]);
			var startHour = Convert.ToDouble(times[0]);

			this.distance = int.Parse(distanceEntry);
			this.time = 60 * Convert.ToInt64 (timeEntry);
			//PROBLEMA LOCALIZADO (no realiza bien el add)
			this.start.AddMinutes (startMin);
			this.start.AddHours (startHour);
			Console.WriteLine ("miramos aki2" + this.start.ToString ());
		}
		private long ToEpochTime(DateTime date)
		{
			var epoch = new DateTime (1970,1,1,0,0,0,DateTimeKind.Utc);
			return Convert.ToInt64 ((date - epoch).TotalSeconds);
		}
	}
}
