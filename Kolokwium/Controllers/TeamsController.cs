using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DTOs;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly IDBServices _services;
        public TeamsController(IDBServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("{id}/players")]
        public IActionResult AddNewPlayerToTeam(int id, AddNewPlayerToTeamRequest request)
        {
            try
            {
                _services.AddNewPlayerToTeam(id, request);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

    }
}
