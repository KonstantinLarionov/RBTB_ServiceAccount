using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Abstractions.Entities;

public class TradeEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }


    [Precision( 18, 2 )]
    public decimal Price { get; set; }


    [Precision( 18, 2 )]
    public decimal Count { get; set; }

    [EnumDataType( typeof( OrderType ) )]
    public OrderType OrderType { get; set; }

    [EnumDataType( typeof( Side ) )]
    public Side Side { get; set; }

    public string Symbol { get; set; }

    [EnumDataType( typeof( OrderStatus ) )]
    public OrderStatus OrderStatus { get; set; }

    [EnumDataType( typeof( TimeInForce ) )]
    public TimeInForce TimeInForce { get; set; }

    public DateTime CreatedDate { get; set; }
}