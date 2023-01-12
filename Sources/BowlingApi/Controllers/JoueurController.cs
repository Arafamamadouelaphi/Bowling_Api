using BowlingEF.Entities;
using BowlingService.Interfaces;
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
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_joueurService.GetAll());
    }
    
    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        return Ok(_joueurService.GetDataWithName(name));
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] JoueurDTO joueur)
    {
        _joueurService.Add(joueur);
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put([FromBody] JoueurDTO joueur)
    {
        _joueurService.Update(joueur);
        return Ok();
    }
    
    
}