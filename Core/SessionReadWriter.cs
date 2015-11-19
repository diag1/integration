using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace calendar
{	
	
	public class SessionReadWriter
	{
		private List<RunSession> lst;


		public List<RunSession> Read (String fn){
			using (StreamReader r = new StreamReader (fn)) {
				string json = r.ReadToEnd ();
				this.lst = JsonConvert.DeserializeObject<List<RunSession>> (json);
				return this.lst;
			}
		}

		public static List<RunSession> ToJson(StreamReader r) {
			string json = r.ReadToEnd ();
			return JsonConvert.DeserializeObject<List<RunSession>> (json);
		} 
		
	}
}