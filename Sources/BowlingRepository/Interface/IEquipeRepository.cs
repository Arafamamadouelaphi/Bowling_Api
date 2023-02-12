  using BowlingEF.Entities;

namespace BowlingRepository.Interface;
/// <summary>
/// Interface définissant les méthodes nécessaires pour gérer les opérations CRUD pour les entités `EquipeEntity`.
/// </summary>
public interface IEquipeRepository
{
    public void Add(EquipeEntity equipe);
    public void Update(EquipeEntity equipe);
    public void Delete(EquipeEntity equipe);
    public Task GetEquipe(int id);
    public IEnumerable<EquipeEntity> GetAllEquipes();
}