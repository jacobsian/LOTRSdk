using System.Text.Json.Serialization;

namespace LOTR.SDK.Models
{
    public class Quote
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Quote
        /// </summary>
        public string Dialog { get; set; }
        /// <summary>
        /// ID Of the Movie the Quote is from
        /// </summary>
        public string Movie { get; set; }

        /// <summary>
        /// ID of the character who said the quote
        /// </summary>
        public string Character { get; set; }
    }
}
