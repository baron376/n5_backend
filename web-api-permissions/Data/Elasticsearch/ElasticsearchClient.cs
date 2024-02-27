using Nest;
using System.Security;
using web_api_permissions.Domain.Entities;
using web_api_permissions.Models;

namespace web_api_permissions.Data.Elasticsearch
{
    public class ElasticsearchClient : IElasticsearchClient
    {
        private readonly IElasticClient _elasticClient;

        public ElasticsearchClient(Uri uri)
        {
            var settings = new ConnectionSettings(uri)
                .DefaultIndex("permissions");
            _elasticClient = new ElasticClient(settings);
        }

        public async Task CreateIndexAsync()
        {
            var existsResponse = await _elasticClient.Indices.ExistsAsync("permissions");
            if (existsResponse.Exists)
                return;

            await _elasticClient.Indices.CreateAsync("permissions", c => c
                .Map<Permiso>(m => m
                    .AutoMap()
                )
            );
        }

        public async Task<bool> IndexPermissionAsync(PermissionModel permission)
        {
            var response = await _elasticClient.IndexDocumentAsync(permission);
            return response.IsValid;
        }

        public async Task InsertDocumentAsync(Permiso permission)
        {
            await _elasticClient.IndexDocumentAsync(permission);
        }
    }
}
