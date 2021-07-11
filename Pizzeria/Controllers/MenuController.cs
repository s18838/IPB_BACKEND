using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Model;

namespace Pizzeria.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MenuController : ControllerBase
    {

        private PizzeriaContext _pizzeriaContext;

        public MenuController(PizzeriaContext context)
        {
            _pizzeriaContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pizzeriaContext.Dishes.ToList());
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
