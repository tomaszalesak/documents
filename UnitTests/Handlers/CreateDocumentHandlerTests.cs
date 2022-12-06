using Documents.Commands;
using Documents.Entities;
using Documents.Handlers;
using Documents.Repositories;
using FluentAssertions;
using Moq;

namespace UnitTests.Handlers;

[TestFixture]
public class CreateDocumentHandlerTests
{
    [Test]
    public async Task Handle()
    {
        // Arrange
        var documentRepository = new Mock<IDocumentRepository>();
        Document document = null!;
        documentRepository.Setup(x => x.Add(It.IsAny<Document>()))
            .Callback<Document>(d => document = d);

        var command = new CreateDocumentCommand
        {
            Id = "id",
            Tags = new List<string> {"tag1", "tag2"},
            Data = new Dictionary<string, string> {{"key1", "value1"}, {"key2", "value2"}}
        };
        var expectedDocument = new Document
        {
            Id = "id",
            Tags = new List<string> { "tag1", "tag2" },
            Data = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } }
        };
        
        var handler = new CreateDocumentHandler(documentRepository.Object);

        // Act
        await handler.Handle(command, new CancellationToken());

        // Assert
        documentRepository.Verify(x => x.Add(It.IsAny<Document>()), Times.Once);
        document.Should().BeEquivalentTo(expectedDocument);
    }
}