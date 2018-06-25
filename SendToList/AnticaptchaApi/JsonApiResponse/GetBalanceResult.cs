using Newtonsoft.Json;

namespace AnticaptchaApi.JsonApiResponse
{
    class BalanceResult : AnticaptchaJsonResult
    {
        [JsonProperty(PropertyName = "balance")]
        public float Balance;
    }
}
