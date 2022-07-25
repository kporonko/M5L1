using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5L1.Models
{
    public class Resource
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("pantone_value")]
        public string PantoneValue { get; set; }

        public override string ToString()
        {
            return $"\tId: {this.Id}\n\tName: {this.Name}\n\tYear: {this.Year}\n\tColor: {this.Color}\n\tPantoneValue: {this.PantoneValue}\n";
        }
    }
}
