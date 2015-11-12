using System;
using System.Collections.Generic;
using System.Wnamespace


namespace calendar
{
	public class Friends
	{

		public List<FacebookFriend> data {get;set;}
	}

	public class FacebookFriend
	{

		public string id {get;set;}
		public string name {get;set;}
	}

	public class Principal
	{
		public static void Main() {
			System.Console.WriteLine (0);
			string json=
				@"{""data"":[{""id"":""518523721"",""name"":""ftyft""}, {""id"":""527032438"",""name"":""ftyftyf""}, {""id"":""527572047"",""name"":""ftgft""}, {""id"":""531141884"",""name"":""ftftft""}]}";


			Friends facebookFriends = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Friends>(json);

			foreach(var item in facebookFriends.data)
			{
				Console.WriteLine("id: {0}, name: {1}",item.id,item.name);
			}
		}
	}
}

