using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WeatherDataDal.Models
{
    [Table("WeatherData")]
    public class WeatherData
    {
        public WeatherData()
        {
            Weathers = new HashSet<Weather>();
        }

        [Key] [JsonProperty("RefId")] public Guid RefId { get; set; }

        [JsonProperty("base")] public string Base { get; set; }

        [JsonProperty("visibility")] public long Visibility { get; set; }

        [JsonProperty("dt")] public long Dt { get; set; }

        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("cod")] public long Cod { get; set; }

        public DateTime UpdatedAt { get; set; }

        [JsonProperty("clouds")]
        [InverseProperty("WeatherDataRef")]
        public virtual Clouds Clouds { get; set; }

        [JsonProperty("coord")]
        [InverseProperty("WeatherDataRef")]
        public virtual Coord Coord { get; set; }

        [JsonProperty("main")]
        [InverseProperty("WeatherDataRef")]
        public virtual Main Main { get; set; }

        [JsonProperty("sys")]
        [InverseProperty("WeatherDataRef")]
        public virtual Sys Sys { get; set; }

        [JsonProperty("wind")]
        [InverseProperty("WeatherDataRef")]
        public virtual Wind Wind { get; set; }

        [JsonProperty("weather")]
        [InverseProperty("WeatherDataRef")]
        public virtual ICollection<Weather> Weathers { get; set; }
    }
}