using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Domains.Requests.Trades;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API;

[ApiController]
[Route("trades")]
[Produces("application/json")]
public class TradesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TradesController( IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException( nameof( mediator ) );
    }

    [HttpGet]
    [Route("")]
    [SwaggerResponse(StatusCodes.Status200OK, "200", typeof(GetTradesResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest," 400",typeof( GetTradesResponse ) )]
    public async Task<IActionResult> GetTrades([FromQuery] GetTradesRequest request)
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpGet]
    [Route( "{tradeId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( GetTradeByIdResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( GetTradeByIdResponse ) )]
    public async Task<IActionResult> GetTradeById( [FromRoute] Guid tradeId )
    {
        var resp = await _mediator.Send( new GetTradeByIdRequest() { TradeId = tradeId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpPost]
    [Route( "create" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( CreateTradeResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( CreateTradeResponse ) )]
    public async Task<IActionResult> CreateTrade( [FromBody] CreateTradeRequest request )
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
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( UpdateTradeResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( UpdateTradeResponse ) )]
    public async Task<IActionResult> UpdateTrade( [FromBody] UpdateTradeRequest request )
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpDelete]
    [Route( "delete/{tradeId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( DeleteTradeResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( DeleteTradeResponse ) )]
    public async Task<IActionResult> DeleteTradeId( [FromRoute] Guid tradeId )
    {
        var resp = await _mediator.Send( new DeleteTradeRequest() { TradeId = tradeId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }
}