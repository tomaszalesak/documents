using Documents.Commands;
using Documents.Dtos;
using Documents.Queries;
using Documents.Requests;
using Documents.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Documents.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("")]
    [Produces("application/json")]
    public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentRequest request)
    {
        try
        {
            await _mediator.Send(new CreateDocumentCommand {Id = request.Id, Tags = request.Tags, Data = request.Data});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpPut("")]
    [Produces("application/json")]
    public async Task<IActionResult> UpsertDocument([FromBody] UpsertDocumentRequest request)
    {
        try
        {
            await _mediator.Send(new UpsertDocumentCommand {Id = request.Id, Tags = request.Tags, Data = request.Data});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }

    [HttpGet("{documentId}.{format}")]
    [FormatFilter]
    public async Task<IActionResult> GetJsonDocument(string documentId)
    {
        return await GetDocument(documentId);
    }

    [HttpGet("list")]
    [Produces("application/json")]
    public async Task<IActionResult> ListAllDocuments()
    {
        IList<DocumentDto> result;
        try
        {
            result = await _mediator.Send(new ListAllDocumentsQuery());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return Ok(result.Select(x => new {x.Id, x.Tags, x.Data}).ToList());
    }

    private async Task<IActionResult> GetDocument(string documentId)
    {
        DocumentDto? result;
        try
        {
            result = await _mediator.Send(new GetDocumentByIdQuery {DocumentId = documentId});
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return result != null ? Ok(new DocumentResponse(result)) : NotFound();
    }
}