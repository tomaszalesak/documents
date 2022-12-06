using Documents.Commands;
using Documents.Entities;
using Documents.Repositories;
using MediatR;

namespace Documents.Handlers;

public class UpsertDocumentHandler : IRequestHandler<UpsertDocumentCommand, Unit>
{
    private readonly IDocumentRepository _documentRepository;

    public UpsertDocumentHandler(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<Unit> Handle(UpsertDocumentCommand request, CancellationToken cancellationToken)
    {
        await _documentRepository.Upsert(new Document
        {
            Id = request.Id,
            Tags = request.Tags,
            Data = request.Data
        });
        return Unit.Value;
    }
}