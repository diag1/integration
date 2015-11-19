using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace calendar
{
	/// <summary>
	/// JSON transformer.
	/// </summary>
	public class JSONTransformer {

		/// <summary>
		/// Converts a JSON file to a RunSession List.
		/// </summary>
		/// <returns>The run RunRunRunRunSessions.</returns>
		/// <param name="r">The reader.</param>
		public static List<RunSession> ToRunSessions(StreamReader r) {
			string json = r.ReadToEnd ();
			return JsonConvert.DeserializeObject<List<RunSession>> (json);
		} 

		public static void ToJson(List<RunSession> lst) {
			string output = JsonConvert.SerializeObject(lst);
			System.Console.WriteLine (output);

			File.WriteAllText ("./data.json", output);
		}
	}

}

