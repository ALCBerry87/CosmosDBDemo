using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1.Models
{
    public interface IDocument
    {
        string Id { get; set; }
    }
}
