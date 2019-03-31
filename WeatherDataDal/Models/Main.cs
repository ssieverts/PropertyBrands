using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WeatherDataDal.Models
{
    [Table("Main")]
    public class Main
    {
        [Key] [JsonProperty("refId")] public Guid RefId { get; set; }

        [JsonProperty("weatherDataRefId")] public Guid WeatherDataRefId { get; set; }

        [JsonProperty("temp")] public double Temp { get; set; }

        [JsonProperty("pressure")] public long Pressure { get; set; }

        [JsonProperty("humidity")] public long Humidity { get; set; }

        [JsonProperty("tempMin")] public double TempMin { get; set; }

        [JsonProperty("tempMax")] public double TempMax { get; set; }

        [ForeignKey("WeatherDataRefId")]
        [InverseProperty("Main")]
        public virtual WeatherData WeatherDataRef { get; set; }
    }
}