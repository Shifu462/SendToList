using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using VkNet;
using VkNet.Utils;

namespace SendToList
{
	public static class VkApp
	{
		private const int AppId = 6427400;
		public const string AppSecret = "N9v5eAzZcwb6W9GrH25g";
		public const string Scope = "friends,users,photo,video,offline";

		public static string AccessToken { get; private set; }
		public static string Code { get; set; }
		
		public const int С = 2000000000; // Const for chats

		public static VkApi Api = new VkApi();

		private static Random RandomGenerator = new Random();

		public static VkCollection<VkNet.Model.FriendList> CurrentFriendlists { get; set; }
		public static IDictionary<long, List<VkNet.Model.User>> Friendlist { get; set; }
		public static IList<VkNet.Model.User> AllFriends { get; set; }

		public static int GetRandomId() => RandomGenerator.Next(int.MaxValue);

		public static string Auth()
		{
			Process.Start( AuthUrlBuilder.User.CreateAuthUrl(VkApp.AppId, VkApp.Scope) );
			
			using( var codeForm = new CodeForm() )
				codeForm.ShowDialog();

			using (var webClient = new WebClient())
			{
				string tokenUrl = AuthUrlBuilder.User.CreateTokenUrl(VkApp.AppId, VkApp.AppSecret, VkApp.Code);
				string response = webClient.DownloadString(tokenUrl);
				var jsonResponse = JsonConvert.DeserializeObject<VkJsonTokenResponse>(response);
				VkApp.AccessToken = jsonResponse.access_token;

				try
				{
					VkApp.Api.Authorize(new VkNet.Model.ApiAuthParams { AccessToken = VkApp.AccessToken });
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Application.Exit();
				}
			}

			return VkApp.AccessToken;
		}
	}

	// Класс для десериализации ответа с токеном
	public class VkJsonTokenResponse
	{
		public string access_token { get; set; }
		public string expires_in { get; set; }
		public string user_id { get; set; }
	}
}
