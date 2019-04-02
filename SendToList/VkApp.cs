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
		public static string GroupAccessToken { get; private set; }
		
		public const int С = 2000000000; // Const for chats

		public static VkApi Api = new VkApi();

		private static Random RandomGenerator = new Random();

		public static VkCollection<VkNet.Model.FriendList> CurrentFriendlists { get; set; }
		public static IDictionary<long, List<VkNet.Model.User>> Friendlist { get; set; }
		public static IList<VkNet.Model.User> AllFriends { get; set; }

		public static int GetRandomId() => RandomGenerator.Next(int.MaxValue);

		public static void Auth()
		{
			using( var codeForm = new EnterTextForm("Разрешите приложению доступ и скопируйте ссылку из адресной строки.\r\n" +
													"Пример: https://oauth.vk.com/blank.html#code=d4943b464ac2b8", "Авторизация пользователя") )
			{
				Process.Start( AuthUrlBuilder.User.CreateAuthUrl(VkApp.AppId, VkApp.Scope) );
				codeForm.ShowDialog();
				try
				{
					string code = codeForm.Result.Split( new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries )[1].Trim();
					VkApp.AuthUserByCode( code );
				}
				catch( Exception ex )
				{
					MessageBox.Show( $"Проверьте правильность введённых данных. \n\n(Ошибка:{ex.Message})" );
					Application.Exit();
				}
			}

			using( var groupTokenForm = new EnterTextForm( "Скопируйте access_token из адресной строки.\r\n" +
														   "Пример: 533bacf01e11f55b5b57531ad114461ae8736d6506a3", "Авторизация сообщества" ) )
			{
				Process.Start( AuthUrlBuilder.Group.CreateAuthUrl(VkApp.AppId, 179170080) );

				groupTokenForm.ShowDialog();

				VkApp.GroupAccessToken = groupTokenForm.Result;
			}

			
		}

		private static void AuthUserByCode(string code)
		{
			using (var webClient = new WebClient())
			{
				string tokenUrl = AuthUrlBuilder.User.CreateTokenUrl(VkApp.AppId, VkApp.AppSecret, code);
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
