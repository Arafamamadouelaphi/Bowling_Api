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
    
    // GET: api/Joueur
    [HttpGet]
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
    
    // GET: api/Joueur/Djon
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
    
    [HttpPut("{name}")]
    public async Task<ActionResult<JoueurDTO>> Put(string name,[FromBody] JoueurDTO joueur)
    {
        try
        {
            if(joueur == null)
                return BadRequest("Le joueur est obligatoire");
            
            var updateJoueur = _joueurService.Update(joueur);
            if (updateJoueur.Result == null)
            {
                return NotFound();
            }
            
            return Ok(updateJoueur);
        }
        catch (Exception e)
        {
            StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            throw;
        }
    }
}