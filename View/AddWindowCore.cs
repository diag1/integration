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
		public void getSessionData ()
		{
			
			var distanceEntry = this.en2.Text;
			var timeEntry = this.en3.Text;		

			this.distance = int.Parse(distanceEntry);
			this.time = 60 * Convert.ToInt64 (time);

		}
			

	}
}