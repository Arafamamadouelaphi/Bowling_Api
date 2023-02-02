using BowlingEF.Entities;
using BowlingService.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BowlingApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class JoueurController:Controller
{
    private IJoueurService _joueurService;
    
    public JoueurController(IJoueurService joueurService)
    {
        _joueurService = joueurService;
    }
    
    /// <summary>
    /// Get all Players
    /// </summary>
    /// <returns>la liste des Joueurs </returns>
    /// <response code="200">Retourne la liste des joueurs</response>
    /// <response code="404">Si la liste est vide</response>
    /// <response code="500">Si une erreur est survenue</response>
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<JoueurDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _joueurService.GetAll();
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
    /// Get a player by name
    /// GET: api/Joueur/Djon
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("{name}")]
    public async Task<IActionResult> Get(string name)
    {
        try
        {
            if(String.IsNullOrWhiteSpace(name))
                return BadRequest("Le nom du joueur est obligatoire");
            
            var result = _joueurService.GetDataWithName(name).Result;
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
    
    // POST: api/Joueur
    [HttpPost]
    public async Task<ActionResult<JoueurDTO>> Post([FromBody] JoueurDTO joueur)
    {
        try
        {
            if (joueur== null)
            {
                return BadRequest("Le joueur est obligatoire");
            }
            var createdJoueur = _joueurService.Add(joueur).Result;
            return CreatedAtAction(nameof(Get), new { id = createdJoueur.Id }, createdJoueur);

        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            throw;
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<JoueurDTO>> Put(long id,[FromBody] JoueurDTO joueur)
    {
        try
        {
            if(joueur == null)
                return BadRequest("Le joueur est obligatoire");
            
            var updateJoueur = _joueurService.Update(id,joueur);
            if (updateJoueur.Result == false)
            {
                return NotFound();
            }
            return Ok(joueur);
        }
        catch (Exception e)
        {
            StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            throw;
        }
    }
}