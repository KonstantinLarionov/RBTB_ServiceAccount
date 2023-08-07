using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API;

[ApiController]
[Route("users")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController( IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException( nameof( mediator ) );
    }

    [HttpGet]
    [Route("")]
    [SwaggerResponse(StatusCodes.Status200OK, "200", typeof(GetUsersResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest," 400",typeof( GetUsersResponse ) )]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersRequest request)
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpGet]
    [Route( "{userId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( GetUserByIdResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( GetUserByIdResponse ) )]
    public async Task<IActionResult> GetUserById( [FromRoute] Guid userId )
    {
        var resp = await _mediator.Send( new GetUserByIdRequest() { UserId = userId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpPost]
    [Route( "create" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( CreateUserResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( CreateUserResponse ) )]
    public async Task<IActionResult> CreateUser( [FromBody] CreateUserRequest request )
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
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( UpdateUserResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( UpdateUserResponse ) )]
    public async Task<IActionResult> UpdateUser( [FromBody] UpdateUserRequest request )
    {
        var resp = await _mediator.Send( request );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpDelete]
    [Route( "delete/{userId}" )]
    [SwaggerResponse( StatusCodes.Status200OK, "200", typeof( DeleteUserResponse ) )]
    [SwaggerResponse( StatusCodes.Status400BadRequest, "400", typeof( DeleteUserResponse ) )]
    public async Task<IActionResult> DeleteUserId( [FromRoute] Guid userId )
    {
        var resp = await _mediator.Send( new DeleteUserRequest() { UserId = userId } );

        if ( resp.Success )
        {
            return Ok( resp );
        }

        return BadRequest( resp );
    }

    [HttpPost]
    [Route("delete/{userId}")]
    [SwaggerResponse(StatusCodes.Status200OK, "200", typeof(DeleteUserResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "400", typeof(DeleteUserResponse))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
        {
            return Ok(resp);
        }

        return BadRequest(resp);
    }
}