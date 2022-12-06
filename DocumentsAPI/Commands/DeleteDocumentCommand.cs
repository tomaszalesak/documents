using MediatR;

namespace Documents.Commands;

public class DeleteDocumentCommand : IRequest
{
    public string Id { get; set; } = null!;
}