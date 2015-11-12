﻿using System;
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
			


			var r = new StreamReader (GenerateStreamFromString (jsonRuns));
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
