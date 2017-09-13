using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Models
{
    public class CandidateGpa
    {
        [JsonProperty(PropertyName = "cumulative")]
        [Display(Name = "Cumulative GPA")]
        public string Cumulative { get; set; }

        [JsonProperty(PropertyName = "current")]
        [Display(Name = "Current GPA")]
        public string Current { get; set; }
    }
}
