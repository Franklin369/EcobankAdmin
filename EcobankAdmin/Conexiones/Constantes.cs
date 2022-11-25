using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcobankAdmin.Conexiones
{
   public class Constantes
    {
        public static FirebaseClient firebase = new FirebaseClient("https://ecob-3563a-default-rtdb.firebaseio.com/");
		public const string WebapyFirebase = "AIzaSyDrVBbR4GbM4PNWfVUZ6iLvDmBT_p9w_-c";
		public static string AppName = "OAuthNativeFlow";
		public const string GoogleMapsApiKey = "AIzaSyAXouLv21vdv0fjnsN9tYBxbAAMZc1xfPA";
		//// OAuth
		//// For Google login, configure at https://console.developers.google.com/
		//public static string iOSClientId = "844060696235-gtoiepn6u6trvaoh5s6uo1a1a3hrcrnq.apps.googleusercontent.com";
		//public static string AndroidClientId = "941627439485-0j4fpb6tfqn8bm51558a1ncn5ad9pj14.apps.googleusercontent.com";

		//// These values do not need changing
		//public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
		//public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
		//public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
		//public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

		//// Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
		//public static string iOSRedirectUrl = "com.googleusercontent.apps.844060696235-gtoiepn6u6trvaoh5s6uo1a1a3hrcrnq:/oauth2redirect";
		//public static string AndroidRedirectUrl = "com.googleusercontent.apps.941627439485-0j4fpb6tfqn8bm51558a1ncn5ad9pj14:/oauth2redirect";
	}
}
