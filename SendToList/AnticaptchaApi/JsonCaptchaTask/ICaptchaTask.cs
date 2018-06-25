using Newtonsoft.Json;

namespace AnticaptchaApi.JsonCaptchaTask
{
    interface ICaptchaTask
    {
        [JsonProperty(PropertyName = "type")]
        string Type { get; }
    }
}
