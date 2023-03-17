using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Domains.Request;
using RBTB_ServiceAccount.Application.Domains.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API.API;
[ApiController]
[Route("/main")]
[DisplayName("Основные функции api")]
[Produces("application/json")]

public class Controller : ControllerBase
{
    private readonly IMediator _mediator;

    public Controller(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [Route("getinfo")]
    [SwaggerResponse(StatusCodes.Status200OK,"все оК",typeof(GetResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest," все плохо",typeof(GetResponse))]
    public async  Task<JsonResult> GetInfo([FromQuery] GetRequest request)
    {
        var resp = await _mediator.Send(request);
        if (resp.Success)
            return new JsonResult(Ok(resp));
        else
        {
            return new JsonResult(BadRequest(resp));
        }
    }
        
}
