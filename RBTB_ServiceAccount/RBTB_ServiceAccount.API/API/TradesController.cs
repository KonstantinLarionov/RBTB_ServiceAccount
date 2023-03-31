using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Responses;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Trades>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Trades>))]
    public JsonResult GetTrade([FromRoute] Guid id)
    {
        var response = _tradesService.GetTrade(id);

        if (response.IsSuccess)
        {
            return new JsonResult(Ok(response));
        }
        else
        {
            return new JsonResult(BadRequest(response));
        }
    }

    [HttpPost]
    [Route("")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Trades>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Trades>))]
    public JsonResult AddTrade([FromBody] Trades trade)
    {
        var response = _tradesService.AddTrade(trade);

        if (response.IsSuccess)
        {
            return new JsonResult(Ok(response));
        }
        else
        {
            return new JsonResult(BadRequest(response));
        }
    }

    [HttpDelete]
    [Route("{id}/delete")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Trades>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Trades>))]
    public JsonResult DeleteTrade([FromRoute] Trades trade)
    {
        var response = _tradesService.DeleteTrade(trade.Id);

        if (response.IsSuccess)
        {
            return new JsonResult(Ok(response));
        }
        else
        {
            return new JsonResult(BadRequest(response));
        }
    }

    [HttpPut]
    [Route("update")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Trades>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Trades>))]
    public JsonResult UpdateTrade([FromBody] Trades trade)
    {
        var response = _tradesService.UpdateTrade(trade);

        if (response.IsSuccess)
        {
            return new JsonResult(Ok(response));
        }
        else
        {
            return new JsonResult(BadRequest(response));
        }
    }

    [HttpGet]
    [Route("")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Trades>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Trades>))]
    public JsonResult GetTradesByUserId([FromQuery] Guid userId)
    {
        var response = _tradesService.GetTradesByUserId(userId);

        if (response.IsSuccess)
        {
            return new JsonResult(Ok(response));
        }
        else
        {
            return new JsonResult(BadRequest(response));
        }
    }
} 