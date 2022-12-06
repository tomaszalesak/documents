using Documents.Commands;
using Documents.Entities;
using Documents.Repositories;
using MediatR;

namespace Documents.Handlers;

public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, Unit>
{
    private readonly IDocumentRepository _documentRepository;

    public CreateDocumentHandler(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<Unit> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        await _documentRepository.Add(new Document {Id = request.Id, Tags = request.Tags, Data = request.Data});
        return Unit.Value;
    }
}