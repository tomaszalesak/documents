using Documents.Dtos;
using MediatR;

namespace Documents.Queries;

public class ListAllDocumentsQuery : IRequest<IList<DocumentDto>>
{
}