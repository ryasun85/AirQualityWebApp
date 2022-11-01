using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirQualityService.Models.Measurements
{
    //public class MeasurementsDTO
    //{// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Coordinates
        {
            [JsonPropertyName("latitude")]
            public double Latitude { get; set; }

            [JsonPropertyName("longitude")]
            public double Longitude { get; set; }
        }

        public class Measurement
        {
            [JsonPropertyName("parameter")]
            public string Parameter { get; set; }

            [JsonPropertyName("value")]
            public double Value { get; set; }

            [JsonPropertyName("lastUpdated")]
            public DateTime LastUpdated { get; set; }

            [JsonPropertyName("unit")]
            public string Unit { get; set; }
        }

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
            [JsonPropertyName("location")]
            public string Location { get; set; }

            [JsonPropertyName("city")]
            public object City { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("coordinates")]
            public Coordinates Coordinates { get; set; }

            [JsonPropertyName("measurements")]
            public List<Measurement> Measurements { get; set; }
        }

        public class /*Root*/ MeasurementsDTO
        {
            [JsonPropertyName("meta")]
            public Meta Meta { get; set; }

            [JsonPropertyName("results")]
            public List<Result> Results { get; set; }
        }


    }
//}
