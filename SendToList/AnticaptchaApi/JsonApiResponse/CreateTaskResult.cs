using Newtonsoft.Json;

namespace AnticaptchaApi.JsonApiResponse
{
    class CreateTaskResult : AnticaptchaJsonResult
    {
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId;
    }
}
