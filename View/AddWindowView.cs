using System;
using Gtk;
namespace calendar
{
	public partial class AddWindowView:Gtk.Dialog
	{
		public AddWindowView (Gtk.Window main)
		{
			this.TransientFor = main;
			this.Build ();
		}


		private void Build()
		{
			
			SetDefaultSize(250, 200);
			vBoxMain = this.VBox;
			//widgets
			this.lb1 = new Gtk.Label("NEW RUN SESSION");

			this.lb2 = new Gtk.Label("Start time (hh:mm):");
			this.en4 = new Gtk.Entry("0");
			this.en4.Alignment = 1;


			this.lb3 = new Gtk.Label("Distance (meters):");
			this.en2 = new Gtk.Entry("0");
			this.en2.Alignment = 1;

			this.lb5 = new Gtk.Label("Time (minutes) :");
			this.en3 = new Gtk.Entry("0");


			this.en3.Alignment = 1;
			this.lb6 = new Gtk.Label("Average speed :");
			this.lb7 = new Gtk.Label("");


			//vBox
			vBoxMain.PackStart(this.lb1,true,false,5);

			//Start time
			vBoxMain.PackStart(this.lb2,true,false,5);
			vBoxMain.PackStart(this.en4,true,false,5);

			//Distance
			vBoxMain.PackStart(this.lb3,true,false,5);
			vBoxMain.PackStart(this.en2,true,false,5);
			//Time
			vBoxMain.PackStart(this.lb5,true,false,5);
			vBoxMain.PackStart(this.en3,true,false,5);	
			//Average
			vBoxMain.PackStart(this.lb6,true,false,5);
			vBoxMain.PackStart(this.lb7,true,false,5);
			// Save button
			this.AddButton ("Save", Gtk.ResponseType.Accept);
			this.AddButton ("Cancel", Gtk.ResponseType.Cancel);
			this.ShowAll ();
			//events
		}

		private Gtk.Entry en2;
		private Gtk.Entry en3;
		private Gtk.Entry en4;

		private Gtk.Label lb1;
		private Gtk.Label lb2;
		private Gtk.Label lb3;
		private Gtk.Label lb5;
		private Gtk.Label lb6;
		private Gtk.Label lb7;

		private Gtk.VBox vBoxMain;

		private long date;
		private long time;
		private long distance;
		private DateTime start;

	}

}

