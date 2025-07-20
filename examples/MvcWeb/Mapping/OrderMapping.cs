using MvcWeb.Dtos;
using MvcWeb.Models;

namespace MvcWeb.Mapping
{
    public static class OrderMapping
        
    {
        public static OrderDto ToDto(this Order order) => new OrderDto
        {
            Id = order.Id,
            UserId = order.UserId.ToString(),
            OrderDateTime = order.OrderDateTime,
            TotalCost = order.TotalCost,
            Status = order.Status,
            OrderItems = order.OrderItems.Select(oi => oi.ToDto()).ToList()
        };

        public static OrderItemDto ToDto(this OrderItem orderItem) => new OrderItemDto
        {
            Id = orderItem.Id,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            UnitPrice = orderItem.UnitPrice
        };

        public static Order ToEntity(this OrderDto orderDto) => new Order
        {
            Id = orderDto.Id,
            UserId = orderDto.UserId,
            OrderDateTime = orderDto.OrderDateTime,
            Status = orderDto.Status,
            OrderItems = orderDto.OrderItems.Select(oi => oi.ToEntity()).ToList()
        };

        public static OrderItem ToEntity(this OrderItemDto orderItemDto) => new OrderItem
        {
            Id = orderItemDto.Id,
            ProductId = orderItemDto.ProductId,
            Quantity = orderItemDto.Quantity,
            UnitPrice = orderItemDto.UnitPrice
        };
    }
}