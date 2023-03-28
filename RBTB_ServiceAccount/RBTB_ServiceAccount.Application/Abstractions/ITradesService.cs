﻿using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Abstractions
{
    public interface ITradesService
    {
        BaseResponse<Trades> GetTrade(Guid id);
    }
}