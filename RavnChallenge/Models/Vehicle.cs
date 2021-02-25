using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeRavn.Models
{
    //This class the name attribute of the vehicle that is required to show on people's details.
    public class Vehicle
    {
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
