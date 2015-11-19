using System;
using System.Globalization;
//using System.Text.RegularExpressions;
namespace calendar
{
	public partial class AddWindowView
	{
		public long GetDate(){
			Console.WriteLine (date);
			return this.date;
		}
		public long GetTime(){
			Console.WriteLine (date);
			return this.time;
		}
		public long GetDistance(){
			return this.distance;
		}
		private void introduce ()
		{
			var date = this.en1.Text ;
			var distance = this.en2.Text;
			var time = this.en3.Text;
			double avg = (Convert.ToDouble (distance)) / (60*Convert.ToDouble (time));
			this.lb7.Text = Convert.ToString (Math.Round(avg,2)) + " m/s";


			if (isDate (date)) {
				this.setDia (Convert.ToDateTime (date));
			} 


			DateTime date2 = getDia();
			DateTime duration2 = dateToDatetimeMin (time);
			int distance2 = int.Parse(distance);

			this.date = ToEpochTime (date2);
			this.time = 60 * Convert.ToInt64 (time);
			this.distance = distance2;

		}
		public DateTime dateToDatetime(String date){
			long toret=0;
			String[] med;
			int day = 3600 * 24;
			med = date.Split ('/');
			toret += Convert.ToInt32 (med[0])*day;

			switch (int.Parse(med [1])) 
			{
			case 2:
				{
					toret += 28 * day;
					break;
				}
			case 4:
			case 6:
			case 9:
			case 11:
				{
					toret += 30 * day;
					break;
				}
			default:
				{
					toret += 31 * day;
					break;
				}
			}

			toret += Convert.ToInt32 (med[2])*day*365;
			DateTime t = FromUnixTime (toret);
			return t;
		}
		//revisar esto
		public DateTime dateToDatetimeMin(String time){

			long toret=0;
			toret += int.Parse (time);
			DateTime t = FromUnixTime (toret);
			return t;
		}


		private void setDia(DateTime en)
		{
			dia = en;
		}
		private DateTime getDia(){
			return dia;
		}

		private DateTime dia;

		private bool isDate(string a) 
		{ //string estará en formato dd/mm/yyyy (dí­as < 32 y meses < 13)
			//Regex Val = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)");
			return true;//Val.IsMatch (a);
		}



		private long ToEpochTime(DateTime date)
		{
			var epoch = new DateTime (1970,1,1,0,0,0,DateTimeKind.Utc);
			return Convert.ToInt64 ((date - epoch).TotalSeconds);
		}	

		public DateTime FromUnixTime(long unixTime)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds(unixTime);
		}
	}
}

