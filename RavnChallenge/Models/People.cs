using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeRavn.Models
{
    //This class contains the required attributes of people
    public class People
    {
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("gender")]
        public string Gender { get; set; }
        
        [System.Text.Json.Serialization.JsonPropertyName("eye_color")]
        public string Eye { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hair_color")]
        public string Hair { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("skin_color")]
        public string Skin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("birth_year")]
        public string Birth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("homeworld")]
        public string Planet { get; set; } // "": "https://swapi.dev/api/planets/1/"

        [System.Text.Json.Serialization.JsonPropertyName("species")]
        public string[] Species { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("vehicles")]
        public string[] Vehicles { get; set; }
    }
}
