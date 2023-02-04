using BowlingEF.Entities;
using BowlingService.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BowlingApi.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class JoueurController:Controller
{
    private IJoueurService _joueurService;
    
    public JoueurController(IJoueurService joueurService)
    {
        _joueurService = joueurService;
    }
    
    /// <summary>
    /// Get all Players
    /// GET: api/joueur
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
    /// Get player with pagination
    /// Get : api/Joueur?page=1&pageSize=10
    /// </summary>
    /// <returns>la liste des Joueurs </returns>
    /// <response code="200">Retourne la liste des joueurs</response>
    /// <response code="404">Si la liste est vide</response>
    /// <response code="500">Si une erreur est survenue</response>
    [HttpGet("{page}/{pageSize}")] 
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<JoueurDTO>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int page=1,int pageSize=10)
    {
        try
        {
            var result = await _joueurService.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            var data = result.Skip((page - 1) * pageSize).Take(pageSize);
            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                totalCount = result.Count(),
                pageSize = pageSize,
                currentPage = page,
                totalPages = (int)Math.Ceiling(result.Count() / (double)pageSize)
            }));
            return Ok(data);
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
    /// <response code="200">Retourne le joueur</response>
    /// <response code="400">Si le nom du joueur est null</response>
    /// <response code="404">Si le joueur n'existe pas</response>
    /// <response code="500">Si une erreur est survenue</response>
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(JoueurDTO), StatusCodes.Status200OK)]
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
    
    /// <summary>
    /// Creer un joueur
    /// POST: api/Joueur
    /// </summary>
    /// <param name="joueur"></param>
    /// <response code="201">Retourne le joueur créé</response>
    /// <response code="400">Si le joueur est null</response>
    /// <response code="500">Si une erreur est survenue</response>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(JoueurDTO), StatusCodes.Status201Created)]
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
    
    /// <summary>
    /// Modifier un joueur
    /// PUT: api/Joueur/5
    /// </summary>
    /// <param name="id"></param>
    /// <param name="joueur"></param>
    /// <response code="200">Retourne le joueur modifié</response>
    /// <response code="400">Si le joueur est null</response>
    /// <response code="404">Si le joueur n'existe pas</response>
    /// <response code="500">Si une erreur est survenue</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(JoueurDTO), StatusCodes.Status200OK)]
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