using System;
using System.Globalization;
using System.Text;
using System.IO;
using System.Collections.Generic;

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
				var day = (uint)(runFilter.FromUnixTime (s.Start).Day);
				this.cal.MarkDay (day);
			}
		}

		/// <summary>
		/// Shows the events for day.
		/// </summary>
		private void ShowEventsForDay() {

			// Clear existing widgets
			foreach (Gtk.Widget w in this.eventDetail.Children) {
				this.eventDetail.Remove (w);
			}

			var RunSessions = this.runFilter.GetEventsForDay(this.cal.Day);



			if (RunSessions.Count == 0 ) {
				var label = new Gtk.Label ("No events for this day");
				this.eventDetail.PackStart (label, true, false, 5);
				label.Show ();
			} else {
				var runVbox = this.buildRunsForDay (RunSessions);
				runVbox.ShowAll ();
				this.eventDetail.PackStart (runVbox, true, false, 5);

				var statsVbox = this.buildStatsForDay ();
				statsVbox.ShowAll ();
				this.eventDetail.PackStart (statsVbox, true, false, 5);
			}

			bIntroducir = new Gtk.Button ("Create session");
			bIntroducir.Show ();
			this.eventDetail.PackStart (bIntroducir, true, false, 5);
			this.bIntroducir.Clicked += (o, args) => this.showAddSession();
		}
	
		/// <summary>
		/// Shows the add session.
		/// </summary>
		private void showAddSession(){
			var addWindow = new AddWindowView (this);
			Gtk.ResponseType result	= (Gtk.ResponseType)addWindow.Run ();
			if (result == Gtk.ResponseType.Accept) {
				// Collect data
				addWindow.getSessionData ();


				var currentDate = this.cal.Date;
				currentDate = currentDate.AddSeconds (addWindow.GetStart ());

				Console.WriteLine (currentDate);

				var distance = addWindow.GetDistance ();
				var time = addWindow.GetTime ();

				this.addSession (this.ToEpochTime(currentDate), time, distance);
				this.ShowEventsForDay ();
			}
			addWindow.Destroy ();
		}

		/// <summary>
		/// Adds the session.
		/// </summary>
		/// <param name="date">Date.</param>
		/// <param name="time">Time.</param>
		/// <param name="distance">Distance.</param>
		private void addSession(long date, long time, long distance){
			var session = new RunSession ();
			session.Start = date;
			session.Duration = time;
			session.Distance = distance;
			this.RunSessions.Add (session);
			this.trans.WriteToDataFormat (this.RunSessions);
		}

		/// <summary>
		/// Ises the date.
		/// </summary>
		/// <returns><c>true</c>, if date was ised, <c>false</c> otherwise.</returns>
		/// <param name="a">The alpha component.</param>
		private bool isDate(string a) 
		{ //string estará en formato dd/mm/yyyy (dí­as < 32 y meses < 13)
			//Regex Val = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)");
			//return Val.IsMatch (a);
			return true;
		}

		/// <summary>
		/// Gets the tree view.
		/// </summary>
		/// <returns>The tree view.</returns>
		private Gtk.TreeView getStatsTreeView(bool flag){
			var treeView = new Gtk.TreeView ();

			try {
				// Create liststore
				var types = new System.Type[4];
				for(int typeNumber = 0; typeNumber < types.Length; ++typeNumber) {
					types[ typeNumber ] = typeof( string );
				}
				Gtk.ListStore listStore = new Gtk.ListStore( types );
				treeView.Model = listStore;

				// Delete existing columns
				while(treeView.Columns.Length > 0) {
					treeView.RemoveColumn( treeView.Columns[ 0 ] );
				}

				// Create index column
				var column = new Gtk.TreeViewColumn();
				var cell = new Gtk.CellRendererText();
				column.Title = "Stats";
				column.PackStart( cell, true );
				cell.Editable = false;
				cell.Foreground = "black";
				cell.Background = "light gray";
				column.AddAttribute( cell, "text", 0 );
				treeView.AppendColumn( column );

				// Create columns belonging to the document
				for(int colNum = 0; colNum < 1; ++colNum) {
					column = new Gtk.TreeViewColumn();
					column.Expand = true;
					cell = new Gtk.CellRendererText();
					column.PackStart( cell, true );
					cell.Editable = false;
					column.AddAttribute( cell, "text", colNum + 1 );

					treeView.AppendColumn( column );
				}
				if(flag==true){
					// Insert data
					var row = new List<string>();
					row.Clear();
					row.Insert( 0, "Distance" );
					row.Insert(1,fa.getDistTot());
					listStore.AppendValues( row.ToArray() );

					row = new List<string>();
					row.Clear();
					row.Insert( 0, "Steps" );
					row.Insert(1,fa.getNumStpsTot());
					listStore.AppendValues( row.ToArray() );

					row = new List<string>();
					row.Clear();
					row.Insert( 0, "Hours" );
					row.Insert(1,fa.getNumHourTot());
					listStore.AppendValues( row.ToArray() );

					row = new List<string>();
					row.Clear();
					row.Insert( 0, "Average speed" );
					row.Insert(1,fa.getVelMedTot());
					listStore.AppendValues( row.ToArray() );
				}
				else{
					// Insert data
					var row = new List<string>();
					row.Clear();
					row.Insert( 0, "Distance" );
					row.Insert(1,fa.getDistDay(dia));
					listStore.AppendValues( row.ToArray() );

					row = new List<string>();
					row.Clear();
					row.Insert( 0, "Steps" );
					row.Insert(1,fa.getNumStpsDay(dia));
					listStore.AppendValues( row.ToArray() );

					row = new List<string>();
					row.Clear();
					row.Insert( 0, "Hours" );
					row.Insert(1,fa.getNumHourDay(dia));
					listStore.AppendValues( row.ToArray() );

					row = new List<string>();
					row.Clear();
					row.Insert( 0, "Average speed" );
					row.Insert(1,fa.getVelMedDay(dia));
					listStore.AppendValues( row.ToArray() );
				}


			} catch(Exception e) {
				Console.Write (e);
			}

			treeView.EnableGridLines = Gtk.TreeViewGridLines.Both;
			treeView.HeadersClickable = true;
			return treeView;
		}

		/// <summary>
		/// Gets the tree view.
		/// </summary>
		/// <returns>The tree view.</returns>
		private Gtk.TreeView getRunsTreeView(List<RunSession> sessions){
			var treeView = new Gtk.TreeView ();

			// Create liststore
			var types = new System.Type[3];
			for (int typeNumber = 0; typeNumber < types.Length; ++typeNumber) {
				types [typeNumber] = typeof(string);
			}
			Gtk.ListStore listStore = new Gtk.ListStore (types);
			treeView.Model = listStore;

			// Delete existing columns
			while (treeView.Columns.Length > 0) {
				treeView.RemoveColumn (treeView.Columns [0]);
			}

			// Create started column
			var columnStarted = new Gtk.TreeViewColumn ();
			var cellStarted = new Gtk.CellRendererText ();
			columnStarted.Title = "Started (hh:mm:ss)";
			columnStarted.PackStart (cellStarted, true);
			cellStarted.Editable = false;
			cellStarted.Foreground = "black";
			cellStarted.Background = "light gray";
			columnStarted.AddAttribute (cellStarted, "text", 0);
			treeView.AppendColumn (columnStarted);

			// Create runned column
			var columnRunned = new Gtk.TreeViewColumn ();
			var cellRunned = new Gtk.CellRendererText ();
			columnRunned.Title = "Distance (m)";
			columnRunned.PackStart (cellRunned, true);
			cellRunned.Editable = false;
			cellRunned.Foreground = "black";
			cellRunned.Background = "light gray";
			columnRunned.AddAttribute (cellRunned, "text", 1);
			treeView.AppendColumn (columnRunned);

			// Create distance column
			var columnDistance = new Gtk.TreeViewColumn ();
			var cellDistance = new Gtk.CellRendererText ();
			columnDistance.Title = "Runned (hh:mm:ss)";
			columnDistance.PackStart (cellDistance, true);
			cellDistance.Editable = false;
			cellDistance.Foreground = "black";
			cellDistance.Background = "light gray";
			columnDistance.AddAttribute (cellDistance, "text", 2);
			treeView.AppendColumn (columnDistance);

			var row = new List<string> ();
			foreach (RunSession s in sessions) {
				// Insert data
				row.Clear ();
				////////////////////////AKIIIIIIIIIII
				/// 
				var date = this.runFilter.FromUnixTime (s.Start);
				Console.Write ("date "+date.ToString ());
				var hour = date.Hour + ":" + date.Minute + ":" + date.Second;
				var distance = s.Distance;
				var duration = TimeSpan.FromSeconds (s.Duration).ToString (@"hh\:mm\:ss");

				row.Insert (0, Convert.ToString (hour));
				row.Insert (1, Convert.ToString (distance));
				row.Insert (2, Convert.ToString (duration));

				listStore.AppendValues (row.ToArray ());
			}
		
			treeView.EnableGridLines = Gtk.TreeViewGridLines.Both;
			treeView.HeadersClickable = true;
			return treeView;
		}

		/// <summary>
		/// Tos the epoch time.
		/// </summary>
		/// <returns>The epoch time.</returns>
		/// <param name="date">Date.</param>
		private long ToEpochTime(DateTime date)
		{
			var epoch = new DateTime (1970,1,1,0,0,0,DateTimeKind.Utc);
			return Convert.ToInt64 ((date - epoch).TotalSeconds);
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

		private Transformer trans;
	}	
}
