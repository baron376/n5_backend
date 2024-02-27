using System.Security;
using web_api_permissions.Domain.Entities;

namespace web_api_permissions.Data.Elasticsearch
{
    public interface IElasticsearchClient
    {
        Task CreateIndexAsync();
        Task InsertDocumentAsync(Permiso permission);
        // Agrega otros métodos necesarios para interactuar con Elasticsearch
    }
}
