using System.IO;
using AnticaptchaApi;

namespace SendToList
{
	public static class AnticaptchaWorker
	{
		public static long? LastCaptchaSid { get; set; } = null;
		public static string LastCaptchaUri { get; set; } = null;
		public static string LastCaptcha { get; set; } = null;

		// If anticaptcha key exists.
		internal static AntiCaptcha Api;

		public static bool TryInitialize()
		{
			string anticaptchaKey = File.Exists("anticaptcha_key.txt") ?
				File.ReadAllText("anticaptcha_key.txt") : null;

			if (anticaptchaKey != null)
			{
				AnticaptchaWorker.Api = new AntiCaptcha(anticaptchaKey);
				return true;
			}

			return false;
		}

		public static void ClearCaptchaInfo()
		{
			LastCaptchaSid = null;
			LastCaptchaUri = null;
			LastCaptcha = null;
		}
	}
}
