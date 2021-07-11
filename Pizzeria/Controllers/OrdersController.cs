using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.DTO;
using Pizzeria.Model;

namespace Pizzeria.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private PizzeriaContext _pizzeriaContext;

        public OrdersController(PizzeriaContext context)
        {
            _pizzeriaContext = context;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int? clientId)
        {
            try
            {
                List<Order> orders = _pizzeriaContext.Orders
                    .Include(e => e.OrderItems)
                    .ThenInclude(e => e.Dish)
                    .Where(e => (clientId == null && e.Status == OrderStatus.Pending) || e.ClientId == clientId)
                    .OrderByDescending(e => e.Id)
                    .ToList();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                Order order = new Order()
                {
                    ClientId = orderRequestDTO.ClientId,
                    Status = OrderStatus.Pending
                };
                _pizzeriaContext.Orders.Add(order);
                _pizzeriaContext.SaveChanges();

                orderRequestDTO.Items.ToList().ForEach(e =>
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        OrderId = order.Id,
                        DishId = e.DishId,
                        Quantity = e.Quantity,
                    };
                    _pizzeriaContext.OrderItems.Add(orderItem);
                    _pizzeriaContext.SaveChanges();
                });
                return Ok(new { });
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                Order order = _pizzeriaContext.Orders.Where(e => e.Id == id)
                    .SingleOrDefault();

                if (order == null)
                {
                    throw new Exception("Order doesn`t exist");
                }
                order.Status = OrderStatus.Ready;
                _pizzeriaContext.SaveChanges();
                return Ok(new { });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
