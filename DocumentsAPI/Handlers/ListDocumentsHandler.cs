using Documents.Dtos;
using Documents.Queries;
using Documents.Repositories;
using MediatR;

namespace Documents.Handlers;

public class ListDocumentsHandler : IRequestHandler<ListAllDocumentsQuery, IList<DocumentDto>>
{
    private readonly IDocumentRepository _documentRepository;

    public ListDocumentsHandler(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<IList<DocumentDto>> Handle(ListAllDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _documentRepository.GetAll();
        var dtos = documents.Select(x => new DocumentDto(id: x.Id, tags: x.Tags, data: x.Data)).ToList();
        return dtos;
    }
}