using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingService;
using BowlingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BowlingApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PartieController : ControllerBase
    {


        private IpartieService _partieService;

        public PartieController(IpartieService partieService)
        {
            _partieService = partieService;
        }




        // GET: api/Partie
        [HttpGet]
        public  IActionResult Get()
        {
            var result =  _partieService.GetAll().Result;
            return Ok(result);
        }

        // GET: api/Partie/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            return Ok(_partieService.GetDataWithName(name));
        }

        // POST: api/Partie
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Partie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Partie/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
