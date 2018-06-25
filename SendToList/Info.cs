using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using VkNet;

namespace SendToList
{
    public struct Info
    {
        public static int AppID { get; } = 6427400; // Your AppID.
        public static string AppSecret { get; } = "N9v5eAzZcwb6W9GrH25g"; // Your AppSecret.

        public static string AccessToken { get; private set; }
        public static string Code { get; set; }
        public static string Scope { get; } = "friends,users,messages,photo,video,offline";
        public const int С = 2000000000; // Const for chats

        public static string Auth()
        {
            System.Diagnostics.Process.Start(
                  $"http://api.vk.com/oauth/authorize" +
                  $"?client_id={Info.AppID}&scope={Info.Scope}");

            new CodeForm().ShowDialog();

            string lnkToken = 
                $"https://api.vk.com/oauth/access_token" +
                $"?client_id={Info.AppID}&client_secret={Info.AppSecret}&code={Info.Code}";

            try
            {
                var webClient = new WebClient();
                string response = webClient.DownloadString(lnkToken);
                webClient.Dispose();

                var jsonResponse = JsonConvert.DeserializeObject<VkJsonTokenResponse>(response);

                Info.AccessToken = jsonResponse.access_token;
                Program.VK.Authorize(new ApiAuthParams { AccessToken = Info.AccessToken });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

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
