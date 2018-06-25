using AnticaptchaApi;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VkNet;
using VkNet.Utils;

namespace SendToList
{
    static class Program
    {
        public static VkApi VK = new VkApi();

        public static long?  LastCaptchaSid { get; set; } = null;
        public static string LastCaptchaUri { get; set; } = null;
        public static string LastCaptcha    { get; set; } = null;

        // If anticaptcha key exists.
        public static AntiCaptcha Anticaptcha;

        public static VkCollection<VkNet.Model.FriendList>     CurrentFriendlists { get; set; } = null;
        public static Dictionary<long, List<VkNet.Model.User>> Friendlist         { get; set; } = null;

        public static void ClearCaptchaInfo()
        {
            LastCaptchaSid = null;
            LastCaptchaUri = null;
            LastCaptcha = null;
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
