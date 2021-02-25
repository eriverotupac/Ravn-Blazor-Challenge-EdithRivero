using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeRavn.Models
{
    //This class defines the specie that the class people belongs.
    public class Specie
    {
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
