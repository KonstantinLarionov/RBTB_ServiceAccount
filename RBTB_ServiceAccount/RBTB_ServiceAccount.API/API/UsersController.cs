using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API.API;

[ApiController]
[Route("users")]
[Produces("application/json")]

public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Users>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Users>))]
    public JsonResult GetUser([FromRoute] Guid id)
    {
        var response = _usersService.GetUser(id);

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
    public JsonResult AddUser([FromBody] AddUserRequest request)
    {
        var response = _usersService.AddUser(request);

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
    public JsonResult DeleteUser([FromRoute] Guid id)
    {
        var response = _usersService.DeleteUser(id);

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
    public JsonResult UpdateUser([FromBody] Users user)
    {
        var response = _usersService.UpdateUser(user);

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
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<List<Users>>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<List<Users>>))]
    public JsonResult GetUserById([FromQuery] Guid id)
    {
        var response = _usersService.GetUserById(id);

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