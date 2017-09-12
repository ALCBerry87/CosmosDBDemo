using CosmosDBv1.Models;
using CosmosDBv1.Repository;
using CosmosDBv1.Services;
using CosmosDBv1.Services.Utility;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1
{
    public static class IoCStartup
    {
        public static void Bootstrap(IServiceCollection services)
        {
            services.AddScoped(typeof(ClaimService), typeof(ClaimService));
            services.AddSingleton(typeof(DocumentClient), s => new DocumentClient(new Uri(AppConfig.CosmosDbUri), AppConfig.CosmosDbAuthKey));
            services.AddScoped(typeof(DocumentDbRepository<Candidate>), typeof(DocumentDbRepository<Candidate>));
            services.AddScoped(typeof(DocumentDbRepository<CandidateNotes>), typeof(DocumentDbRepository<CandidateNotes>));
            services.AddScoped(typeof(CandidateService), typeof(CandidateService));
        }
    }
}
