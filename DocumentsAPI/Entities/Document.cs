using System.Collections;

namespace Documents.Entities;

public class Document
{
    public string Id { get; set; } = null!;
    public IList<string>? Tags { get; set; }
    public IDictionary? Data { get; set; }
}