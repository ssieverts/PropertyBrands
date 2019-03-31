using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WeatherDataDal.Models
{
    [Table("Wind")]
    public class Wind
    {
        [Key] [JsonProperty("refId")] public Guid RefId { get; set; }

        [JsonProperty("weatherDataRefId")] public Guid WeatherDataRefId { get; set; }

        [JsonProperty("speed")] public double Speed { get; set; }

        [JsonProperty("deg")] public long Deg { get; set; }

        [JsonProperty("gust")] public double Gust { get; set; }

        [ForeignKey("WeatherDataRefId")]
        [InverseProperty("Wind")]
        public virtual WeatherData WeatherDataRef { get; set; }
    }
}