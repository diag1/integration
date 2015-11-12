﻿using System;
using System.Collections.Generic;

namespace calendar
{
	/// <summary>
	/// Run event filter.
	/// </summary>
	public class RunEventFilter
	{
		private List<RunSession> sessions;
		public RunEventFilter (List<RunSession> sessions)
		{
			this.sessions = sessions;	
		}

		/// <summary>
		/// Gets the events for month.
		/// </summary>
		/// <returns>The events for month.</returns>
		/// <param name="month">Month.</param>
		public List<RunSession> GetEventsForMonth(int month) {

			month = month + 1;

			List<RunSession> toret = new List<RunSession> ();

			foreach (RunSession s in this.sessions) {
				var date = this.FromUnixTime (s.start);
				System.Console.WriteLine ("MonthIN=" + month + " MonthOUT=" + date.Month);
				if (date.Month == month) {
					toret.Add (s);
				}
			}

			System.Console.WriteLine ("Number of month sessions = " + toret.Count);
			return toret;
		}

		/// <summary>
		/// Gets the events for day.
		/// </summary>
		/// <returns>The events for day.</returns>
		/// <param name="day">Day.</param>
		public List<RunSession> GetEventsForDay(int day) {

			//day = day + 1;

			List<RunSession> toret = new List<RunSession> ();

			foreach (RunSession s in this.sessions) {
				var date = this.FromUnixTime (s.start);
				System.Console.WriteLine ("DayIN=" + day + " DayOUT=" + date.Day);
				if (date.Day == day) {
					toret.Add (s);
				}
			}

			System.Console.WriteLine ("Number of day sessions = " + toret.Count);
			return toret;
		}

		/// <summary>
		/// Froms the unix time.
		/// </summary>
		/// <returns>The unix time.</returns>
		/// <param name="unixTime">Unix time.</param>
		public DateTime FromUnixTime(long unixTime)
		{
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return epoch.AddSeconds(unixTime);
		}
	}
}
