using System.Collections;
using MediatR;

namespace Documents.Commands;

public class UpsertDocumentCommand : IRequest
{
    public string Id { get; set; } = null!;
    public IList<string>? Tags { get; set; }
    public IDictionary? Data { get; set; }
}