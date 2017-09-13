using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Models
{
    public class CandidateNotes : IDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "campus")]
        public string Campus { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type
        {
            get
            {
                return "notes";
            }
        }

        [JsonProperty(PropertyName = "candidateId")]
        public string CandidateId { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

    }
}
