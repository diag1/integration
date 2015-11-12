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

			string jsonRuns = @"[
			{""start"":1446133195,""duration"":3600, ""distance"":200},
			{""start"":1444923595,""duration"":100, ""distance"":400},
			{""start"":1444925595,""duration"":1400, ""distance"":1100}
			]";

			string jsonWeights = @"[
			{""start"":1446133195,""weight"":80000},
			{""start"":1444923595,""weight"":85000},
			{""start"":1444925595,""weight"":86000}
			]";


			var r = new StreamReader (GenerateStreamFromString (jsonRuns));
			var sessionList = JSONTransformer.ToRunSessions(r);

			r = new StreamReader (GenerateStreamFromString (jsonWeights));
			var weightsList = JSONTransformer.ToWeightSessions (r);

			//var recorridos = Recorridos.Crea ();
			Gtk.Application.Init();
			var wMain = new MainWindow (sessionList, weightsList);
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
