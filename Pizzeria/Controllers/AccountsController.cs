using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.DTO;
using Pizzeria.Model;

namespace Pizzeria.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountsController : ControllerBase
    {

        private PizzeriaContext _pizzeriaContext;

        public AccountsController(PizzeriaContext context)
        {
            _pizzeriaContext = context;
        }

        [HttpPost("authorize")]
        public IActionResult Authorize(CredentialsRequestDTO credentialsRequestDTO)
        {
            try
            {
                Person person = _pizzeriaContext.People.Where(e =>
                    e.Email == credentialsRequestDTO.Email &&
                    e.Password == credentialsRequestDTO.Password
                ).SingleOrDefault();
                if (person == null)
                {
                    throw new Exception("Bad login or password");
                }
                return Ok(new {
                    Id = person.Id,
                    Name = person.Name,
                    Surname = person.Surname,
                    Role = person is Client ? 1 : 2
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
