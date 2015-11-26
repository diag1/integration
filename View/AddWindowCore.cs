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
			return this.distance;
		}
			
		public long GetStart(){
			return this.start;
		}

		public void getSessionData ()
		{
			string start = this.en4.Text;
			var distanceEntry = this.en2.Text;
			var timeEntry = this.en3.Text;		

			string[] times = start.Split (':');

			int startMin = Convert.ToInt32(times[0]);
			int startSec = Convert.ToInt32(times[1]);

			this.distance = int.Parse(distanceEntry);
			this.time = 60 * Convert.ToInt64 (timeEntry);
			this.start.AddMinutes (startMin);
			this.start.AddSeconds (startSec);



		}
			



	}
}