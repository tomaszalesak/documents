using Documents.Dtos;
using Documents.Queries;
using Documents.Repositories;
using MediatR;

namespace Documents.Handlers;

public class GetDocumentByIdHandler : IRequestHandler<GetDocumentByIdQuery, DocumentDto?>
{
    private readonly IDocumentRepository _documentRepository;

    public GetDocumentByIdHandler(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<DocumentDto?> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var document = await _documentRepository.GetById(request.DocumentId);
        return document == null
            ? null
            : new DocumentDto(id: document.Id, tags: document.Tags, data: document.Data);
    }
}