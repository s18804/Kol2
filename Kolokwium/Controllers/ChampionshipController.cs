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

    [Route("api/championship")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly IDBServices _services;

        public ChampionshipController(IDBServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("{id}/teams")]
        public IActionResult GetChampionships(int id)
        {

            var res = new List<GetChampionshipsResponse>();
            try
            {
                res = _services.getChampionships(id).Result;
            }
            catch (Exception e)
            {
                return NotFound("Nie znaleziono mistrzostw");
            }
            return Ok(res);
        }



    }
}
