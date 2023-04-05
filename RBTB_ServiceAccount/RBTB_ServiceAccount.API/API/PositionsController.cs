using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Application.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API.API;

[ApiController]
[Route("positions")]
[Produces("application/json")]

public class PositionsController : ControllerBase
{
    private readonly IPositionsService _PositionsService;

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
        var response = _positionService.UpdatePosition(position);

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
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<List<Trades>>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<List<Trades>>))]
    public JsonResult GetPositionsByUserId([FromQuery] Guid userId)
    {
        var response = _positionsService.GetPositionsByUserId(userId);

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
