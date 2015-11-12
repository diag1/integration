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
		/// <returns>The run sessions.</returns>
		/// <param name="r">The reader.</param>
		public static List<RunSession> ToRunSessions(StreamReader r) {
			string json = r.ReadToEnd ();
			return JsonConvert.DeserializeObject<List<RunSession>> (json);
		} 

		/// <summary>
		/// Converts a JSON file to a WeightSession List.
		/// </summary>
		/// <returns>The weight sessions.</returns>
		/// <param name="r">The reader.</param>
		public static List<WeightSession> ToWeightSessions(StreamReader r) {
			string json = r.ReadToEnd ();
			return JsonConvert.DeserializeObject<List<WeightSession>> (json);
		}
	}

}

