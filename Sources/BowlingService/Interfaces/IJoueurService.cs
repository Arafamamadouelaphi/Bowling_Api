using BowlingEF.Entities;
using DTOs;

namespace BowlingService.Interfaces;

public interface IJoueurService
{
    Task<JoueurDTO> Add(JoueurDTO data);
    Task<bool> Delete(JoueurDTO data);
    Task<bool> Update(JoueurDTO data);
    Task<JoueurDTO> GetDataWithName(string name);
    Task<IEnumerable<JoueurDTO>> GetAll();
}