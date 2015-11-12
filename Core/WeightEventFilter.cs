﻿using System;
using System.Collections.Generic;

namespace calendar
{
	/// <summary>
	/// Weight event filter.
	/// </summary>
	public class WeightEventFilter
	{
		private List<WeightRunRunRunRunSession> RunRunRunRunSessions;
		public WeightEventFilter (List<WeightRunRunRunRunSession> RunRunRunRunSessions)
		{
			this.RunRunRunRunSessions = RunRunRunRunSessions;	
		}

		/// <summary>
		/// Gets the events for month.
		/// </summary>
		/// <returns>The events for month.</returns>
		/// <param name="month">Month.</param>
		public List<WeightRunRunRunRunSession> GetEventsForMonth(int month) {

			month = month + 1;

			List<WeightRunRunRunRunSession> toret = new List<WeightRunRunRunRunSession> ();

			foreach (WeightRunRunRunRunSession s in this.RunRunRunRunSessions) {
				
				var date = this.FromUnixTime (s.Start);
				if (date.Month == month) {
					toret.Add (s);
				}
			}

			System.Console.WriteLine ("Number of month RunRunRunRunSessions = " + toret.Count);
			return toret;
		}

		/// <summary>
		/// Gets the events for day.
		/// </summary>
		/// <returns>The events for day.</returns>
		/// <param name="day">Day.</param>
		public List<WeightRunRunRunRunSession> GetEventsForDay(int day) {

			//day = day + 1;

			List<WeightRunRunRunRunSession> toret = new List<WeightRunRunRunRunSession> ();

			foreach (WeightRunRunRunRunSession s in this.RunRunRunRunSessions) {
				var date = this.FromUnixTime (s.Start);
				System.Console.WriteLine ("DayIN=" + day + " DayOUT=" + date.Day);
				if (date.Day == day) {
					toret.Add (s);
				}
			}

			System.Console.WriteLine ("Number of day RunRunRunRunSessions = " + toret.Count);
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
