using System;
using DTOs;
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



        /// <summary>
        /// Get all partie
        /// GET: api/parti
        /// </summary>
        /// <returns>la liste des parti </returns>
        /// <response code="200">Retourne la liste des joueurs</response>
        /// <response code="404">Si la liste est vide</response>
        /// <response code="500">Si une erreur est survenue</response>
        // GET: api/Partie
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(JoueurDTO), StatusCodes.Status200OK)]
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //  return Ok(_partieService.GetDataWithName(name));


            try
            {
                if (id == null)
                    return BadRequest("Le nom de la partie  est obligatoire");

                var result = _partieService.GetDataWithId(id).Result;
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
        /// <summary>
        /// Creeation
        /// POST: api/parti
        /// </summary>
        /// <param name="parti"></param>
        /// <response code="201">Retourne la parti créé</response>
        /// <response code="400">Si la parti est null</response>
        /// <response code="500">Si une erreur est survenue</response>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(JoueurDTO), StatusCodes.Status201Created)]
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

        /// <summary>
        /// Modification partie
        /// PUT: api/parti/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partie"></param>
        /// <response code="200">Retourne la modification</response>
        /// <response code="400">Si le partie est null</response>
        /// <response code="404">Si le partie n'existe pas</response>
        /// <response code="500">Si une erreur est survenue</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PartieDTO), StatusCodes.Status200OK)]
        
        public async Task<ActionResult<PartieDTO>> Put(long id, [FromBody] PartieDTO partie)
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

