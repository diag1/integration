using System;

namespace calendar
{
	public partial class MainWindow
	{
		/// <summary>
		/// Raises the close event.
		/// </summary>
		private void OnClose() {
			Gtk.Application.Quit();
		}

		/// <summary>
		/// Marks the events for month.
		/// </summary>
		/// <param name="month">Month.</param>
		private void MarkEventsForMonth(int month) {
			this.cal.ClearMarks ();
			System.Console.WriteLine("Month" + month);

			// Mark days in the calendar where an event has ocurred
			foreach (RunSession s in this.runFilter.GetEventsForMonth(month)) {
				var day = (uint)(runFilter.FromUnixTime (s.start).Day);
				this.cal.MarkDay (day);
			}

			// Mark days in the calendar where an event has ocurred
			foreach (WeightSession s in this.weightFilter.GetEventsForMonth(month)) {
				var day = (uint)(weightFilter.FromUnixTime (s.Start).Day);
				this.cal.MarkDay (day);
			}
		}


		private void ShowAddTrip() {
			/*var addWindow = new AddWindow (this);
			Gtk.ResponseType result = (Gtk.ResponseType)addWindow.Run ();

			if (result == Gtk.ResponseType.Accept) {
				var origin = addWindow.GetOrigin ();
				var dst = addWindow.GetDestination ();
				var kms = addWindow.GetKMS ();
				this.rds.Add(Recorrido.Crea (origin, dst, kms));
				this.rds.GuardaXml ();
			}
			addWindow.Destroy ();
			*/
		}


		private  void ShowListTrips() {
			/*
			var listWindow = new ListWindow (this, this.rds);
			Gtk.ResponseType result = (Gtk.ResponseType)listWindow.Run ();
			listWindow.Destroy ();
			*/
		}

		/// <summary>
		/// Shows the events for day.
		/// </summary>
		private void ShowEventsForDay() {

			// Clear existing widgets
			foreach (Gtk.Widget w in this.eventDetail.Children) {
				this.eventDetail.Remove (w);
			}

			var runSessions = this.runFilter.GetEventsForDay(this.cal.Day);
			var weightSessions = this.weightFilter.GetEventsForDay (this.cal.Day);

			if (runSessions.Count == 0 && weightSessions.Count == 0) {
				
				var label = new Gtk.Label ("No events for this day");
				label.Show ();
				this.eventDetail.PackStart (label, true, false, 5);

			} else {
				
				var label = new Gtk.Label ("There are " + (runSessions.Count+weightSessions.Count) + " events for this day");
				label.Show ();
				this.eventDetail.PackStart (label, true, false, 5);


				var labelRuns = new Gtk.Label ("You have run " + runSessions.Count + " times this day");
				labelRuns.Show ();
				this.eventDetail.PackStart (labelRuns, true, false, 5);

				foreach (RunSession s in runSessions) {	
					var hbox = this.BuildRunEvent (s);
					hbox.Show();
					this.eventDetail.PackStart (hbox, true, false, 5);
				}

				var labelWeights = new Gtk.Label ("You have weighted " + weightSessions.Count + " times this day");
				labelWeights.Show ();
				this.eventDetail.PackStart (labelWeights, true, false, 5);

				foreach (WeightSession s in weightSessions) {	
					var hbox = this.BuildWeightEvent (s);
					hbox.Show();
					this.eventDetail.PackStart (hbox, true, false, 5);
				}


			}
		}
	}	
}

