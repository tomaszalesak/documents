using Documents.Entities;

namespace Documents.Repositories;

public interface IDocumentRepository
{
    Task Add(Document document);
    Task<Document?> GetById(string id);
    Task Upsert(Document document);
    Task Remove(string id);
    Task<ICollection<Document>> GetAll();
    Task RemoveAll();
}