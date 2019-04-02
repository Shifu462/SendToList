using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using VkNet;
using VkNet.Utils;

namespace SendToList
{
	public static class VkApp
	{
		private const int AppID = 6427400;
		public const string AppSecret = "N9v5eAzZcwb6W9GrH25g";
		public const string Scope = "friends,users,photo,video,offline";

		public static string AccessToken { get; private set; }
		public static string Code { get; set; }
		
		public const int С = 2000000000; // Const for chats

		public static VkApi Api = new VkApi();

		private static Random RandomGenerator = new Random();

		public static VkCollection<VkNet.Model.FriendList> CurrentFriendlists { get; set; } = null;
		public static IDictionary<long, List<VkNet.Model.User>> Friendlist { get; set; } = null;
		public static IList<VkNet.Model.User> AllFriends { get; set; } = null;

		public static int GetRandomId() => RandomGenerator.Next(int.MaxValue);

		public static string Auth()
		{
			System.Diagnostics.Process.Start(
				  $"http://api.vk.com/oauth/authorize" +
				  $"?client_id={VkApp.AppID}&scope={VkApp.Scope}");

			new CodeForm().ShowDialog();

			string lnkToken =
				$"https://api.vk.com/oauth/access_token" +
				$"?client_id={VkApp.AppID}&client_secret={VkApp.AppSecret}&code={VkApp.Code}";

			using (var webClient = new WebClient())
			{
				string response = webClient.DownloadString(lnkToken);
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
