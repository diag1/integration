using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace calendar
{
	/// <summary>
	/// JSON transformer.
	/// </summary>
	public class JSONTransformer:Transformer {

		public JSONTransformer(string fn) {
			this.filename = fn;
		}

		/// <summary>
		/// Converts a JSON file to a RunSession List.
		/// </summary>
		/// <returns>The RunSessions.</returns>
		/// <param name="r">The reader.</param>
		public List<RunSession> GetRunSessions() {
			try {
				string text = System.IO.File.ReadAllText(this.filename);
				var r = new StreamReader (this.GenerateStreamFromString (text));
				string json = r.ReadToEnd ();
				var sessions = JsonConvert.DeserializeObject<List<RunSession>> (json);
				if (sessions == null) {
					sessions = new List<RunSession> ();
				}
				return sessions;
			} catch (FileNotFoundException e) {
				using (File.Create(this.filename)) {}
				return this.GetRunSessions ();
			}
				
				
		} 

		/// <summary>
		/// Tos the json.
		/// </summary>
		/// <param name="lst">Lst.</param>
		public void WriteToDataFormat(List<RunSession> lst) {
			string output = JsonConvert.SerializeObject(lst);
			System.Console.WriteLine (output);

			File.WriteAllText ("./data.json", output);
		}

		private string filename;


		/// <summary>
		/// Generates the stream from string.
		/// </summary>
		/// <returns>The stream from string.</returns>
		/// <param name="s">S.</param>
		private Stream GenerateStreamFromString(string s)
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

