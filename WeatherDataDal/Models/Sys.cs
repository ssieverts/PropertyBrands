using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WeatherDataDal.Models
{
    public class Sys
    {
        [Key] [JsonProperty("refId")] public Guid RefId { get; set; }

        [JsonProperty("weatherDataRefId")] public Guid WeatherDataRefId { get; set; }


        [JsonProperty("type")] public long Type { get; set; }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("message")] public double Message { get; set; }

        [JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("sunrise")] public long Sunrise { get; set; }

        [JsonProperty("sunset")] public long Sunset { get; set; }

        [ForeignKey("WeatherDataRefId")]
        [InverseProperty("Sys")]
        public virtual WeatherData WeatherDataRef { get; set; }
    }
}