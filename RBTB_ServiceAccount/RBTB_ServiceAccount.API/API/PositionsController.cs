using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API.API;

[ApiController]
[Route("positions")]
[Produces("application/json")]

public class PositionsController : ControllerBase
{
    private readonly IPositionsService _positionsService;

    public PositionsController(IPositionsService positionsService)
    {
        _positionsService = positionsService;
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Positions>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Positions>))]
    public JsonResult GetPosition([FromRoute] Guid id)
    {
        var response = _positionsService.GetPosition(id);

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
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Guid>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Guid>))]
    public JsonResult AddPosition([FromBody] AddPositionRequest request)
    {
        var response = _positionsService.AddPosition(request);

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
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<bool>))]
    public JsonResult DeletePosition([FromRoute] Guid id)
    {
        var response = _positionsService.DeletePosition(id);

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
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<bool>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<bool>))]
    public JsonResult UpdatePosition([FromBody] Positions position)
    {
        var response = _positionsService.UpdatePosition(position);

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
    [Route("{userId}/{symbol}")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Positions>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Positions>))]

    public JsonResult GetPositionBySymbol([FromRoute] Guid userId, [FromRoute] string symbol)
    {
        var response = _positionsService.GetPositionBySymbol(userId, symbol);

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
    [Route("{userId}")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<List<Positions>>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<List<Positions>>))]
    public JsonResult GetPositionByUserId([FromRoute] Guid userId)
    {
        var response = _positionsService.GetPositionByUserId(userId);

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
    [Route("trades")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Positions>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Positions>))]
    public JsonResult GetPositionByTradesId([FromQuery] Guid tradesId)
    {
        var response = _positionsService.GetPositionByTradesId(tradesId);

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
    [Route("positions/{userId}/{symbol}")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<List<Positions>>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<List<Positions>>))]

    public JsonResult GetPositionByUserIdAndSymbol([FromRoute] Guid userId, [FromRoute] string symbol, [FromQuery] GetPositionsBySymbolRequest request)
    {
        var response = _positionsService.GetPositionByUserIdAndSymbol(userId, symbol, request);

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