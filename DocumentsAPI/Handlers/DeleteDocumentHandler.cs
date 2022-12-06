using Documents.Commands;
using Documents.Repositories;
using MediatR;

namespace Documents.Handlers;

public class DeleteDocumentHandler : IRequestHandler<DeleteDocumentCommand, Unit>
{
    private readonly IDocumentRepository _documentRepository;

    public DeleteDocumentHandler(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        await _documentRepository.Remove(request.Id);
        return Unit.Value;
    }
}