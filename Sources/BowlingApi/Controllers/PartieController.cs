using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingEF.Entities;
using BowlingLib.Model;
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _partieService.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                throw;
            }
            //var result =  _partieService.GetAll().Result;
            //return Ok(result);
        }

        // GET: api/Partie/djon
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            //  return Ok(_partieService.GetDataWithName(name));


            try
            {
                if (name == null)
                    return BadRequest("Le nom de la partie  est obligatoire");

                var result = _partieService.GetDataWithName(name).Result;
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                throw;
            }

        }

        // POST: api/Partie
        [HttpPost]
        public async Task<ActionResult<PartieDTO>> Post([FromBody] PartieDTO parti)
        {


            try
            {
                if (parti == null)
                {
                    return BadRequest("partie est obligatoire");
                }
                var createdpartie = _partieService.Add(parti).Result;
                return CreatedAtAction(nameof(Get), new { id = parti.Id }, createdpartie);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                throw;
            }

        }

        // PUT: api/Partie/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PartieDTO>> Put(string name, [FromBody] PartieDTO partie)
        {
            try
            {
                if (partie == null)
                    return BadRequest("La partie est obligatoire");

                var updatepartie = _partieService.Update(partie);
                if (updatepartie.Result == null)
                {
                    return NotFound();
                }

                return Ok(updatepartie);
            }
            catch (Exception e)
            {
                StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                throw;
            }

        }


    }
}

