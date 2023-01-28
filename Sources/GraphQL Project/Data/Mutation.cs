using BowlingService.Interfaces;
using DTOs;
using GraphQL_Project.Record;

namespace GraphQL_Project.Data;

public class Mutation
{
    public async Task<JoueurAddedPayload> AddjoueurAsync(AddJoueurInput input, [Service] IJoueurService joueurService)
    {
        JoueurDTO joueurDto = new JoueurDTO
        {
            Pseudo = input.Pseudo
        };
        var result = await joueurService.Add(joueurDto);
        return new JoueurAddedPayload(result);
    }
}