using Newtonsoft.Json;
using AnticaptchaApi.JsonCaptchaSolution;

namespace AnticaptchaApi.JsonApiResponse
{
    class AnticaptchaTaskResult : AnticaptchaJsonResult
    {
        public bool IsDone => (Status == "ready");

        /// <summary>
        /// Use IsDone property to check whether your task has solution.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "solution")]
        public ImageToTextSolution Solution; // actually CaptchaSolution

        [JsonProperty(PropertyName = "cost")]
        public double Cost;

        [JsonProperty(PropertyName = "ip")]
        public string TaskCreatorIp;

        [JsonProperty(PropertyName = "createTime")]
        public int CreateTime;

        [JsonProperty(PropertyName = "endTime")]
        public int EndTime;

        [JsonProperty(PropertyName = "solveCount")]
        public int SolveCount;
    }
}
