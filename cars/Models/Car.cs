using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cars.Models
{
    public class Car
    {
        [JsonPropertyName("model")]

        [Required]
        public string model { get; set; }
        [Required]
        public string company { get; set; }
        public string color { get; set; }
        public int speed { get; set; }
        [JsonPropertyName("img")]
        public string image { get; set; }

        public int quantity { get; set; }

        //public override string ToString()
        //{
        //    return JsonSerializer.Serialize<Car>(this);
        //}

        public override string ToString() => JsonSerializer.Serialize<Car>(this);


    }
}
