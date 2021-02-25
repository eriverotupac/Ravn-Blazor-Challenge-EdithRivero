using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeRavn.Models
{
    //This class defines the homeworld of people.
    public class Planet
    {
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
