using Newtonsoft.Json;

namespace AnticaptchaApi.JsonCaptchaSolution
{
    class ImageToTextSolution : CaptchaSolution
    {
        [JsonProperty(PropertyName = "text")]
        public string Text;

        [JsonProperty(PropertyName = "url")]
        public string Url;
    }
}
