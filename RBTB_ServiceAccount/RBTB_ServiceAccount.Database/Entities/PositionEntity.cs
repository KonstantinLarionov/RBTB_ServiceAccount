using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RBTB_ServiceAccount.Database.Entities.Enums;

namespace RBTB_ServiceAccount.Database.Entities;

public class PositionEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid TradesId { get; set; }

    [Precision( 18, 2 )]
    public decimal Price { get; set; }

    public string Symbol { get; set; }

    [Precision( 18, 2 )]
    public decimal Count { get; set; }

    [EnumDataType( typeof( Side ) )]
    public Side Side { get; set; }

    [EnumDataType( typeof( PositionStatus ) )]
    public PositionStatus PositionStatus { get; set; }

    public DateTime CreatedDate { get; set; }
}