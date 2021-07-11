using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required]
        public Person Client { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        [Required]
        public OrderStatus Status { get; set; }

        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
    }
}
