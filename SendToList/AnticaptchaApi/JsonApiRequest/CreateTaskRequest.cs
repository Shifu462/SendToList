using AnticaptchaApi.JsonCaptchaTask;
using Newtonsoft.Json;

namespace AnticaptchaApi.JsonApiRequest
{
    class CreateTaskRequest : AnticaptchaJsonRequest
    {
        [JsonProperty(PropertyName = "task")]
        public ICaptchaTask CaptchaTask;
        
        [JsonProperty(PropertyName = "softId")]
        public int SoftId { get; set; }          // appcenter id

        [JsonProperty(PropertyName = "languagePool")]
        public string LanguagePool { get; set; } // workers pool lang (en/rn)

        [JsonProperty(PropertyName = "callbackUrl")]
        public string CallbackUrl { get; set; }
    }
}
