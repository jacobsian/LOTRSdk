using System.Text.Json.Serialization;

namespace LOTR.SDK.Models
{
    public class Movie
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public int RuntimeInMinutes { get; set; }
        public decimal BudgetInMillions { get; set; }
        public decimal BoxOfficeRevenueInMillions { get; set; }
        public int AcademyAwardNominations { get; set; }
        public int AcademyAwardWins { get; set; }
        public decimal RottenTomatoesScore { get; set; }
    }
}
