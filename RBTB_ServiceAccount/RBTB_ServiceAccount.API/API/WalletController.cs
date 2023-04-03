using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace RBTB_ServiceAccount.API.API;

[ApiController]
[Route("wallet")]
[Produces("application/json")]

public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Wallet>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Wallet>))]
    public JsonResult GetWallet([FromRoute] Guid id)
    {
        var response = _walletService.GetWallet (id);

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
    public JsonResult AddWallet([FromBody] AddWalletRequest request)
    {
        var response = _walletService.AddWallet(request);

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
    public JsonResult DeleteTrade([FromRoute] Guid id)
    {
        var response = _walletService.DeleteWallet(id);

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
    public JsonResult UpdateWallet([FromBody] Wallet wallet)
    {
        var response = _walletService.UpdateWallet(wallet);

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
    public JsonResult GetWalletByUserId([FromQuery] Guid userId)
    {
        var response = _walletService.GetWalletByUserId(userId);

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
    [SwaggerResponse(StatusCodes.Status200OK, "все ок", typeof(BaseResponse<Wallet>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, " все плохо", typeof(BaseResponse<Wallet>))]

    public JsonResult GetWalletBySymbol([FromRoute] Guid userId, [FromRoute] string symbol)
    {
        var response = _walletService.GetWalletBySymbol(userId, symbol);

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