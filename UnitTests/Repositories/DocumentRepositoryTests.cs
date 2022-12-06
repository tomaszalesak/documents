using System.Collections.ObjectModel;
using Documents.Entities;
using Documents.Repositories;
using FluentAssertions;

namespace UnitTests.Repositories;

[TestFixture]
public class DocumentRepositoryTests
{
    private readonly IDocumentRepository _documentRepository = new DocumentRepository();
    
    [TearDown]
    public void TearDown()
    {
        _documentRepository.RemoveAll();
    }

    [Test]
    public async Task Add()
    {
        // Arrange
        const string id = "id";
        var document = new Document
        {
            Id = id,
            Tags = new List<string> { "tag1", "tag2" },
            Data = new Dictionary<string, string>{{"key1", "value1"}, {"key2", "value2"}}
        };
        
        // Act
        await _documentRepository.Add(document);
        
        // Assert
        var result =  await _documentRepository.GetById(id);
        result.Should().BeEquivalentTo(document);
    }
    
    [Test]
    public async Task GetAll()
    {
        // Arrange
        const string id1 = "id1";
        const string id2 = "id2";
        var document1 = new Document
        {
            Id = id1,
            Tags = new List<string> { "tag1", "tag2" },
            Data = new Dictionary<string, string>{{"key1", "value1"}, {"key2", "value2"}}
        };
        var document2 = new Document
        {
            Id = id2,
            Tags = new List<string> { "tag1", "tag2" },
            Data = new Dictionary<string, string>{{"key1", "value1"}, {"key2", "value2"}}
        };
        await _documentRepository.Add(document1);
        await _documentRepository.Add(document2);
        
        // Act
        var result = await _documentRepository.GetAll();
        
        // Assert
        result.Should().BeEquivalentTo(new Collection<Document> {document1, document2});
    }
}