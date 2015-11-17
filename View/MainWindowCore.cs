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
				var day = (uint)(runFilter.FromUnixTime (s.start).Day);
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

			var RunSessions = this.runFilter.GetEventsForDay(this.cal.Day);

			if (RunSessions.Count == 0 ) {
				var label = new Gtk.Label ("No events for this day");
				label.Show ();
				this.eventDetail.PackStart (label, true, false, 5);

			} else {
				
				foreach (RunSession s in RunSessions) {	
					var hbox = this.BuildRunEvent (s);
					hbox.Show();
					this.eventDetail.PackStart (hbox, true, false, 5);
				}

				var statsVbox = this.buildStatsForDay ();
				statsVbox.ShowAll ();
				this.eventDetail.PackStart (statsVbox, true, false, 5);
			}
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
		private Gtk.TreeView getTreeView(){
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
				column.Title = "Estadisticas";
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
					column.Title = colNum == 0 ? "Valor"//REVISAR ESTO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
						: colNum == 1 ? "Destination" : "Kms";
					column.PackStart( cell, true );
					cell.Editable = false;
					column.AddAttribute( cell, "text", colNum + 1 );

					treeView.AppendColumn( column );
				}

				// Insert data
				var row = new List<string>();
				row.Clear();
				row.Insert( 0, "Distancia" );
				row.Insert(1,fa.getDistTot());
				listStore.AppendValues( row.ToArray() );

				row = new List<string>();
				row.Clear();
				row.Insert( 0, "Pasos" );
				row.Insert(1,fa.getNumStpsTot());
				listStore.AppendValues( row.ToArray() );

				row = new List<string>();
				row.Clear();
				row.Insert( 0, "Horas" );
				row.Insert(1,fa.getNumHourTot());
				listStore.AppendValues( row.ToArray() );

				row = new List<string>();
				row.Clear();
				row.Insert( 0, "Velocidad Media" );
				row.Insert(1,fa.getVelMedTot());
				listStore.AppendValues( row.ToArray() );

			} catch(Exception e) {

			}

			treeView.EnableGridLines = Gtk.TreeViewGridLines.Both;
			treeView.HeadersClickable = true;
			return treeView;
		}
	}	
}
