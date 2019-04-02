
namespace SendToList
{
	public static class AuthUrlBuilder
    {
		public static class User
		{
			public static string CreateAuthUrl(int appId, string scope)
			{
				return "http://api.vk.com/oauth/authorize?" +
					   $"client_id={appId}" +
					   $"&scope={scope}";
			}

			public static string CreateTokenUrl(int appId, string appSecret, string code)
			{
				return "https://api.vk.com/oauth/access_token" +
					  $"?client_id={appId}" +
					  $"&client_secret={appSecret}" +
					  $"&code={code}";
			}
		}

		public static class Group
		{
			public static string CreateAuthUrl(int appId, long groupId, string redirectUrl = @"https://www.blank.org/")
			{
				return "https://oauth.vk.com/authorize" +
					$"?client_id={appId}" +
					$"&group_ids={groupId}" +
					$"&redirect_uri={redirectUrl}" +
					 "&scope=messages" +
					 "&response_type=token&display=page&v=5.92";
			}
		}

        
    }
}
