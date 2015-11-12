using System;
using System.Collections.Generic;

namespace calendar
{	
	/// <summary>
	/// Main window represents the calendar UI
	/// </summary>
	public partial class MainWindow: Gtk.Window
	{
		public List<RunSession> runSessions;
		public List<WeightSession> weightSessions;

		public RunEventFilter runFilter;
		public WeightEventFilter weightFilter;

		public MainWindow (List<RunSession> runSessions, List<WeightSession> weightSessions)
			:base(Gtk.WindowType.Toplevel)
		{
			this.runSessions = runSessions;
			this.runFilter = new RunEventFilter (this.runSessions);

			this.weightSessions = weightSessions;
			this.weightFilter = new WeightEventFilter (this.weightSessions);

			this.Build();
		}

		/// <summary>
		/// Builds the run event.
		/// </summary>
		/// <returns>The UI run event.</returns>
		/// <param name="s">A run session.</param>
		private Gtk.HBox BuildRunEvent(RunSession s) {

			var hbox = new Gtk.HBox(true, 5);
			var date = this.runFilter.FromUnixTime (s.start);
			var labelHour = new Gtk.Label ("Started: " + date.Hour + ":" + date.Minute + ":" + date.Second);
			var labelDistance = new Gtk.Label ("Runned: " + s.distance + " kms");
			var labelDuration = new Gtk.Label ("Duration: " + TimeSpan.FromSeconds(s.duration).ToString(@"hh\:mm\:ss"));
	
			labelHour.Show ();
			labelDistance.Show ();
			labelDuration.Show ();

			hbox.PackStart (labelHour, true, false, 5 );
			hbox.PackStart (labelDistance, true, false, 5);
			hbox.PackStart (labelDuration, true, false, 5);

			return hbox;
		}

		/// <summary>
		/// Builds the weight event.
		/// </summary>
		/// <returns>The UI weight event.</returns>
		/// <param name="s">A weight session.</param>
		private Gtk.HBox BuildWeightEvent(WeightSession s) {
			var hbox = new Gtk.HBox(true, 5);
			var date = this.runFilter.FromUnixTime (s.Start);
			var labelHour = new Gtk.Label ("Started: " + date.Hour + ":" + date.Minute + ":" + date.Second);
			var labelWeight = new Gtk.Label ("Weight: " + s.Weight/1000 + " kg");

			labelHour.Show ();
			labelWeight.Show ();

			hbox.PackStart (labelHour, true, false, 5 );
			hbox.PackStart (labelWeight, true, false, 5);

			return hbox;
		}

		/// <summary>
		/// Builds the UI.
		/// </summary>
		private void Build(){
			SetDefaultSize (250, 200);
			var vbox = new Gtk.VBox(false, 5);

			this.eventDetail = new Gtk.VBox (true, 5);
			this.cal = new Gtk.Calendar ();
			this.banner = new Gtk.Label ("Calendar");
			//this.btnAdd = new Gtk.Button ("Add trip");
			//this.btnList = new Gtk.Button ("List trips");

			vbox.PackStart (this.banner, true, false, 5);
			//vbox.PackStart (this.btnAdd, true, false, 5);
			//vbox.PackStart (this.btnList, true, false, 5);
			vbox.PackStart (this.cal, true, false, 5);
			vbox.PackStart (this.eventDetail, true, false, 5);
			this.Add(vbox);

			// Mark events for calendar
			this.MarkEventsForMonth (this.cal.Month);

			// Events
			this.DeleteEvent += (o, args) => this.OnClose();
			//this.btnAdd.Clicked += (o, args) => this.ShowAddTrip();
			//this.btnList.Clicked += (o, args) => this.ShowListTrips();
			this.cal.DaySelected += (o, args) => this.ShowEventsForDay ();
			this.cal.MonthChanged += (object sender, EventArgs e) => this.MarkEventsForMonth (this.cal.Month);

		}

		private Gtk.VBox eventDetail;
		private Gtk.Label banner;
		private Gtk.Button btnList;
		private Gtk.Button btnAdd;
		private Gtk.Calendar cal;
	}


}
