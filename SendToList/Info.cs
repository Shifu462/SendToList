using VkNet;

namespace SendToList
{
	public struct Info
    {
        public static string AccessToken { get; set; }

        public static string Scope { get; } = "friends,users,messages,photo,video,offline";

        public static string Auth()
        {
            System.Diagnostics.Process.Start( "https://vk.cc/8E0H4r" );

            new CodeForm().ShowDialog(); // CodeForm пишет токен в Info.AccessToken
			
			Program.VK.Authorize(new ApiAuthParams { AccessToken = Info.AccessToken });

            return Info.AccessToken;
        }
    }

    // Класс для десериализации ответа
    public class VkJsonTokenResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string user_id { get; set; }
    }
}
