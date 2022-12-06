using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Documents.Requests;

public class UpsertDocumentRequest
{
    [Required] public string Id { get; set; } = null!;

    public IList<string>? Tags { get; set; }
    public IDictionary? Data { get; set; }
}