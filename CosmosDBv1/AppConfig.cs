using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBv1
{
    public static class AppConfig
    {
        public static string CosmosDbUri { get; set; }
        public static string CosmosDbAuthKey { get; set; }
        public static string CosmosDbDatabaseName { get; set; }
        public static string CosmosDbCollectionName { get; set; }

        public static IConfigurationRoot Bootstrap(IConfigurationBuilder builder)
        {
            //builder.AddJsonFile("appSettings.json");
            var configuration = builder.Build();
            var cosmosDbSection = configuration.GetSection("CosmosDb");

            CosmosDbUri = cosmosDbSection.GetValue<string>("Uri");
            CosmosDbAuthKey = cosmosDbSection.GetValue<string>("AuthKey");
            CosmosDbDatabaseName = cosmosDbSection.GetValue<string>("DatabaseName");
            CosmosDbCollectionName = cosmosDbSection.GetValue<string>("CollectionName");

            return configuration;
        }
    }
}
