using System.Collections;
using System.Runtime.Serialization;
using Documents.Dtos;

namespace Documents.Responses;

[DataContract]
[KnownType(typeof(string))]
[KnownType(typeof(string[]))]
[KnownType(typeof(IDictionary))]
public class DocumentResponse
{
    public DocumentResponse()
    {
    }

    public DocumentResponse(DocumentDto dto)
    {
        Id = dto.Id;
        Tags = dto.Tags?.ToArray();
        Data = dto.Data;
    }

    [DataMember] public string Id { get; set; } = null!;

    [DataMember] public string[]? Tags { get; set; }

    [DataMember] public IDictionary? Data { get; set; }
}