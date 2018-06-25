namespace AnticaptchaApi
{
    struct ApiMethodUrl
    {
        private const string ApiLink = "https://api.anti-captcha.com/";

        public const string CreateTask    = ApiLink + "createTask";
        public const string GetTaskResult = ApiLink + "getTaskResult";

        public const string GetBalance    = ApiLink + "getBalance";
        public const string GetQueueStats = ApiLink + "getQueueStats";
    }
}
