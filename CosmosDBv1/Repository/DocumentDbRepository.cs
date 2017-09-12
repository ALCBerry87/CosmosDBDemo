using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Client;
using System.Linq.Expressions;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;
using System.Linq;
using CosmosDBv1.Models;

namespace CosmosDBv1.Repository
{
    public class DocumentDbRepository<T> where T : IDocument
    {
        private readonly DocumentClient _client;

        public DocumentDbRepository(DocumentClient client)
        {
            _client = client;
        }

        //Read

        public async Task<T> GetByIdAsync(string id)
        {
            var doc = await _client.ReadDocumentAsync<T>(
                    UriFactory.CreateDocumentUri(AppConfig.CosmosDbDatabaseName, AppConfig.CosmosDbCollectionName, id)
                );

            return doc.Document;
        }

        private IOrderedQueryable<T> CreatePartitionedQuery(string pk)
        {
            return _client.CreateDocumentQuery<T>(
                        UriFactory.CreateDocumentCollectionUri(AppConfig.CosmosDbDatabaseName, AppConfig.CosmosDbCollectionName),
                        new FeedOptions() { PartitionKey = new PartitionKey(pk) });
        }

        public async Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> predicate, string pk)
        {
            var query = CreatePartitionedQuery(pk).Where(predicate).AsDocumentQuery();

            List<T> items = new List<T>();
            while(query.HasMoreResults)
            {
                items.AddRange(await query.ExecuteNextAsync<T>());
            }

            return items;
        }

        //Create
        public async Task<T> CreateAsync(T doc)
        {
            var newDoc = 
                await _client.CreateDocumentAsync(
                    UriFactory.CreateDocumentCollectionUri(AppConfig.CosmosDbDatabaseName, AppConfig.CosmosDbCollectionName),
                    doc
                );

            return (T)(dynamic)newDoc;
        }

        //Update
        public async Task<T> UpdateAsync(T doc)
        {
            var updatedDoc =
                await _client.ReplaceDocumentAsync(
                    UriFactory.CreateDocumentUri(AppConfig.CosmosDbDatabaseName, AppConfig.CosmosDbCollectionName, doc.Id), 
                    doc
                );

            return (T)(dynamic)updatedDoc;
        }

        public async Task<T> UpsertAsync(T doc)
        {
            var upsertedDoc =
                await _client.UpsertDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(AppConfig.CosmosDbDatabaseName, AppConfig.CosmosDbCollectionName),
                        doc
                    );

            return (T)(dynamic)upsertedDoc;
        }

        //Delete
        public async Task<T> DeleteAsync(T doc)
        {
            var deletedDoc = 
                await _client.DeleteDocumentAsync(
                    UriFactory.CreateDocumentUri(AppConfig.CosmosDbDatabaseName, AppConfig.CosmosDbCollectionName, doc.Id)
                );

            return (T)(dynamic)deletedDoc;
        }
    }
}
