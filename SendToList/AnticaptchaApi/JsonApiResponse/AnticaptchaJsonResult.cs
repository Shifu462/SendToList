using Newtonsoft.Json;

namespace AnticaptchaApi.JsonApiResponse
{
    abstract class AnticaptchaJsonResult
    {
        [JsonProperty(PropertyName = "errorId")]
        public int ErrorId;

        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode;

        [JsonProperty(PropertyName = "errorDescription")]
        public string ErrorDescription;
    }
}
