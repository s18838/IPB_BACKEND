using System;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int DishId { get; set; }
        [Required]
        public Dish Dish { get; set; }
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
    }
}
