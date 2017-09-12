using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Models
{
    public class CandidateGpa
    {
        [JsonProperty(PropertyName = "cumulative")]
        public string Cumulative { get; set; }

        [JsonProperty(PropertyName = "current")]
        public string Current { get; set; }
    }
}
