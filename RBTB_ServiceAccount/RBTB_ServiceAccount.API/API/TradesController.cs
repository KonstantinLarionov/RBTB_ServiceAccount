using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace RBTB_ServiceAccount.API.API;

[ApiController]
[Route("trades")]
[Produces("application/json")]

 public class TradesController : ControllerBase
{
    private readonly ITradesService _tradesService;

    public TradesController(ITradesService tradesService)
        {
            _tradesService = tradesService;
        }

    [HttpGet]
    [Route("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "все оК", typeof(BaseResponse<Trades>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Trades>))]
    public JsonResult GetTrade([FromRoute] Guid id)
    {
        var response = _tradesService.GetTrade(id);

        if (response.Success)
        {
            return new JsonResult(response);
        }
        else
        {
            return new JsonResult(response)
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}