using Newtonsoft.Json;

namespace AnticaptchaApi.JsonApiRequest
{
    class GetTaskResultRequest : AnticaptchaJsonRequest
    {
        [JsonProperty(PropertyName = "taskId")]
        public int TaskId { get; set; }
    }
}
