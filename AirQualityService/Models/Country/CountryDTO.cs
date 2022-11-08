using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirQualityService.Models.Country
{

    public class Meta
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("license")]
        public string License { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("found")]
        public int Found { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("locations")]
        public int Locations { get; set; }

        [JsonPropertyName("firstUpdated")]
        public DateTime FirstUpdated { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("parameters")]
        public List<string> Parameters { get; set; }

        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonPropertyName("cities")]
        public int Cities { get; set; }

        [JsonPropertyName("sources")]
        public int Sources { get; set; }
    }

    public class CountryDTO
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }

}
