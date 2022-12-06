using Documents.Entities;

namespace Documents.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private static readonly IDictionary<string, Document> Documents = new Dictionary<string, Document>();

    public Task Add(Document document)
    {
        Documents.Add(document.Id, document);
        return Task.CompletedTask;
    }

    public Task<Document?> GetById(string id)
    {
        return Task.FromResult(Documents.TryGetValue(id, out var document) ? document : null);
    }

    public Task Upsert(Document document)
    {
        return Task.FromResult(Documents[document.Id] = document);
    }

    public Task Remove(string id)
    {
        return Task.FromResult(Documents.Remove(id));
    }

    public Task<ICollection<Document>> GetAll()
    {
        return Task.FromResult(Documents.Values);
    }
    
    public Task RemoveAll()
    {
        Documents.Clear();
        return Task.CompletedTask;
    }
}