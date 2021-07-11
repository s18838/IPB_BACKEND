using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Pizzeria.Model
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; }

        public Dish() {
            OrderItems = new HashSet<OrderItem>();
        }
    }
}
