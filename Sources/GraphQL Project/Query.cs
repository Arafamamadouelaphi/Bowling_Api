using BowlingService.Interfaces;
using DTOs;

namespace GraphQL_Project;

public class Query
{
    private readonly IJoueurService _joueurService;

    public Query(IJoueurService joueurService)
    {
        _joueurService = joueurService;
    }

    public  IQueryable<JoueurDTO> GetJoueurs()
    {
        var data = _joueurService.GetAll();
        var result = data.Result;
        return result.AsQueryable();
    }
}