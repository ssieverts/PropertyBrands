using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WeatherDataDal.Models
{
    public class Clouds
    {
        [Key] [JsonProperty("refId")] public Guid RefId { get; set; }

        [JsonProperty("weatherDataRefId")] public Guid WeatherDataRefId { get; set; }

        [JsonProperty("all")] public long All { get; set; }

        [ForeignKey("WeatherDataRefId")]
        [InverseProperty("Clouds")]
        public virtual WeatherData WeatherDataRef { get; set; }
    }
}