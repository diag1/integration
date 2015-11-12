using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stats
{
	public class Reader
	{
		private List<Session> lst;
		public Reader (String nameArch){
			using (StreamReader r = new StreamReader(nameArch)){
				string json = r.ReadToEnd();
				List<Session> items = JsonConvert.DeserializeObject<List<Session>>(json);
				this.lst = items;
			}
		}
		public List<Session> getFile(){
			return lst;
		}
	}
}

