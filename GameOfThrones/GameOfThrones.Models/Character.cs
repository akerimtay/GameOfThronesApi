using Newtonsoft.Json;
using System;

namespace GameOfThrones.Models
{
    public class Character
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }

        [JsonProperty("birth")]
        public int Birth { get; set; }

        [JsonProperty("alive")]
        public bool IsAlive { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}