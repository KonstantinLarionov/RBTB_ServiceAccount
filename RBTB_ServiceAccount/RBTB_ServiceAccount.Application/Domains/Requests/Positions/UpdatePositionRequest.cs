﻿using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;
using RBTB_ServiceAccount.Database.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Positions
{
    public class UpdatePositionRequest : IRequest<UpdatePositionResponse>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid TradesId { get; set; }

        public decimal Price { get; set; }

        public string Symbol { get; set; }

        public decimal Count { get; set; }

        public Side Side { get; set; }

        public PositionStatus PositionStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}