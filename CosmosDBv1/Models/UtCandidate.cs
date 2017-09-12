using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Models
{
    public class UtCandidate : Candidate
    {
        [JsonProperty(PropertyName = "knowsRob")]
        public bool KnowsRob { get; set; }
    }
}
