using System.Collections;

namespace Documents.Dtos;

public class DocumentDto
{
    public DocumentDto(string id, IList<string>? tags, IDictionary? data)
    {
        Id = id;
        Tags = tags;
        Data = data;
    }

    public string Id { get; set; }
    public IList<string>? Tags { get; set; }
    public IDictionary? Data { get; set; }
}