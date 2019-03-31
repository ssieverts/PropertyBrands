using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WeatherDataDal.Models
{
    [Table("Coord")]
    public class Coord
    {
        [Key] [JsonProperty("refId")] public Guid RefId { get; set; }

        [JsonProperty("weatherDataRefId")] public Guid WeatherDataRefId { get; set; }

        [JsonProperty("lon")] public double Lon { get; set; }

        [JsonProperty("lat")] public double Lat { get; set; }

        [ForeignKey("WeatherDataRefId")]
        [InverseProperty("Coord")]
        public virtual WeatherData WeatherDataRef { get; set; }
    }
}