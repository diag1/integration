using System;
using System.IO;
using System.Collections.Generic;

namespace calendar
{
	public class Functions:Fachada
	{
		private List<RunSession> lst;
		private SessionReadWriter red;
		private String rout;
		public Functions (List<RunSession> list){
			this.lst = list;
		}
		/// <summary>
		/// Gets the dist day.
		/// </summary>
		/// <returns>The dist day.</returns>
		/// <param name="day">Day.</param>
		public String getDistDay(DateTime fecha){
			double med=0.0;
			foreach(RunSession k in lst){
				DateTime f = FromUnixTime (k.start);
				if (f.Year.Equals(fecha.Year)&&f.Month.Equals(fecha.Month)&&f.Day.Equals(fecha.Day)) {
					med += k.distance;
				}
			}
			return Convert.ToString(med);
		}
		/// <summary>
		/// Gets the dist tot.
		/// </summary>
		/// <returns>The dist tot.</returns>
		public String getDistTot(){
			return Convert.ToString (getDistTotIn ());
		}
		/// <summary>
		/// Gets the vel media.
		/// </summary>
		/// <returns>The vel med total on m/s.</returns>
		public String getVelMedTot(){
			String toret = Convert.ToString (getDistTotIn () / getDurTot ())+"m/s";
			return toret;
		}
		/// <summary>
		/// Gets the vel med day.
		/// </summary>
		/// <returns>The vel med day.</returns>
		/// <param name="day">Day.</param>
		public String getVelMedDay(DateTime fecha){
			long dur = 0;
			long dist = 0;
			foreach(RunSession k in lst){
				DateTime f = FromUnixTime (k.start);
				if (f.Year.Equals(fecha.Year)&&f.Month.Equals(fecha.Month)&&f.Day.Equals(fecha.Day)) {
					dur+= k.duration;
					dist += k.distance;
				}
			}
			return Convert.ToString(dist / dur);
		}
		/// <summary>
		/// Gets the number stps tot.
		/// </summary>
		/// <returns>The number stps tot.</returns>
		public String getNumStpsTot(){
			double distStep=0.6;
			double med = 0;
			foreach(RunSession k in lst){
				med+= k.distance/distStep;
			}
			return Convert.ToString(med);
		}
		/// <summary>
		/// Gets the number stps day.
		/// </summary>
		/// <returns>The number stps day.</returns>
		/// <param name="day">Day.</param>
		public String getNumStpsDay(DateTime fecha){
			double distStep=0.6;
			double med = 0;
			foreach(RunSession k in lst){
				DateTime f = FromUnixTime (k.start);
				if (f.Year.Equals(fecha.Year)&&f.Month.Equals(fecha.Month)&&f.Day.Equals(fecha.Day)) {
					med+= k.distance/distStep;
				}
			}
			return Convert.ToString(med);
		}
		/// <summary>
		/// Calculate Total Num of Hours
		/// </summary>
		/// <returns>The total number of hour .</returns>
		public String getNumHourTot(){
			String toret="0";
			int dias = 0;
			int horas = 0;
			int min = 0;
			int sec = 0;
			DateTime f;
			foreach(RunSession k in lst){
				f = FromUnixTime (k.duration);
				sec += f.Second;
				if (sec >= 60) {
					sec=sec - 60;
					min++;
				}
				min += f.Minute;
				if (min >= 60) {
					min=min - 60;
					horas++;
				}
				horas += f.Hour;
				if (horas >= 24) {
					horas=horas - 24;
					dias++;
				}
			}
			toret = dias + "d " + horas + "h " + min + "m " + sec + "s ";
			return toret;
		}
		/// <summary>
		/// Gets the number hour of this day.
		/// </summary>
		/// <returns>The number hour of this day.</returns>
		/// <param name="day">Day.</param>
		public String getNumHourDay(DateTime fecha){
			String toret="0";
			foreach(RunSession k in lst){
				DateTime f = FromUnixTime (k.start);
				DateTime w = FromUnixTime (k.duration);
				if (f.Year.Equals(fecha.Year)&&f.Month.Equals(fecha.Month)&&f.Day.Equals(fecha.Day)) {
					toret=w.Hour+"h "+w.Minute+"m "+w.Second+"s";
				}
			}
			return toret;
		}
	
		/// <summary>
		/// Calculate total duration
		/// </summary>
		/// <returns>Total duration.</returns>
		/// <param name="lt">List of RunSessions</param>
		private double getDurTot(){
			double toret=0;
			foreach(RunSession k in lst){
				toret+= k.duration;
			}
			return toret;
		}
		/// <summary>
		/// Calculate total distance
		/// </summary>
		/// <returns>total distance.</returns>
		/// <param name="lt"> List of RunSessions.</param>
		private double getDistTotIn(){
			double toret=0;
			foreach(RunSession k in lst){
				toret+= k.distance;
			}
			return toret;
		}
		/// <summary>
		/// Froms the unix time.
		/// </summary>
		/// <returns>The unix time.</returns>
		/// <param name="unixTime">Unix time.</param>
		private  DateTime FromUnixTime(long unixTime)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds(unixTime);
		}
		/// <summary>
		/// Tos the unix time.
		/// </summary>
		/// <returns>The unix time.</returns>
		/// <param name="date">Date.</param>
		private long ToUnixTime(DateTime date)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return Convert.ToInt64((date - epoch).TotalSeconds);
		}

	}
}

