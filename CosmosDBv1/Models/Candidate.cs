using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Documents;

namespace CosmosDBv1.Models
{
    public class Candidate : IDocument
    {
        public Candidate()
        {
            Majors = new List<string>();
            Minors = new List<string>();
            Notes = new List<CandidateNotes>();
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "campus")]
        public string Campus { get; set; }

        [Required]
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "contact")]
        public CandidateContactInfo ContactInfo { get; set; }

        [JsonProperty(PropertyName = "isFullTime")]
        public bool IsFullTime { get; set; }

        [JsonProperty(PropertyName = "graduationDate")]
        public DateTime GraduationDate { get; set; }

        [JsonProperty(PropertyName = "majors")]
        public List<string> Majors { get; set; }

        [JsonProperty(PropertyName = "minors")]
        public List<string> Minors { get; set; }

        [JsonProperty(PropertyName = "gpa")]
        public CandidateGpa GPA { get; set; }

        [JsonIgnore]
        public List<CandidateNotes> Notes { get; set; }
    }
}
