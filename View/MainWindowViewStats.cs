/*using System;
using Gtk;
namespace Stats
{
	public partial class MainWindow: Gtk.Window
	{
		public MainWindow ()
			:base(Gtk.WindowType.Toplevel)
		{
			fa=new Functions("./json");
			this.build ();
			this.vBoxDia.Visible = false;
			this.vBoxMain.Visible = false;
			porMain ();
		}
		private void build(){
			this.buildMain ();
			this.buildDia();

			var a =  new Gtk.VBox (false, 5);

			this.vBoxMain.Visible = true;
			this.vBoxDia.Visible = false;
			a.PackStart (vBoxMain);
			a.PackStart (vBoxDia);

			this.Add (a);
			a.ShowAll ();
			//events
			this.DeleteEvent += (o, args) =>this.OnClose() ;

		}
		/// <summary>
		/// Build this instance.
		/// </summary>
		private void buildMain(){
			SetDefaultSize(250, 200);
			vBoxMain = new Gtk.VBox (false, 5);
			//widgets
			this.lb1 = new Gtk.Label("ESTADISTICAS");
			lb1.UseMarkup = true;
			this.lb2 = new Gtk.Label("Peso: "+fa.getActWeight());
			this.lb3 = new Gtk.Label("Distancia: "+fa.getDistTot());
			this.lb4 = new Gtk.Label("Pasos: "+fa.getNumStpsTot());
			this.lb5 = new Gtk.Label("Horas: "+fa.getNumHourTot());
			this.lb6 = new Gtk.Label("Velocidad Media: "+fa.getVelMedTot());
			this.en1 = new Gtk.Entry("dd/MM/yyyy");
			this.en1.Alignment = 1;
			this.btVol = new Gtk.Button("Aceptar");
			//vBox
			vBoxMain.PackStart(this.lb1,true,false,5);
			vBoxMain.PackStart(this.lb2,true,false,5);
			vBoxMain.PackStart(this.lb3,true,false,5);
			vBoxMain.PackStart(this.lb4,true,false,5);
			vBoxMain.PackStart(this.lb5,true,false,5);
			vBoxMain.PackStart(this.lb6,true,false,5);
			vBoxMain.PackStart(this.en1,true,false,5);
			vBoxMain.PackStart(this.btVol,true,false,5);


			//events
			this.DeleteEvent += (o, args) =>this.OnClose() ;
			this.btVol.Clicked += (o, args) => this.introduce ();
		}
		/// <summary>
		/// Builds the dia.
		/// </summary>
		private void buildDia(){
			SetDefaultSize(250, 200);
			vBoxDia = new Gtk.VBox (false, 5);
			//widgets"01/08/2008"

			this.lb7 = new Gtk.Label("DIA CONCRETO");
			this.lb8 = new Gtk.Label("Peso: "+fa.getWeightDay(dia));
			this.lb9 = new Gtk.Label("Distancia: "+fa.getDistDay(dia));
			this.lb10 = new Gtk.Label("Pasos: "+fa.getNumStpsDay(dia));
			this.lb11= new Gtk.Label("Horas: "+fa.getNumHourDay(dia));
			this.lb12= new Gtk.Label("Velocidad Media: "+fa.getVelMedDay(dia));
			this.btVol = new Gtk.Button("Retroceder");

			//vBox
			vBoxDia.PackStart(this.lb7,true,false,5);
			vBoxDia.PackStart(this.lb8,true,false,5);
			vBoxDia.PackStart(this.lb9,true,false,5);
			vBoxDia.PackStart(this.lb10,true,false,5);
			vBoxDia.PackStart(this.lb11,true,false,5);
			vBoxDia.PackStart(this.lb12,true,false,5);
			vBoxDia.PackStart(this.btVol,true,false,5);

			//events
			this.DeleteEvent += (o, args) =>this.OnClose() ;
			this.btVol.Clicked += (o, args) => this.porMain ();

		}
		private void newDay(){
			this.lb8.Text ="Peso: " + fa.getWeightDay (dia);
			this.lb9.Text ="Distancia: "+fa.getDistDay(dia);
			this.lb10.Text ="Pasos: "+fa.getNumStpsDay(dia);
			this.lb11.Text ="Horas: "+fa.getNumHourDay(dia);
			this.lb12.Text ="Velocidad Media: "+fa.getVelMedDay(dia);
		}
		/// <summary>
		/// Pors the dia.
		/// </summary>
		private void porDia(){
			vBoxMain.Visible = false;
			vBoxDia.Visible = true;
		}
		/// <summary>
		/// Pors the main.
		/// </summary>
		private void porMain(){
			vBoxMain.Visible = true;
			vBoxDia.Visible = false;
		}
		private Gtk.Button btVol;

		private Gtk.Entry en1;
		private Gtk.Label lb1;
		private Gtk.Label lb2;
		private Gtk.Label lb3;
		private Gtk.Label lb4;
		private Gtk.Label lb5;
		private Gtk.Label lb6;
		private Gtk.Label lb7;
		private Gtk.Label lb8;
		private Gtk.Label lb9;
		private Gtk.Label lb10;
		private Gtk.Label lb11;
		private Gtk.Label lb12;
		private Gtk.VBox vBoxMain;
		private Gtk.VBox vBoxDia;
		private Fachada fa;
		private DateTime dia;
	}
}

*/