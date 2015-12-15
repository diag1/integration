using System;
using System.Globalization;
using Gtk;

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
			return this.start;
		}

		private int start;

		public void getSessionData ()
		{
			string initEntry = this.en4.Text;
			var distanceEntry = this.en2.Text;
			var timeEntry = this.en3.Text;



				string[] hoursAndMinutes = initEntry.Split (':');

				var minutes = Convert.ToInt32(hoursAndMinutes[1]);
				var hours = Convert.ToInt32(hoursAndMinutes[0]);
				var seconds = hours * 3600 + minutes * 60;

				this.start = seconds;

				this.distance = int.Parse(distanceEntry);



			this.time = 60 * Convert.ToInt64 (timeEntry);
				
		}
	}
}