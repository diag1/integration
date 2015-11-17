using System;
using System.Collections.Generic;

namespace calendar
{	
	/// <summary>
	/// Main window represents the calendar UI
	/// </summary>
	public partial class MainWindow: Gtk.Window
	{
		public List<RunSession> RunSessions;

		public RunEventFilter runFilter;

		public MainWindow (List<RunSession> RunSessions)
			:base(Gtk.WindowType.Toplevel)
		{
			this.RunSessions = RunSessions;
			this.runFilter = new RunEventFilter (this.RunSessions);
			this.fa = new Functions(this.RunSessions);
			this.Build();
		}

		/// <summary>
		/// Builds the run event.
		/// </summary>
		/// <returns>The UI run event.</returns>
		/// <param name="s">A run RunRunRunRunSession.</param>
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
		/// Builds the UI.
		/// </summary>
		private void Build(){
			SetDefaultSize (600, 600);
		
			this.calendarVbox = new Gtk.VBox(false, 5);
			this.bottomHBox = new Gtk.HBox (true, 5);
			this.eventDetail = new Gtk.VBox (false, 5);

			this.cal = new Gtk.Calendar ();
			calendarVbox.PackStart (this.banner, true, false, 5);
			calendarVbox.PackStart (this.cal, true, false, 5);

			this.bottomHBox.PackStart(this.buildStats(), true, false, 5);
			this.bottomHBox.PackStart (eventDetail, true, false, 5);



			calendarVbox.PackEnd (bottomHBox, true, false, 5);



			this.Add(calendarVbox);

			// Mark events for calendar
			this.MarkEventsForMonth (this.cal.Month);

			// Events
			this.DeleteEvent += (o, args) => this.OnClose();
			//this.btnAdd.Clicked += (o, args) => this.ShowAddTrip();
			//this.btnList.Clicked += (o, args) => this.ShowListTrips();
			this.cal.DaySelected += (o, args) => this.ShowEventsForDay ();
			this.cal.MonthChanged += (object sender, EventArgs e) => this.MarkEventsForMonth (this.cal.Month);

		}

		/// <summary>
		/// Build this instance.
		/// </summary>
		private Gtk.VBox buildStats(){
			var vBoxMain = new Gtk.VBox (false, 5);
			var tableStats = getTreeView ();


			vBoxMain.PackStart(tableStats,true,false,5);
			return vBoxMain;
		}


		/// <summary>
		/// Builds the dia.
		/// </summary>
		private Gtk.VBox buildStatsForDay(){

			var dia = this.cal.Date;

			var vBoxDia = new Gtk.VBox (false, 5);
			//widgets"01/08/2008"

			var lb9 = new Gtk.Label("Distancia: "+fa.getDistDay(dia));
			var lb10 = new Gtk.Label("Pasos: "+fa.getNumStpsDay(dia));
			var lb11= new Gtk.Label("Horas: "+fa.getNumHourDay(dia));
			var lb12= new Gtk.Label("Velocidad Media: "+fa.getVelMedDay(dia));

			//vBox
		
			vBoxDia.PackStart(lb9,true,false,5);
			vBoxDia.PackStart(lb10,true,false,5);
			vBoxDia.PackStart(lb11,true,false,5);
			vBoxDia.PackStart(lb12,true,false,5);

			return vBoxDia;
		}
	
	
		private Gtk.HBox bottomHBox;
		private Gtk.VBox calendarVbox;
		private Gtk.VBox eventDetail;
		private Gtk.Label banner;
		private Gtk.Calendar cal;
		private Fachada fa;
	}



}
