using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace AnticaptchaApi.JsonCaptchaTask
{
    class ImageToTextTask : ICaptchaTask
    {
        /// <summary>
        /// Task type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type => "ImageToTextTask";

        /// <summary>
        /// Image file base64 encoded.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string ImageBase64;

        public ImageToTextTask(string path)
        {
            if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
                this.ImageBase64 = EncodeFromUrl(path);
            else
                this.ImageBase64 = EncodeFile(path);
        }

        #region Optional Fields

        /// <summary>
        /// Optional.
        /// </summary>
        [JsonProperty(PropertyName = "phrase")]
        public bool WillContainSpaces; // contains spaces?

        /// <summary>
        /// Optional. Use <c>enum SymbolicContent</c> to set this property.
        /// </summary>
        [JsonProperty(PropertyName = "numeric")]
        public int Numeric;

        /// <summary>
        /// Optional.
        /// </summary>
        [JsonProperty(PropertyName = "math")]
        public bool WillContainMath; // contains math equation?

        /// <summary>
        /// Optional.
        /// </summary>
        [JsonProperty(PropertyName = "case")]
        public bool CaseSensitive;

        /// <summary>
        /// Optional. 0..20
        /// </summary>
        [JsonProperty(PropertyName = "minLength")]
        public int MinResponseLength; // 0..20 min resp length

        /// <summary>
        /// Optional. 0..20
        /// </summary>
        [JsonProperty(PropertyName = "maxLength")]
        public int MaxResponseLength; // 0..20 max resp length

        #endregion
        
        protected string EncodeFile(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(bytes);
        }

        protected string EncodeFromUrl(string url)
        {
            WebClient wc = new WebClient();
            byte[] bytes;
            
            try
            {
                bytes = wc.DownloadData(url);
            }
            finally
            {
                if (wc != null) wc.Dispose();
            }
            
            return Convert.ToBase64String(bytes);
        }
    }

    enum SymbolicContent
    {
        All,
        OnlyDigits,
        OnlyChars
    }
}
