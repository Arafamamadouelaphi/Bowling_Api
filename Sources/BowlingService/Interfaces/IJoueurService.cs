using BowlingEF.Entities;

namespace BowlingService.Interfaces;

public interface IJoueurService
{
    Task<bool> Add(JoueurDTO data);
    Task<bool> Delete(JoueurDTO data);
    Task<bool> Update(JoueurDTO data);
    Task<JoueurDTO> GetDataWithName(string name);
    Task<IEnumerable<JoueurDTO>> GetAll();
}