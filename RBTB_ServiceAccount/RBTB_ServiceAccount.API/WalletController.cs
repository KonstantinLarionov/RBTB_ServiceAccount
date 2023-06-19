using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Domains.Requests.Wallets;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API;

[ApiController]
[Route("wallets")]
[Produces("application/json")]
public class WalletController : ControllerBase
{
    private readonly IMediator _mediator;

    public WalletController( IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException( nameof( mediator ) );
    }

    [HttpGet]
    [Route("")]
    [SwaggerResponse(StatusCodes.Status200OK, "200", typeof(GetWalletsResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest," 400",typeof( GetWalletsResponse ) )]
    public async Task<IActionResult> GetWallets([FromQuery] GetWalletsRequest request)
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpGet]
    [Route( "{walletId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( GetWalletByIdResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( GetWalletByIdResponse ) )]
    public async Task<IActionResult> GetWalletById( [FromRoute] Guid walletId )
    {
        var resp = await _mediator.Send( new GetWalletByIdRequest() { WalletId = walletId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpPost]
    [Route( "create" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( CreateWalletResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( CreateWalletResponse ) )]
    public async Task<IActionResult> CreateWallet( [FromBody] CreateWalletRequest request )
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
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( UpdateWalletResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( UpdateWalletResponse ) )]
    public async Task<IActionResult> UpdateWallet( [FromBody] UpdateWalletRequest request )
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpDelete]
    [Route( "delete/{walletId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( DeleteWalletResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( DeleteWalletResponse ) )]
    public async Task<IActionResult> DeleteWalletId( [FromRoute] Guid walletId )
    {
        var resp = await _mediator.Send( new DeleteWalletRequest() { WalletId = walletId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }
}