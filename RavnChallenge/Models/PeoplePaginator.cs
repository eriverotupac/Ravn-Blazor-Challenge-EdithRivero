using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeRavn.Models
{
    public class PeoplePaginator
    {
        [System.Text.Json.Serialization.JsonPropertyName("next")]
        public string Next { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("results")]
        public List<People> PeopleList { get; set; }
    }
}
