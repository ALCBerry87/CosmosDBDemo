using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Models
{
    public class CandidateContactInfo
    {
        [Required]
        [EmailAddress]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Phone]
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
    }
}
