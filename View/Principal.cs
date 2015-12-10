using System;
using Gtk;
using System.IO;

namespace calendar
{
	/// <summary>
	/// Principal handles the main program
	/// </summary>
	public class Principal
	{
		public static void Main() {

			Transformer transformer = new JSONTransformer ("./data.json");
			var runSessionList = transformer.GetRunSessions ();

			Gtk.Application.Init();
			var wMain = new MainWindow (runSessionList, transformer);
			wMain.ShowAll ();
			Gtk.Application.Run ();
		}

	}
}