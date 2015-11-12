using System;

namespace Stats
{
	public class main
	{
		public static void Main (String [] args)
		{	
			Gtk.Application.Init ();
			var wMain = new MainWindow ();
			wMain.Show ();
			Gtk.Application.Run ();
		}
	}
}

