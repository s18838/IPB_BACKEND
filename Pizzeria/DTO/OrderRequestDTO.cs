using System;
using System.Collections.Generic;

namespace Pizzeria.DTO
{
    public class OrderRequestDTO
    {
        public int ClientId { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; }
    }
}
