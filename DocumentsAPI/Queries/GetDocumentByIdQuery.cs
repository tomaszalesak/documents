using System.ComponentModel.DataAnnotations;
using Documents.Dtos;
using MediatR;

namespace Documents.Queries;

public class GetDocumentByIdQuery : IRequest<DocumentDto?>
{
    [Required] public string DocumentId { get; set; } = null!;
}