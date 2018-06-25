using Newtonsoft.Json;

namespace AnticaptchaApi.JsonApiRequest
{
    abstract class AnticaptchaJsonRequest
    {
        [JsonProperty(PropertyName = "clientKey")]
        public string ClientKey { get; set; }
    }
}
