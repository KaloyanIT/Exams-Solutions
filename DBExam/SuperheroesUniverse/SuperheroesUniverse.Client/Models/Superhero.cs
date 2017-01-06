using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SuperheroesUniverse.Models;
namespace SuperheroesUniverse.Client.Models
{
    public class Superhero
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("secretIdentity")]
        public string SecretIndentity { get; set; }

        public City City { get; set; }

        [JsonProperty("alignment")]
        public string Aligment { get; set; }
       
        public string Story { get; set; }
        
        public ICollection<string> Fractions { get; set; }
        
        public ICollection<string> Powers { get; set; }
    }
}
