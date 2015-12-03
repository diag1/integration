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

			string text = System.IO.File.ReadAllText(@"./data.json");

			var r = new StreamReader (GenerateStreamFromString (text));
			var runSessionList = JSONTransformer.ToRunSessions (r);

			Gtk.Application.Init();
			var wMain = new MainWindow (runSessionList);
			wMain.ShowAll ();
			Gtk.Application.Run ();
		}

		private static Stream GenerateStreamFromString(string s)
		{
			MemoryStream stream = new MemoryStream();
			StreamWriter writer = new StreamWriter(stream);
			writer.Write(s);
			writer.Flush();
			stream.Position = 0;
			return stream;
		}
	}
}
