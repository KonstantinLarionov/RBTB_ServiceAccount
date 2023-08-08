using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Domains.Requests.Positions;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API;

[ApiController]
[Authorize]
[Route("positions")]
[Produces("application/json")]
public class PositionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PositionsController( IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException( nameof( mediator ) );
    }

    [HttpGet]
    [Route("")]
    [SwaggerResponse(StatusCodes.Status200OK, "200", typeof( GetPositionsResponse ) )]
    [SwaggerResponse(StatusCodes.Status400BadRequest,"400",typeof( GetPositionsResponse ) )]
    public async Task<IActionResult> GetPositions([FromQuery] GetPositionsRequest request )
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpGet]
    [Route( "{positionId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( GetPositionByIdResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( GetPositionByIdResponse ) )]
    public async Task<IActionResult> GetPositionById( [FromRoute] Guid positionId )
    {
        var resp = await _mediator.Send( new GetPositionByIdRequest() { PositionId = positionId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpPost]
    [Route( "create" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( CreatePositionResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( CreatePositionResponse ) )]
    public async Task<IActionResult> CreatePosition( [FromBody] CreatePositionRequest request )
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpPut]
    [Route( "update" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( UpdatePositionResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( UpdatePositionResponse ) )]
    public async Task<IActionResult> UpdatePosition( [FromBody] UpdatePositionRequest request )
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpDelete]
    [Route( "delete/{positionId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( DeletePositionResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( DeletePositionResponse ) )]
    public async Task<IActionResult> DeletePositionId( [FromRoute] Guid positionId )
    {
        var resp = await _mediator.Send( new DeletePositionRequest() { PositionId = positionId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }
}